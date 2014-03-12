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
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

using ToolSuite.Lib;

namespace TemplateTool
{
	[ProvideData]
	public class RowTemplates
	{
		#region Queries
		/// <summary> not that we need it or anything </summary>
		internal const string Insert_Templates = @"INSERT INTO [templates] (
	[container],
	[row],
	[grouphead],
	[groupfoot],
	[head],
	[foot],
	[note],
	[table],
	[fields])
	VALUES(
	@container,
	@row,
	@grouphead,
	@groupfoot,
	@head,
	@foot,
	@note,
	@table,
	@fields);";
		/// <summary> not that we need it or anything </summary>
		internal const string Update_Templates = @"UPDATE [templates] SET 
		[container] = @container,
		[row] = @row,
		[grouphead] = @grouphead,
		[groupfoot] = @groupfoot,
		[head] = @head,
		[foot] = @foot,
		[note] = @note,
		[table] = @table,
		[fields] = @fields
	WHERE [id] = @xid;";
		#endregion
		
		public readonly int? id;
		public string container;
		public string row;
		public string grouphead;
		public string groupfoot;
		public string head;
		public string foot;
		public string note;
		public string table;
		public string fields;
	
		public RowTemplates(DataRowView row)
		{
			this.id	= row["id"] as int?;
			this.container	= row["container"] as string;
			this.row	= row["row"] as string;
			this.grouphead	= row["grouphead"] as string;
			this.groupfoot	= row["groupfoot"] as string;
			this.head	= row["head"] as string;
			this.foot	= row["foot"] as string;
			this.note	= row["note"] as string;
			this.table	= row["table"] as string;
			this.fields	= row["fields"] as string;
		}
	
		/// <summary>
		/// Used for cloning operations.
		/// <para>Particularly for Insert/Update SQL Queries due to the readonly PRIMARY KEY value.</para>
		/// </summary>
		public RowTemplates(RowTemplates value)
		{
			this.SetFields(value);
		}
	
		/// <summary>
		/// Used for cloning operations.
		/// <para>Particularly for Insert/Update SQL Queries due to the readonly PRIMARY KEY value.</para>
		/// </summary>
		public void SetFields(RowTemplates value)
		{
			this.container = value.container;
			this.row = value.row;
			this.grouphead = value.grouphead;
			this.groupfoot = value.groupfoot;
			this.head = value.head;
			this.foot = value.foot;
			this.note = value.note;
			this.table = value.table;
			this.fields = value.fields;
		}
	
		/// <summary>
		/// Used for cloning operations.
		/// <para>Particularly for Insert/Update SQL Queries due to the readonly PRIMARY KEY value.</para>
		/// <para>That is, we're not implementing a Primary Key value here.</para>
		/// </summary>
		public void SetRowValue(DataRowView row)
		{
			row["container"] = this.container;
			row["row"] = this.row;
			row["grouphead"] = this.grouphead;
			row["groupfoot"] = this.groupfoot;
			row["head"] = this.head;
			row["foot"] = this.foot;
			row["note"] = this.note;
			row["table"] = this.table;
			row["fields"] = this.fields;
		}
	
		// TODO: add if (usePrimary) to the primary key
		// an insert statement would not use or contain
		// a primary key value (or would contain a null,
		// hence we provide the oppertunity to neglect
		// it here.
		public SQLiteCommand Parameterize(SQLiteCommand cmd, bool usePrimary)
		{
			if (usePrimary) cmd.Parameters.AddWithValue("@xid", this.id);
			cmd.Parameters.AddWithValue("@container", this.container);
			cmd.Parameters.AddWithValue("@row", this.row);
			cmd.Parameters.AddWithValue("@grouphead", this.grouphead);
			cmd.Parameters.AddWithValue("@groupfoot", this.groupfoot);
			cmd.Parameters.AddWithValue("@head", this.head);
			cmd.Parameters.AddWithValue("@foot", this.foot);
			cmd.Parameters.AddWithValue("@note", this.note);
			cmd.Parameters.AddWithValue("@table", this.table);
			cmd.Parameters.AddWithValue("@fields", this.fields);
			return cmd;
		}
	}
}
