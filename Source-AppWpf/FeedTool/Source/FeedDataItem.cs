/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 2/18/2013
 * Time: 8:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;

namespace FeedTool
{
	/// <summary>
	/// This item represents our input such as a URI request to a particular
	/// RSS/XML URL REQUEST.
	/// </summary>
	public class FeedDataItem
	{
		[System.Xml.Serialization.XmlAttribute]
		public string GroupID { get;set; }
		
		[System.Xml.Serialization.XmlAttribute]
		public string Title { get;set; }
		
		[System.Xml.Serialization.XmlAttribute]
		public string Category { get;set; }
		
		[System.Xml.Serialization.XmlAttribute]
		public string Url { get;set; }
		
		[System.Xml.Serialization.XmlAttribute, System.ComponentModel.DefaultValue(0)]
		public int Order { get;set; }
		
		public FeedDataItem(){}
		public FeedDataItem(DataRowView row)
		{
			if (row["GroupID"]!=DBNull.Value)		Title = row["GroupID"] as string;
			if (row["Title"]!=DBNull.Value)		Title = row["Title"] as string;
			if (row["Category"]!=DBNull.Value)	Category = row["Category"] as string;
			if (row["Url"]!=DBNull.Value)		Url = row["Url"] as string;
			if (row["Order"]!=DBNull.Value)		Order = (row["Order"] as int?).Value;
		}
		public void ToRow(DataRowView row)
		{
			row["GroupID"] = GroupID;
			row["Title"] = Title;
			row["Category"] = Category;
			row["Url"] = Url;
			row["Order"] = Order;
		}
	}
}
