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

namespace FeedTool.Loaders
{
	public class MasterFeedNode : BasicFeedNode // BasicFeedNode
	{
		public string       Key      { get;set; }
		public FeedListItem ListItem { get;set; }
		public FeedParser   Parser   { get;set; }
		public UriDownloader Downloader { get; set; }
		
		public ObservableCollection<NodeInfo> Children { get;set; }
		
		public void GetChildren(MasterFeedNode parent) {
			foreach (NodeInfo n in Parser.Xml.Nodes)
			{
				n.Parent = parent;
				Children.Add(n);
			}
		}
		public MasterFeedNode()
		{
			ListItem = new FeedListItem();
			Parser = new FeedParser();
			Downloader = new UriDownloader();
			Key = string.Empty;
			Children = new ObservableCollection<NodeInfo>();
		}
	}
}
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