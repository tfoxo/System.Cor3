/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/6/2013
 * Time: 6:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml;

using FeedTool.Converters;
using Microsoft.Win32;

namespace FeedTool.Loaders
{
	public class BasicFeedNode
	{
		public string Name {
			get { return name; }
			set { name = value; }
		} string name;
		
		public string Text {
			get { return text; }
			set { text = value; }
		} string text;
		
		public NodeInfo Tag {
			get { return tag; }
			set { tag = value; }
		} NodeInfo tag;
		
	}
}
