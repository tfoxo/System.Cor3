/*
 * Created by SharpDevelop.
 * User: oIo
 * Date: 11/15/2010
 * Time: 6:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms.Integration;
namespace wpv
{
	/// <summary>
	/// Interaction logic for FlvControl.xaml
	/// </summary>
	public partial class FlvControl : UserControl
	{
		FlashVidTool flvTool;
		public FlashVidTool FlvTool
		{
			get { return this.flvTool; }
		}
		
		protected void Initialize()
		{
			this.flvTool = new FlashVidTool();
			WindowsFormsHost wfh = new WindowsFormsHost() { Child = FlvTool, };
			Content = wfh;
		}
		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			Initialize();
			
//			this.flvhost
		}
		public FlvControl()
		{
			InitializeComponent();
		}
	}
}