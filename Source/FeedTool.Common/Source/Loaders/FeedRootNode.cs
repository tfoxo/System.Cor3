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
	/// <summary>
	/// In a hierarchical MV/VM pattern, we construct a class which represents
	/// the root node of our tree.
	/// <para>This particular model was designed for a <tt>System.Windows.Forms.TreeView.Tag</tt>
	/// as can be noticed by usage of <tt>SelectedImageKey</tt></para>
	/// </summary>
	public class FeedRootNode : BasicFeedNode
	{
		/// <summary>
		/// I don't know how this will be used yet
		/// </summary>
		public string ImageKey {
			get;
			set;
		} 
		
		/// <summary>
		/// I don't know how this will be used yet
		/// </summary>
		public string SelectedImageKey {
			get;
			set;
		} 
		
		/// <summary>
		/// We will just be using a one or zero
		/// </summary>
		public int DownloadProgress {
			get;
			set;
		} 
	}
}
