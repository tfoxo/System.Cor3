/* User: oIo * Date: 8/18/2010 * Time: 4:27 AM */

namespace System
{
	using System.Collections.Generic;
	public class VarAmpersand : SVar
	{
		static public new char[] trimChars = new Char[]{'@'};
		public override char[] TrimChars { get { return trimChars; } }
		protected override string QFmt { get { return "@{0}"; } }
		public VarAmpersand() : base(string.Empty,SVarFormat.VarAmpersand) { }
		public VarAmpersand(string input) : base( input.Trim(trimChars) , SVarFormat.VarAmpersand ) { }
		public VarAmpersand(string input, SVarFormat fmt) : base( input.Trim(trimChars) , fmt ) { }
		public override string Value { get { return base.Value; } }
	
		static public implicit operator VarAmpersand(string s){ return new VarAmpersand(string.Copy(s.TrimStart(trimChars)),SVarFormat.VarAmpersand); }
		static public implicit operator string(VarAmpersand s){ return string.Copy(s.Value); }
	}
}
