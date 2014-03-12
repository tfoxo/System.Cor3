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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using ToolSuite.Lib;
using ToolSuite.Model;

namespace TemplateTool.View
{
	/// <summary>
	/// Description of TemplateViewerView.
	/// </summary>
	public partial class TemplateViewerView : UserControl
	{
		#region Registry
		
		const string regpath = @"Software\tfoxo\template-tool";
		const string reg_template_viewer_db 	= "Template Viewer Database";
		
		public string LastOpenDatabase {
			get { return Reg.GetKeyValueString(regpath,reg_template_viewer_db); }
			set { Reg.SetKeyValueString(regpath,reg_template_viewer_db,value); }
		}
		#endregion

		const string file_db_filter = "SQLite Database (*.db3)|*.db3|SQLite Database (*.sqlite)|*.sqlite|All files (*)|*";
		SaveFileDialog sfd = new SaveFileDialog();
		OpenFileDialog ofd = new OpenFileDialog();
		
		#region Model
		class Model
		{
			internal static TemplateUtil util;
			internal static List<string> groups;
			internal static List<TemplateElement> rows;
			
			internal static void Initialize(string path)
			{
				if (util!=null) Clear();
				util = new TemplateUtil(path);
				groups = util.GetGroups();
			}
			
			internal static void Clear()
			{
				if (util!=null) {
					util.Templates.Clear();
					if (groups!=null) groups.Clear();
					if (rows!=null) rows.Clear();
					util = null;
					GC.Collect(); // this probably happens automatically, but I'm not sure.
				}
			}
			
			internal static void GetRows(string tableName)
			{
				rows = util.Templates.Where(t=>t.Table==tableName).ToList();
			}
		}
		#endregion
		
		public TemplateViewerView()
		{
			InitializeComponent();
			InitializeUI();
			SetText(string.Empty);
			
		}

		#region Model/View Configuration
		
		void InitializeUI()
		{
			// TextEditor Highlighting-Manager
			foreach (DictionaryEntry o in HighlightingManager.Manager.HighlightingDefinitions)
				comboSyntax.Items.Add(string.Format("{0}",o.Key));
			this.comboSyntax.SelectedValueChanged += new System.EventHandler(ChangeSyntax);
			// set default text-highlighting
			comboSyntax.Text = "XML";
			
			// Field Combo (readonly string[] data)
			this.comboField.DataSource = TemplateUtil.template_table_fields;
			this.comboField.SelectedValueChanged += ComboFieldSelectionChangeCommitted;
			
			
			if (System.IO.File.Exists(LastOpenDatabase))
				InitializeView(LastOpenDatabase);
			
			
		}
		
		void InitializeView(string path)
		{
			Model.Initialize(path);
			this.comboGroup.DataSource = Model.groups;
			this.comboGroup.SelectedValueChanged += this.ComboGroupSelectionChangeCommitted;
			if (System.IO.File.Exists(path))
				LastOpenDatabase = path;
			this.ComboGroupSelectionChangeCommitted(null,EventArgs.Empty);
		}
		void UninitializeView()
		{
			this.comboGroup.SelectedValueChanged -= this.ComboGroupSelectionChangeCommitted;
			// just clear the model.
			Model.Clear();
			this.comboGroup.DataSource = null;
			this.comboRow.DataSource = null;
		}

		#endregion
		
		#region Model Actions
		
		/// <summary>
		/// Gets a value from the database provided the current
		/// selected row and field via combo-box selections.
		/// </summary>
		string SelectionValue
		{
			get {
				return
					(string)Model.util.Templates
					.Where(t=> t.Table==comboGroup.Text && t.Title == comboRow.Text)
					.FirstOrDefault()
					.GetKeyValue(comboField.Text)
					??
					string.Empty;
			}
		}
		
		bool HasValue()
		{
			return Model.util.Templates.Where(
				t =>
				t.Table==comboGroup.Text &&
				t.Title == comboRow.Text
			).Count() > 0;
		}

		#endregion
		
		#region UI Actions

		bool HasField { get { return !CheckFields() || comboField.SelectedIndex==-1; } }
		bool CheckFields()
		{
			if (!(comboField.Enabled = comboGroup.DataSource!=null)) comboField.SelectedIndex = -1;
			return comboField.Enabled;
		}
		
		void ComboFieldSelected()
		{
			if (HasField)
			{
				textEditorControl1.Text = string.Empty;
				return;
			}
			if (!HasValue()) SetText(string.Empty);
			else SetText(SelectionValue);
		}
		
		void ComboGroupSelected()
		{
			// Set the rows to our Model
			Model.GetRows(this.comboGroup.Text);
			
			this.comboGroup.SelectedValueChanged -= ComboGroupSelectionChangeCommitted;
			
			this.comboRow.DataSource = Model.rows;
			this.comboRow.DisplayMember = "Title";
			
			this.comboGroup.SelectedValueChanged += ComboGroupSelectionChangeCommitted;
		}
		
		#endregion
		
		#region Text Editor
		
		void SetText(string text)
		{
			textEditorControl1.Document.UndoStack.ClearAll();
			textEditorControl1.Text = text;
			textEditorControl1.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
			textEditorControl1.Font = DefaultTextEditorFont;
			textEditorControl1.ActiveTextAreaControl.Font = DefaultTextEditorFont;
		}
		readonly Font DefaultTextEditorFont = new Font("Ubuntu Mono",10,GraphicsUnit.Point);
		void ClearTextEditor()
		{
			SetText(string.Empty);
			
		}
		void RefreshTextEditor()
		{
			textEditorControl1.Document.UndoStack.ClearAll();
		}
		
		#endregion
		#region Text Editor Handler
		void ChangeSyntax(object sender, EventArgs e)
		{
			textEditorControl1.SetHighlighting(comboSyntax.Text);
		}
		#endregion
		
		#region Combo Event Handlers
		void ComboFieldSelectionChangeCommitted(object sender, EventArgs e)
		{
			ComboFieldSelected();
		}
		void ComboGroupSelectionChangeCommitted(object sender, EventArgs e)
		{
			ComboGroupSelected();
			CheckFields();
		}
		#endregion
		#region Menu Event Handlers
		void LoadSQLiteDatabaseToolStripMenuItemClick(object sender, EventArgs e)
		{
			ofd.Filter = file_db_filter;
			if (ofd.ShowDialog() != DialogResult.OK) return;
			UninitializeView();
			InitializeView(ofd.FileName);
		}
		void UnloadDatabaseToolStripMenuItemClick(object sender, EventArgs e)
		{
			UninitializeView();
			GC.Collect();
			SetText(string.Empty);
		}
		void CreateSQLiteDatabaseToolStripMenuItemClick(object sender, EventArgs e)
		{
			sfd.Filter = file_db_filter;
			if (sfd.ShowDialog() != DialogResult.OK)
				return;
			TemplateUtil.CreateTemplatesTable(sfd.FileName);
		}
		#endregion
		
		string StrField { get { return comboField.SelectedValue as string; } }
		string StrGroup	{ get { return comboGroup.SelectedValue as string; } }
		TemplateElement StrRow { get { return comboRow.SelectedValue as TemplateElement; } }
		
		#region Row Menu
		
		void Event_MenuSaveToRow(object sender, EventArgs e)
		{
			if (Model.util.Templates==null)
			{
				Debug.Print("Nothing to do; Nothing is loaded");
				return;
			}
			Debug.Print("Row, id: ‘{0}’, name: {1}", StrRow.Id.Value, StrRow.Title);
			StrRow.SetValue(StrField,textEditorControl1.Text);
			TemplateUtil.UpdateTemplateRow(LastOpenDatabase,"templates",StrRow,StrField,textEditorControl1.Text);
		}
		
		#endregion
	}
}
