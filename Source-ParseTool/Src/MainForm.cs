/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 12/1/2013
 * Time: 6:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Internals;
using System.Reflection;
using System.Windows.Forms;

using System.Cor3.Parsers;
using ParseTool.Views;

namespace ParseTool
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MenuItem ViewMenuItem { get;set; }
		public XView CurrentView { get;set; }
		public List<XProvider> Views = XProvider.EnumerateViewTypes<XProvider>(Assembly.GetExecutingAssembly());
		public ParserStrategy ParserSettings { get;set; }
		
		readonly OpenFileDialog ofd = new OpenFileDialog(){Filter="XML Configuaration|*.xml"};
		readonly SaveFileDialog sfd = new SaveFileDialog(){Filter="XML Configuaration|*.xml"};
		
		TreeNode tStrings, tRegex, tParsers;
		
		public MainForm()
		{
			InitializeComponent();
			InitializeStrategy();
			InitializeUi();
			InvalidateParser();
		}
		
		void InitializeStrategy()
		{
			ParserSettings = new ParserStrategy
			{
				Items=new List<StringValue>(){
//					new StringValue{Key="digits",Value="[0-9]"},
//					new StringValue{Key="lcase",Value="[a-z]"},
//					new StringValue{Key="ucase",Value="[A-Z]"},
				}
			};
		}
		
		void InitializeUi()
		{
			this.Menu = new MainMenu();
			this.Menu.MenuItems.Add("&File")
				.MenuItems.AddRange(
					new MenuItem[]{
						new MenuItem("Save",SaveFileHandler),
						new MenuItem("Open",OpenFileHandler),
						new MenuItem("-"),
						new MenuItem("E&xit",ExitHandler)
					}
				);
			ViewMenuItem = Menu.MenuItems.Add("&View");
			foreach (XProvider v in Views)
			{
				v.Parent = this;
				AddViewPoint(v);
			}
		}
		
		void AddViewPoint(XProvider v)
		{
			// this has to change based on the operating system.
			// we could perhaps focus on a new control
			// or use reflection to create the control.

			splitContainer1.Panel2.Controls.Add(v.View);
			v.View.Dock = DockStyle.Fill;
			ViewMenuItem.MenuItems.Add(v.Title, ViewItemClick);
		}
		
		void InvalidateParser()
		{
			treeView1.Nodes.Clear();
			if (ParserSettings==null) {
				ParserSettings = new ParserStrategy();
				return;
			}
			tStrings = treeView1.Nodes.Add("Strings");
			tRegex = treeView1.Nodes.Add("Regex");
			tParsers = treeView1.Nodes.Add("Parsers");
			foreach (StringValue value in ParserSettings.Items)
			{
				tStrings.Nodes.Add(new TreeNode(value.Key){Tag=value});
			}
		}
		void InvalidateParser(ParserStrategy strategy)
		{
			ParserSettings = strategy;
			treeView1.Nodes.Clear();
			tStrings = treeView1.Nodes.Add("Strings");
			tRegex = treeView1.Nodes.Add("Regex");
			tParsers = treeView1.Nodes.Add("Parsers");
			foreach (StringValue value in ParserSettings.Items)
			{
				tStrings.Nodes.Add(new TreeNode(value.Key){Tag=value});
			}
		}
		
		void SaveFileHandler(object o, EventArgs a)
		{
			if ( sfd.ShowDialog() == DialogResult.OK ) ParserSettings.Save(sfd.FileName,ParserSettings);
		}
		
		void OpenFileHandler(object o, EventArgs a)
		{
			if ( ofd.ShowDialog() == DialogResult.OK ) {
				ParserStrategy settings = ParserStrategy.Load(ofd.FileName);
				InvalidateParser(settings);
			}
		}
		
		void ExitHandler(object o, EventArgs a)
		{
			Close();
		}
		
		//Dictionary Editor
		public XView GetView(string tag)
		{
			var vp = Views.FindView<MainForm,XProvider,XView>(tag);
			vp.View.BringToFront();
			foreach (MenuItem m in ViewMenuItem.MenuItems)
				m.Checked = m.Text==vp.Title;
			return vp.View;
		}
		void ViewItemClick(object o, EventArgs a)
		{
			GetView((o as MenuItem).Text);
		}

		void TreeItemAfterSelected(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Level==0)
			{
				
			}
			else if (e.Node.Level == 1)
			{
				if (e.Node.Tag is StringValue)
				{
					DictionaryView v = GetView("Dictionary Editor") as DictionaryView;
					v.SetTerm(e.Node.Tag as StringValue);
				}
			}
		}
	}
}
