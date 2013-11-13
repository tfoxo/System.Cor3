using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CefSharp;
using FeedTool.Loaders;
using FeedTool.Properties;
using FeedTool.ViewMain;

namespace FeedTool
{
	class FeedSchemeHandler : ISchemeHandler
	{
//	    private readonly IDictionary<string, string> resources;
		
		public FeedSchemeHandler()
		{
		}
		
		public bool ProcessRequestAsync(IRequest request, SchemeHandlerResponse response, OnRequestCompletedHandler requestCompletedCallback)
		{
			var uri = new Uri(request.Url);
			string host = uri.Host;
			string parent = Uri.UnescapeDataString(uri.Segments[1].Trim('/','\\'));
			MasterFeedNode item = MainControl.Self.Model.Items.Where(x => x.Key==parent).FirstOrDefault();
			int ChildID = int.Parse(uri.Segments[2].Trim('/','\\'));
			
			NodeInfo node = item.Children[ChildID];
			node.GenerateLinks();
			Console.WriteLine("ProcessRequestAsync: \"{0}\", \"{1}\", \"{2}\"", host, parent, ChildID);
			
			switch (host)
			{
				case "ytfeedentry":
				case "rssnode":
				case "atomentry":
					var bytes = Encoding.UTF8.GetBytes(node.HtmlText);
					response.ResponseStream = new MemoryStream(bytes);
					response.MimeType = "text/html";
					requestCompletedCallback();
					return true;
				default:
					return false;
			}
		}
	}
}
