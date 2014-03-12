#region User/License
// oio * 8/20/2012 * 8:07 AM

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
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Windows.Forms;

using Generator.Core.Entities;
using Generator.Core.Markup;
using SoftwareIndex.GenLib;
using TemplateTool.CmdLib;
using ToolSuite.Lib;

namespace TemplateTool.View
{
	[Export]
	public class GeneratorInfoView : UserControl
	{
		const string xml_test_file = @"c:/users/oio/desktop/test.xml";
		
		#region Registry
		
		const string reg_gen_cfg 	= "Generator Configuration File";
		const string reg_cmd_file	= "Command Set";
		
		public string LastGeneratorConfig {
			get { return Reg.GetKeyValueString(Program.regpath,reg_gen_cfg); }
			set { Reg.SetKeyValueString(Program.regpath,reg_gen_cfg,value); }
		}
		
		public string LastCommandset {
			get { return Reg.GetKeyValueString(Program.regpath,reg_cmd_file); }
			set { Reg.SetKeyValueString(Program.regpath,reg_cmd_file,value); }
		}
		#endregion
		
		#region Extensibility
		
		[ImportMany(typeof(IGenTool))]
		public IEnumerable<IGenTool> GeneratorTools { get; set; }

		[ImportMany(typeof(INamedTest))]
		public IEnumerable<INamedTest> testers { get; set; }
		
		public IEnumerable<ITaskCommandProvider> commandprovider { get; set; }

		List<T> EnumerateTest<T>(IEnumerable<T> provider)
		{
			List<T> list = new List<T>();
			if (provider==null)
			{
				Debug.Print("The loader had no content.");
				return null;
			}
			using (IEnumerator<T> enumerator = provider.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					list.Add(enumerator.Current);
				}
			}
			return list;
		}
		
		void EnumerateTasks(IEnumerable<ITaskCommandProvider> provider)
		{
			using (IEnumerator<ITaskCommandProvider> enumerator = provider.GetEnumerator())
			{
				List<Type> tasks = new List<Type>();
				while (enumerator.MoveNext())
				{
					tasks.Add(enumerator.Current.GetType());
				}
				commandUtility1.CommandTasks = tasks;
			}
		}
		
		#endregion
		
		GeneratorModel geninfo = new GeneratorModel();
		List<IGenTool> GeneratorToolList = null;
		
		List<string> TplGroups = null;
		List<TableTemplate> TblTemplates = null;
		
		[ImportingConstructor]
		public GeneratorInfoView([ImportMany]IEnumerable<ITaskCommandProvider> inputTasks )
		{
			InitializeComponent();
			commandprovider = inputTasks;
		}
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			
			EnumerateTasks(commandprovider);
			
			comboBox1.DataSource = GeneratorToolList = EnumerateTest<IGenTool>(GeneratorTools);
			comboBox1.DisplayMember = "Name";
			
			if (LastGeneratorConfig!=null && File.Exists(LastGeneratorConfig))
			{
				geninfo.LoadConfiguration(LastGeneratorConfig);
				LoadGeneratorConfiguration();
			}
		}
		
		#region Design
		
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadGeneratorConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.loadDatabaseConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadTemplateConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.comboDb = new System.Windows.Forms.ComboBox();
			this.comboTbl = new System.Windows.Forms.ComboBox();
			this.comboField = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.cbTplGrp = new System.Windows.Forms.ComboBox();
			this.cbTplAlias = new System.Windows.Forms.ComboBox();
			this.comboTplPart = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabCommands = new System.Windows.Forms.TabPage();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.commandUtility1 = new SoftwareIndex.Controls.CommandUtility();
			this.tabDb = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
			this.tableLayoutPanel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabCommands.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 48);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.menuStrip1.Size = new System.Drawing.Size(86, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.loadGeneratorConfigurationToolStripMenuItem,
									this.toolStripMenuItem1,
									this.loadDatabaseConfigurationToolStripMenuItem,
									this.loadTemplateConfigurationToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
			this.fileToolStripMenuItem.Text = "Data-Config";
			// 
			// loadGeneratorConfigurationToolStripMenuItem
			// 
			this.loadGeneratorConfigurationToolStripMenuItem.Name = "loadGeneratorConfigurationToolStripMenuItem";
			this.loadGeneratorConfigurationToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
			this.loadGeneratorConfigurationToolStripMenuItem.Text = "Load Generator Configuration";
			this.loadGeneratorConfigurationToolStripMenuItem.Click += new System.EventHandler(this.Event_LoadCfgGen);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(229, 6);
			// 
			// loadDatabaseConfigurationToolStripMenuItem
			// 
			this.loadDatabaseConfigurationToolStripMenuItem.Name = "loadDatabaseConfigurationToolStripMenuItem";
			this.loadDatabaseConfigurationToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
			this.loadDatabaseConfigurationToolStripMenuItem.Text = "Load Database Configuration";
			this.loadDatabaseConfigurationToolStripMenuItem.Click += new System.EventHandler(this.Event_LoadCfgDb);
			// 
			// loadTemplateConfigurationToolStripMenuItem
			// 
			this.loadTemplateConfigurationToolStripMenuItem.Name = "loadTemplateConfigurationToolStripMenuItem";
			this.loadTemplateConfigurationToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
			this.loadTemplateConfigurationToolStripMenuItem.Text = "Load Template Configuration";
			this.loadTemplateConfigurationToolStripMenuItem.Click += new System.EventHandler(this.Event_LoadCfgTpl);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Controls.Add(this.comboDb, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.comboTbl, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.comboField, 2, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(86, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(624, 24);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// comboDb
			// 
			this.comboDb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboDb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDb.FormattingEnabled = true;
			this.comboDb.Location = new System.Drawing.Point(0, 0);
			this.comboDb.Margin = new System.Windows.Forms.Padding(0);
			this.comboDb.Name = "comboDb";
			this.comboDb.Size = new System.Drawing.Size(208, 21);
			this.comboDb.TabIndex = 0;
			this.comboDb.SelectedIndexChanged += new System.EventHandler(this.Event_ComboDataSelectedIDChanged);
			// 
			// comboTbl
			// 
			this.comboTbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboTbl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboTbl.FormattingEnabled = true;
			this.comboTbl.Location = new System.Drawing.Point(208, 0);
			this.comboTbl.Margin = new System.Windows.Forms.Padding(0);
			this.comboTbl.Name = "comboTbl";
			this.comboTbl.Size = new System.Drawing.Size(208, 21);
			this.comboTbl.TabIndex = 0;
			this.comboTbl.SelectedIndexChanged += new System.EventHandler(this.Event_ComboBoxTableIDChanged);
			// 
			// comboField
			// 
			this.comboField.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboField.FormattingEnabled = true;
			this.comboField.Location = new System.Drawing.Point(416, 0);
			this.comboField.Margin = new System.Windows.Forms.Padding(0);
			this.comboField.Name = "comboField";
			this.comboField.Size = new System.Drawing.Size(208, 21);
			this.comboField.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.Controls.Add(this.cbTplGrp, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.cbTplAlias, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.comboTplPart, 2, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(86, 24);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(624, 24);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// cbTplGrp
			// 
			this.cbTplGrp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbTplGrp.FormattingEnabled = true;
			this.cbTplGrp.Location = new System.Drawing.Point(0, 0);
			this.cbTplGrp.Margin = new System.Windows.Forms.Padding(0);
			this.cbTplGrp.Name = "cbTplGrp";
			this.cbTplGrp.Size = new System.Drawing.Size(208, 21);
			this.cbTplGrp.TabIndex = 0;
			this.cbTplGrp.SelectedIndexChanged += new System.EventHandler(this.Event_TemplateGroupChanged);
			// 
			// cbTplAlias
			// 
			this.cbTplAlias.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbTplAlias.FormattingEnabled = true;
			this.cbTplAlias.Location = new System.Drawing.Point(208, 0);
			this.cbTplAlias.Margin = new System.Windows.Forms.Padding(0);
			this.cbTplAlias.Name = "cbTplAlias";
			this.cbTplAlias.Size = new System.Drawing.Size(208, 21);
			this.cbTplAlias.TabIndex = 0;
			// 
			// comboTplPart
			// 
			this.comboTplPart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboTplPart.FormattingEnabled = true;
			this.comboTplPart.Location = new System.Drawing.Point(416, 0);
			this.comboTplPart.Margin = new System.Windows.Forms.Padding(0);
			this.comboTplPart.Name = "comboTplPart";
			this.comboTplPart.Size = new System.Drawing.Size(208, 21);
			this.comboTplPart.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(0, 24);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Templates";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabCommands);
			this.tabControl1.Controls.Add(this.tabDb);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ItemSize = new System.Drawing.Size(120, 18);
			this.tabControl1.Location = new System.Drawing.Point(0, 48);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(710, 298);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 2;
			// 
			// tabCommands
			// 
			this.tabCommands.Controls.Add(this.button3);
			this.tabCommands.Controls.Add(this.button2);
			this.tabCommands.Controls.Add(this.button1);
			this.tabCommands.Controls.Add(this.comboBox1);
			this.tabCommands.Controls.Add(this.commandUtility1);
			this.tabCommands.Location = new System.Drawing.Point(4, 22);
			this.tabCommands.Name = "tabCommands";
			this.tabCommands.Padding = new System.Windows.Forms.Padding(3);
			this.tabCommands.Size = new System.Drawing.Size(702, 272);
			this.tabCommands.TabIndex = 0;
			this.tabCommands.Text = "Commands";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(264, 133);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "Run";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Event_TestCommand);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(102, 163);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Read XML";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Event_XMLLoad);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(21, 163);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Save XML";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Event_XMLSave);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(21, 135);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(237, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.Event_TemplateGroupChanged);
			// 
			// commandUtility1
			// 
			this.commandUtility1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.commandUtility1.Location = new System.Drawing.Point(6, 6);
			this.commandUtility1.Name = "commandUtility1";
			this.commandUtility1.Size = new System.Drawing.Size(690, 105);
			this.commandUtility1.TabIndex = 3;
			// 
			// tabDb
			// 
			this.tabDb.Location = new System.Drawing.Point(4, 22);
			this.tabDb.Name = "tabDb";
			this.tabDb.Padding = new System.Windows.Forms.Padding(3);
			this.tabDb.Size = new System.Drawing.Size(702, 272);
			this.tabDb.TabIndex = 1;
			this.tabDb.Text = "Data Configuration";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.textEditorControl1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(702, 272);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Template Part";
			// 
			// textEditorControl1
			// 
			this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textEditorControl1.IsReadOnly = false;
			this.textEditorControl1.Location = new System.Drawing.Point(3, 3);
			this.textEditorControl1.Name = "textEditorControl1";
			this.textEditorControl1.Size = new System.Drawing.Size(696, 266);
			this.textEditorControl1.TabIndex = 0;
			this.textEditorControl1.Text = "textEditorControl1";
			// 
			// GeneratorInfoView
			// 
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
			this.Name = "GeneratorInfoView";
			this.Size = new System.Drawing.Size(710, 346);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabCommands.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
		private System.Windows.Forms.ComboBox comboTplPart;
		private System.Windows.Forms.TabPage tabPage3;
		private SoftwareIndex.Controls.CommandUtility commandUtility1;
		private System.Windows.Forms.TabPage tabDb;
		private System.Windows.Forms.TabPage tabCommands;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ToolStripMenuItem loadTemplateConfigurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadDatabaseConfigurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem loadGeneratorConfigurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbTplAlias;
		private System.Windows.Forms.ComboBox cbTplGrp;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.ComboBox comboField;
		private System.Windows.Forms.ComboBox comboTbl;
		private System.Windows.Forms.ComboBox comboDb;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		
		#endregion
		
		// Check if we have geninfo and report an error if not.
		#region MessageBox Helpers
		
		bool HasInfo(string msg = "Nothing to do")
		{
			if (geninfo==null) { MessageBox.Show(msg); return false; }
			return true;
		}
		
		bool HasInfo(object checkMe, string msg = "Nothing to do")
		{
			if (checkMe==null) { MessageBox.Show(msg); return false; }
			return true;
		}

		#endregion
		
		#region Actions
		
		void LoadGeneratorConfiguration()
		{
			// #1 Ensure geninfo (GeneratorModel)
			if (!HasInfo(geninfo)) return;
			// #2 Deserialize configuration files.
			geninfo.PrepareContent();
			// #3 ensure we have a db-configuration
			if (!HasInfo(geninfo.datacollection)) return;
			
			LastGeneratorConfig = geninfo.configGen;
			comboTplPart.DataSource = new string[]{ "Row", "Field", "Preview" };
			comboTplPart.SelectedIndexChanged += Event_ComboTemplatePart;
			ResetBindingData(false);
		}
		
		void ResetBindingData(bool ignoreDb = true, bool ignoreTable = false)
		{
			if (!ignoreDb)
			{
				comboDb.DataSource = geninfo.datacollection.Databases;
				comboDb.DisplayMember = "Name";
			}
			if (!ignoreTable)
			{
				comboTbl.DataSource = (comboDb.SelectedValue as DatabaseElement).Items;
				comboTbl.DisplayMember = "Name";
			}
			comboField.DataSource = (comboTbl.SelectedValue as TableElement).Fields;
			comboField.DisplayMember = "DataName";
			List<string> list = geninfo.templatescollection.Templates
				.Select( x => x.Group ).ToList();
			cbTplGrp.DataSource = TplGroups = list
				.Distinct()
				.ToList();
			cbTplGrp.SelectedIndex = 0;
		}
		
		#endregion
		
		#region Event Handlers
		void Event_ComboTemplatePart(object sender, EventArgs e)
		{
			
		}
		void Event_LoadCfgGen(object sender, EventArgs e)
		{
			geninfo.LoadConfiguration();
			LoadGeneratorConfiguration();
		}
		
		void Event_LoadCfgDb(object sender, EventArgs e)
		{
			geninfo.LoadDataConfig();
		}
		
		void Event_LoadCfgTpl(object sender, EventArgs e)
		{
			geninfo.LoadTemplateConfig();
		}
		
		void Event_ComboDataSelectedIDChanged(object sender, EventArgs e)
		{
			ResetBindingData();
		}
		
		void Event_ComboBoxTableIDChanged(object sender, EventArgs e)
		{
			ResetBindingData(true,true);
		}

		void Event_XMLSave(object sender, EventArgs e)
		{
			string str = CommandHelper.SerializeCommandXml(commandUtility1.Commandtask);
			File.WriteAllText(xml_test_file,str);
			str = null;
		}
		
		void Event_XMLLoad(object sender, EventArgs e)
		{
			CommandHelper.CommandXmlTest(commandUtility1.Commandtask,File.ReadAllText(xml_test_file));
		}

		#endregion
		
		void Event_TestCommand(object sender, EventArgs e)
		{
			IGenTool tool = comboBox1.SelectedValue as IGenTool;
//			tool.
		}
		
		void Event_TemplateGroupChanged(object sender, EventArgs e)
		{
			string tplg = cbTplGrp.SelectedValue as string;
			cbTplAlias.DataSource = TblTemplates = geninfo.templatescollection.Templates.Where(
				t => t.Group == tplg
			).ToList();
//			geninfo.templatescollection.Templates[0].Name
			cbTplAlias.DisplayMember = "Name"; // "Alias"
		}
	}
}
