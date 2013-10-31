#region Using
using System;
using System.Collections.Generic;
using System.Cor3.Data;
using System.Cor3.Data.Engine;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;

#endregion
namespace System.Data
{
	/// <summary>
	/// remember that rowparamcaller returns a new adapter.
	/// </summary>
	static class SQLiteDb_Extensions
	{
		static public string SQuote(this string input) { return string.Format("'{0}'",input); }
		
		static public string DQuote(this string input) { return string.Format(@"""{0}""",input); }
		
		static public DataSet GetTopRecord(this SQLiteDb db, string table, string index)
		{
			string query = ""
				.Replace("@tablename", table.QBrace())
				.Replace("@tableindex",index.QBrace())
				;
			return db.Select(table,query,null);
		}
		
		static SQLiteDataAdapter DefaultSelectAdapter(DbOp op, string query, SQLiteConnection connection)
		{
			return new SQLiteDataAdapter(){ SelectCommand=new SQLiteCommand(){ CommandText=query, Connection=connection} };
		}
		/// <summary>
		/// this is the one.
		/// </summary>
		/// <param name="db"></param>
		/// <param name="table"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		static public DataSet GetSequenceID(this SQLiteDb db, string table)
		{
			DataSet ds = null;
			string query = "SELECT * from sqlite_sequence where [name] = @tablename;".Replace("@tablename", table.SQuote());
			using (SQLiteConnection connection = db.Connection) ds = db.Select( table, query, DefaultSelectAdapter );
			return ds;
		}
		
		static public long GetSequenceIndex(this SQLiteDb db, string table, string index)
		{
			object ourIndex ;
			using (DataSet ds = GetSequenceID(db,table)) ourIndex = ds.GetFirstRow(0)[index];
			return (long) ourIndex;
		}
		
		static public DataSet GetDataSet(this SQLiteDb db, string table, string clauses = "")
		{
			DataSet ds = null;
			string query = "SELECT * from [@tablename]@clauses;"
				.Replace("@tablename", table)
				.Replace("@clauses",clauses)
				;
			using (SQLiteConnection connection = db.Connection)
				ds = db.Select( table, query, DefaultSelectAdapter );
			return ds;
		}
		
		static public DataSet DEMO_GetSequenceId(this SQLiteDb db, string table, string index)
		{
			DataSet ds = null;
			string query = "SELECT * from sqlite_sequence where [name] = @tablename;"
				.Replace("@tablename", table.DQuote());
			using (SQLiteConnection connection = db.Connection)
				using (SQLiteDataAdapter adapter = new SQLiteDataAdapter())
			{
				ds = db.Select(
					table,
					query,
					delegate (DbOp op, string q, SQLiteConnection cn)
					{
						return null;
					},
					delegate (SQLiteDataAdapter A, DataSet D, string tablename)
					{
						return A.Fill(D);
					}
				);
			}
			return ds;
		}
	}
}
