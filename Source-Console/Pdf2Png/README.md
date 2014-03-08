# pdf2png csharp/winforms application (windows)

Convert PDF to PNG images

![](https://raw.github.com/tfoxo/System.Cor3/master/Source-Console/Pdf2Png/info/pdfmatrixfilter.png)

Generally, a UI taking advantage of the [mupdf-converter] project which depends on [MuPDF] (`mupdflib.dll`) which can be obtained via the [SumatraPDF] project.

Like most of my messy projects up here, I use this but the UI is a bit misleading in that not all the functionality is there.

## What works?

* you can edit the `default.settings` XML file to modify the matrix presets that can be applied by changing the presets selected by the combo-box.
* First, press ``update page ct/len'' button.  Then you can hit the update button to generate the images.


Youre welcome to comment somewhere in the comments of [tfwxo-blog](http://tfwio.wordpress.com/projects) to get me to update this if you would like to kick-start a particular update.

[MuPDF]: http://www.mupdf.com
[SumatraPDF]: blog.kowalczyk.info/software/sumatrapdf/free-pdf-reader.html‎
[mupdf-converter]: https://code.google.com/p/mupdf-converter/source/browse/trunk/MuPDF/MuPDFConverter.cs?r=2
