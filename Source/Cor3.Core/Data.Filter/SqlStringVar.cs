/* User: oIo * Date: 8/18/2010 * Time: 4:27 AM */

namespace System
{
	using System.Collections.Generic;
	
	/// <summary>
	/// Strips ‘\’.  Isn't this class supposed to do something more?
	/// <para>
	/// note that this class is generally used to represent a Field within a (SQL) Query-Expression.
	/// </para>
	/// </summary>
	public class SqlStringVar : SVar
	{
		/// <summary>
		/// a (T:char[]) character array containing characters to trim: <code>trimChars = new char[]{'\''};</code>
		/// </summary>
		static public new char[] trimChars = new char[]{'\''};
		/// <summary>
		/// An overridable version of static public field ‘trimChars’ (which should probably not be static).
		/// </summary>
		public override char[] TrimChars { get { return trimChars; } }
		/// <summary>
		/// Defaults to <code>base(string.Empty,SVarFormat.Quoted)</code>.
		/// <para>
		/// The default, parameterless constructor.
		/// </para>
		/// </summary>
		public SqlStringVar() : base(string.Empty,SVarFormat.Quoted) { }
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="input">The input string for the field value.</param>
		public SqlStringVar(string input) : base( input.Trim(trimChars) , SVarFormat.VarDollar ) { }
		public override string Value { get { return base.Value; } }
	
		static public implicit operator SqlStringVar(string s){ return new SqlStringVar(string.Copy(s.Trim(trimChars))); }
		static public implicit operator string(SqlStringVar s){ return string.Copy(s.Value); }
	}
}
