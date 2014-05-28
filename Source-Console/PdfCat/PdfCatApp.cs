/* oio * 10/27/2013 * 3:47 AM */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Tasks;

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfCat
{
    /// <summary>
    /// http://www.pdfsharp.net/wiki/CombineDocuments-sample.ashx
    /// </summary>
    class PdfCatApp : System.Commander
    {
        DirectoryInfo InputDirectory = null;
        string inputStartPath = null;
        /// <summary>
        /// A value of -1 means to ignore this feature.
        /// <para>
        /// This feature has been added specifically for concatenating a set
        /// of google-analytics EXPORTs, some of which bleed little to
        /// nothing into a second page, so setting the limit to 1 means
        /// we only place the first page from a particular document into
        /// the new PDF.</para>
        /// </summary>
        int pageLimit = -1;
        
        [STAThread]
        static void Main(string[] args)
        {
            PdfCatApp app = new PdfCatApp(args);
        }
        
        public PdfCatApp(params string[] a)
        {
            Args = new List<string>(a);
            if (Args==null) {
                Console.WriteLine("Nothing to do for us tools.");
                Console.WriteLine("current directory: {0}",Environment.CurrentDirectory);
                WaitForKey();
                return;
            }
            
            if (HasValue("-l"))
            {
                string tempLimit = GetValue(true,"-l");
                pageLimit = int.Parse(tempLimit);
            }
            
            if (Args.Count==1  &&  Directory.Exists(this.Args[0].Trim())) {
                inputStartPath = Args[0].Trim();
                InputDirectory = new DirectoryInfo(inputStartPath);
            }
            else if (HasValue("-i")) {
                inputStartPath = GetValue(true,"-i");
                InputDirectory = new DirectoryInfo(inputStartPath);
            }
            else {
                Console.WriteLine("Nothing to do for us tools.");
                Console.WriteLine("current directory: {0}",Environment.CurrentDirectory);
                WaitForKey();
                return;
            }
            
            Variant1();
            //            Variant2();
            //            Variant3();
            //            Variant4();
            
            //WaitForKey();
        }
        
        
        /// <summary>
        /// Put your own code here to get the files to be concatenated.
        /// </summary>
        string[] InitializeCommand()
        {
            FileInfo[] fileInfos = InputDirectory.GetFiles("*.pdf");
            ArrayList list = new ArrayList();
            foreach(FileInfo info in fileInfos)
            {
                // HACK: Just skip the protected samples file...
                if (info.Name.IndexOf("protected") == -1)
                    list.Add(info.FullName);
            }
            return (string[])list.ToArray(typeof(string));
        }
        
        /// <summary>
        /// Imports all pages from a list of documents.
        /// </summary>
        public void Variant1()
        {
            // Get some file names
            string[] files = InitializeCommand();
            
            // Open the output document
            PdfDocument outputDocument = new PdfDocument();
            
            // Iterate files
            foreach (string file in files)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument;
                try {
                    inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("File: {0}", file);
                    Console.Error.WriteLine("Error: {0}: {1}", e.Source, e.Message);
                    continue;
                }
                
                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    if (pageLimit==-1) {
                        
                        // Get the page from the external document...
                        PdfPage page = inputDocument.Pages[idx];
                        // ...and add it to the output document.
                        outputDocument.AddPage(page);
                    }
                    else if (pageLimit > 0 && idx < pageLimit)
                    {
                        // Get the page from the external document...
                        PdfPage page = inputDocument.Pages[idx];
                        // ...and add it to the output document.
                        outputDocument.AddPage(page);
                    }
                    else break;
                }
            }
            
            // Save the document...
            string filename = "ConcatenatedDocument1.pdf";
            outputDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
        
        /// <summary>
        /// This sample adds each page twice to the output document. The output document
        /// becomes only a little bit larger because the content of the pages is reused
        /// and not duplicated.
        /// </summary>
        public void Variant2()
        {
            // Get some file names
            string[] files = InitializeCommand();
            
            // Open the output document
            PdfDocument outputDocument = new PdfDocument();
            
            // Show consecutive pages facing. Requires Acrobat 5 or higher.
            outputDocument.PageLayout = PdfPageLayout.TwoColumnLeft;
            
            // Iterate files
            foreach (string file in files)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                
                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // Get the page from the external document...
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add them twice to the output document.
                    outputDocument.AddPage(page);
                    outputDocument.AddPage(page);
                }
            }
            
            // Save the document...
            string filename = "ConcatenatedDocument2.pdf";
            outputDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
        
        /// <summary>
        /// This sample adds a consecutive number in the middle of each page.
        /// It shows how you can add graphics to an imported page.
        /// </summary>
        public void Variant3()
        {
            // Get some file names
            string[] files = InitializeCommand();
            
            // Open the output document
            PdfDocument outputDocument = new PdfDocument();
            
            // Note that the output document may look significant larger than in Variant1.
            // This is because adding graphics to an imported page causes the
            // uncompression of its content if it was compressed in the external document.
            // To compare file sizes you should either run the sample as Release build
            // or uncomment the following line.
            //outputDocument.Options.CompressContentStreams = true;
            
            XFont font = new XFont("Verdana", 40, XFontStyle.Bold);
            XStringFormat format = XStringFormats.Center;
            int number = 0;
            
            // Iterate files
            foreach (string file in files)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                
                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // Get the page from the external document...
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add it to the output document.
                    // Note that the PdfPage instance returned by AddPage is a
                    // different object.
                    page = outputDocument.AddPage(page);
                    
                    // Create a graphics object for this page. To draw beneath the existing
                    // content set 'Append' to 'Prepend'.
                    XGraphics gfx =
                        XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append);
                    DrawNumber(gfx, font, ++number);
                }
            }
            
            // Save the document...
            string filename = "ConcatenatedDocument3.pdf";
            outputDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
        
        /// <summary>
        /// This sample is the combination of Variant2 and Variant3. It shows that you
        /// can add external pages more than once and still add individual graphics on
        /// each page. The external content is shared among the pages, the new graphics
        /// are unique to each page. You can check this by comparing the file size
        /// of Variant3 and Variant4.
        /// </summary>
        public void Variant4()
        {
            // Get some file names
            string[] files = InitializeCommand();
            
            // Open the output document
            PdfDocument outputDocument = new PdfDocument();
            
            // For checking the file size uncomment next line.
            //outputDocument.Options.CompressContentStreams = true;
            
            XFont font = new XFont("Verdana", 40, XFontStyle.Bold);
            XStringFormat format = XStringFormats.Center;
            int number = 0;
            
            // Iterate files
            foreach (string file in files)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                
                // Show consecutive pages facing. Requires Acrobat 5 or higher.
                outputDocument.PageLayout = PdfPageLayout.TwoColumnLeft;
                
                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // Get the page from the external document...
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add it twice to the output document.
                    PdfPage page1 = outputDocument.AddPage(page);
                    PdfPage page2 = outputDocument.AddPage(page);
                    
                    XGraphics gfx =
                        XGraphics.FromPdfPage(page1, XGraphicsPdfPageOptions.Append);
                    DrawNumber(gfx, font, ++number);
                    
                    gfx = XGraphics.FromPdfPage(page2, XGraphicsPdfPageOptions.Append);
                    DrawNumber(gfx, font, ++number);
                }
            }
            
            // Save the document...
            string filename = "ConcatenatedDocument4.pdf";
            outputDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
        
        /// <summary>
        /// Draws the number in the middle of the page.
        /// </summary>
        void DrawNumber(XGraphics gfx, XFont font, int number)
        {
            double width = 130;
            gfx.DrawEllipse(new XPen(XColors.DarkBlue, 7), XBrushes.DarkOrange,
                            new XRect((gfx.PageSize.ToXPoint() - new XSize(width, width)) / 2,
                                      new XSize(width, width)));
            gfx.DrawString(number.ToString(), font, XBrushes.Firebrick,
                           new XRect(XPoint.Empty, gfx.PageSize),XStringFormats.Center);
        }
    }
}
