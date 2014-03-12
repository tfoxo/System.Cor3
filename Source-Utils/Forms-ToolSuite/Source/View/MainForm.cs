#region User/License
// oio * 8/18/2012 * 11:45 PM

// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

using ToolSuite.Lib;

namespace TemplateTool.View
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	[Export]
	public partial class MainForm : Form
	{
		TreeNode NodeTasks = new TreeNode("Tasks");
		
		[ImportingConstructor]
		public MainForm([ImportMany] IEnumerable<ITaskControlProvider> tasks)
		{
			InitializeComponent();
			WindowsInterop.WindowsTheme.HandleTheme(this);
			WindowsInterop.WindowsTheme.HandleTheme(this.treeTasks);
			
			treeTasks.Nodes.Add(NodeTasks);
			foreach (var task in tasks) { NodeTasks.Nodes.Add(task.Name).Tag = task; }
			treeTasks.ExpandAll();
			this.Text = this.Text + ((System.Runtime.InteropServices.Marshal.SizeOf(IntPtr.Zero) == 8) ? " (x64)" : " (x86)");
		}
		
		void ItemSelected(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Tag==null) return;
			if (viewContainer.Controls.Count>0)
			{
				viewContainer.Controls[0].Dispose();
				viewContainer.Controls.Clear();
				GC.Collect();
			}
			UserControl view = (e.Node.Tag as ITaskControlProvider).GetView();
			view.Dock = DockStyle.Fill;
			viewContainer.Controls.Add(view);
		}
		
		public MainForm()
		{
			InitializeComponent();
			treeTasks.ExpandAll();
		}
		
	}
}
