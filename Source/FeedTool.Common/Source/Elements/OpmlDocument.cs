using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;

namespace FeedTool.Elements
{
	/// <summary>
	/// Given the obvious derivation in XPathItem
	/// </summary>
	public class OpmlDocument : XPathItem
	{
		public XmlDocument XML { get;set; }
		
		public const string ROOT =		"//opml";
		public const string TITLE =		"/head/title";
		public const string OUTLINE =	"/body/outline";
		
		public string Title { get;set; }
		public List<OpmlOutline> ELEMENTS { get;set; }
		
		public OpmlDocument() {}
		public OpmlDocument(string xmlContent) : base()
		{
			XMLROOT = ROOT;
			XML = new XmlDocument();
			bool gotxml = true;
			{
				try{ XML.LoadXml(xmlContent); }
				catch { gotxml = false; }
			}
			if (!gotxml) return;
			
			// TITLE
			XmlNode titlenode = XML.FirstChild.SelectSingleNode( GetPath(TITLE) );
			if (titlenode!=null) Title = titlenode.InnerText;
			Debug.Print("OPML Document Title: {0}",Title);
			
			// CHILDREN
			int index = 1;
			foreach (XmlNode child in XML.FirstChild.SelectNodes(GetPath(OUTLINE)))
			{
				ELEMENTS.Add(new OpmlOutline(child,GetPath(++index,OUTLINE)));
				Debug.Print(child.Name);
			}

		}
		/// <exception cref="T:System.Exception"></exception>
		public OpmlDocument(FileInfo xmlContent) : base()
		{
			XMLROOT = ROOT;
			XML = new XmlDocument();
			bool gotxml = true;
			{
				try{ XML.Load(xmlContent.FullName); }
				catch { gotxml = false; }
			}
			if (!gotxml) return;
			
			// TITLE
			XmlNode titlenode = XML.DocumentElement.SelectSingleNode( GetPath(TITLE) );
			if (titlenode!=null) Title = titlenode.InnerText;
			Debug.Print("OPML Document Title: {0}",Title);
			
			ELEMENTS = new List<OpmlOutline>();
			
			// CHILDREN
			string newroot = GetPath(OUTLINE);
			XmlNodeList list = XML.DocumentElement.SelectNodes(newroot);
			int numChildren = list.Count;
			Debug.Print("{0}, Count: {1}",newroot,numChildren);
			for (int i= 0; i < numChildren; i++)
			{
				try{
					
					string newPath = GetPath(newroot,i+1);
					Debug.Print("doc:begin: {0}::{1}",i,newPath);
					
					var childOutline = new OpmlOutline(list[i],newPath);
					ELEMENTS.Add(childOutline);
					
					Debug.Print("doc:end: {0}::{1}",i,newPath);
				}
				catch (Exception exception)
				{
					throw exception;
				}
			}
			Debug.Print("passed iteration.\nend of opml reader.");
		}
	}
}
