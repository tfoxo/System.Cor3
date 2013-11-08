css: build/fringe/style.css
title: FeedTool App

Feed Tool
===================

Introduction
-------------------------

New project picking up where the FeedTool (WinForms) left off.

Target **Platform**: Windows Vista/7/8 (NET-v4.5/MSBuild-v5.0)

Features
------

* **Supported URL data**
	* Podcast feed
	* Youtube User/Video feed
	* Atom feed
	* Rss Feed
* **Integrated (Featured) Libraries**
	* Autofac
	* [ICSharpCode.AvalonEdit]
	* MahApps.Metro
	* [CefSharp], CefSharp.Wpf; AKA: Chromium Embedded Framework (CEF) 
	* [Caliburn.Metro], Caliburn.Metro.Autofac, Caliburn.Metro.Core;
		* Binary Release page: [CefSharp-bin] v1.25.5
		* Binary Release ddl: [CefSharp-v1.25.5-binaries.zip][CefSharp-ddl]
    * [YouTubeExtractor]
	* ReactiveUI

Third-Party Libraries, Credits and/or Dependencies
-------------------------

**Css Used in this page one time or another**

* foghorn.css : https://github.com/jasonm23/markdown-css-themes/blob/gh-pages/foghorn.css
* md.css : https://gist.github.com/somebox/1082608
* style.css : https://gist.github.com/andyferra/2554919

<!--regex-->
<!--<package id=\"([a-Z0-9.-]*)\" version=\"([a-Z0-9.-]*)\" targetFramework=\"([a-Z0-9.-]*)" />-->
<!--Full package list

* Autofac v3.1.5 (net45)
* AvalonEdit v4.3.1.9430 (net45)
* Caliburn.Metro.Autofac v0.4.0 (net45)
* Caliburn.Micro v1.5.2 (net45)
* MahApps.Metro v0.10.1.1 (net45)
* MahApps.Metro.Resources v0.1.0.1 (net45)
* reactiveui-core v5.2.0 (net45)
* Rx-Core v2.1.30214.0 (net45)
* Rx-Interfaces v2.1.30214.0 (net45)
* Rx-Linq v2.1.30214.0 (net45)
* Rx-Main v2.1.30214.0 (net45)
* Rx-PlatformServices v2.1.30214.0 (net45)-->

[Thread]:                 http://msdn.microsoft.com/en-us/library/system.threading.thread(v=vs.80).aspx
[Thread40]:               http://msdn.microsoft.com/en-us/library/system.threading.thread.aspx
[BackgroundWorker]:       http://msdn.microsoft.com/en-us/library/system.componentmodel.backgroundworker(v=vs.80).aspx
[YTEDownloadUrlResolver]: https://github.com/flagbug/YoutubeExtractor/blob/master/YoutubeExtractor/YoutubeExtractor/DownloadUrlResolver.cs
[GitSubModules]:          http://git-scm.com/book/en/Git-Tools-Submodules
[BLagun]:                 http://brianlagunas.com/free-metro-light-and-dark-themes-for-wpf-and-silverlight-microsoft-controls/
[CaliburnMicro]:          http://caliburnmicro.codeplex.com/
[await]:                  http://msdn.microsoft.com/en-us/library/vstudio/hh156528.aspx
[async]:                  http://msdn.microsoft.com/en-us/library/vstudio/hh156513.aspx
[asyncawait]:             http://msdn.microsoft.com/en-us/library/vstudio/hh191443.aspx
[oauth]:                  https://developers.google.com/gdata/articles/oauth
[Caliburn.Metro.Autofac]: https://www.nuget.org/packages/Caliburn.Metro.Autofac
[CefSharp]:               https://github.com/cefsharp/CefSharp
[CefSharp-bin]:           https://github.com/cefsharp/CefSharp/releases/tag/v1.25.5
[CefSharp-ddl]:           https://github.com/cefsharp/CefSharp/releases/download/v1.25.5/CefSharp-v1.25.5-binaries.zip
[Caliburn.Metro]:         https://github.com/ziyasal/Caliburn.Metro
[ICSharpCode.AvalonEdit]: https://github.com/icsharpcode/SharpDevelop/wiki/AvalonEdit
[YouTubeExtractor]:       https://github.com/flagbug/YoutubeExtractor/