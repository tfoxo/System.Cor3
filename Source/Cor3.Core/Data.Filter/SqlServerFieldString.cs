/* User: oIo * Date: 8/18/2010 * Time: 4:27 AM */

namespace System
{
	using System.Collections.Generic;
	/// <summary>
	/// A syntax helper for interpreting and outputting a string value
	/// that represents a SqlServer Table or Field reference.
	/// </summary>
	/// <remarks>
	/// I'm not sure if this class is working perfectly.
	/// </remarks>
	public class SqlServerFieldString : SVar
	{
		/// <summary>
		/// 
		/// </summary>
		static public new char[] trimChars = new Char[]{'[',']'};
		/// <summary>
		/// 
		/// </summary>
		public override char[] TrimChars {
			get { return trimChars; }
		}
		/// <summary>
		/// 
		/// </summary>
		public SqlServerFieldString() : base(string.Empty,SVarFormat.VarSqlServer) { }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		public SqlServerFieldString(string input) : base( input.Trim(trimChars) , SVarFormat.VarDollar ) { }
		/// <summary>
		/// 
		/// </summary>
		public override string Value { get { return base.Value; } }
	
		/// <summary>
		/// Converts from a string to SqlServerFieldString.
		/// </summary>
		/// <param name="s"></param>
		/// <returns>
		/// if you send in the string string
		/// <code>string tablename = ‘tablename’; //
		/// string convertedTablename = (SqlServerFieldString)tablename; // convertedTablename is now: ‘[tablename]’
		/// </code>
		/// </returns>
		static public implicit operator SqlServerFieldString(string s){ return new SqlServerFieldString(string.Copy(s.Trim(trimChars))); }
		/// <summary>
		/// Converts from SqlServerFieldString to string
		/// </summary>
		/// <param name="s"></param>
		/// <returns>
		/// the string value (not sure, but I think the value will not contain braces)
		/// </returns>
		static public implicit operator string(SqlServerFieldString s){ return string.Copy(s.Value); }
	}
}
