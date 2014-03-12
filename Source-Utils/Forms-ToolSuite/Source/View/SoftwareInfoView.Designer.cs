#region User/License
// oio * 8/27/2012 * 9:06 AM

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
namespace SoftwareIndex.View
{
	partial class SoftwareInfoView
	{
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createSoftwareDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadSoftwareDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.unloadSoftwareDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveCurrentEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveCurrentRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.copyRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.duplicateRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(555, 27);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.saveCurrentEntryToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(84, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.createSoftwareDBToolStripMenuItem,
									this.loadSoftwareDBToolStripMenuItem,
									this.toolStripMenuItem1,
									this.unloadSoftwareDBToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// createSoftwareDBToolStripMenuItem
			// 
			this.createSoftwareDBToolStripMenuItem.Name = "createSoftwareDBToolStripMenuItem";
			this.createSoftwareDBToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
									| System.Windows.Forms.Keys.N)));
			this.createSoftwareDBToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.createSoftwareDBToolStripMenuItem.Text = "New Software DB";
			// 
			// loadSoftwareDBToolStripMenuItem
			// 
			this.loadSoftwareDBToolStripMenuItem.Name = "loadSoftwareDBToolStripMenuItem";
			this.loadSoftwareDBToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.loadSoftwareDBToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.loadSoftwareDBToolStripMenuItem.Text = "Load Software DB";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(249, 6);
			// 
			// unloadSoftwareDBToolStripMenuItem
			// 
			this.unloadSoftwareDBToolStripMenuItem.Name = "unloadSoftwareDBToolStripMenuItem";
			this.unloadSoftwareDBToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
									| System.Windows.Forms.Keys.X)));
			this.unloadSoftwareDBToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.unloadSoftwareDBToolStripMenuItem.Text = "Unload Software DB";
			// 
			// saveCurrentEntryToolStripMenuItem
			// 
			this.saveCurrentEntryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.saveCurrentRowToolStripMenuItem,
									this.toolStripMenuItem2,
									this.copyRowToolStripMenuItem,
									this.pasteRowToolStripMenuItem,
									this.duplicateRowToolStripMenuItem});
			this.saveCurrentEntryToolStripMenuItem.Name = "saveCurrentEntryToolStripMenuItem";
			this.saveCurrentEntryToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.saveCurrentEntryToolStripMenuItem.Text = "Edit";
			// 
			// saveCurrentRowToolStripMenuItem
			// 
			this.saveCurrentRowToolStripMenuItem.Name = "saveCurrentRowToolStripMenuItem";
			this.saveCurrentRowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveCurrentRowToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.saveCurrentRowToolStripMenuItem.Text = "Save Current Row";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(204, 6);
			// 
			// copyRowToolStripMenuItem
			// 
			this.copyRowToolStripMenuItem.Name = "copyRowToolStripMenuItem";
			this.copyRowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
									| System.Windows.Forms.Keys.C)));
			this.copyRowToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.copyRowToolStripMenuItem.Text = "Copy Row";
			// 
			// pasteRowToolStripMenuItem
			// 
			this.pasteRowToolStripMenuItem.Name = "pasteRowToolStripMenuItem";
			this.pasteRowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
									| System.Windows.Forms.Keys.V)));
			this.pasteRowToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.pasteRowToolStripMenuItem.Text = "Paste Row";
			// 
			// duplicateRowToolStripMenuItem
			// 
			this.duplicateRowToolStripMenuItem.Name = "duplicateRowToolStripMenuItem";
			this.duplicateRowToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.duplicateRowToolStripMenuItem.Text = "Duplicate Row";
			// 
			// comboBox1
			// 
			this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(87, 3);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(229, 21);
			this.comboBox1.TabIndex = 1;
			// 
			// SoftwareInfoView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "SoftwareInfoView";
			this.Size = new System.Drawing.Size(555, 378);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ToolStripMenuItem duplicateRowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteRowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyRowToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem saveCurrentRowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveCurrentEntryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createSoftwareDBToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem unloadSoftwareDBToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem loadSoftwareDBToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}
