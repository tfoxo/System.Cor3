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
	public class FeedRootNode : BasicFeedNode
	{
		/// <summary>
		/// I don't know how this will be used yet
		/// </summary>
		public string ImageKey {
			get { return imageKey; }
			set { imageKey = value; }
		} string imageKey;
		/// <summary>
		/// I don't know how this will be used yet
		/// </summary>
		public string SelectedImageKey {
			get { return selectedImageKey; }
			set { selectedImageKey = value; }
		} string selectedImageKey;
		/// <summary>
		/// We will just be using a one or zero
		/// </summary>
		public int DownloadProgress {
			get { return downloadProgress; }
			set { downloadProgress = value; }
		} int downloadProgress;
	}
}
