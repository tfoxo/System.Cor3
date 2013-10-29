/*
 * oIo ? 11/15/2010 ? 6:23 PM
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Flash.External;

namespace Flash
{
	/// <summary>
	/// Description of FlashVidTool.
	/// </summary>
	public partial class FlashVidTool : UserControl
	{
		public static byte[] SwfMovieBinary {
			get { return swfMovieBinary; }
			set { swfMovieBinary = value; }
		} static byte[] swfMovieBinary;
		
		[System.ComponentModel.DefaultValue(false)]
		[System.ComponentModel.Category("Flash Info")]
		public bool UseResWebUI {
			get { return useResWebUI; }
			set { useResWebUI = value; }
		} bool useResWebUI = false;
		
		static string flvPath
		{
			get
			{
				return System.IO.Path.Combine(
					System.IO.Path.GetDirectoryName(Application.ExecutablePath),
					@"res\webui.swf");
			}
		}
		
		public void sendMessage(string message)
		{
			sendMessage("get_flv",message);
		}
		
		public void sendMessage(string mthd, string message)
		{
			axFlashPlayer.Proxy.Call(mthd, message);
			Console.WriteLine("Flash.External Message: ‘{0}’: {1}",mthd,message);
		}
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			try {
				SetMovie();
			} catch {
			
			}
		}
		
		void SetMovie()
		{
			if (SwfMovieBinary==null && UseResWebUI)
			{
				lock (axFlashPlayer) {
					axFlashPlayer.Movie = flvPath;
				}
			}
			else
			{
				InitFlashMovie(SwfMovieBinary);
			}
			axFlashPlayer.Proxy = new ExternalInterfaceProxy(axFlashPlayer);
		}
		
		public void InitFlashMovie(byte[] swfFile)
		{
			//http://stackoverflow.com/questions/1874077/loading-a-flash-movie-from-a-memory-stream-or-a-byte-array/
			using (MemoryStream stm = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter(stm))
				{
					/* Write length of stream for AxHost.State */
					writer.Write(8 + swfFile.Length);
					/* Write Flash magic 'fUfU' */
					writer.Write(0x55665566);
					/* Length of swf file */
					writer.Write(swfFile.Length);
					writer.Write(swfFile);
					stm.Seek(0, SeekOrigin.Begin);
					/* 1 == IPeristStreamInit */
					axFlashPlayer.OcxState = new AxHost.State(stm, 1, false, null);
				}
			}
		}

		public FlashVidTool()
		{
			InitializeComponent();
		}
	}
}
