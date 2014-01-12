css: build/fringe/style.css
title: Compiling FeedTool App

Compiling (WPF) Feed Tool
===================

Requirements
-------------------------

* Windows VISTA/7/8
* MSBuild 5.0
* Microsoft .NET Framework 4.5
* NuGet
* [Inno Setup] v5.0 or greater

Instructions
-------------------------

1. Extract Source Archive
2. Open `FeedTool-WPF.csproj` and check the paths as noted in the [CSPROJ PATHS] section

## CSPROJ Paths

`Cor3_Directory`
: `..\..` points to the projects root directory.

`YoutubeExtractor`
: `$(Cor3_Directory)\Source-External\YoutubeExtractor\YoutubeExtractor\YoutubeExtractor`.
: Either via git-submodule, or manually extracted.
: Note that this directory should contain `YoutubeExtractor.csproj`.

`Cor3Inc`
: `$(Cor3_Directory)\Source\Cor3.Core\Include`

`FlashExtSrc`
: It seems that this path is no longer required, however we might use this in the future: `$(Cor3_Directory)\Source-Libs\Flash.External`

`ApplicationIcon`
: `Build\Fringe\oxygen-refit-application-rss+xml.ico`


[Inno Setup]:http://www.jrsoftware.org/isinfo.php
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