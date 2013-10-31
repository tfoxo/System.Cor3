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
	public class FeedCollection : System.IO.SerializableClass<FeedCollection>
	{
		public FeedCollection(){}
		
		[System.Xml.Serialization.XmlElement("enclosure")]
		public List<FeedDataItem> Items { get; set; }
	}
}
