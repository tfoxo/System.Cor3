using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MuPDFLib;

namespace Pdf2Png
{
	static class lfoo
	{
		
		#region Main Method
		
		[STAThread]
		static void Main (string[] args)
		{
			if (args.Length==0)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new ColorMatrixControl());
			}
			else if (args.Length==1)
			{
				IDMatrix idm = new IDMatrix(1,0,0,0,0, 0,1,0,0,0, 0,0,1,0,0, 0,0,0,1,0, 1.5,0,0,0,1)
				{
					Key = "Red Mode",
					Description = "Adds 150% more red to the color of the given image."
				};
				MatrixCollection mx = new MatrixCollection(){
					Children = new List<IDMatrix>(new IDMatrix[]{ idm })
				};
				mx.Save("idm.xml",mx);
				PdfToImage(
					args[0],
					600,
					RenderType.RGB,
					false,false,360000,null,
					new IDMatrix(1,0,0,0,0, 0,1,0,0,0, 0,0,1,0,0, 0,0,0,1,0, 1.5,0,0,0,1),
					-1, -1
				);
			}
			//			PdfToImage(args[0],300,RenderType.RGB,false,false,360000,null);
			//			PdfToImage(args[0],150,RenderType.RGB,false,false,360000,null);
		}
		
		#endregion
		
		#region Methods static bool PdfToImage
		
		public static bool PdfToImage(string sourceFile, float dpi, RenderType type, bool rotateLandscapePages, bool shrinkToLetter, int maxSizeInPdfPixels, string pdfPassword)
		{
			FileInfo source = new FileInfo(sourceFile);
			string name = Path.GetFileNameWithoutExtension(sourceFile);
			bool output = false;
			
			// check source files
			using (MuPDF pdfDoc = new MuPDF(sourceFile, pdfPassword))
			{
				//				using (FileStream outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
				//				{
				//					ImageCodecInfo info = GetCodecInfo();
				pdfDoc.AntiAlias = false;
				for (int i = 1; i <= pdfDoc.PageCount; i++)
				{
					pdfDoc.Page = i;
					using (Bitmap FirstImage = pdfDoc.GetBitmap(0, 0, dpi, dpi, 0, type, rotateLandscapePages, shrinkToLetter, maxSizeInPdfPixels))
					{
						// this is where the bitmap might be converted.
						string outputFile = string.Format("{0}",Path.Combine(source.Directory.FullName,string.Format("{0}-{1:00#}.png",name,i)));
						
						using (Bitmap ScaleImage = new Bitmap(FirstImage,Convert.ToInt32(FirstImage.Width/2f), Convert.ToInt32(FirstImage.Height/2f)))
						{
							ScaleImage.SetResolution(300,300);
							using (
								ImageColourizer ic = new ImageColourizer
								{
									OutputFile = outputFile,
									SourceImage=ScaleImage,
									ImageMatrix = new IDMatrix(
										1000,0,0,0,0,
										0,1,0,0,0,
										0,0,1,0,0,
										0,0,0,1,0,
										0,0,0,0,1
									)
								})
							{
								Console.WriteLine("Colorizing",name,i);
								ic.ProcessColour();
								ic.RenderTargetImage();
								ic.TargetImage.Save(outputFile,ImageFormat.Png);
							}
							Console.WriteLine("{0}-{1:00#}.png",name,i);
						}
					}
				}
			}
			return output;
		}
		
		public static bool PdfToImage(
			string sourceFile,
			float dpi,
			RenderType type,
			bool rotateLandscapePages,
			bool shrinkToLetter,
			int maxSizeInPdfPixels,
			string pdfPassword,
			IDMatrix m,
			int iPageStart,
			int iPageLength
		)
		{
			Console.WriteLine("PDF2IMG");
			FileInfo source = new FileInfo(sourceFile);
			string name = Path.GetFileNameWithoutExtension(sourceFile);
			
			bool output = false;
			// check source files
			using (MuPDF pdfDoc = new MuPDF(sourceFile, pdfPassword))
			{
				pdfDoc.AntiAlias = false;
				
				int sta = iPageStart==-1 ? 1 : iPageStart;
				int len = iPageLength ==-1 ? pdfDoc.PageCount : iPageLength;
				
				for (int i = sta; i < len; i++)
				{
					pdfDoc.Page = i;
					using (Bitmap FirstImage = pdfDoc.GetBitmap(0, 0, dpi, dpi, 0, type, rotateLandscapePages, shrinkToLetter, maxSizeInPdfPixels))
					{
						// this is where the bitmap might be converted.
						string outputFile = string.Format("{0}",Path.Combine(source.Directory.FullName,string.Format("{0}-{1:00#}.png",name,i)));
						using (Bitmap ScaleImage = new Bitmap(FirstImage,Convert.ToInt32(FirstImage.Width/2f), Convert.ToInt32(FirstImage.Height/2f)))
						{
							ScaleImage.SetResolution(300,300);
							using (
								ImageColourizer ic = new ImageColourizer
								{
									OutputFile = outputFile,
									SourceImage=ScaleImage,
									ImageMatrix = m
								})
							{
								Console.WriteLine("Colorizing",name,i);
								ic.ProcessColour();
								ic.RenderTargetImage();
								ic.TargetImage.Save(outputFile,ImageFormat.Png);
							}
							Console.WriteLine("{0}-{1:00#}.png",name,i);
						}
					}
				}
			}
			return output;
		}
		
		#endregion
		
		#region REFERENCE METHOD (NOT COMPILED)
		#if NO
		static ImageCodecInfo GetCodecInfo()
		{
			ImageCodecInfo info = null;
			
			foreach (ImageCodecInfo ice in ImageCodecInfo.GetImageEncoders())
			{
				if (ice.MimeType == "image/tiff") info = ice;
			}
			return info;
		}
		static public void SaveImageToTiff(MuPDF pdfDoc, Bitmap FirstImage, FileStream outputStream, RenderType type, ImageCodecInfo info, int i)
		{
			Bitmap saveTif = null;
			
			if (FirstImage == null) throw new Exception("Unable to convert pdf to tiff!");
			
			using (EncoderParameters ep = new EncoderParameters(2))
			{
				ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
				ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
				if (type == RenderType.Monochrome)
				{
					ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
				}
				
				if (i == 1)
				{
					saveTif = FirstImage;
					saveTif.Save(outputStream, info, ep);
				}
				else
				{
					ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);
					saveTif.SaveAdd(FirstImage, ep);
					FirstImage.Dispose();
				}
				if (i == pdfDoc.PageCount)
				{
					ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.Flush);
					saveTif.SaveAdd(ep);
					saveTif.Dispose();
				}
			}
		}
		#endif
		#endregion
		
	}
}
