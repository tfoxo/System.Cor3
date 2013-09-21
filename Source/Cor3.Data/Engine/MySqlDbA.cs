#if USEMYSQL
/*
 * User: oIo
 * Date: 11/15/2010 – 2:49 AM
 */
using System;
using System.Cor3.Data.Engine;
using System.Cor3.Data;

using MySql.Data.MySqlClient;

namespace System.Cor3.Data.Engine
{
	/// <summary>
	/// this abstraction is intended for mysql databsae connections.
	/// </summary>
	public abstract class MySqlDbA : IDataAbstraction<MySqlConnection, MySqlCommand, MySqlDataAdapter/*, MySqlParameters*/>,IDbAbstraction
		
	{
		DICT_List<string,string> parameters = new DICT_List<string,string>();
		public DICT_List<string,string> QueryParams { get { return parameters; } }

		int lastRecordsEffected = -1;
		int IDbAbstraction.LastRecordsAffected { get { return lastRecordsEffected; } set { lastRecordsEffected = value; } }

		const string cstring = cstrings.MICROSOFT_ACE_OLEDB_12_0;
		string dsource=string.Empty, dconnect=string.Empty;

		string IDbAbstraction.DataSource { get { return dsource; }  }
		string IDbAbstraction.ConnectionString { get { return DataSource; } }

		protected override int DefaultFill(SQLiteDataAdapter A, DataSet D, string tablename)
		{
			return A.Fill(D,tablename);
		}
		
		protected abstract string DataSource { get; }
		protected abstract string ConnectionString { get; }

		abstract public MySqlConnection Connection { get; }
		abstract public MySqlDataAdapter Adapter { get; }
	}
}
#endif