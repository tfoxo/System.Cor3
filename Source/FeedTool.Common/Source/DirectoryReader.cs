using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;

namespace FeedTool.Forms
{
    /// <summary>
    /// <para>
    /// I guess this is intended to parse (default) web-server directory
    /// information as found on a few apache and IIS serevers.
    /// </para>
    /// <para>
    /// There does not appear to be a difference between IIS5 and IIS7 as
    /// it appears here.
    /// </para>
    /// </summary>
    class DirectoryReader
    {
        WebClient client;
        BackgroundWorker worker;

        static readonly Regex HtmlText = new Regex(@"^([^\<]*|\<br /\>[^\<]*)",defaultOptions);
        static readonly Regex HtmlLink = new Regex(@"\<A [^\>]\>([^\<][^A])*",defaultOptions);
        const RegexOptions defaultOptions = RegexOptions.Compiled|RegexOptions.Multiline|RegexOptions.CultureInvariant|RegexOptions.IgnoreCase;

        const string apache_doc = @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 3.2 Final//EN"">";
        const string IIS5PATH = "//html/body/pre/A";
        const string IIS7PATH = "//html/body/pre/A";
        const string APACHEPATH = "//html/body/ul/li/a";

        public Uri                   URL        { get; set; }
        bool                         IsApache   { get; set; }
        public string                Content    { get; set; }
        public string                Result     { get; set; }
        public List<string>          Items      { get; set; }
        Dictionary<string,string>    Headers    { get; set; }

        public Action<DirectoryReader> Complete { get; set; }

        public DirectoryReader(string url)
        {
            URL = new Uri(url);
            URL.EnableHacks();
            worker = new BackgroundWorker { WorkerReportsProgress=false , WorkerSupportsCancellation=true };
            worker.DoWork += Run;
            worker.RunWorkerCompleted += Done;
        }
        
        public void Go()
        {
            IsApache = false;
            worker.RunWorkerAsync();
        }
        
        void ParseContent()
        {
            Result = string.Empty;
            Items = new List<string>();
            string content=null,html=null;
            GetIis5Directory(Content, out content, out html);
            Content = content;
            IsApache = Content.Contains(apache_doc);
            Result = html;
            worker.CancelAsync();
        }
        
        static public string IISFilter(string content)
        {
            return
                content
                .Replace("<pre><A","<pre>\n<A")
                .Replace("</A><br>","</A><br/>\n")
                .Replace("<hr>","<hr />")
                .Replace("<br>","<br />")
                ;
        }
        
        static public void GetIis5Directory(string input, out string output, out string xmlOut)
        {
            string content = input;
            bool isIis5=content.Contains("html"), isapache=content.Contains(apache_doc);
            string html = string.Empty;
            var Items = new List<string>();
            string path=string.Empty;
            if (content==null)
                content = "(we've got nothing)";
            else if (isapache) {
                content = content.Replace(apache_doc,"");
                path=APACHEPATH;
            } else if (isIis5) {
                isIis5=true;
                content = IISFilter(content);
                content = HtmlText.Replace(content,"");
                path=IIS5PATH;
            } else {
                content = IISFilter(content);
                content = HtmlText.Replace(content,"");
                path=IIS7PATH;
            }
            string matches = string.Empty;
            foreach (Match m in HtmlLink.Matches(content)) matches += m.Groups[0].Value;

            var doc = new XmlDocument();

            try
            {
                doc.LoadXml(content);
                foreach (XmlNode node in doc.FirstChild.SelectNodes(path))
                    Items.Add(node.InnerText);
                html = string.Join("\n",Items.ToArray());
            } catch (Exception exception) {
                html = exception.ToString();
            }
            output = content;
            bool isa = isapache?true:false;
            xmlOut = matches + "\n"+html+string.Format("\n{{ IsApache={0} }}",isa);
        }
        
        void GotString(object sender, DownloadStringCompletedEventArgs e)
        {
            try {
                foreach (string key in client.ResponseHeaders.AllKeys)
                    Headers.Add(key,client.ResponseHeaders[key]);
            } catch {}
            if (e.Error!=null) {
                Content = e.Result;
            }
            ParseContent();
        }
        
        void Run(object sender, DoWorkEventArgs e)
        {
            using (client = new WebClient { Encoding=System.Text.Encoding.UTF8, UseDefaultCredentials=true }) {
                client.DownloadStringCompleted += GotString;
                client.DownloadStringAsync(URL);
            }
            client = null;
        }
        
        void Done(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Complete!=null) Complete(this);
        }
    }
}
