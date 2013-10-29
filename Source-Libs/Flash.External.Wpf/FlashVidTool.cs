/*
 * oIo — 11/15/2010 — 6:23 PM
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Flash.External;

namespace wpv
{
	/// <summary>
	/// Description of FlashVidTool.
	/// </summary>
	public partial class FlashVidTool : UserControl
	{
		static string flvPath
		{
			get
			{
				return System.IO.Path.Combine(
				System.IO.Path.GetDirectoryName(Application.ExecutablePath),
				@"res\webui.swf");
			}
		}

		private ExternalInterfaceProxy proxy;
		public void sendMessage(string message)
		{
			sendMessage("get_flv",message);
		}
		public void sendMessage(string mthd, string message)
		{
			proxy.Call(mthd, message);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			axShockwaveFlash1.Movie = flvPath;
			proxy = new ExternalInterfaceProxy(axShockwaveFlash1);
		}

		public FlashVidTool()
		{
			InitializeComponent();
		}
	}
}
