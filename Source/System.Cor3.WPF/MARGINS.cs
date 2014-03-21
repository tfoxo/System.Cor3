/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 3/14/2012
 * Time: 6:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace System.Cor3.WPF
{
	[StructLayout(LayoutKind.Sequential)]
	public struct MARGINS
	{
		public int cxLeftWidth;      // width of left border that retains its size
		public int cxRightWidth;     // width of right border that retains its size
		public int cyTopHeight;      // height of top border that retains its size
		public int cyBottomHeight;   // height of bottom border that retains its size
		public MARGINS(float dpi, int all)
		{
			cxLeftWidth = cxRightWidth = cyBottomHeight = cyTopHeight = Convert.ToInt32(all*dpi);
		}
		public MARGINS (float dpi, int top, int rig, int btm, int lef)
		{
			this.cyTopHeight = Convert.ToInt32(top*dpi);
			this.cxRightWidth = Convert.ToInt32(rig*dpi);
			this.cyBottomHeight = Convert.ToInt32(btm*dpi);
			this.cxLeftWidth = Convert.ToInt32(lef*dpi);
		}
	};
}
