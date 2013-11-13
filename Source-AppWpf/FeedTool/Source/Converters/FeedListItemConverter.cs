using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml;

using FeedTool.Loaders;

namespace FeedTool.Converters
{
	public class FeedListItemConverter
	{
		public string FeedTextFile { get;set; }
		public IList<FeedListItem> Items { get;set; }
		
		#region GetText
		
		/// <summary>
		/// using cr+lf terminator by default.
		/// <para>list to string.</para>
		/// </summary>
		public string GetText()
		{
			return GetText("\r\n");
		}
		/// <summary>
		/// list to string.
		/// </summary>
		/// <param name="lineterminator"></param>
		/// <returns></returns>
		public string GetText(string lineterminator)
		{
			if (Items.Count==0) return null;
			List<string> list = new List<string>();
			foreach (FeedListItem item in Items)
			{
				if (string.IsNullOrEmpty(item.title)||string.IsNullOrEmpty(item.url)) continue;
				list.Add(string.Format("{0}|{1}",item.title,item.url));
			}
			string result = string.Join(lineterminator,list.ToArray());
			list.Clear();
			list = null;
			return result;
		}

		#endregion
		
		/// <summary>
		/// if FeedTextFile exists, provides Items to list.
		/// </summary>
		public void Refresh()
		{
			if (string.IsNullOrEmpty(FeedTextFile)) return;
			if (!System.IO.File.Exists(FeedTextFile)) return;
			Items = GetList();
		}
		
		#region GetList
		public IList<FeedListItem> GetList()
		{
			return GetList(true);
		}
		public IList<FeedListItem> GetList(bool sort)
		{
			return TextToList(FeedTextFile,sort);
		}
		#endregion
		
		// not referenced
		public IDictionary<string,FeedListItem> GetDictionary(bool sortByTitle=true)
		{
			return TextToDictionary(FeedTextFile,sortByTitle);
		}
		
		public FeedListItemConverter() { }
		
		#region Static
		/// <summary>
		/// Converts a FeedDataConverter to a list of FedListItem(s).
		/// </summary>
		/// <param name="converter"></param>
		/// <returns>List&lt;FeedListItem&gt;</returns>
		static public List<FeedListItem> GetData(FeedDataConverter converter)
		{
			List<FeedListItem> list = new List<FeedListItem>();
			converter.UpdateItems();
			foreach (FeedDataItem item in converter.Items)
				list.Add(new FeedListItem{ title=item.Title,url=item.Url });
			return list;
		}
		// not referenced
		static public IList<FeedListItem> TextToList(string fileName) { return TextToList(fileName,true); }
		/// <summary>
		/// Here we are obtaining a list of FeedListItems.
		/// <para>FeedListItem is interchangable from DataRowView.</para>
		/// <para>The only elements used from FeedListItem are Title and Url.</para>
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="sort"></param>
		/// <returns></returns>
		static public IList<FeedListItem> TextToList(string fileName, bool sort)
		{
			FileInfo file = new FileInfo(fileName);
			string files = File.ReadAllText(fileName);
			
			Stack<string> FeedsStack = new Stack<string>(files.Split('\n'));
			FeedsStack.Reverse();
			
			List<FeedListItem> feedsList = new List<FeedListItem>();
			
			//
			while (FeedsStack.Count > 0) {
				string[] currentNode;
				string currentItem = FeedsStack.Pop().Trim('\r','\n');
				//
				if (string.IsNullOrEmpty(currentItem)) continue;
				else if (currentItem[0]=='#') continue;
				//
				currentNode = currentItem.Split('|');
				if (currentNode[0] == null || currentNode[1] == null) continue;
				feedsList.Add( new FeedListItem {groupid=currentNode[0],title=currentNode[1],url=currentNode[2]} );
			}
			feedsList.Sort(delegate(FeedListItem a, FeedListItem b) { return a.SortName.CompareTo(b.SortName); });
			return feedsList;
		}
		/// <summary>
		/// Used by the main app to get a dictionary of FeedListItems.
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="sortByTitle"></param>
		/// <returns></returns>
		static public IDictionary<string,FeedListItem> TextToDictionary(string fileName, bool sortByTitle=true)
		{
			Dictionary<string,FeedListItem> FeedsDictionary = new Dictionary<string,FeedListItem>();
			foreach (FeedListItem feed in TextToList(fileName,sortByTitle)) FeedsDictionary.Add(feed.title,feed);
			return FeedsDictionary;
		}
		/// <summary>
		/// Used by the main app to get a dictionary of FeedListItems.
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="sortByTitle"></param>
		/// <returns></returns>
		static public ObservableCollection<MasterFeedNode> TextToMaster(string fileName, bool sortByTitle=true)
		{
			ObservableCollection<MasterFeedNode> items = new ObservableCollection<MasterFeedNode>();
			foreach (FeedListItem feed in TextToList(fileName,sortByTitle)) items.Add(
				new MasterFeedNode{
					Key=feed.title,
					ListItem=feed,
					Parser=new FeedParser {
						ActionCompleted=delegate{},
						Xml=new XmlInfo { Doc=new XmlDocument() }
					}
				}
			);
			return items;
		}
		#endregion
	}
}
