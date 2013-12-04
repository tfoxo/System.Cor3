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
	public partial class DictionaryView : XView
	{
		public StringValue SelectedValue { get;set; }
		public void SetTerm(StringValue term)
		{
			SelectedValue = term;
			tNext.Text = SelectedValue.Key;
			textEditorControl1.SetText(SelectedValue.Value);
		}
		public void SaveTerm()
		{
			SelectedValue.Key = tNext.Text;
			SelectedValue.Value = textEditorControl1.Text;
		}
		
		public DictionaryView()
		{
			InitializeComponent();
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			textEditorControl1.SetText(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
			textEditorControl1.SetHighlighting("XML");
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
			textEditorControl1.SetHighlighting(x.Text);
		}
		void LinkPrevClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
		}
		void LinkNextClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
		}
		
		void RevertAction(object sender, LinkLabelLinkClickedEventArgs e)
		{
			tNext.Text = SelectedValue.Key;
			textEditorControl1.SetText(SelectedValue.Value);
		}
		
		void SaveAction(object sender, LinkLabelLinkClickedEventArgs e)
		{
			SelectedValue.Key = tNext.Text;
			SelectedValue.Value = textEditorControl1.Text;
		}
	}
	
	public class DictionaryViewProvider : XProvider
	{
		public DictionaryViewProvider() : base()
		{
			title = "Dictionary Editor";
			this.View = new DictionaryView(){ Name="DictionaryView" };
		}
		
	}
	

}
