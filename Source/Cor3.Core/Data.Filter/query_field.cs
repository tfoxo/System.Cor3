/* User: oIo * Date: 8/18/2010 * Time: 4:27 AM */

namespace System
{
	using System.Collections.Generic;
	/// <summary>
	/// SQL String utility foundation.
	/// <para>(obsoleted by <see cref="System.SVar" />)</para>
	/// </summary>
	public class query_field
	{
		internal protected char[] trimChars = new char[]{'\r','\n'};
		internal protected string _value;
		internal protected const string _qfmt = "`{0}`";
		virtual protected string QFmt { get { return _qfmt; } }
		public string InnerString { get { return  _value; } }
		virtual public string Value { get { return  string.Format(QFmt,_value); } }
		virtual public char[] TrimChars { get { return trimChars; } }
	
		internal protected query_field(string inval) { _value = inval; }
		internal protected query_field() : this(string.Empty) {  }
		//		static public implicit operator %(query_field s){ return new query_field(string.Copy(s)); }
		static public implicit operator query_field(string s){ return new query_field(string.Copy(s)); }
		static public implicit operator string(query_field s){ return string.Copy(s._value); }
	}
}
