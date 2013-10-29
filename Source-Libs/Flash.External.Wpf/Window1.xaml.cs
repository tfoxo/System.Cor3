/*
 * oIo — 11/15/2010 — 6:23 PM
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace wpv
{

	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{

		public Window1()
		{
			InitializeComponent();
			cBox.DisplayMemberPath = "FullName";
			cBox.SelectedValuePath = "FullName";
			cBox.ItemsSource = FileLoader.GetDrives();
			cBox.IsEditable=true;
			cBox.SelectionChanged += eComboSelected;
			lBox.MouseDoubleClick += eListClick;
			lBox.ItemsSource = FileLoader.GetFiles(@"D:\musica\newmedia\030410",FileLoader.fmts);
			lBox.DisplayMemberPath = "Name";
			lBox.SelectedValuePath = "FullName";
			//MessageBox.Show(lBox.Items.Count.ToString());
		}
		void eComboSelected(object sender, SelectionChangedEventArgs e)
		{
			try {
				lBox.ItemsSource = FileLoader.GetFiles((cBox.SelectedItem as DirectoryInfo).FullName,FileLoader.fmts);
			} catch (Exception) {
			//	throw;
			}
		}
		void eListClick(object sender, MouseButtonEventArgs e)
		{
			try {
				Global.statM(lBox.SelectedValue.ToString());
				flvp.FlvTool.sendMessage(lBox.SelectedValue.ToString());
				this.Title = lBox.SelectedValue.ToString();
			} catch (Exception) {
			//	throw;
			}
		}

	}
}