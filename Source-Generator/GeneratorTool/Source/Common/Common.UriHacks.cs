/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 2/6/2012
 * Time: 7:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;

namespace GeneratorTool.Common
{
	static class UriHacks // thanks to stackoverflow
	{
		private const int CompressPath = 0x800000;
		private const int UnEscapeDotsAndSlashes = 0x2000000;
		public static void LeaveDotsAndSlashesEscaped(this Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}
			
			FieldInfo fieldInfo = uri.GetType().GetField("m_Syntax", BindingFlags.Instance | BindingFlags.NonPublic);
			if (fieldInfo == null)
			{
				throw new MissingFieldException("'m_Syntax' field not found");
			}
			object uriParser = fieldInfo.GetValue(uri);
			
			fieldInfo = typeof(UriParser).GetField("m_Flags", BindingFlags.Instance | BindingFlags.NonPublic);
			if (fieldInfo == null)
			{
				throw new MissingFieldException("'m_Flags' field not found");
			}
			object uriSyntaxFlags = fieldInfo.GetValue(uriParser);
			
			// Clear the flag that we don't want
			uriSyntaxFlags = (int)uriSyntaxFlags & ~UnEscapeDotsAndSlashes;
			
			fieldInfo.SetValue(uriParser, uriSyntaxFlags);
		}
		public static void LeaveMultipleSlashesAsIs(this Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}
			
			FieldInfo fieldInfo = uri.GetType().GetField("m_Syntax", BindingFlags.Instance | BindingFlags.NonPublic);
			if (fieldInfo == null)
			{
				throw new MissingFieldException("'m_Syntax' field not found");
			}
			object uriParser = fieldInfo.GetValue(uri);
			
			fieldInfo = typeof(UriParser).GetField("m_Flags", BindingFlags.Instance | BindingFlags.NonPublic);
			if (fieldInfo == null)
			{
				throw new MissingFieldException("'m_Flags' field not found");
			}
			object uriSyntaxFlags = fieldInfo.GetValue(uriParser);
			
			// Clear the flag that we don't want
			uriSyntaxFlags = (int)uriSyntaxFlags & ~CompressPath;
			
			fieldInfo.SetValue(uriParser, uriSyntaxFlags);
		}
	}
}
