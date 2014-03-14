/* oio : 3/9/2014 10:25 PM */
using System;
using System.Collections.Generic;
using System.Cor3.Data;
using System.Cor3.Data.Engine;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using Microsoft.Win32;

namespace SQLiteUtil.Views
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class SQLiteView : UserControl
	{
		
		static public readonly ICommand DbFileLoadCommand = new RoutedUICommand();
		static public readonly ICommand DbFileCreateCommand = new RoutedUICommand();
		
		static public readonly ICommand SqlExecuteSelectCommand = new RoutedUICommand();
		static public readonly ICommand SqlExecuteInsertCommand = new RoutedUICommand();
		
		static SQLFileLoader sqlFile = new SQLFileLoader();
		static DataFileLoader database = new DataFileLoader();
		
		DataSet data;
		
		
		public SQLiteView()
		{
			InitializeComponent();
		}
		public override void BeginInit()
		{
			base.BeginInit();
			Console.WriteLine("SQLiteView.BeginInit");
			sqlFile.UpdateBindings(this);
		}
		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			Console.WriteLine("SQLiteView.OnInitialized");
		}
		
		#region database commands
		int Adapt(SQLiteDataAdapter A, DataSet D, string tablename)
		{
			return A.Fill(D,tablename);
		}
		SQLiteDataAdapter DBSelect(DbOp op, string query, SQLiteConnection connection)
		{
			return new SQLiteDataAdapter(){ SelectCommand = new SQLiteCommand(query,connection) };
		}
		SQLiteDataAdapter DBInsert(DbOp op, string query, SQLiteConnection connection)
		{
			return new SQLiteDataAdapter(){ InsertCommand = new SQLiteCommand(query,connection) };
		}
		
		void Event_ExecuteNonQuery(object sender, RoutedEventArgs args)
		{
			if (!database.IsLoaded) return;
			using (SQLiteDb db = new SQLiteDb(database.DataFile))
			{
				data = db.Insert(edit.Text,DBInsert);
			}
		}
		void Event_ExecuteSelectQuery(object sender, RoutedEventArgs args)
		{
			if (!database.IsLoaded) return;
			using (SQLiteDb db = new SQLiteDb(database.DataFile))
			{
				data = db.Select("mytable", edit.Text, DBSelect,Adapt);
				if (data.Tables.Count > 0) grid.ItemsSource = data.Tables["mytable"].DefaultView;
			}
		}
		void Event_CreateDb(object sender, RoutedEventArgs args)
		{
			database.Create();
			if (!database.IsLoaded) 
			{
				return;
			}
		}
		void Event_OpenDb(object sender, RoutedEventArgs args)
		{
			database.Load();
			if (!database.IsLoaded) 
			{
				return;
			}
		}
		void Event_OpenSQL(object sender, RoutedEventArgs args)
		{
			sqlFile.Load();
			if (!sqlFile.IsLoaded) 
			{
				return;
			}
			edit.Load(sqlFile.SqlFile);
		}
		#endregion
	}
}