css: style.css
title: FeedTool App

<!--
foghorn.css
https://github.com/jasonm23/markdown-css-themes/blob/gh-pages/foghorn.css
md.css
https://gist.github.com/somebox/1082608
style.css
https://gist.github.com/andyferra/2554919
-->

Feed Tool
===================

Introduction
-------------------------

FeedTool is a cor3/sandbox application that seems worthy of a little more consideration.

`FeedTool` design bares the following characteristics.

Features
-------------------------

* Multiple Feed Source/Inputs
    - OPML
    - Simple-Text-File
* Simple text-file as initialization file to load RSS/FEED urls from.
* XML/RSS Formats: PODCAST, YOUTUBE User-Videos, RSS/ATOM, XML/RSS (general feed)
* Implement cross-platform solution for AV playback of podcast or feed `enclosure`
  elements which usually point to mp3 or audio files as defined in podcast feeds.
* Additionally, the project was an personal excersize in using/testing a couple .NET
  [`Thread`][Thread] patterns including [`BackgroundWorker`][BackgroundWorker]
  in the windows-forms demo.

Future
--------------------------

* Integrate some features of a particular AvUtils application for the playback features.
* Parse/Check for OpenSearch and/or compatible information to 'page' content perhaps
  via application or global setting(s).

Build Targets
-------------------------

Windows Vista/7/8 (.NET v4.5)

Third-Party Libraries, Credits and/or Dependencies
-------------------------

See: [GitSubModules] (for no particular reason)

### Credit: YouTubeExtractor (Dennis Daume)

Credit due to [YouTubeExtractor]'s [`DownloadUrlResolver.cs`][YTEDownloadUrlResolver]
for pointing out:

    http://www.youtube.com/get_video_info?&video_id={{videoid}}&el=detailpage&ps=default&eurl=&gl=US&hl=en

Some inspirations also having been gathered from [Brian Lagunas][BLagun]'s Free Metro light and dark themes pointed out by Dennis.

### Adobe Flash Player

Adobe Flash Player (Microsoft ActiveX control version) is required to view YouTube videos and perhaps some multimedia (audio) files.

Download Flash Player (ActiveX version) [here](http://www.adobe.com/support/flashplayer/downloads.html)

Development Topics & References
-------------------------

* [await] operator keyword, [async] keyword
* I've recently observed this project is neglecting some of the newer features of the .NET v4.5 framework.
* These guys are not relevant, come think of it.
    * [Using OAuth with the Google Data APIs][oauth], or perhaps…
    * [code.google.com\p\gdata-python-client\signature-gdata-pycrypto.py (attachment)](https://code.google.com/p/gdata-python-client/issues/attachmentText?id=638&aid=6380000000&name=signature-gdata-pycrypto.py&token=etXU4Ul5MdUR9y8J2bP5PvnJurw%3A1346876520202)



[Thread]:           http://msdn.microsoft.com/en-us/library/system.threading.thread(v=vs.80).aspx
[Thread40]:         http://msdn.microsoft.com/en-us/library/system.threading.thread.aspx
[BackgroundWorker]: http://msdn.microsoft.com/en-us/library/system.componentmodel.backgroundworker(v=vs.80).aspx
[YouTubeExtractor]: https://github.com/flagbug/YoutubeExtractor/
[YTEDownloadUrlResolver]: https://github.com/flagbug/YoutubeExtractor/blob/master/YoutubeExtractor/YoutubeExtractor/DownloadUrlResolver.cs
[GitSubModules]:    http://git-scm.com/book/en/Git-Tools-Submodules
[BLagun]:           http://brianlagunas.com/free-metro-light-and-dark-themes-for-wpf-and-silverlight-microsoft-controls/
[CaliburnMicro]:    http://caliburnmicro.codeplex.com/
[await]:            http://msdn.microsoft.com/en-us/library/vstudio/hh156528.aspx
[async]:            http://msdn.microsoft.com/en-us/library/vstudio/hh156513.aspx
[asyncawait]:       http://msdn.microsoft.com/en-us/library/vstudio/hh191443.aspx
[oauth]:            https://developers.google.com/gdata/articles/oauth