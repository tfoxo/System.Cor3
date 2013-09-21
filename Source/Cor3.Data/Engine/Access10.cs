/*
 * oIo — 11/23/2010 — 7:47 AM
 */
using System;
using System.Cor3.Data;
using System.Cor3.Data.Engine;
using System.Data;
using System.Data.OleDb;

namespace System.Cor3.Data.Engine
{
	/// <summary>
	/// Description of AccessDbConnector.
	/// </summary>
	public class Access10 :  DataAbstract<OleDbConnection, OleDbCommand, OleDbDataAdapter, OleDbParameter>
	{
		protected internal override string data_id { get { return "Access10"; } }

		protected DataSet globalData = null;
		public override DataSet GlobalData { get { return globalData; } protected set { globalData = value; } }
		
		DictionaryList<string,string> queryParams = new DictionaryList<string, string>();
		public override DictionaryList<string, string> QueryParams { get { return queryParams; } }
		protected DICT<string, string> KeyParams = new DICT<string,string>();
		protected DICT<string, string> QueryGlobal = new DICT<string,string>();
		protected DictionaryList<string, OleDbParameter> InsertParams = new DictionaryList<string,OleDbParameter>();

		protected string dataSource=string.Empty;
		public override string DataSource { get { return dataSource; } }

		int lastRecord;
		public override int LastRecordsAffected { get { return lastRecord; } set { lastRecord = value; } }

		public void SetUser(string name) { userName = name; }
		
		string userName = "Admin";
		virtual public string User { get { return userName; } }

		readonly string aceProvider = "Microsoft.ACE.OLEDB.12.0";
		virtual public string Provider { get { return aceProvider; } }
		
		public override string ConnectionString {
			get {
				return cstrings.DEFALUT_MICROSOFT_ACE_OLEDB_12_0
					.Replace("$(user)",User)
					.Replace("$(provider)",Provider)
					.Replace("$(datasource)",DataSource);
			}
		}

		public override OleDbConnection Connection { get { return new OleDbConnection(ConnectionString); } }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="A">OleDbDataAdapter</param>
		/// <param name="D"></param>
		/// <param name="tablename"></param>
		/// <returns></returns>
		public override int DefaultFill(OleDbDataAdapter A, DataSet D, string tablename) { return A.Fill(D,tablename); }

		public Access10(string dSource) : this()
		{
			dataSource = dSource;
		}
		public Access10()
		{
//			globalData = new DataSet(data_id);
		}
		
		public override OleDbDataAdapter Adapter { get { return new OleDbDataAdapter(); } }
	}
	class cstrings
	{
		internal const string MICROSOFT_ACE_OLEDB_12_0 = @"
	Provider=Microsoft.ACE.OLEDB.12.0;
	User ID=Admin;
	Data Source={0};
	Mode=ReadWrite|Share Deny None;
	Persist Security Info=False
";
		internal const string DEFALUT_MICROSOFT_ACE_OLEDB_12_0 = @"
	Provider=$(provider);
	User ID=$(user);
	Data Source=$(datasource);
	Persist Security Info=False
";
//	Mode=ReadWrite|Share Deny None;
	}
}
