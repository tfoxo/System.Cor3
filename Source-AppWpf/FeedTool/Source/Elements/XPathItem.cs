using System;
using System.Linq;

namespace FeedTool.Forms
{
	public class XPathItem
	{
		public string XMLROOT { get; set; }
		public string XMLPATH { get; set; }
		public string GetPath(string key)
		{
			return string.Format("{0}{1}",XMLROOT,key);
		}
		public string GetPath(int index, string key)
		{
			return GetPath(XMLROOT,index,key);
		}
		public string GetPath(string root, int index)
		{
			return string.Format("{0}[{1}]",root,index);
		}
		public string GetPath(string root, int index, string key)
		{
			return string.Format("{0}[{1}]{2}",root,index,key);
		}
	}
}
