using System;
using System.Collections.Generic;

namespace FeedTool
{
	static class DictionaryFromStringExtension
	{
		/// <summary>
		/// for line-broken 2-item, UTF-8 string conversion to dictionary.
		/// </summary>
		static public Dictionary<string,string> ToStringDictionary(this string input, char sepRows, char sepCols, char[] lineComment, char[] trim)
		{
			var dic = new Dictionary<string, string>();
			if (string.IsNullOrEmpty(input)) return dic;
			var list = new List<string>(input.Split(sepRows));
			foreach (string r in list)
			{
				string row = r.Trim(trim);
				foreach (char c in lineComment) if (row[0]==c) goto skip2next;
				
				string[] item = row.Split(sepCols);
				if (item.Length!=2) continue;
				dic.Add(item[0].Trim(trim),item[1].Trim(trim));
				// label
				skip2next:;
			}
			// we want an empty dictionary, so forget this
			//if (dic.Count) == 0) { dic = null; return null; }
			return dic;
		}
		/// <summary>
		/// for line-broken 2-item, UTF-8 string conversion to dictionary.
		/// </summary>
		static public Dictionary<string,string> ToStringDictionary(this System.IO.FileInfo input, char sepRows, char sepCols, char[] lineComment, char[] trim)
		{
			return !input.Exists ? string.Empty.ToStringDictionary(sepRows, sepCols, lineComment, trim) : System.IO.File.ReadAllText(input.FullName, System.Text.Encoding.UTF8).ToStringDictionary(sepRows, sepCols, lineComment, trim); // empty dictionary
		}
	}
}
