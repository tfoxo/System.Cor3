/* oOo * 11/28/2007 : 5:29 PM */
using System;
using System.Cor3.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Utilities.SuperOld;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace System.Drawing
{
	static public class GraphicsExtension
	{
		/// <summary>
		/// An attempt to interpolate only when the image is rendered smaller then the original.
		/// </summary>
		/// <param name="g"></param>
		/// <param name="InterpolMax"></param>
		/// <param name="targetBitmap"></param>
		static public void HighQuality(this Graphics g, FloatPoint InterpolMax, Bitmap targetBitmap)
		{
			if (InterpolMax < targetBitmap.Size)
			{
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			}
			else
			{
				g.SmoothingMode = SmoothingMode.None;
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
			}
		}
	}
}
