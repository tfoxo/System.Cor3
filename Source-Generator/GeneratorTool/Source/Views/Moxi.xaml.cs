/* oio : 1/21/2014 9:33 AM */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using Generator.Core.Entities;
using Generator.Core.Entities.Types;
using Generator.Core.Markup;
using Generator.Core.Operations;

namespace GeneratorTool.Views
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class MoxiView : UserControl, INotifyPropertyChanged
	{
		#region Commands
		static public readonly ICommand MyCommandCommand = new RoutedUICommand(){ Text="MyCommandCommand Command." };
		
		static public readonly ICommand TemplateViewCommand = new RoutedUICommand(){ Text="TemplateView Command.", InputGestures={ new KeyGesture(Key.F6) } };
		static public readonly ICommand DatabaseViewCommand = new RoutedUICommand(){ Text="DatabaseView Command.", InputGestures={ new KeyGesture(Key.F7) } };
		// for $(DbType), $(ConnectionT) $(AdapterT)
		static public readonly ICommand TemplateSaveCommand = new RoutedUICommand(){ Text="Template Save Command.", InputGestures={ new KeyGesture(Key.S, ModifierKeys.Control) } };
		static public readonly ICommand TemplateLoadCommand = new RoutedUICommand(){ Text="Template Load Command.", InputGestures={ new KeyGesture(Key.O, ModifierKeys.Shift|ModifierKeys.Control) } };
		
		// via treeview
		static public readonly ICommand StatePushCommand = new RoutedUICommand(){ Text="TreeItem Changed Command." };
		// via combobox
		static public readonly ICommand TableTypeCommand = new RoutedUICommand(){ Text="Table Type Command." };
		static public readonly ICommand ToggleTemplateGroupCommand = new RoutedUICommand(){ Text="Template Group Command." };
		static public readonly ICommand ToggleTemplateRowCommand = new RoutedUICommand(){ Text="Template Row Command." };
		
		static public readonly ICommand ToggleTableCommand = new RoutedUICommand(){ Text="Template button toggled.", InputGestures={ new KeyGesture(Key.F3) } };
		static public readonly ICommand ToggleFieldCommand = new RoutedUICommand(){ Text="Field button toggled.", InputGestures={ new KeyGesture(Key.F4) } };
		static public readonly ICommand TogglePreviewCommand = new RoutedUICommand(){ Text="Preview button toggled.", InputGestures={ new KeyGesture(Key.F5) } };
		#endregion
		
		public TemplateManager TemplateContext { get;set; }
		
		#region ViewMode
		
		public enum ViewMode {
			Undefined = 0,
			Database,
			Table,
			Field,
			TemplateTable,
			TemplateField,
			TemplatePreview
		} ViewMode LastViewMode = ViewMode.TemplateTable;
		#endregion
		
		/// <summary>
		/// It appears that ViewText
		/// </summary>
		string ViewText = null;
		
		int i=0;

		#region Little Helpers
		
		public TemplateManager LastFactory { get;set; }
		public object LastTemplate { get;set; }
		public object LastSelectedObject { get;set; }
		public object LastSelectedView { get;set; }
		
		void SetCombos(TableElement table) { cbDatabase.SelectedItem = table.Parent; cbTable.SelectedItem = table; cbField.SelectedItem = null; }
		void SetCombos(FieldElement field) { cbDatabase.SelectedItem = field.Parent.Parent; cbTable.SelectedItem = field.Parent; cbField.SelectedItem = field; }
		void SetCombos(DatabaseElement db) { cbDatabase.SelectedItem = db; cbTable.SelectedItem = null; cbField.SelectedItem = null; }
		/// <summary>
		/// Nothing to do here really.
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		TemplateManager CreateTemplate(DatabaseElement field)
		{
			return new TemplateManager(){
				SelectedDatabase = field
			};
		}
		TemplateManager CreateTemplate(TableElement field)
		{
			return new TemplateManager(){
				SelectedCollection = Reader.Model.Databases,
				SelectedDatabase = field.Parent,
				SelectedTable = field,
				SelectedField = null,
				SelectedTemplate = (TableTemplate)cbTemplateGroups.SelectedItem
			};
		}
		TemplateManager CreateTemplate(FieldElement field)
		{
			return new TemplateManager(){
				SelectedCollection = Reader.Model.Databases,
				SelectedDatabase = field.Parent.Parent,
				SelectedTable = field.Parent,
				SelectedField = field,
				SelectedTemplate = (TableTemplate)cbTemplateGroups.SelectedItem,
			};
		}

		#endregion
		
		void PushState(DatabaseElement database)
		{
			LastViewMode = ViewMode.Database;
			LastSelectedObject = database;
			LastFactory = CreateTemplate(database);
			SetCombos(database);
		}
		void PushState(TableElement table)
		{
			LastViewMode = ViewMode.Table;
			LastSelectedObject = table;
			LastFactory = CreateTemplate(table);
			SetCombos(table);
		}
		void PushState(FieldElement field)
		{
			LastViewMode = ViewMode.Field;
			LastSelectedObject = field;
			LastFactory = CreateTemplate(field);
			SetCombos(field);
		}
		void PushState(TableTemplate template)
		{
			LastViewMode = ViewMode.TemplatePreview;
			LastTemplate = template;
			cbTemplateGroups.Text = (template).Group;
			cbTemplateRow.SelectedValue = template;
		}
		
		/// <summary>
		/// Through this method, the LastTemplate is set.
		/// </summary>
		void StatePush()
		{
			var treeSelection = tvModel.SelectedValue;
			if (treeSelection is DatabaseElement) PushState(treeSelection as DatabaseElement);
			else if (treeSelection is TableElement) PushState(treeSelection as TableElement);
			else if (treeSelection is FieldElement) PushState(treeSelection as FieldElement);
			else if (treeSelection is TableTemplate) PushState(treeSelection as TableTemplate);
			else if (treeSelection is string) MessageBox.Show("Look a string.");
			dataEditor.DataContext = LastFactory;
		}
		void StatePushAction(object sender, RoutedEventArgs e)
		{
			StatePush();
		}
		
		public GeneratorReader Reader { get; set; }
		
		ObservableCollection<TableTemplate> TemplateGroups { get;set; }
		
		public MoxiView()
		{
			InitializeComponent();
			InitializeReader();
			LastSelectedView = pane;
		}
		
		/// <summary>
		/// The active-template was changed.
		/// We might want to call StatePush.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ToggleTemplateRowAction(object sender, RoutedEventArgs e)
		{
			// check if a group has been selected.
			if (string.IsNullOrEmpty(cbTemplateRow.Text)) {
				editor.Text = string.Empty; return;
			}
			// check LastTemplate
			// check if a row has been selected.
			if (cbTemplateRow.SelectedValue == null) {
				editor.Text = string.Empty; return;
			}
			// 
			switch (LastViewMode) {
				case ViewMode.Undefined:
					case ViewMode.TemplateTable:   if (cbTemplateRow.SelectedValue!=null) editor.Text = (cbTemplateRow.SelectedValue as TableTemplate).ElementTemplate; break;
					case ViewMode.TemplateField:   if (cbTemplateRow.SelectedValue!=null) editor.Text = (cbTemplateRow.SelectedValue as TableTemplate).ItemsTemplate; break;
					case ViewMode.TemplatePreview: if (cbTemplateRow.SelectedValue!=null) editor.Text = Reader.Generate(cbTable.SelectedValue as TableElement, cbTemplateRow.SelectedValue as TableTemplate); break;
					default: break;
			}
		}
		
		void ToggleTemplateGroupAction(object sender, RoutedEventArgs e)
		{
			if (cbTemplateGroups.SelectedValue == null) return;
			string groupname = (cbTemplateGroups.SelectedValue as TableTemplate) . Group;
			System.Diagnostics.Debug.WriteLine("Text: {0}",groupname);
			cbTemplateRow.ItemsSource = Reader.Model.Templates.Templates.Where( p => p.Group == groupname);
			editor.Text = null;
		}
		
		#region Show in editor
		
		void ToggleEditorTemplateAction(object sender, RoutedEventArgs e) { LastTemplate=cbTemplateRow.SelectedValue; LastViewMode = ViewMode.TemplateTable; try { ViewText = editor.Text = (cbTemplateRow.SelectedValue as TableTemplate).ElementTemplate; } catch(Exception err) { if (cbTemplateRow.SelectedValue != null) { throw err; } } }
		void ToggleEditorFieldAction(object sender, RoutedEventArgs e) { LastTemplate=cbTemplateRow.SelectedValue; LastViewMode = ViewMode.TemplateField; try { ViewText = editor.Text = (cbTemplateRow.SelectedValue as TableTemplate).ItemsTemplate; }  catch(Exception err) { if (cbTemplateRow.SelectedValue != null) { throw err; } } }
		void ToggleEditorPreviewAction(object sender, RoutedEventArgs e) { LastTemplate=cbTemplateRow.SelectedValue; LastViewMode = ViewMode.TemplatePreview; try { ViewText = Reader.Generate(cbTable.SelectedValue as TableElement,cbTemplateRow.SelectedValue as TableTemplate); } catch {} }
		
		#endregion
		
		// ComboBox Trigger
		void TableTypeAction(object sender, RoutedEventArgs e)
		{
			try {
				string val = string.Format("{0}",dataEditor.viewTable.comboTableType.SelectedValue);
				Debug.WriteLine(val);
				dataEditor.viewField.comboDataType.ItemsSource = null;
//				dataEditor.viewTable.comboTableType
				switch (val) {
					case "SQLite":
						dataEditor.viewField.comboDataType.ItemsSource = Enum.GetValues(typeof(System.Data.SQLite.TypeAffinity));
						break;
					case "SqlServer":
						dataEditor.viewField.comboDataType.ItemsSource = Enum.GetValues(typeof(System.Data.SqlDbType));
						break;
					case "OleDb":
					case "OleAccess":
						dataEditor.viewField.comboDataType.ItemsSource = Enum.GetValues(typeof(System.Data.OleDb.OleDbType));
						break;
				}
			} finally {
			}
		}
		
		void InitializeReader()
		{
			Reader = new GeneratorReader { LoadCompleteAction=InitializeDataSource, };
			Reader.BindUIElement(this);
			Reader.TemplateGeneratedAction = a => editor.Text = a;
			
			CommandBindings.Add(new CommandBinding(DatabaseViewCommand,(e,r) => { dataEditor.Visibility = Visibility.Visible; pane.Visibility = Visibility.Collapsed; }));
			CommandBindings.Add(new CommandBinding(TemplateViewCommand,(e,r) => { dataEditor.Visibility = Visibility.Collapsed; pane.Visibility = Visibility.Visible; }));
			
			editor.CommandBindings.Add(
				new CommandBinding(
					TemplateSaveCommand,(e,r) => {
						if (LastTemplate==null) {
							editor.Text += "\n";
							editor.Text += "No template to save.";
							editor.Text += "\n";
							return;
						}
						switch (LastViewMode) {
							case ViewMode.Undefined:
								editor.Text += "ViewMode.Undefined.";
								editor.Text += "\n";
								editor.Text = string.Format("Error[{0}]:", (int)LastViewMode);
								editor.Text += "\n";
								break;
							case ViewMode.TemplateField:
								(LastTemplate as TableTemplate).ItemsTemplate = editor.Text;
								editor.Text += "TABLE FIELD";
								editor.Text += "\n";
								editor.Text += "The tempalte was saved.";
								editor.Text += "\n";
								break;
							case ViewMode.TemplateTable:
								(LastTemplate as TableTemplate).ElementTemplate = editor.Text;
								editor.Text += "TABLE ROW";
								editor.Text += "\n";
								editor.Text += "The tempalte was saved.";
								editor.Text += "\n";
								break;
							case ViewMode.TemplatePreview:
								editor.Text += "PREVIEW";
								editor.Text += "\n";
								break;
						}
						editor.Text += "Compare SelectedTemplate to Model.";
						editor.Text += "\n";
					}));
			editor.CommandBindings.Add(
				new CommandBinding(
					TemplateLoadCommand,(e,r) => {
						if (LastTemplate==null) return;
						if (LastTemplate==null) {
							editor.Text = "No template to save.";
							return;
						}
						editor.Text = "Testing the Load Template Command.";
						editor.Text += "\n";
						editor.Text += "Compare SelectedTemplate to Model.";
					}));
			
			CommandBindings.Add(new CommandBinding(StatePushCommand,StatePushAction));
			// cbTemplateRow
			CommandBindings.Add(new CommandBinding(ToggleTemplateRowCommand,ToggleTemplateRowAction));
			// cbTemplateGroups
			CommandBindings.Add(new CommandBinding(ToggleTemplateGroupCommand,ToggleTemplateGroupAction));
			// comboTableType
			CommandBindings.Add(new CommandBinding(TableTypeCommand,TableTypeAction));
			//
			CommandBindings.Add(new CommandBinding(ToggleTableCommand,ToggleEditorTemplateAction));
			CommandBindings.Add(new CommandBinding(ToggleFieldCommand,ToggleEditorFieldAction));
			CommandBindings.Add(new CommandBinding(TogglePreviewCommand,ToggleEditorPreviewAction));
		}
		
		void InitializeDataSource()
		{
			cbDatabase.ItemsSource = null;
			cbDatabase.ItemsSource = Reader.Model.Databases.Databases;
			cbDatabase.DisplayMemberPath = "Name";
			cbTemplateRow.ItemsSource = null;
			
			TemplateGroups = new ObservableCollection<TableTemplate>();
			
			foreach (var tpl in Reader.Model.Templates.Templates) {
				if ((TemplateGroups.Where(p => p.Group == tpl.Group)).Any()) continue;
				TemplateGroups.Add(tpl);
			}
			cbTemplateGroups.ItemsSource = TemplateGroups.OrderBy(m=>m.Group);
			
			DataContext = Reader.Model;
			tnTemplates.ItemsSource = Reader.Model.Templates.GetGrouping();
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

#if no
void TreeItemChangedAction(object sender, RoutedEventArgs e)
{
	if (tvModel.SelectedValue is DatabaseElement)
	{
		cbDatabase.SelectedValue = tvModel.SelectedValue;
		// ---------------------------------------------------
		System.Diagnostics.Debug.WriteLine("Database");
	}
	else if (tvModel.SelectedValue is TableElement)
	{
		var field = tvModel.SelectedValue as TableElement;
		cbDatabase.SelectedItem = (tvModel.SelectedValue as TableElement).Parent;
		cbTable.SelectedItem = tvModel.SelectedValue;
		// ---------------------------------------------------
		dataEditor.viewField.DataContext = null;
		dataEditor.viewTable.DataContext =
			new TemplateManager(){
			SelectedCollection = Reader.Model.Databases,
			SelectedDatabase = field.Parent,
			SelectedTable = field,
			SelectedField = null,
			SelectedTemplate = (TableTemplate)cbTemplateGroups.SelectedItem
//						SelectedTemplate = template,
//						SelectedTemplateGroup = template.Group
		};
		System.Diagnostics.Debug.WriteLine("Table");
		
	}
	else if (tvModel.SelectedValue is FieldElement)
	{
		var field = (FieldElement)tvModel.SelectedValue;
		cbDatabase.SelectedItem = field.Parent.Parent;
		cbTable.SelectedItem = field.Parent;
		cbField.SelectedItem = tvModel.SelectedValue;
		// ---------------------------------------------------
//				dataEditor.viewTable.DataContext = field.Parent;
		dataEditor.viewField.DataContext =
			dataEditor.viewTable.DataContext =
			new TemplateManager(){
			SelectedCollection = Reader.Model.Databases,
			SelectedDatabase = field.Parent.Parent,
			SelectedTable = field.Parent,
			SelectedField = field,
			SelectedTemplate = (TableTemplate)cbTemplateGroups.SelectedItem,
//						SelectedTemplate = template,
//						SelectedTemplateGroup = template.Group
		};
		System.Diagnostics.Debug.WriteLine("Field");
	}
}

#endif