//#define SQLITE
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace FeedTool
{
	using System.ComponentModel;
	using System.Data;
	using System.ComponentModel.DataAnnotations;
	using System.Data.SQLite;
	using System.Windows.Forms.VisualStyles;

	class FeedAutoData
	{
		[DataType(DataType.Text),Display(Name="id",ShortName="id")]
		public int? id { get;set; }
		[DataType(DataType.Text),Display(Name="title",ShortName="title")]
		public string Title { get;set; }
		[DataType(DataType.Text),Display(Name="url",ShortName="url")]
		public string Url { get;set; }
		[DataType(DataType.Text),Display(Name="group",ShortName="group")]
		public string Group { get;set; }
	}
	
	
	#if SQLITE
	using System.Data;
	using FeedTool.Converters;
	using System.Cor3.Data;
	using System.Cor3.Data.Engine;
	using System.Data.SQLite;
	static class SQLiteFeeds
	{
		static public void TextToSqlite(string fileName, bool sortByTitle)
		{
			IDictionary<string,FeedListItem> dic = FeedListItemConverter.TextToDictionary(fileName,sortByTitle);
			
			var file = new FileInfo(fileName);
			
			string sqliteFile = string.IsNullOrEmpty(file.Extension) ?
				file.FullName+".sqlite" :
				file.FullName.Replace(file.Extension,".sqlite");
			
			SQLiteConnection.CreateFile(sqliteFile);
			
			foreach (KeyValuePair<string,FeedListItem> pair in dic) {
				AddFeed(sqliteFile, pair.Value);
			}
			file = null;
		}

		const string feeds = "Feeds";

		static public long AddFeed(string fileName, FeedListItem item)
		{
			long currentIndex, nextIndex = -1;
			using (var db = new SQLiteDb(fileName)) {
				currentIndex = db.GetSequenceIndex("Feeds","id");
				try {
					db.Insert(
						"Feeds",
						FeedListItem.Insert_Feeds,
						(op, query, c) => {
							var adapt = new SQLiteDataAdapter() {
								InsertCommand = new SQLiteCommand(query, c)
							};
							item.Parameterize(adapt.InsertCommand, false);
							return adapt;
						},
						(a, dataset, tbl) => -1
					);
				} catch (Exception e) {
				}
				nextIndex = db.GetSequenceIndex("Feeds","id");
			}
			return nextIndex;
		}
		
		static public DataSet Execute(
			ref string errortext,
			string fileName,
			string query,
			SQLiteDb.CBRowParam parameterize,
			SQLiteDb.CBDataFill fill)
		{
			DataSet ds = null;
			using (var db = new SQLiteDb(fileName)) {
				try {
					ds = db.Select("Feeds",query,parameterize,fill);
				} catch (Exception e) {
					errortext = e.ToString();
				}
			}
			return ds;
		}
		
		static public string Execute(
			string fileName, string query,
			SQLiteDb.CBRowParam parameterize,
			SQLiteDb.CBDataFill fill)
		{
			string result = null;
			Execute(ref result,fileName,query,parameterize,fill);
			return result;
		}
		/// <summary>
		/// returns the exception's text if any.
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		static public string CreateTable(string fileName)
		{
			string errortext = null;
			Execute(
				ref errortext,
				fileName,
				Resource.Sqlite_Db_Create,
				(op, query, c) => {
					var adapt = new SQLiteDataAdapter() {
						SelectCommand = new SQLiteCommand(query, c)
					};
					return adapt;
				},
				(SQLiteDataAdapter a, DataSet dataset, string tbl) => -1
			);
			return errortext;
		}
		static public DataSet ReadFeeds(string fileName, FeedListItem item)
		{
			var ds = new DataSet();
			using (var db = new SQLiteDb(fileName)) {
				ds = db.Select(
					table: "Feeds",
					query: "Select * From [Feeds] Order By [title];",
					S: (op, query, c) => {
						return new SQLiteDataAdapter() {
							SelectCommand = new SQLiteCommand(query, c)
						};
					},
					Fill: (SQLiteDataAdapter a, DataSet dataset, string tbl) => a.Fill(dataset)
				);
			}
			return ds;
		}
		static public string Update(string fileName, FeedListItem feed)
		{
			string errortext = string.Empty;
			using (var db = new SQLiteDb(fileName)) {
				try {
					db.Update(
						"Feeds",
						FeedListItem.Update_Feeds,
						delegate(DbOp op, string query, SQLiteConnection c) {
							var adapt = new SQLiteDataAdapter() {
								DeleteCommand = new SQLiteCommand(query, c)
							};
							adapt.DeleteCommand.Parameters.AddWithValue("@xid", feed.id);
							return adapt;
						},
						(SQLiteDataAdapter a, DataSet dataset, string tbl) => -1
					);
				} catch (Exception e) {
					errortext = e.ToString();
				}
			}
			return errortext;
		}
		static public string DeleteFeed(string fileName, long id)
		{
			string errortext = string.Empty;
			using (var db = new SQLiteDb(fileName)) {
				try {
					db.Delete(
						"Feeds",
						"Delete from feeds where [id] = @xid;"
						/*Feeds.Delete_Feed*/,
						(op, query, c) => {
							var adapt = new SQLiteDataAdapter() {
								DeleteCommand = new SQLiteCommand(query, c)
							};
							adapt.DeleteCommand.Parameters.AddWithValue("@xid", id);
							return adapt;
						},
						(SQLiteDataAdapter a, DataSet ds, string tbl) => -1
					);
				} catch (Exception e) {
					errortext = e.ToString();
				}
			}
			return errortext;
		}
		
	}
	#endif
}
