/* oio * 3/13/2014 * Time: 6:04 PM
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace GeneratorTool.Views
{
	/// <summary>
	/// Interaction logic for WriterTemplateControl.xaml
	/// </summary>
	public partial class WriterTemplateControl : UserControl
	{
		static readonly OpenFileDialog Ofd = new OpenFileDialog(){ Filter="SQLite Database (sqlite,db3)|*.sqlite;*.db3;*.db" }; 
		static readonly SaveFileDialog Sfd = new SaveFileDialog(){ Filter="SQLite Database (sqlite,db3)|*.sqlite;*.db3;*.db" }; 
		
		WriterTplModel Model {
			get { return model; }
			set { model = value; }
		} WriterTplModel model = new WriterTplModel();
		
		void LoadDatabase(object send, RoutedEventArgs args)
		{
			var val = Ofd.ShowDialog();
			if (!(val.HasValue && val.Value)) return;
			Model.Initialize(Ofd.FileName);
			cbTplGroup.ItemsSource = model.GroupNames;
			
		}
		
		public WriterTemplateControl()
		{
			InitializeComponent();
		}
		void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			(sender as Button).ContextMenu.IsOpen = true;
		}
		void CbTplGroup_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			model.SelectedGroup = cbTplGroup.SelectedItem as string;
			cbTplName.ItemsSource = model.Rows;
		}
	}
}