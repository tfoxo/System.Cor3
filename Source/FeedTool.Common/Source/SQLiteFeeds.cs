using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FeedTool
{
	#if SQLITE
	using System.Cor3.Data;
	using System.Cor3.Data.Engine;
	using System.Data.SQLite;
	static class SQLiteFeeds
	{
		static public void TextToSqlite(string fileName, bool sortByTitle)
		{
			IDictionary<string,FeedListItem> dic = FeedListItemConverter.TextToDictionary(fileName,sortByTitle);
			
			FileInfo file = new FileInfo(fileName);
			
			string sqliteFile = string.IsNullOrEmpty(file.Extension) ?
				file.FullName+".sqlite" :
				file.FullName.Replace(file.Extension,".sqlite");
			
			SQLiteConnection.CreateFile(sqliteFile);
			
			foreach (KeyValuePair<string,FeedListItem> pair in dic) {
				AddFeed(sqliteFile,pair.Value);
			}
			file = null;
		}
		static public long AddFeed(string fileName, FeedListItem item)
		{
			long currentIndex, nextIndex = -1;
			using (SQLiteDb db = new SQLiteDb(fileName)) {
				currentIndex = db.GetSequenceIndex("Feeds","id");
				try {
					db.Insert(
						"Feeds",
						FeedListItem.Insert_Feeds,
						delegate(DbOp op,string query, SQLiteConnection c) {
							SQLiteDataAdapter adapt  = new SQLiteDataAdapter() {
								InsertCommand = new SQLiteCommand(query,c)
							};
							item.Parameterize(adapt.InsertCommand,false);
							return adapt;
						},
						delegate(SQLiteDataAdapter a, DataSet dataset, string tbl) {
							// were not doing a fill.
							return -1;
						}
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
			using (SQLiteDb db = new SQLiteDb(fileName)) {
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
				delegate(DbOp op,string query, SQLiteConnection c) {
					SQLiteDataAdapter adapt  = new SQLiteDataAdapter() {
						SelectCommand = new SQLiteCommand(query,c)
					};
					return adapt;
				},
				delegate(SQLiteDataAdapter a, DataSet dataset, string tbl) {
					// were not doing a fill.
					return -1;
				}
			);
			return errortext;
		}
		static public DataSet ReadFeeds(string fileName, FeedListItem item)
		{
			DataSet ds = new DataSet();
			using (SQLiteDb db = new SQLiteDb(fileName)) {
				ds = db.Select(
					"Feeds",
					"Select * From [Feeds] Order By [title];",
					delegate(DbOp op, string query, SQLiteConnection c) {
						return new SQLiteDataAdapter() {
							SelectCommand = new SQLiteCommand(query,c)
						};
					},
					delegate(SQLiteDataAdapter a, DataSet dataset, string tbl) {
						// were not doing a fill.
						return a.Fill(dataset);
					}
				);
			}
			return ds;
		}
		static public string Update(string fileName, FeedListItem feed)
		{
			string errortext = string.Empty;
			using (SQLiteDb db = new SQLiteDb(fileName)) {
				try {
					db.Update(
						"Feeds",
						FeedListItem.Update_Feeds,
						delegate(DbOp op,string query, SQLiteConnection c) {
							SQLiteDataAdapter adapt  = new SQLiteDataAdapter() {
								DeleteCommand = new SQLiteCommand(query,c)
							};
							adapt.DeleteCommand.Parameters.AddWithValue("@xid",feed.id);
							return adapt;
						},
						delegate(SQLiteDataAdapter a, DataSet dataset, string tbl) {
							// were not doing a fill.
							return -1;
						}
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
			using (SQLiteDb db = new SQLiteDb(fileName)) {
				try {
					db.Delete(
						"Feeds",
						"Delete from feeds where [id] = @xid;"
						/*Feeds.Delete_Feed*/,
						delegate(DbOp op,string query, SQLiteConnection c) {
							SQLiteDataAdapter adapt  = new SQLiteDataAdapter() {
								DeleteCommand = new SQLiteCommand(query,c)
							};
							adapt.DeleteCommand.Parameters.AddWithValue("@xid",id);
							return adapt;
						},
						delegate(SQLiteDataAdapter a, DataSet ds, string tbl) {
							// were not doing a fill.
							return -1;
						}
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
