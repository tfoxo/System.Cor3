title: Third Party Source Packages
encoding: utf-8

# External References

Thus far, we will be accumilating some external CSPROJ references here.
Currently subdirectories content is as follows:

```
legend:
  + directory
  * obsolete directory
  - file
-------------------------------------------
+ Archives
  - SharpFFmpeg_2.0_src.zip
+ ffmpeg-sharp
  + examples
  + src
+ ICSharpCode.TextEditor
+ Nuget
  + ICSharpCode.TextEditor.3.2.1.6466
* SharpFFmpeg_2.0_src
+ YoutubeExtractor
```

## Archive Types

Categorically, packages/modules required for compilation will be noted
here as well as in respective `csproj` file location dependant on such
assemblies, packages or sub-modules.


* Git Repository

* SVN Repository

* Zip/7z Archive

* Nuget Package

## Git SubModules

**YoutubeExtractor**: [github.com/flagbug/YoutubeExtractor](https://github.com/flagbug/YoutubeExtractor)

The layout for YoutubeExtractor will be as follows where projects and/or linked-includes will point to the following directory structure:

`$(github-cor3)\Source-External\YoutubeExtractor\YoutubeExtractor\YoutubeExtractor\YoutubeExtractor.csproj`

## Zip Archives

**SharpFFmpeg**: [sourceforge.com/projects/sharpffmpeg]

- No longer used.  See [ffmpeg-sharp][ffmpeg-sharp-local].

- Download the source package to "third-party-source-archives" directory

- extract the directory to "sharpffmpeg-dir"

```
project-root          = /system.cor3
external-archives     = $project-root$/source-external/archives
sharpffmpeg-dir       = $external-archives$/SharpFFmpeg_2.0_src.zip
```

### ffmpeg-sharp [ffmpeg-sharp-local]

[ffmpeg-sharp]

- svn-root: `http://ffmpeg-sharp.googlecode.com/svn`
- as used: `http://ffmpeg-sharp.googlecode.com/svn/trunk/ffmpeg-sharp`

[ffmpeg-sharp]:                         https://code.google.com/p/ffmpeg-sharp/
[sourceforge.com/projects/sharpffmpeg]: http://sourceforge.net/projects/sharpffmpeg
