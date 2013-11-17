using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Windows;

namespace System
{
	public class ClipboardMonitorService : IServiceProvider, IDisposable
	{
		const string message_handle_zero = "Failed obtaining window handle.";

		// service-container (test)
		#region Service
		static readonly ServiceContainer services = new ServiceContainer();
		object IServiceProvider.GetService(Type serviceType)
		{
			return (ClipboardMonitorService) services.GetService(serviceType);
		}
		#endregion
		
		#region Win32
		
		[DllImport(user32)] static extern IntPtr SetClipboardViewer(IntPtr hWnd);
		[DllImport(user32)] static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
		[DllImport(user32)] static extern int ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNext);

		const string user32 = "user32.dll";
		const int WM_DRAWCLIPBOARD = 0x308, WM_PAINTCLIPBOARD=0x309, WM_CHANGECBCHAIN = 0x30d;
		#endregion
		#region Win32-Hook
		IntPtr WinProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			switch (msg)
			{
				case WM_CHANGECBCHAIN:
					if (wParam == hWndNextViewer)
					{
						// clipboard viewer chain changed, need to fix it.
						hWndNextViewer = lParam;
					}
					else if (hWndNextViewer != IntPtr.Zero)
					{
						// pass the message to the next viewer.
						SendMessage(hWndNextViewer, msg, wParam, lParam);
					}
					break;
				case WM_DRAWCLIPBOARD:
					// clipboard content changed
//					lock (LOCK)
					{
						OnGotClipboard();
					}
					// pass the message to the next viewer.
					SendMessage(hWndNextViewer, msg, wParam, lParam);
					break;
			}
			return IntPtr.Zero;
		}
		#endregion
		
		#region Fields
		Window window;
		HwndSource hWndSource;
		IntPtr hWndNextViewer;
		bool isViewing = false;
		static readonly object LOCK = new object();
		#endregion
		
		public ClipboardMonitorService(Window window,RoutedEventHandler handler) : this(window)
		{
			AddHandler(handler);
		}
		public ClipboardMonitorService(Window window)
		{
			services.AddService(typeof(ClipboardMonitorService),this,false);
			this.window = window;
			Initialize();
		}
		
		private void Initialize()
		{
			WindowInteropHelper wih = new WindowInteropHelper(this.window);
			if (wih.Handle==IntPtr.Zero)
			{
				MessageBox.Show(message_handle_zero);
				return;
			}
			hWndSource = HwndSource.FromHwnd(wih.Handle);
			hWndSource.AddHook(this.WinProc); // start processing window messages
			hWndNextViewer = SetClipboardViewer(hWndSource.Handle); // set this window as a viewer
			isViewing = true;
		}
		private void Deinitialize()
		{
			ChangeClipboardChain(hWndSource.Handle, hWndNextViewer);
			hWndNextViewer = IntPtr.Zero;
			hWndSource.RemoveHook(this.WinProc);
			isViewing = false;
		}

		#region Event
		public void AddHandler(RoutedEventHandler handler)
		{
			GotClipboard += handler;
		}
		public void RemoveHandler(RoutedEventHandler handler)
		{
			GotClipboard -= handler;
		}

		public event RoutedEventHandler GotClipboard;
		protected virtual void OnGotClipboard()
		{
			if (GotClipboard != null) {
				GotClipboard(window, default(RoutedEventArgs));
			}
		}
		#endregion

		#region IDisposable
		void IDisposable.Dispose()
		{
			services.RemoveService(typeof(ClipboardMonitorService));
			services.Dispose();
			Deinitialize();
		}
		#endregion
	}
}
