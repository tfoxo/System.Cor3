/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 12/1/2013
 * Time: 11:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Cor3.Parsers;
using System.Drawing;
using System.Internals;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ParseTool.Views
{
	/// <summary>
	/// Description of UserControl1.
	/// </summary>
	public partial class FictionaryView : XView
	{
		OpenFileDialog ofd { get;set; }
		SaveFileDialog sfd { get;set; }
		
		public StringValue SelectedValue { get;set; }
		public void SetTerm(StringValue term)
		{
			SelectedValue = term;
//			tNext.Text = SelectedValue.Key;
//			textEditorControl1.SetText(SelectedValue.Value);
		}
		public void SaveTerm()
		{
//			SelectedValue.Key = tNext.Text;
//			SelectedValue.Value = textEditorControl1.Text;
		}
		
		public FictionaryView()
		{
			InitializeComponent();
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
//			textEditorControl1.SetText(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
//			textEditorControl1.SetHighlighting("XML");
		}
		MenuItem[] GetItems()
		{
			List<MenuItem> items = new List<MenuItem>();
			foreach (var x in TextEditorUtil.GetHighlighters())
				items.Add(new MenuItem(x,SetLanguage));
			return items.ToArray();
		}
		
		void SetLanguage(object sender, EventArgs e)
		{
			var x = sender as MenuItem;
//			textEditorControl1.SetHighlighting(x.Text);
		}
		void LinkPrevClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
		}
		void LinkNextClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
		}
		
		void RevertAction(object sender, LinkLabelLinkClickedEventArgs e)
		{
//			tNext.Text = SelectedValue.Key;
//			textEditorControl1.SetText(SelectedValue.Value);
		}
		
		void SaveAction(object sender, LinkLabelLinkClickedEventArgs e)
		{
//			SelectedValue.Key = tNext.Text;
//			SelectedValue.Value = textEditorControl1.Text;
		}
		
		#region Designer
		
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(529, 311);
			this.dataGridView1.TabIndex = 0;
			// 
			// FictionaryView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.dataGridView1);
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "FictionaryView";
			this.Size = new System.Drawing.Size(529, 311);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolTip toolTip1;
		#endregion
	}


	
	public class FictionaryViewProvider : XProvider
	{
		public FictionaryViewProvider() : base()
		{
			title = "Fictionary Editor";
			this.View = new FictionaryView(){ Name="FictionaryView" };
		}
		
	}
}
