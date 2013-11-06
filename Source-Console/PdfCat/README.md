# PDFCAT.cs

Note that PDFsharp supports up to PDF v1.4 in it's read/write
operations, so this tool will ignore any files complient to 
spec v1.5 and newer.

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

1. Install PdfSharp from NuGet.
2. Link to or include [`Commander.cs`](https://github.com/tfoxo/System.Cor3/blob/master/Source/Cor3.Core/System/Commander.cs)
3. Compile, Test
