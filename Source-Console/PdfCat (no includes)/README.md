# PDFCAT

## SUMMARY

A modified sample from [PdfSharp/Migradoc WIKI](http://www.pdfsharp.net/wiki/CombineDocuments-sample.ashx).

The tool takes in a directory and concatenates all PDFs in the diectory.

Used in this little program is a particular `variant1()` method, as `variant2`-`variant4` were left in tact to
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

----

LICENSE: MIT (inherited from PDFsharp)
