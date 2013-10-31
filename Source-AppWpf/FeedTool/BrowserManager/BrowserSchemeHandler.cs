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
	        };
	    }
	
	    public bool ProcessRequestAsync(IRequest request, SchemeHandlerResponse response, OnRequestCompletedHandler requestCompletedCallback)
	    {
	        var uri = new Uri(request.Url);
	        var segments = uri.Segments;
	        var file = segments[segments.Length - 1];
	
	        string resource;
	        if (resources.TryGetValue(file, out resource) &&
	            !String.IsNullOrEmpty(resource))
	        {
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
