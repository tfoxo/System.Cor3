/*
 * User: oIo
 * Date: 11/15/2010 – 2:49 AM
 */
using System;
using System.Collections.Generic;
using System.Cor3.Data;
using System.Data;
using System.Data.SQLite;

namespace System.Cor3.Data.Engine
{
	/// <summary>
	/// see: http://www.connectionstrings.com/sqlite
	/// </summary>
	public class SQLiteDb : DataAbstract<SQLiteConnection, SQLiteCommand, SQLiteDataAdapter, SQLiteParameter>
	{
		#region SQLite Keywords
		
		const string kw = @"ABORT
ACTION
ADD
AFTER
ALL
ALTER
ANALYZE
AND
AS
ASC
ATTACH
AUTOINCREMENT
BEFORE
BEGIN
BETWEEN
BY
CASCADE
CASE
CAST
CHECK
COLLATE
COLUMN
COMMIT
CONFLICT
CONSTRAINT
CREATE
CROSS
CURRENT_DATE
CURRENT_TIME
CURRENT_TIMESTAMP
DATABASE
DEFAULT
DEFERRABLE
DEFERRED
DELETE
DESC
DETACH
DISTINCT
DROP
EACH
ELSE
END
ESCAPE
EXCEPT
EXCLUSIVE
EXISTS
EXPLAIN
FAIL
FOR
FOREIGN
FROM
FULL
GLOB
GROUP
HAVING
IF
IGNORE
IMMEDIATE
IN
INDEX
INDEXED
INITIALLY
INNER
INSERT
INSTEAD
INTERSECT
INTO
IS
ISNULL
JOIN
KEY
LEFT
LIKE
LIMIT
MATCH
NATURAL
NO
NOT
NOTNULL
NULL
OF
OFFSET
ON
OR
ORDER
OUTER
PLAN
PRAGMA
PRIMARY
QUERY
RAISE
REFERENCES
REGEXP
REINDEX
RELEASE
RENAME
REPLACE
RESTRICT
RIGHT
ROLLBACK
ROW
SAVEPOINT
SELECT
SET
TABLE
TEMP
TEMPORARY
THEN
TO
TRANSACTION
TRIGGER
UNION
UNIQUE
UPDATE
USING
VACUUM
VALUES
VIEW
VIRTUAL
WHEN
WHERE";
		#endregion
		
		/// <inheritdoc/>
		protected internal override string data_id { get { return "SqlLite"; } }
		protected DataSet globalData = null;
		/// <inheritdoc/>
		public override DataSet GlobalData { get { return globalData; } protected set { globalData = value; } }
		
		DictionaryList<string,string> parameters = new DictionaryList<string,string>();
		public override DictionaryList<string,string> QueryParams { get { return parameters; } }

		#region Constantly
		// New=False;Compress=True
		const string cstring_attach = @"Data Source=$(AttachDbFileName);Version=3;";
		// Data Source=OOO\SQL2005EXPRESS
		// AttachDbFileName="d:\dev\lip_data.mdf"
//		const string cstring_attach = @"
//	Data Source=$(DataSource);
//	AttachDbFilename=""$(AttachDbFileName)"";
//	Integrated Security=True;
//	Connect Timeout=30";
//	User=$(UserName);
//		const string cstring = @"
//	Integrated Security=SSPI;
//	Persist Security Info=False;
//	Database=$(InitialCatalog);
//	Server=$(DataSource)
		//";
		#endregion

		protected string dsource=string.Empty, dconnect=cstring_attach, dcatalog, username;
		int lastRecordsEffected = -1;
		/// <inheritdoc/>
		public override int LastRecordsAffected { get { return lastRecordsEffected; } set { lastRecordsEffected = value; } }

		protected string DataCatalog { get { return dcatalog; } set { dcatalog=value; } }
		/// <inheritdoc/>
		public override string DataSource { get { return dsource; }  }
//		protected bool LoadFile = false;
		/// <inheritdoc/>
		public override string ConnectionString {
			get {
				return
					//LoadFile ?
					cstring_attach
//					.Replace("$(InitialCatalog)",DataCatalog)
					.Replace("$(AttachDbFileName)",DataSource)
					;
//				cstring
//					.Replace("$(UserName)",username)
//					.Replace("$(InitialCatalog)",DataCatalog)
//					.Replace("$(DataSource)",DataSource);
			}
		}
		/// <inheritdoc/>
		public override int DefaultFill(SQLiteDataAdapter A, DataSet D, string tablename)
		{
			return A.Fill(D,tablename);
		}
		public SQLiteDb()
		{
//			globalData = new DataSet(data_id);
		}
		public SQLiteDb(string source) : this()
		{
			this.dsource = source;
//			this.dcatalog = table;
		}
		

		/// <inheritdoc/>
		public override SQLiteConnection Connection { get { return new SQLiteConnection(ConnectionString); } }
		/// <inheritdoc/>
		public override SQLiteDataAdapter Adapter { get { return new SQLiteDataAdapter(); } }
	}
}
