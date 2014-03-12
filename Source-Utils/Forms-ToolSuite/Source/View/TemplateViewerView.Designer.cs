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
namespace TemplateTool.View
{
	partial class TemplateViewerView
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
			this.comboSyntax = new System.Windows.Forms.ComboBox();
			this.comboField = new System.Windows.Forms.ComboBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.loadSQLiteDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unloadDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createSQLiteDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.updateCurrentValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comboGroup = new System.Windows.Forms.ComboBox();
			this.comboRow = new System.Windows.Forms.ComboBox();
			this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
			this.tableLayoutPanel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.comboSyntax, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.comboField, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.comboGroup, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.comboRow, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 20);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(613, 24);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// comboSyntax
			// 
			this.comboSyntax.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboSyntax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSyntax.FormattingEnabled = true;
			this.comboSyntax.Location = new System.Drawing.Point(476, 0);
			this.comboSyntax.Margin = new System.Windows.Forms.Padding(0);
			this.comboSyntax.Name = "comboSyntax";
			this.comboSyntax.Size = new System.Drawing.Size(137, 21);
			this.comboSyntax.TabIndex = 4;
			// 
			// comboField
			// 
			this.comboField.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboField.FormattingEnabled = true;
			this.comboField.Location = new System.Drawing.Point(341, 0);
			this.comboField.Margin = new System.Windows.Forms.Padding(0);
			this.comboField.Name = "comboField";
			this.comboField.Size = new System.Drawing.Size(135, 21);
			this.comboField.TabIndex = 2;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripMenuItem1,
									this.tasksToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.menuStrip1.Size = new System.Drawing.Size(71, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.loadSQLiteDatabaseToolStripMenuItem,
									this.unloadDatabaseToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStripMenuItem1.Size = new System.Drawing.Size(29, 24);
			this.toolStripMenuItem1.Text = "&File";
			// 
			// loadSQLiteDatabaseToolStripMenuItem
			// 
			this.loadSQLiteDatabaseToolStripMenuItem.Name = "loadSQLiteDatabaseToolStripMenuItem";
			this.loadSQLiteDatabaseToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.loadSQLiteDatabaseToolStripMenuItem.Text = "Load SQLite Database";
			this.loadSQLiteDatabaseToolStripMenuItem.Click += new System.EventHandler(this.LoadSQLiteDatabaseToolStripMenuItemClick);
			// 
			// unloadDatabaseToolStripMenuItem
			// 
			this.unloadDatabaseToolStripMenuItem.Name = "unloadDatabaseToolStripMenuItem";
			this.unloadDatabaseToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.unloadDatabaseToolStripMenuItem.Text = "Unload Database";
			this.unloadDatabaseToolStripMenuItem.Click += new System.EventHandler(this.UnloadDatabaseToolStripMenuItemClick);
			// 
			// tasksToolStripMenuItem
			// 
			this.tasksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.createSQLiteDatabaseToolStripMenuItem,
									this.toolStripMenuItem2,
									this.updateCurrentValueToolStripMenuItem});
			this.tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
			this.tasksToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.tasksToolStripMenuItem.Size = new System.Drawing.Size(40, 24);
			this.tasksToolStripMenuItem.Text = "Tasks";
			// 
			// createSQLiteDatabaseToolStripMenuItem
			// 
			this.createSQLiteDatabaseToolStripMenuItem.Name = "createSQLiteDatabaseToolStripMenuItem";
			this.createSQLiteDatabaseToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.createSQLiteDatabaseToolStripMenuItem.Text = "Create SQLite Database";
			this.createSQLiteDatabaseToolStripMenuItem.Click += new System.EventHandler(this.CreateSQLiteDatabaseToolStripMenuItemClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(224, 6);
			// 
			// updateCurrentValueToolStripMenuItem
			// 
			this.updateCurrentValueToolStripMenuItem.Name = "updateCurrentValueToolStripMenuItem";
			this.updateCurrentValueToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.updateCurrentValueToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.updateCurrentValueToolStripMenuItem.Text = "Update Current Value";
			this.updateCurrentValueToolStripMenuItem.Click += new System.EventHandler(this.Event_MenuSaveToRow);
			// 
			// comboGroup
			// 
			this.comboGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboGroup.FormattingEnabled = true;
			this.comboGroup.Location = new System.Drawing.Point(71, 0);
			this.comboGroup.Margin = new System.Windows.Forms.Padding(0);
			this.comboGroup.Name = "comboGroup";
			this.comboGroup.Size = new System.Drawing.Size(135, 21);
			this.comboGroup.TabIndex = 1;
			// 
			// comboRow
			// 
			this.comboRow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboRow.FormattingEnabled = true;
			this.comboRow.Location = new System.Drawing.Point(206, 0);
			this.comboRow.Margin = new System.Windows.Forms.Padding(0);
			this.comboRow.Name = "comboRow";
			this.comboRow.Size = new System.Drawing.Size(135, 21);
			this.comboRow.TabIndex = 3;
			// 
			// textEditorControl1
			// 
			this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textEditorControl1.IsReadOnly = false;
			this.textEditorControl1.Location = new System.Drawing.Point(0, 24);
			this.textEditorControl1.Name = "textEditorControl1";
			this.textEditorControl1.Size = new System.Drawing.Size(613, 362);
			this.textEditorControl1.TabIndex = 3;
			this.textEditorControl1.Text = "textEditorControl1";
			this.textEditorControl1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			// 
			// TemplateViewerView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textEditorControl1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.DoubleBuffered = true;
			this.Name = "TemplateViewerView";
			this.Size = new System.Drawing.Size(613, 386);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem updateCurrentValueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createSQLiteDatabaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tasksToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem unloadDatabaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadSQLiteDatabaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ComboBox comboSyntax;
		private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
		private System.Windows.Forms.ComboBox comboRow;
		private System.Windows.Forms.ComboBox comboField;
		private System.Windows.Forms.ComboBox comboGroup;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}
