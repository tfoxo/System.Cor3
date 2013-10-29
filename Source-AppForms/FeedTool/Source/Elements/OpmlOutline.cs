using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml;

namespace FeedTool.Forms
{
	public class OpmlOutline : XPathItem
	{
		internal const string HTMLURL =	"/@htmlUrl";
		internal const string OUTLINE =	"/outline";
		internal const string XMLURL =	"/@xmlUrl";
		internal const string TITLE =	"/@title";
		internal const string TEXT =	"/@text";
		internal const string TYPE =	"/@type";
		
		public List<OpmlOutline> ELEMENTS { get;set; }
		
		public string HtmlText { get;set; }
		public string HtmlUrl { get;set; }
		public string Text { get;set; }
		public string Title { get;set; }
		public string Type { get;set; }
		public string XmlUrl { get;set; }

		public OpmlOutline(){  }
		public OpmlOutline(XmlNode node, string root)
		{
			XMLROOT = root;
			Debug.Print("get-attributes:begin");
			if (node.Attributes["text"]!=null) Text =			node.Attributes["text"].Value;
			if (node.Attributes["htmlText"]!=null) HtmlText =	node.Attributes["htmlText"].Value;
			if (node.Attributes["htmlUrl"]!=null) HtmlUrl =		node.Attributes["htmlUrl"].Value;
			if (node.Attributes["type"]!=null) Type =			node.Attributes["type"].Value;
			if (node.Attributes["title"]!=null) Title =			node.Attributes["title"].Value;
			if (node.Attributes["xmlUrl"]!=null) XmlUrl =		node.Attributes["xmlUrl"].Value;
			Debug.Print("get-attributes:end");
			
			Debug.Print("Text=“{0}”",Text);

			ELEMENTS =	new List<OpmlOutline>();
			
			// CHILDREN
			string newroot = GetPath(OUTLINE);
			XmlNodeList list = node.OwnerDocument.DocumentElement.SelectNodes(newroot);
			int numChildren = list.Count;
			
			Debug.Print("get-children-begin: {0}, Count: {1}",newroot,numChildren);
			for (int i= 0; i < numChildren; i++)
			{
				string newPath = GetPath(newroot,i+1);
				Debug.Print("elm-begin: {0}::{1}",i,newPath);
				OpmlOutline childOutline = new OpmlOutline(list[i],newPath);
				ELEMENTS.Add(childOutline);
				Debug.Print("elm-end: {0}::{1}",i,newPath);
			}
			Debug.Print("get-children-end: {0}", newroot);
			
		}
		public OpmlOutline(DataRowView row)
		{
			if (row["Text"]!=DBNull.Value) Text = row["Text"] as string;
			if (row["HtmlUrl"]!=DBNull.Value) HtmlUrl = row["HtmlUrl"]as string;
			if (row["HtmlText"]!=DBNull.Value) HtmlText = row["HtmlText"]as string;
			if (row["ELEMENTS"]!=DBNull.Value) ELEMENTS = row["ELEMENTS"] as List<OpmlOutline>;
		}
	}
}
