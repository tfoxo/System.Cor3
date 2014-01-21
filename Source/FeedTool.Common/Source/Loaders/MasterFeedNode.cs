/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/6/2013
 * Time: 6:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FeedTool.Loaders
{
	/// <summary>
	/// Level 1
	/// </summary>
	public class MasterFeedNode : BasicFeedNode, INotifyPropertyChanged // BasicFeedNode
	{
		
		void Initialize(){
			
		}
		
		#region Properties
		public string       Key      { get;set; }
		public FeedListItem ListItem { get;set; }
		public FeedParser   Parser   { get;set; }
		public UriDownloader Downloader { get; set; }
		
		public bool HasPages { get; set; }
		public int ItemsPerPage { get; set; }
		public int PageCount { get; set; }
		
		public int NumChildren       { get { return Children==null ? 0 : Children.Count; } }
		
		public ObservableCollection<NodeInfo> Children { get;set; }
		#endregion
		
		public void GetChildren(MasterFeedNode parent)
		{
			foreach (NodeInfo n in Parser.Xml.Nodes)
			{
				n.Parent = parent;
				Children.Add(n);
			}
//			OnPropertyChanged("NumChildren");
		}
		
		public MasterFeedNode()
		{
			ListItem = new FeedListItem();
			Parser = new FeedParser();
			Downloader = new UriDownloader();
			Key = string.Empty;
			Children = new ObservableCollection<NodeInfo>();
		}
		
		protected virtual void OnPropertyChanged(string property)
		{
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		} public event PropertyChangedEventHandler PropertyChanged;
	}
}
#region Mess
//				if (n is YtFeedEntry) {new TreeNode {
//					               	Name = n.Name,
//					               	Text = n.Name,
//					               	Tag = n,
//					               	ImageKey = "ui-radio-button-uncheck.png",
//					               	SelectedImageKey = "ui-radio-button.png"
//					               }
//				} else if (n is RssNode) {
//					node.Nodes.Add(new TreeNode {
//					               	Name = n.Name,
//					               	Text = n.Name,
//					               	Tag = n,
//					               	ImageKey = "ui-radio-button-uncheck.png",
//					               	SelectedImageKey = "ui-radio-button.png"
//					               });
//				} else if (n is AtomEntry) {
//					node.Nodes.Add(new TreeNode {
//					               	Name = n.Name,
//					               	Text = n.Name,
//					               	Tag = n,
//					               	ImageKey = "ui-radio-button-uncheck.png",
//					               	SelectedImageKey = "ui-radio-button.png"
//					               });
//				}
#endregion