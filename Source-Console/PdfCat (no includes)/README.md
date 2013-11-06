# PDFCAT

Note that PDFsharp supports up to PDF v1.4 in it's read/write
operations, so this tool will ignore any files complient to 
spec v1.5 and newer.

## SUMMARY

A modified sample from [PdfSharp/Migradoc WIKI][empira-wiki-sample].

The tool takes in a directory and concatenates all PDFs within.

Used in from the original sample from empira Software demo is a particular
`variant1()` method, as `variant2`-`variant4` were left in tact to
portray the PdfSharp XGraphics sample/capability.

## PARAMS

    PdfCat.exe [-i ("dir-path")] [-l (int-max-page-limit)]
    PdfCat.exe "c:/path/to/dir"

* `-i` include directory.
* `-l` number of pages to limit on input pdf files.

## COMPILE

1. There is no SLN file in the source package, so please set up a new SLN and add the project to your workspace in #develop, VisualStudio, ...
2. Install PDFsharp from NuGet in #develop or VisualStudio using the "restore packages" option.
3. (Optionally reset your target CPU and Fx, ...) Compile.
4. Drag a folder containing two or three PDF files into/onto pdfcat executable or shortcut to test.

Download the [binary package][binary-package] (compiled on Intel CORE i7 -- win7x64)

----

LICENSE: MIT (inherited from PDFsharp)

[binary-package]:https://github.com/tfoxo/System.Cor3/releases/download/pdfcat-20131106/PDFcat-bin-20131106.zip
[empira]: http://www.pdfsharp.net
[empira-wiki-sample]: http://www.pdfsharp.net/wiki/ConcatenateDocuments-sample.ashx
