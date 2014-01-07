/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 1/31/2013
 * Time: 12:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

using FeedTool.Loaders;

namespace FeedTool
{
	/// <summary>
	/// A basic class designed as a hierarchical tree-node by providing a Parent entry
	/// (pointing to type: MasterFeedNode/Level 1) and also prviding 'Children' nodes
	/// however this particular type is used for LEVEL 2 within the tree.
	/// That is, our MasterFeedNode is LEVEL 1 and the children are all going
	/// to derive from this (NodeInfo) type.
	/// </summary>
	abstract public class NodeInfo
	{
		
		internal const string linkFormat = @"<a title=""{0}"" href=""{1}""{2}>{3}</a>";
		
		public MasterFeedNode Parent { get; set; }
		
		/// <summary>
		/// ddd, MM-dd-yyyy hh:mm:ss
		/// </summary>
		static public string dateFmt = "ddd, MM-dd-yyyy hh:mm:ss";
		
		internal static readonly string nullString = string.Empty;
		
		#region Generate(d) Html Hyper-Links
		
		public IDictionary<string,string> HtmlLinks {
			get { return htmlLinks; }
		} internal Dictionary<string,string> htmlLinks = new Dictionary<string,string>();
		
		virtual public void GenerateLinks()
		{
		}

		#endregion
		
		#region Properties
		
		/// <summary>
		/// For rss item, this would be “//channel/item[#index]”
		/// </summary>
		public string ItemPath { get;set; }

		virtual public string Content { get; set; }
		
		virtual public string Description { get; set; }
		
		virtual public string DefaultContent
		{
			get {
				return string.IsNullOrEmpty(Content) ? Description : Content;
			}
		}

		abstract internal Dictionary<string,string> Infos { get; }
		
		virtual public string Name { get { throw new NotImplementedException(); } }
		
		public int Index { get;set; }

		#endregion
		
		#region HtmlText
		
		abstract public string HtmlText { get; }
		
		#endregion
		
		public DateTime? CheckDate(string origin)
		{
			DateTime? dt;
			try   { dt = DateTime.Parse(origin); }
			catch { dt = null; }
			return dt;
		}
		
		#region Xml (and/or XPath) Parsing Methods
		
		abstract public void Parse(XmlDocument doc, XmlNamespaceManager man);
		
		/// <summary>
		/// Returns null or the value if present.
		/// </summary>
		internal string TryGetText(XmlDocument doc, XmlNamespaceManager man, ref XmlNode node, string key)
		{
			string result = nullString;
			try
			{
				result = GetNodeText(doc, man, ref node, key);
			} catch {
			}
			
			return result;
		}
		
		internal string GetNodeText(XmlDocument doc, XmlNamespaceManager man, ref XmlNode node, string nodeName)
		{
			node = GetNode(doc,man,nodeName);
			return node==null ? nullString : node.InnerText;
		}
		
		internal XmlNode GetNode(XmlDocument doc, XmlNamespaceManager man, string dicPath)
		{
			return man!=null ?
				doc.DocumentElement.SelectSingleNode(GetPath(Infos[dicPath]),man):
				doc.DocumentElement.SelectSingleNode(GetPath(Infos[dicPath]));
		}
		
		internal string GetPath(string toAdd)
		{
			return ItemPath+toAdd;
		}
		
		internal XmlNode GetNode(XmlNode root, XmlNamespaceManager man, string path)
		{
			return root.SelectSingleNode(GetPath(path),man);
		}
		
		internal XmlNodeList GetNodes(XmlNode root, XmlNamespaceManager man, string path)
		{
			return root.SelectNodes(GetPath(path),man);
		}
		
		#endregion
		
	}
}
