/* User: oIo * Date: 9/21/2010 * Time: 10:22 AM */
using System;
namespace System.Drawing
{
	/// <summary>
	/// As defined for css.  It apparently is based on a mm which
	/// in the case of css2 is defined as a macro parsable by GNU tools
	/// Flex and/or Bison.
	/// </summary>
	public class Metrics // as defined for css.  It apparently is based on a mm which in the case of css2 is defined as a macro
	{
		// see Printable RTF to see more on Windows Units for printing
		// we have a DPI for RTF Printing in there.  This could be PixelT
		public const double INCH = (25.4D * MM);
		public const double CM = 10D * MM;
		public const double MM = 1D;
		public static double def_mm = 1D;
		public const double PICA = (12D * INCH/72D * MM);
		public const double POINT = (INCH/72D * MM);
		public const double PixelT = MM/92D;
//		public Metrics() : base()
//		{
//			Add("INCH",INCH);
//			Add("CM",CM);
//			Add("MM",MM);
//			Add("PICA",PICA);
//			Add("POINT",POINT);
//			Add("PixelT",PixelT);
//		}
	}
}
