using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;

namespace FeedTool.Forms
{
	
	public class HttpContentReader<T> : HttpContentReader where T:class,new()
	{
		public T Output { get;set; }
		
		/// <summary>
		/// An action to be performed (by the caller) on a succesfull process.
		/// </summary>
		public Action<T>	Complete { get; set; }
		
		internal override void Done(object sender, RunWorkerCompletedEventArgs e)
		{
			if (Complete!=null) Complete(Output);
		}
	}
	abstract public class HttpContentReader
	{
		internal WebClient			Client { get; set; }
		internal BackgroundWorker	Worker { get; set; }
		/// <summary>
		/// The web-request's starting point
		/// </summary>
		public Uri					URL { get; set; }
		/// <summary>
		/// This should be the xml document in its downloaded form.
		/// </summary>
		public string				Content { get; set; }
		/// <summary>
		/// If the XmlDocument (Content) is modified or transformed
		/// to an output format, then this is the result.
		/// </summary>
		public string				Result { get; set; }
		
		/// <summary>
		/// </summary>
		public bool					IsFileSystemMode { get;set; }
		/// <summary>
		/// We will be using one of either FileSystem mode or WebClient mode.
		/// </summary>
		public FileInfo LocalFile { get;set; }

		
		/// initialize some
		public void Go()
		{
			System.Diagnostics.Debug.Print("Worker starting...");
			Worker.RunWorkerAsync();
		}
		
		virtual public void Run(object sender, DoWorkEventArgs e)
		{
			System.Diagnostics.Debug.Print("Worker Started.");
			System.Diagnostics.Debug.Print("IsFileSystemMode: {0}",IsFileSystemMode);
			if (IsFileSystemMode)
			{
				Content = File.ReadAllText(LocalFile.FullName);
				System.Diagnostics.Debug.Print("File is loaded.  Starting to parse");
				ParseContent();
			}
			else
			{
				System.Diagnostics.Debug.Print("Download process beginning…");
				using (
					Client = new WebClient
					{
						Encoding=System.Text.Encoding.UTF8,
						UseDefaultCredentials=true
					})
				{
					Client.DownloadStringCompleted += GotString;
					// The following method is started
					// by making a call to Go().
					Client.DownloadStringAsync(URL);
					System.Diagnostics.Debug.Print("Download prepared…");
				}
			}
			Client = null;
		}
		
		abstract internal void Done(object sender, RunWorkerCompletedEventArgs e);
		
		internal void GotString(object sender, DownloadStringCompletedEventArgs e)
		{
			if (e.Error!=null) Content = e.Result;
			Result = string.Empty;
			ParseContent();
		}
		/// <summary>
		/// base method calls Worker.CancelAsync() so call the base method in the end of your override.
		/// </summary>
		virtual public void ParseContent()
		{
			Worker.CancelAsync();
		}
		
	}
}
