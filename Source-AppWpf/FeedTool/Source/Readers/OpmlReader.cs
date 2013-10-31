using System;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace FeedTool.Forms
{
    public class OpmlReader : HttpContentReader<OpmlDocument>
    {
        public OpmlReader(){ }
        public OpmlReader(string url)
        {
            System.Diagnostics.Debug.Print("::OpmlReader(string url)");
            URL = new Uri(url);
            URL.EnableHacks();
            Worker = new BackgroundWorker {
                WorkerReportsProgress=false,
                WorkerSupportsCancellation=true
            };
            Worker.DoWork += Run;
            Worker.RunWorkerCompleted += Done;
        }
        public OpmlReader(FileInfo file)
        {
            System.Diagnostics.Debug.Print("::OpmlReader(FileInfo file)");
            URL = null;
            IsFileSystemMode = true;
            LocalFile = file;
            
            Worker = new BackgroundWorker {WorkerReportsProgress=false,WorkerSupportsCancellation=true};
            Worker.DoWork += Run;
            Worker.RunWorkerCompleted += Done;
            
        }
        public override void ParseContent()
        {
            System.Diagnostics.Debug.Print("::ParseContent()");
            if (string.IsNullOrEmpty(Content))
            {
                Content = "(we've got nothing)";
                System.Diagnostics.Debug.Print("Got nothing.");
                base.ParseContent();
                return;
            }
            bool isopml=Content.Contains("<opml");
            System.Diagnostics.Debug.Print("Loaded file.  Getting OPML File... \nIsOPML: {0}",isopml);

            if (!isopml)
            {
                System.Diagnostics.Debug.Print("Not an OPML file.",isopml);
            }
            else
            {
                this.Output = IsFileSystemMode ?
                    new OpmlDocument(LocalFile):
                    new OpmlDocument(Content);
            }
            base.ParseContent();
        }
    }
}
