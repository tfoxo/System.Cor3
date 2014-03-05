/* oio : 12/13/2013 5:57 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace System.Drawing.Imaging
{
	// http://code.msdn.microsoft.com/windowsdesktop/ColorMatrix-Image-Filters-f6ed20ae/sourcecode?fileId=76990&pathId=1063569018
	
	/// <summary>
	/// This class is simply used to process an image.
	/// </summary>
	class ImageColourizer : IDisposable
	{
		#region Properties: Bitmap/Imaging
		
		ImageAttributes TargetAttributes { get;set; }
		
		public IDMatrix ImageMatrix { get; set; }
		public Bitmap SourceImage { get;set; }
		public Bitmap TargetImage { get;set; }
		
		#endregion
		
		#region Properties: File
		public string InputFile {
			get { return inputFile; }
			set { inputFile = value; SetSource(inputFile); }
		} string inputFile;
		public string OutputFile { get;set; }
		#endregion
		
		#region Methods: Save Image
		
		public void Save(ImageFormat fmt) { if (!string.IsNullOrEmpty(OutputFile)) TargetImage.Save(OutputFile,fmt); }
		
		public void Save() { Save(ImageFormat.Png); }
		
		#endregion
		#region Methods: Render
		public void RenderToControl(Control c)
		{
			if (TargetImage==null) return;
			using (Graphics g = c.CreateGraphics())
			{
				g.DrawImage(
					TargetImage,
					new Rectangle(0,0,SourceImage.Width,SourceImage.Height),
					0,0,SourceImage.Width,SourceImage.Height,
					GraphicsUnit.Pixel,TargetAttributes
				);
			}
		}
		public void RenderTargetImage()
		{
			// Create TargetImage based on source
			TargetImage = new Bitmap(SourceImage);
			
			// Render
			using (Graphics g = Graphics.FromImage(TargetImage))
			{
				g.Clear(Color.White);
				g.CompositingQuality = CompositingQuality.HighQuality;
				g.InterpolationMode  = InterpolationMode.HighQualityBicubic;
				g.SmoothingMode      = SmoothingMode.HighQuality;
				g.DrawImage(
					SourceImage,
					new Rectangle(0,0,SourceImage.Width,SourceImage.Height),
					0,0,SourceImage.Width,SourceImage.Height,
					GraphicsUnit.Pixel,
					TargetAttributes
				);
			}
		}
		#endregion
		#region Methods: Set Bitmap
		public void SetSource(Bitmap image)
		{
			if (image!=null) SourceImage = image;
		}
		public void SetSource(string imageFile)
		{
			// Check InputFile
			if (!System.IO.File.Exists(imageFile)) throw new System.IO.FileNotFoundException();
			// Set InputFile
			InputFile = imageFile;
			// Set SourceImage
			SourceImage = new Bitmap(InputFile);
		}
		#endregion
		#region Methods: Color-Process
		/// <summary>
		/// if ImageMatrix isn't set, we'll have problems.
		/// </summary>
		public void ProcessColour()
		{
			// Apply MATRIX
			TargetAttributes = new ImageAttributes();
			TargetAttributes.SetColorMatrix(ImageMatrix,ColorMatrixFlag.Default,ColorAdjustType.Bitmap);
		}
		#endregion
		
		public void Dispose()
		{
			inputFile = null;
			OutputFile = null;
			TargetAttributes = null;
			if (SourceImage!=null) SourceImage.Dispose();
			if (TargetImage!=null) TargetImage.Dispose();
		}
		
		//MuFoo.Matrix GetMatrix( float r, float g, float b, float a) { return new MuFoo.Matrix( r,0,0,0,0, /**/ 0,g,0,0,0, /**/ 0,0,b,0,0, /**/ 0,0,0,a,0, /**/ 0,0,0,0,0 ); }
		
	}
}
