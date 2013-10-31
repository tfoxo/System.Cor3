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
	class BrowserDownloadHandler : IDownloadHandler
	{
	    private readonly string _path;
	    private Stream _stream;
	
	    public BrowserDownloadHandler(string fileName)
	    {
	        _path = Path.Combine(Path.GetTempPath(), fileName);
	        _stream = File.Create(_path);
	    }
	
	    public bool ReceivedData(byte[] data)
	    {
	        _stream.Write(data, 0, data.GetLength(0));
	        return true;
	
	    }
	    public void Complete()
	    {
	        _stream.Dispose();
	        _stream = null;
	
	        Console.WriteLine("Downloaded: {0}", _path);
	    }
	}
}
