﻿using System;
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
	public interface IBrowserView
	{
	    // file
	    event EventHandler ShowDevToolsActivated;
	    event EventHandler CloseDevToolsActivated;
	    event EventHandler ExitActivated;
	
	    // edit
	    event EventHandler UndoActivated;
	    event EventHandler RedoActivated;
	    event EventHandler CutActivated;
	    event EventHandler CopyActivated;
	    event EventHandler PasteActivated;
	    event EventHandler DeleteActivated;
	    event EventHandler SelectAllActivated;
	
	    // test
	    event EventHandler TestResourceLoadActivated;
	    event EventHandler TestSchemeLoadActivated;
	    event EventHandler TestExecuteScriptActivated;
	    event EventHandler TestEvaluateScriptActivated;
	    event EventHandler TestBindActivated;
	    event EventHandler TestConsoleMessageActivated;
	    event EventHandler TestTooltipActivated;
	    event EventHandler TestPopupActivated;
	    event EventHandler TestLoadStringActivated;
	    event EventHandler TestCookieVisitorActivated;
	
	    // navigation
	    event Action<object, string> UrlActivated;
	    event EventHandler BackActivated;
	    event EventHandler ForwardActivated;
	
	    void SetTitle(string title);
	    void SetAddress(string address);
	    void SetCanGoBack(bool can_go_back);
	    void SetCanGoForward(bool can_go_forward);
	    void SetIsLoading(bool is_loading);
	
	    void ExecuteScript(string script);
	    object EvaluateScript(string script);
	    void DisplayOutput(string output);
	}
}
