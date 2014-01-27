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
	public partial class MoxiView : UserControl, INotifyPropertyChanged, IContent
	{
		
		public void OnFragmentNavigation(FragmentNavigationEventArgs e){
			
		}
		public void OnNavigatedFrom(NavigationEventArgs e){
			
		}
		public void OnNavigatedTo(NavigationEventArgs e){
			
		}
		public void OnNavigatingFrom(NavigatingCancelEventArgs e){
			
		}
//		new KeyGesture (Key.F3,ModifierKeys.None)
		static public readonly ICommand StatePushCommand = new RoutedUICommand(){ Text="TreeItem Changed Command." };
		static public readonly ICommand MyCommandCommand = new RoutedUICommand(){ Text="MyCommandCommand Command." };
		/// <summary>
		/// Acts on a table modification.
		/// </summary>
		static public readonly ICommand TableTypeCommand = new RoutedUICommand(){ Text="Table Type Command.", InputGestures={ new KeyGesture(Key.F3) } };
		static public readonly ICommand ToggleTableCommand = new RoutedUICommand(){ Text="Template button toggled.", InputGestures={ new KeyGesture(Key.F3) } };
		static public readonly ICommand ToggleTemplateGroupCommand = new RoutedUICommand(){ Text="Template Group Command." };
		static public readonly ICommand ToggleTemplateRowCommand = new RoutedUICommand(){ Text="Template Row Command." };
		static public readonly ICommand ToggleFieldCommand = new RoutedUICommand(){ Text="Field button toggled.", InputGestures={ new KeyGesture(Key.F4) } };
		static public readonly ICommand TogglePreviewCommand = new RoutedUICommand(){ Text="Preview button toggled.", InputGestures={ new KeyGesture(Key.F5) } };
		
		public TemplateManager TemplateContext { get;set; }

		#region Little Helpers
		
		public object LastFactory { get;set; }
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
		void StatePush()
		{
			LastSelectedObject = tvModel.SelectedValue;
			if (LastSelectedObject is DatabaseElement)
			{
				LastFactory = CreateTemplate(LastSelectedObject as DatabaseElement);
				SetCombos(LastSelectedObject as DatabaseElement);
			}
			else if (LastSelectedObject is TableElement)
			{
				LastFactory = CreateTemplate(LastSelectedObject as TableElement);
				SetCombos(LastSelectedObject as TableElement);
			}
			else if (LastSelectedObject is FieldElement)
			{
				LastFactory = CreateTemplate(LastSelectedObject as FieldElement);
				SetCombos(LastSelectedObject as FieldElement);
			}
		}
		
		void StatePushAction(object sender, RoutedEventArgs e)
		{
			StatePush();
			dataEditor.DataContext = LastFactory;
		}
		
		public GeneratorReader Reader { get; set; }
		
		ObservableCollection<TableTemplate> TemplateGroups { get;set; }
		
		public MoxiView()
		{
			InitializeComponent();
			InitializeReader();
//			System.Diagnostics.Debug.WriteLine("Parent (MUI) : {0}",parent);
		}
		
		string ViewMode = "tpl_field";
		string ViewText = null;
		
		int i=0;
		void ToggleTemplateRowAction(object sender, RoutedEventArgs e)
		{
			editor.Text = string.Format("row test {0}",i++);
			
			if (string.IsNullOrEmpty(cbTemplateRow.Text)) return;
			if (cbTemplateRow.SelectedValue == null) return;
			
			switch (ViewMode)
			{
				case "tpl_row":
					try {
						editor.Text = (cbTemplateRow.SelectedValue as TableTemplate).ElementTemplate;
					} finally {
					}
					break;
				case "tpl_field":
					try {
						editor.Text = (cbTemplateRow.SelectedValue as TableTemplate).ItemsTemplate;
					} finally {
					}
					break;
				case "tpl_go":
					try {
						editor.Text = Reader.Generate(cbTable.SelectedValue as TableElement, cbTemplateRow.SelectedValue as TableTemplate);
					} finally {
					}
					break;
				default:
					break;
			}
		}
		
		void ToggleTemplateGroupAction(object sender, RoutedEventArgs e)
		{
			string groupname = (cbTemplateGroups.SelectedValue as TableTemplate) . Group;
			System.Diagnostics.Debug.WriteLine("Text: {0}",groupname);
			cbTemplateRow.ItemsSource = Reader.Model.Templates.Templates.Where( p => p.Group == groupname);
			editor.Text = null;
		}
		
		void ToggleTemplateAction(object sender, RoutedEventArgs e) { ViewMode = "tpl_row"; try { ViewText = editor.Text = (cbTemplateRow.SelectedValue as TableTemplate).ElementTemplate; } catch(Exception err) { if (cbTemplateRow.SelectedValue != null) { throw err; } } }
		
		void ToggleFieldAction(object sender, RoutedEventArgs e) { ViewMode = "tpl_field"; try { ViewText = editor.Text = (cbTemplateRow.SelectedValue as TableTemplate).ItemsTemplate; }  catch(Exception err) { if (cbTemplateRow.SelectedValue != null) { throw err; } } }
		
		void TogglePreviewAction(object sender, RoutedEventArgs e) { ViewMode = "tpl_go"; try { ViewText = Reader.Generate(cbTable.SelectedValue as TableElement,cbTemplateRow.SelectedValue as TableTemplate); } catch {} }
		
		void TableTypeAction(object sender, RoutedEventArgs e)
		{
			try {
				string val = string.Format("{0}",dataEditor.viewTable.comboTableType.SelectedValue);
				Debug.WriteLine(val);
				dataEditor.viewField.comboDataType.ItemsSource = null;
//				dataEditor.viewTable.comboTableType
				if (val == "SQLite")
				{
					dataEditor.viewField.comboDataType.ItemsSource = Enum.GetValues(typeof(System.Data.SQLite.TypeAffinity));
				}
				else if (val == "SqlServer")
				{
					dataEditor.viewField.comboDataType.ItemsSource = Enum.GetValues(typeof(System.Data.SqlDbType));
				}
				else if (val == "OleDb" || val=="OleAccess")
				{
					dataEditor.viewField.comboDataType.ItemsSource = Enum.GetValues(typeof(System.Data.OleDb.OleDbType));
				}
			} finally {
				
				
			}
		}
		
		void InitializeReader()
		{
			Reader = new GeneratorReader { LoadCompleteAction=InitializeDataSource, };
			Reader.BindUIElement(this);
			Reader.TemplateGeneratedAction = a => editor.Text = a;
			
			CommandBindings.Add(new CommandBinding(StatePushCommand,StatePushAction));
			
			CommandBindings.Add(new CommandBinding(ToggleTemplateRowCommand,ToggleTemplateRowAction));
			CommandBindings.Add(new CommandBinding(ToggleTemplateGroupCommand,ToggleTemplateGroupAction));
			
			CommandBindings.Add(new CommandBinding(TableTypeCommand,TableTypeAction));
			
			CommandBindings.Add(new CommandBinding(ToggleTableCommand,ToggleTemplateAction));
			CommandBindings.Add(new CommandBinding(ToggleFieldCommand,ToggleFieldAction));
			CommandBindings.Add(new CommandBinding(TogglePreviewCommand,TogglePreviewAction));
//			cbTemplateRow.Triggers.Add(new EventToCommand ());
		}
		
		void InitializeDataSource()
		{
			DataContext = Reader.Model;
			cbDatabase.ItemsSource = null;
			cbDatabase.ItemsSource = Reader.Model.Databases.Databases;
			cbDatabase.DisplayMemberPath = "Name";
			cbTemplateRow.ItemsSource = null;
			
			TemplateGroups = new ObservableCollection<TableTemplate>();
			
			foreach (var tpl in Reader.Model.Templates.Templates) {
				if ((TemplateGroups.Where(p => p.Group == tpl.Group)).Any()) continue;
				TemplateGroups.Add(tpl);
			}
			
			tnDatabases.ItemsSource = Reader.Model.Databases.Databases;
			
			cbTemplateGroups.ItemsSource = TemplateGroups.OrderBy(m=>m.Group);
			cbTemplateGroups.DisplayMemberPath = "Group";
//			cbTemplateRow.ItemsSource = Reader.Model.Templates.Templates;
//			var tt = new TableTemplate();
//			var tt = new FieldTemplate();
//			cbTemplateRow.DisplayMemberPath = "Name";
			cbTemplateRow.DisplayMemberPath = "Alias";
//			var tt = new TableTemplate();
//			tt.FieldTemplate.ElementTemplate;
//			tt.FieldTemplate.ItemsTemplate;
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