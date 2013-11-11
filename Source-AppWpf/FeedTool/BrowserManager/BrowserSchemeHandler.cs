using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

using CefSharp;
using FeedTool.Properties;

namespace FeedTool
{
	class BrowserSchemeHandler : ISchemeHandler
	{
	    private readonly IDictionary<string, string> resources;
	
	    public BrowserSchemeHandler()
	    {
	        resources = new Dictionary<string, string>
	        {
	            { "BindingTest.html", Resources.BindingTest },
	            { "PopupTest.html", Resources.PopupTest },
	            { "SchemeTest.html", Resources.SchemeTest },
	            { "TooltipTest.html", Resources.TooltipTest },
	            { "yuck", "We want some info now." },
	            { "yuk.html?fart=0", "Now you know, I'm number two" },
	            { "fart=0", "Now you know, I'm number three" },
	            { "?fart=0", "Now you know, I'm number four" },
	        };
	    }
	
	    public bool ProcessRequestAsync(IRequest request, SchemeHandlerResponse response, OnRequestCompletedHandler requestCompletedCallback)
	    {
	        var uri = new Uri(request.Url);
	        var segments = uri.Segments;
	        var file = segments[segments.Length - 1];
	        string resource, segmentInfo = string.Empty;
	        if (resources.TryGetValue(file, out resource) &&
	            !String.IsNullOrEmpty(resource))
	        {
	            int i = 0;
	            segmentInfo += string.Format("Host {1}: {0}<br/>",uri.Host, i);
	            foreach (string segment in segments)
	            {
	            	if (i==0) { i++; continue; }
	            	segmentInfo += string.Format("Segment {1}: {0}<br/>",segment, i);
	            	i++;
	            }
	            resource = string.Concat(resource,"<br />",segmentInfo);
	            var bytes = Encoding.UTF8.GetBytes(resource);
	            response.ResponseStream = new MemoryStream(bytes);
	            response.MimeType = "text/html";
	            requestCompletedCallback();
	            
	            return true;
	        }
	        return false;
	    }
	}

}
