#region User/License
// oio * 8/18/2012 * 11:45 PM

// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
#endregion
using System;
using System.Collections.Generic;
using System.Cor3.Data;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

//using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
//	using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query,connection))
//{
//	connection.Open();
//
//	connection.Close();
//}
namespace ToolSuite.Lib
{
	/// <summary>
	/// Connection Template
	/// </summary>
	class DataSoftware
	{
		const string table_sqlite_software = @"
	drop table if exists [software];
	create table [software](
	    [id]			INTEGER PRIMARY KEY AUTOINCREMENT,
	    [groupid]	VARCHAR,
	    [title]		VARCHAR,
	    [version]	VARCHAR,
	    [url]			VARCHAR,
	    [desc]		VARCHAR,
	    [tags]		VARCHAR
	);";
		static public DataSet LoadOrderBy(string file, string default_orderby)
		{
			string connectionstring = string.Format("Data Source={0};Version=3;",file);
			string query = string.Format("select * from [software] order by '{0}';",default_orderby);
			DataSet returned = default(DataSet);
			using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
				using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query,connection))
			{
				connection.Open();
				adapter.SelectCommand.ExecuteNonQuery();
				adapter.Fill(returned);
				connection.Close();
			}
			return returned;
		}
		
		public DataSoftware()
		{
			
		}
	}
}
