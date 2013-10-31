/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 2/18/2013
 * Time: 8:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;

namespace FeedTool.Converters
{
	/// <summary>
	/// <para>
	/// The responsibilty of this class is to convert listings of feed
	/// data to and from a a generalized format such as our text-file,
	/// or perhaps a FeedDataItem list.
	/// </para>
	/// <para>
	/// See the FeedListConverter.
	/// </para>
	/// </summary>
	public class FeedDataConverter
	{
		const string sortOrderAscTitleAsc = "[Order], [Title]";
		const string ds_table = "Enclosures", ds_dataset = "Feeds";
		
		public List<FeedDataItem> Items {
			get { return items; }
		} List<FeedDataItem> items = new List<FeedDataItem>();
		
		#region DataSet Info
		
		DataSet Data = new DataSet(ds_dataset)
		{
			Tables =
			{
				new DataTable(ds_table){
					Columns={
						new DataColumn("Title",typeof(string)),
						new DataColumn("Category",typeof(string)),
						new DataColumn("Url",typeof(string)),
						new DataColumn("Order",typeof(int)),
					}
				}
			}
		};
		public DataTable Table { get { return Data.Tables[ds_table]; } }
		public DataView View { get { return Table.DefaultView; } }
		#endregion
		
		public FeedDataConverter()
		{
		}
		
		public void Clear()
		{
			if (Table!=null) {
				Table.Clear();
				Table.AcceptChanges();
			}
		}
		
		public void RefreshFromList(bool append)
		{
			if (!append) Clear();
			foreach (FeedDataItem enc in items) enc.ToRow(View.AddNew());
			Table.AcceptChanges();
		}
		
		public FeedDataConverter(System.IO.FileInfo file)
		{
			FeedListConverter converter = new FeedListConverter(){};
			converter.Convert(file);
			this.items = converter.Items;
			converter = null;
		}
		
		public void ToGrid(System.Windows.Forms.DataGridView view)
		{
			RefreshFromList(false);
			view.AutoGenerateColumns = true;
			view.AllowUserToAddRows = true;
			view.DataSource = View;
		}
		
		public void UpdateItems()
		{
			Items.Clear();
			foreach (DataRowView row in View) {
				FeedDataItem enc = new FeedDataItem(row);
				items.Add(enc);
			}
		}
		
		#region Load/Save
		
		System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog{ Filter="Feeds|*.feeds" };
		System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog{ Filter="Feeds|*.feeds" };
		
		public void SaveXml() { if (sfd.ShowDialog()==System.Windows.Forms.DialogResult.OK) SaveXml(sfd.FileName); }
		public void SaveXml(string filename)
		{
			Table.AcceptChanges();
			UpdateItems();
			FeedCollection collection = new FeedCollection{ Items=this.Items };
			collection.Save(filename,collection);
		}
		
		public void LoadXml(bool append) { if (ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK) LoadXml(ofd.FileName,append); }
		public void LoadXml(string filename, bool append)
		{
			FeedCollection collection = FeedCollection.Load(filename);
			this.items = collection.Items;
			RefreshFromList(append);
		}
		
		#endregion
		
	}
}
