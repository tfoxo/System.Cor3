/* User: oIo * Date: 8/18/2010 * Time: 4:27 AM */

namespace System
{
	using System.Collections.Generic;
	public class SqlFieldString : SVar
	{
		static public new char[] trimChars = new Char[]{'`'};
		public override char[] TrimChars {
			get { return trimChars; }
		}
		public SqlFieldString() : base(string.Empty,SVarFormat.VarDollar) { }
		public SqlFieldString(string input) : base( input.Trim(trimChars) , SVarFormat.VarDollar ) { }
		public override string Value { get { return base.Value; } }
	
		static public implicit operator SqlFieldString(string s){ return new SqlFieldString(string.Copy(s.Trim(trimChars))); }
		static public implicit operator string(SqlFieldString s){ return string.Copy(s.Value); }
	}
}
