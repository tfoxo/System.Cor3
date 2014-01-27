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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Xml;

using FeedTool.Converters;
using Microsoft.Win32;

namespace FeedTool.Loaders
{
	/// <summary>
	/// Description of ModelLoader.
	/// </summary>
	public class ModelLoader : IFeedAppAPI, INotifyPropertyChanged
	{
		public int? AllItemsProgress {
			get { return allItemsProgress; }
			set { allItemsProgress = value; }
		} int? allItemsProgress = 0;
		
		public int  AllItemsProgressMin = 0;
		public int  AllItemsProgressMax = 0;
		
		public ObservableCollection<MasterFeedNode> Items;
		
		#region Important Dictionary
		/// <summary>
		/// a set of strings where key is the name, value is the url
		/// </summary>
		Dictionary<string, FeedListItem> FeedDictionary { get; set; }
		/// <summary>
		/// key is name, value is the xmlinfo
		/// </summary>
		Dictionary<string, FeedParser> XmlList { get; set; }
		#endregion
		
		const string DefaultFileName = "initial-data-set.txt";
		
		readonly OpenFileDialog ofd_text = new OpenFileDialog { Filter = "Feed Text|*.txt;*.text|All Files|*" };
		readonly OpenFileDialog ofd_AllXml = new OpenFileDialog { Filter = "Xml File|*.xml;*.rss*.opml*.feed|All Files|*" };
		readonly OpenFileDialog ofd_opml = new OpenFileDialog { Filter = "OPML File|*.opml;*.xml|All Files|*" };

		readonly SaveFileDialog sfd_xml = new SaveFileDialog { Filter = "Xml File|*.xml;*.rss*.opml*.feed|All Files|*" };
		readonly SaveFileDialog sfd_txt = new SaveFileDialog { Filter = "Feed Text|*.txt;*.text|All Files|*" };
		
		public string CurrentFeedTextFileName {
			get { return currentFeedTextFileName; }
			set { currentFeedTextFileName = value; }
		} string currentFeedTextFileName = DefaultFileName;
		
		/// <summary>
		/// Not implemented.
		/// </summary>
		public void Event_TextSave(object sender, RoutedEventArgs args)
		{
		}
		public void Event_TextLoad(object sender, RoutedEventArgs args)
		{
			bool? value = ofd_text.ShowDialog();
			if (value.HasValue && value.Value) {
				CurrentFeedTextFileName = ofd_text.FileName;
				RefreshFeed();
			}
		}
		public void RefreshFeed()
		{
			// Loads feeds to dictionary.
			GetFeedsFile(CurrentFeedTextFileName);
			//	LoadFeedSet();
		}
		public void GetFeedsFile(string fileName)
		{
//			FeedDictionary = FeedListItemConverter.TextToDictionary(fileName) as Dictionary<string, FeedListItem>;

			//GetGridViewFromText(fileName);
			/*PrepareTreeFromFeedsList();*/
			// – add each treenode to the tree or list-view.
			// – add XmlList (XmlInfo dictionary with new XmlDocument elements)
			// Clear anything needing clearing
			ResetControls();
			ProcessFeedDictionary(fileName);
		}
		
		/// <summary>
		/// 1.1
		/// <para>Clear TreeView Nodes</para>
		/// <para>Reset Progress Bar</para>
		/// </summary>
		public void ResetControls()
		{
//			treeView1.Nodes.Clear();
			//
			AllItemsProgress = 0;
			AllItemsProgressMin = 0;
			AllItemsProgressMax = 1;
		}
		/// <summary>
		/// 1.2
		/// <para>Create XML List (Dictionary).</para>
		/// <para>Iterate FeedDictionary of FeedListItmes.</para>
		/// <para>Creates a blank ActionCompleted Delegate.</para>
		/// <para>Adds a TreeNode to the treeview (winforms).</para>
		/// <para></para>
		/// </summary>
		public void PrepareTreeFromFeedsList()
		{
		}
		
		/// <summary>
		/// <para>1.3 parse content and build ui tree-nodes for each dictionary-FeedListItem in the FeedDictionary.</para>
		/// </summary>
		public void ProcessFeedDictionary() {}
		public void ProcessFeedDictionary(string fileName)
		{
			// begin:PreparTreeFromFeedsList
			// =====================================================================
			Items = FeedListItemConverter.TextToMaster(fileName);
//			this.PropertyChanged(this,new PropertyChangedEventArgs("Items"));
			
			// end:PreparTreeFromFeedsList
			// =====================================================================
			// we should be able to bind to a dictionary
			foreach (MasterFeedNode pair in Items) {
				string k = pair.Key;
				string v = pair.ListItem.url;
				// Create the URI downloader
				pair.Downloader = new UriDownloader {
					UriAddress = pair.ListItem.url,
					OnComplete = delegate(UriDownloader downloader)
					{
						if (downloader.HasException) AllItemsProgress++;
						else System.Diagnostics.Debug.Print("Got XmlList Content, continuing");
						pair.Parser.Content = downloader.Content;
						pair.Parser.ActionCompleted = () => {
							//							try {
							if (!string.IsNullOrEmpty(pair.Parser.Content))
								pair.ListItem.content = pair.Parser.Content;
							AllItemsProgress++;
							if (AllItemsProgress.Value == AllItemsProgressMax) {
								AllItemsProgress = 0;
								CheckForErrors();
							}
							System.Diagnostics.Debug.Print("DownloadUrl Completed Loading/Parsing Child elements");
							pair.GetChildren(pair);
							//							} catch (Exception exception) {
							//								MessageBox.Show(string.Concat(exception.Message,"\r",exception.Source));
							//							}
						};
						pair.Parser.Run();
					}
				};
				try {
					System.Diagnostics.Debug.Print("executing-downloader");
					pair.Downloader.Run();
				} catch				/* (Exception ex)*/ {
					System.Diagnostics.Debug.Print("download-exception...");
				}
				// UriDownloader dl = new UriDownloader {}
				// Create the URI downloader
			}
		}
		/// <summary>
		/// ModelLoader requires that first a file is loaded.
		/// </summary>
		public ModelLoader()
		{
			Items = new ObservableCollection<MasterFeedNode>();
		}
		
		public void CheckForErrors(bool refreshChildren = false)
		{
//			throw new NotImplementedException();
		}
		public void LoadFeedSet()
		{
			throw new NotImplementedException();
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
	}
	public interface IFeedAppAPI
	{
		
		#region Processing Methods
		/// <summary>
		/// Once data is collected, this is called to send hierarchical
		/// data to the main Tree-Nodes's Children.
		/// <para>Also shows error information if present.</para>
		/// </summary>
		void CheckForErrors(bool refreshChildren);
		/// <summary>
		/// 1. Main Loader Capsule
		/// </summary>
		void LoadFeedSet();
		/// <summary>
		/// 1.1
		/// <para>Clear TreeView Nodes</para>
		/// <para>Reset Progress Bar</para>
		/// </summary>
		void ResetControls();
		/// <summary>
		/// 1.2
		/// <para>Create XML List (Dictionary).</para>
		/// <para>Iterate FeedDictionary of FeedListItmes.</para>
		/// <para></para>
		/// </summary>
		void PrepareTreeFromFeedsList();
		/// <summary>
		/// 1.3
		/// <para>parse content and build ui tree-nodes for each dictionary-FeedListItem in the FeedDictionary.</para>
		/// </summary>
		/// <remarks>
		/// This method happens to go a bit overboard in how it manages to get the tree-node information updated for each parsed element.
		/// </remarks>
		void ProcessFeedDictionary();
		void ProcessFeedDictionary(string filename);
		#endregion
//		void Event_FeedContextItem(object sender, RoutedEventArgs args);
//		void Event_FeedContextItem(object sender, RoutedEventArgs args);
	}
	public interface IFeedAppAPI_Events
	{
		#region Event handlers
		void Event_FeedContextItem(object sender, RoutedEventArgs args);
		void Event_ListBox_SelectedIndexChange(object sender, RoutedEventArgs args);
		void Event_NodeMouseClick(object sender, RoutedEventArgs args);
		void Event_ReloadAll(object sender, RoutedEventArgs args);
		void Event_RootContextItem(object sender, RoutedEventArgs args);
		void Event_TimedSelection(object sender, RoutedEventArgs args);
		void Event_TreeView_DoubleClick(object sender, RoutedEventArgs args);
		void Event_TryLoadOPML(object sender, RoutedEventArgs args);
		#endregion
		#region File-Load/Save
		void LoadTextToolStripMenuItemClick(object sender, RoutedEventArgs args);
		void SaveTextToolStripMenuItemClick(object sender, RoutedEventArgs args);
		#endregion

	}
	public interface IFeedEditorAPI
	{
		void ChangeFormat(object sender, EventArgs args);
	}
}
