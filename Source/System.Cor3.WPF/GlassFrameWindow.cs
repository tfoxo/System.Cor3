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



	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class GlassFrameWindow : Window
		// http://msdn.microsoft.com/en-us/library/ms748975.aspx
	{
		MARGINS margins = new MARGINS();
		IntPtr HANDLE = IntPtr.Zero;
		HwndSource mainWindowSrc;
		Graphics desktop;
		
		[DllImport("DwmApi.dll")]
		public static extern int DwmExtendFrameIntoClientArea( IntPtr hwnd, ref MARGINS pMarInset);

		public GlassFrameWindow()
		{
			this.Loaded += OnLoaded;
		}
		
		
		public float FDpiX { get { return desktop.DpiX / 96; } }
		int DpiX { get { return Convert.ToInt32(DpiX); } }
		float FDpiY { get { return desktop.DpiY / 96; } }
		
		protected System.Windows.Media.Color dwmBgColour = System.Windows.Media.Color.FromArgb(0,0,0,0);
		#region remarked
		/*		protected void ResetMargins(System.Windows.Media.Color color, int all) { ResetMargins(color, all,all,all,all); }
		protected void ResetMargins(System.Windows.Media.Color color, int t, int r, int b, int l)
		{
			MARGINS m = new MARGINS( FDpiX, t, r, b, l );
			ResetMargins(color,m);
		}
		protected void ResetMargins(System.Windows.Media.Color color, MARGINS m)
		{
			dwmBgColour = color;
			margins = m;
			try
			{
				InitializeHandle(  );
//				if (HANDLE==IntPtr.Zero) {
//					Application.Current.MainWindow.Background = System.Windows.Media.Brushes.White;
//					return;
//				}
				int hr = DwmExtendFrameIntoClientArea(this.HANDLE, ref this.margins);
				//
				if (hr < 0)
				{
					//DwmExtendFrameIntoClientArea Failed
				}
			}
			// If not Vista, paint background white.
			catch (DllNotFoundException)
			{
				Application.Current.MainWindow.Background = System.Windows.Media.Brushes.White;
			}
		}
		 */
		#endregion
		
		virtual protected MARGINS GetMargins()
		{
			return new MARGINS(FDpiX,5);
		}
		void dwmInit()
		{
			try
			{
				// Obtain the window handle for WPF application
				HANDLE = new WindowInteropHelper(this).Handle;
				HwndSource mainWindowSrc = HwndSource.FromHwnd(HANDLE);
				mainWindowSrc.CompositionTarget.BackgroundColor = dwmBgColour;

				// Get System Dpi
				desktop = System.Drawing.Graphics.FromHwnd(HANDLE);
//				float DesktopDpiX = desktop.DpiX;
//				float DesktopDpiY = desktop.DpiY;

				// Set Margins
				margins = GetMargins();

				// Extend glass frame into client area
				// Note that the default desktop Dpi is 96dpi. The  margins are
				// adjusted for the system Dpi.
//				margins.cxLeftWidth = Convert.ToInt32(5 * (DesktopDpiX / 96));
//				margins.cxRightWidth = Convert.ToInt32(5 * (DesktopDpiX / 96));
//				margins.cyTopHeight = Convert.ToInt32(((int)topBar.ActualHeight + 5) * (DesktopDpiX / 96));
//				margins.cyBottomHeight = Convert.ToInt32(5 * (DesktopDpiX / 96));

				int hr = DwmExtendFrameIntoClientArea(mainWindowSrc.Handle, ref margins);
				//
				if (hr < 0)
				{
					//DwmExtendFrameIntoClientArea Failed
				}
			}
			// If not Vista, paint background white.
			catch (DllNotFoundException)
			{
				Application.Current.MainWindow.Background = System.Windows.Media.Brushes.White;
			}
		}
//	}
		
//		void InitializeHandle()
//		{
//			this.HANDLE = new WindowInteropHelper(this).Handle;
//			desktop = System.Drawing.Graphics.FromHwnd(HANDLE);
//			mainWindowSrc = HwndSource.FromHwnd(this.HANDLE);
//			mainWindowSrc.CompositionTarget.BackgroundColor = dwmBgColour;
//
//		}
		/// <summary>
		/// you don't need to override me.  Override GetMargins()
		/// </summary>
		/// <param name="s"></param>
		/// <param name="a"></param>
		virtual protected void OnLoaded(object s, RoutedEventArgs a)
		{
			dwmInit();
//			this.dwmBgColour = System.Windows.Media.Colors.Transparent;
			//ResetMargins( this.dwmBgColour, 5 );
			// Obtain the window handle for WPF application
			
		}
		
	}
}