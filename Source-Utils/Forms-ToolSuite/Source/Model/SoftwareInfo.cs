﻿#region User/License
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
using System.Cor3.Data.Engine;
using System.Data;
using System.Data.SQLite;

using ToolSuite.Lib;

namespace ToolSuite.Model
{
	class SoftwareUtil
	{
		static public List<Software> LoadSoftware(string dbFile)
		{
			using (SQLiteDb db = new SQLiteDb(dbFile))
				using (SQLiteConnection c = db.Connection)
					using (SQLiteDataAdapter a = new SQLiteDataAdapter("SELECT * FROM [software] ORDER BY [groupid], [title];",c))
			{
				c.Open();
				a.SelectCommand.ExecuteNonQuery();
				c.Close();
			}
			return null;
		}
	}
	
	// Generated by a tool : 08/27/2012 12:12.35 PM
	// ------------------------
	class Software
	{
		#region Queries
		/// <summary> not that we need it or anything </summary>
		internal const string Insert_Software = @"INSERT INTO [software] (
	[groupid],
	[title],
	[version],
	[url],
	[desc],
	[tags])
VALUES(
	@groupid,
	@title,
	@version,
	@url,
	@desc,
	@tags);";
		/// <summary> not that we need it or anything </summary>
		internal const string Update_Software = @"UPDATE [software] SET
		[groupid] = @groupid,
		[title] = @title,
		[version] = @version,
		[url] = @url,
		[desc] = @desc,
		[tags] = @tags
WHERE [id] = @xid;";
		#endregion
		
		public readonly long? id;
		public string groupid;
		public string title;
		public string version;
		public string url;
		public string desc;
		public string tags;

		public Software(DataRowView row)
		{
			this.id	= row["id"] as long?;
			this.groupid	= row["groupid"] as string;
			this.title	= row["title"] as string;
			this.version	= row["version"] as string;
			this.url	= row["url"] as string;
			this.desc	= row["desc"] as string;
			this.tags	= row["tags"] as string;
		}

		/// <summary>
		/// Used for cloning operations.
		/// <para>Particularly for Insert/Update SQL Queries due to the readonly PRIMARY KEY value.</para>
		/// </summary>
		public Software(Software value)
		{
			this.id = value.id;
			this.SetFields(value);
		}

		/// <summary>
		/// Used for cloning operations.
		/// <para>Particularly for Insert/Update SQL Queries due to the readonly PRIMARY KEY value.</para>
		/// </summary>
		public void SetFields(Software value)
		{
			this.groupid = value.groupid;
			this.title = value.title;
			this.version = value.version;
			this.url = value.url;
			this.desc = value.desc;
			this.tags = value.tags;
		}

		// TODO: add if (usePrimary) to the primary key
		// an insert statement would not use or contain
		// a primary key value (or would contain a null,
		// hence we provide the oppertunity to neglect
		// it here.
		public SQLiteCommand Parameterize(SQLiteCommand cmd, bool usePrimary)
		{
			if (usePrimary) cmd.Parameters.AddWithValue("@xid", this.id);
			cmd.Parameters.AddWithValue("@groupid", this.groupid);
			cmd.Parameters.AddWithValue("@title", this.title);
			cmd.Parameters.AddWithValue("@version", this.version);
			cmd.Parameters.AddWithValue("@url", this.url);
			cmd.Parameters.AddWithValue("@desc", this.desc);
			cmd.Parameters.AddWithValue("@tags", this.tags);
			return cmd;
		}
	}
	#region No
	#if NO
	/// <summary>
	/// Generated by a tool.
	/// </summary>
	[ProvideData]
	public class RowSoftware : ISQLiteDataProof
	{
		#region Queries
		/// <summary> not that we need it or anything </summary>
		internal const string Insert_Row_Software = @"INSERT INTO [software] (
	[groupid],
	[title],
	[version],
	[url],
	[desc],
	[tags])
VALUES(
	@groupid,
	@title,
	@version,
	@url,
	@desc,
	@tags);";
		/// <summary> not that we need it or anything </summary>
		internal const string Update_Row_Software = @"UPDATE [software] SET
		[groupid] = @groupid,
		[title] = @title,
		[version] = @version,
		[url] = @url,
		[desc] = @desc,
		[tags] = @tags
WHERE [id] = @xid;";
		internal const string Delete_Row_Software = @"DELETE FROM [software] where [id] = @xid";
		#endregion
		
		public readonly Int64? id;
		public string groupid;
		public string title;
		public string version;
		public string url;
		public string desc;
		public string tags;

		public RowSoftware(DataRowView row)
		{
			this.id	= row["id"] as Int64?;
			this.groupid	= row["groupid"] as string;
			this.title	= row["title"] as string;
			this.version	= row["version"] as string;
			this.url	= row["url"] as string;
			this.desc	= row["desc"] as string;
			this.tags	= row["tags"] as string;
		}

		/// <summary>
		/// Used for cloning operations.
		/// <para>Particularly for Insert/Update SQL Queries due to the readonly PRIMARY KEY value.</para>
		/// </summary>
		public RowSoftware(RowSoftware value)
		{
			SetFields(value);
		}

		/// <summary>
		/// Used for cloning operations.
		/// <para>Particularly for Insert/Update SQL Queries due to the readonly PRIMARY KEY value.</para>
		/// </summary>
		public void SetFields(RowSoftware value)
		{
			this.groupid = value.groupid;
			this.title = value.title;
			this.version = value.version;
			this.url = value.url;
			this.desc = value.desc;
			this.tags = value.tags;
		}

		// TODO: add if (usePrimary) to the primary key
		// an insert statement would not use or contain
		// a primary key value (or would contain a null,
		// hence we provide the oppertunity to neglect
		// it here.
		public SQLiteCommand Parameterize(SQLiteCommand cmd, bool usePrimary)
		{
			if (usePrimary) cmd.Parameters.AddWithValue("@xid", this.id);
			cmd.Parameters.AddWithValue("@groupid", this.groupid);
			cmd.Parameters.AddWithValue("@title", this.title);
			cmd.Parameters.AddWithValue("@version", this.version);
			cmd.Parameters.AddWithValue("@url", this.url);
			cmd.Parameters.AddWithValue("@desc", this.desc);
			cmd.Parameters.AddWithValue("@tags", this.tags);
			return cmd;
		}
	}
	#endif

	#endregion
}
