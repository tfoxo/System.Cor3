using System;
using System.Collections.Generic;

namespace FeedTool.Converters
{
	/// <summary>
	/// Convert from text file (delimited by '\n' and '|') to List&lt;FeedDataItems&gt;.
	/// </summary>
	public class FeedListConverter
	{
		//^(\w*)\.([A-z0-9 ._,\:()?-]*)\|([^\n\r]*)
		readonly char[] splitter = { '\n', '\r', '\t' };
		public List<FeedDataItem> Items {
			get { return items; }
		} readonly List<FeedDataItem> items = new List<FeedDataItem>();

		public void Convert(System.IO.FileInfo file)
		{
			var list = new List<string>(System.IO.File.ReadAllLines(file.FullName));
			for (int i=0; i < list.Count; i++)
			{
				string sitem = list[i].Trim(splitter);
				if (string.IsNullOrEmpty(sitem)) continue;
				else if (sitem[0]=='#') continue;
				list[i] = sitem;
				string[] node = list[i].Split('|');
				items.Add(new FeedDataItem { GroupID=node[0], Title=node[1].Trim(splitter), Url=node[2].Trim(splitter) });
			}
		}
		
		public FeedListConverter(){}
	}
	/// <summary>
	/// Convert from text file (delimited by '\n' and '|') to List&lt;FeedDataItems&gt;.
	/// </summary>
	public class FeedListConverter_OLD
	{
		readonly char[] splitter = { '\n', '\r', '\t' };
		public List<FeedDataItem> Items {
			get { return items; }
		} readonly List<FeedDataItem> items = new List<FeedDataItem>();

		public void Convert(System.IO.FileInfo file)
		{
			var list = new List<string>(System.IO.File.ReadAllLines(file.FullName));
			for (int i=0; i < list.Count; i++)
			{
				string sitem = list[i].Trim(splitter);
				if (string.IsNullOrEmpty(sitem)) continue;
				else if (sitem[0]=='#') continue;
				list[i] = sitem;
				string[] node = list[i].Split('|');
				items.Add(new FeedDataItem { Title=node[0].Trim(splitter), Url=node[1].Trim(splitter) });
			}
		}
		
		public FeedListConverter_OLD(){}
	}
}
