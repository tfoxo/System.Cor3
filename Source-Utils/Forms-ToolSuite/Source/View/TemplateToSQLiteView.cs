#region User/License
// oio * 8/20/2012 * 8:45 AM

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
using System.Diagnostics;
using System.Windows.Forms;

using TemplateTool.CmdLib;
using ToolSuite.Lib;
using VisualEditor.SQLite;

namespace TemplateTool.View
{
	
	public class TemplateToSQLiteView : UserControl
	{
		ITaskCommandProvider commandtask = null;
		BindingSource bs = null;
		
		SqliteTemplateWorker worker;
		
		OpenFileDialog ofd = new OpenFileDialog();
		SaveFileDialog sfd = new SaveFileDialog();
		
		List<Type> CommandTasks = new List<Type>(){
			typeof(CommandCheckForTwoInputs),
			typeof(CommandCheckForThreeInputs)
		};
		
		public TemplateToSQLiteView()
		{
			this.InitializeComponent();
			
			this.worker = new SqliteTemplateWorker();
			this.commandUtility1.CommandTasks = this.CommandTasks;
		}
		
		#if NO
		/// <summary>
		/// Drops tables and re-creates them in sqlite database.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ReCreate(object sender, EventArgs e)
		{
			Generator2SQLiteOperations
				.GeneratorDataCollectionDestroy(true);
		}
		#endif

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
		
		void InitializeComponent()
		{
			this.commandUtility1 = new SoftwareIndex.Controls.CommandUtility();
			this.SuspendLayout();
			// 
			// commandUtility1
			// 
			this.commandUtility1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.commandUtility1.Location = new System.Drawing.Point(11, 6);
			this.commandUtility1.Name = "commandUtility1";
			this.commandUtility1.Size = new System.Drawing.Size(476, 105);
			this.commandUtility1.TabIndex = 2;
			// 
			// TemplateToSQLiteView
			// 
			this.Controls.Add(this.commandUtility1);
			this.Name = "TemplateToSQLiteView";
			this.Size = new System.Drawing.Size(498, 157);
			this.ResumeLayout(false);
		}
		private SoftwareIndex.Controls.CommandUtility commandUtility1;
		#endregion
	}
}
