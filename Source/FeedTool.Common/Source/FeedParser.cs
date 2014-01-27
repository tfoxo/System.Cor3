using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml;

// from:
// http://www.codeproject.com/Articles/9494/Manipulate-XML-data-with-XPath-and-XmlDocument-C
// "To update a node, first I search out which node you are updating by
// SelectSingleNode, and then create a new node element.
// After setting the InnerXml of the new node, call ReplaceChild
// method of XmlElement to update the document."
namespace FeedTool
{
    /// <summary>
    /// First layer of parsing.
    /// The second layer of parsing would be represented by the
    /// diffent 'Elements' types or rather, the classes rooted
    /// on 'NodeInfo' such as AtomEntry, RssNode, YtFeedEntry
    /// and YtMediaContent.
    /// </summary>
    public class FeedParser
    {
        const string uri_atom =          "http://www.w3.org/2005/atom";
        const string uri_gdata_youtube = "http://www.w3.org/2005/atom";
        // 02:12 - human stem cell ink / 3D printer.
        
        /// <summary>
        /// Must the XmlDocument must be fully loaded when sent here.
        /// </summary>
        public XmlInfo Xml { get;set; }
        public Action ActionCompleted { get;set; }
        public string Content { get; set; }
        
        public void Run()
        {
            using (
                var Worker = new BackgroundWorker
                {
                    WorkerReportsProgress =         false,
                    WorkerSupportsCancellation =    false
                })
            {
                Worker.DoWork += Parse;
                Worker.RunWorkerCompleted += ParseCompleted;
                Worker.RunWorkerAsync();
            }
        }
        
        void ParseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActionCompleted!=null) ActionCompleted();
        }
        
        public void Parse(object sender, DoWorkEventArgs args)
        {
            Xml.Load(Content);
            System.Diagnostics.Debug.Print("We're going to parse {0}", Xml.RootType);
            
            switch (Xml.RootType) {
                case "rss":
                    ParseRss();
                    break;
                case "feed":
                    if (Xml.HasNSValue(uri_atom)&&!Xml.HasNSValue(uri_gdata_youtube))
                        ParseAtom();
                    else
                        ParseFeed();
                    break;
            }
        }
        
        void ParseAtom()
        {
            var xnl = Xml.DocRoot.SelectNodes("//entry");
            for (int i = 0; i < xnl.Count; i++) {
                var node = new AtomEntry { Index=i, ItemPath=string.Format("//entry[{0}]",i+1), };
                node.Parse(Xml.Doc, Xml.DocNs);
                Xml.Nodes.Add( node );
            }
            Xml.DocRoot.SelectSingleNode("//title");
        }
        void ParseRss()
        {
            var xnl = Xml.DocRoot.SelectNodes("//channel/item");
            for (int i = 0; i < xnl.Count; i++) {
                var node = new RssNode { Index=i, ItemPath=string.Format("//channel/item[{0}]",i+1), };
                node.Parse(Xml.Doc, Xml.DocNs);
                Xml.Nodes.Add( node );
            }
            Xml.DocRoot.SelectSingleNode("//title");
        }
        // Feeds are actually podcasts.
        void ParseFeed()
        {
            var xnl = Xml.DocRoot.SelectNodes("//xmlroot:entry", Xml.DocNs);
            for (int i = 0; i < xnl.Count; i++) {
                var node = new YtFeedEntry { Index=i, ItemPath=string.Format("//xmlroot:entry[{0}]",i+1), };
                node.Parse(Xml.Doc, Xml.DocNs);
                Xml.Nodes.Add( node );
            }
            Xml.DocRoot.SelectSingleNode("//xmlroot:title", Xml.DocNs);
        }
    }
    

}
