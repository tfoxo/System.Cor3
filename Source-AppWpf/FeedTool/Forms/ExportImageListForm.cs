using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FeedTool.Forms
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class ExportImageListForm : Form
	{
		MainForm ownerForm;
		List<string> list = new List<string>();
		
		public ExportImageListForm(MainForm owner)
		{
			InitializeComponent();
			ownerForm = owner;
		}
		void Execute(object sender, EventArgs args)
		{
			using (SaveFileDialog sfd = new SaveFileDialog{Filter="Text|*.text"})
			{
				if (sfd.ShowDialog()!= DialogResult.OK) return;
				string result = FormattedString;
				File.WriteAllText(sfd.FileName,result);
				result = null;
				GC.Collect(); // probably not necessary.
			}
		}
		
		#region Formatter
		string FormattedString
		{
			get
			{
				Reformat();
				string[] values = list.ToArray();
				string results = string.Join("\n",values);
				values = null;
				return results;
			}
		}
		void Reformat()
		{
			list.Clear();
			foreach (string key in ownerForm.imageList2.Images.Keys)
				list.Add(string.Format(textBox3.Text,key));
		}
		#endregion
		
		void Event_Reformat(object sender, EventArgs e)
		{
			Reformat();
			textEditor.SetText(FormattedString);
		}
	}
}
