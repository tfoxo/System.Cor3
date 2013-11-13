using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

using DspAudio.Formats;
using FeedTool.Converters;

namespace FeedTool.Forms
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private System.Windows.Forms.ContextMenuStrip ctx0;
		
		Options AppOptions = new Options();

		public object ContextSelection {
			get { return contextSelection; }
			set { contextSelection = value; }
		}
		object contextSelection = null;
		
		NodeInfo selectednode;
		FeedDataConverter GridViewer = new FeedDataConverter();
		
		static long counter = 0;
		MainMenu mrMenu = new MainMenu();

		#region Program
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread()]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//            try {
			Application.Run(new MainForm());
			//            }catch{}
		}

		#endregion

		#region Constants
		static Font LabelFont = new Font("Segoue UI", 8.5f, FontStyle.Bold, GraphicsUnit.Point);
		const string feed_unloaded = "feed--exclamation.png";
		const string feed_loaded = "feed.png";
		const string feed_podcast = "podcast.png";
		const string feed_youtube = "youtube.ico";
		const string feed_rdf = "feed-rdf.png";
		const string feed_atom = "feed-atom.png";
		const string feed_selected = "feed-document.png";
		#endregion

		#region Form Properties
		
		OpenFileDialog ofd_text = new OpenFileDialog { Filter = "Feed Text|*.txt;*.text|All Files|*" };
		OpenFileDialog ofd_AllXml = new OpenFileDialog { Filter = "Xml File|*.xml;*.rss*.opml*.feed|All Files|*" };
		OpenFileDialog ofd_opml = new OpenFileDialog { Filter = "OPML File|*.opml;*.xml|All Files|*" };
		
		Timer SelectorTimer = new Timer { Interval = 300 };
		
		SaveFileDialog sfd_xml = new SaveFileDialog { Filter = "Xml File|*.xml;*.rss*.opml*.feed|All Files|*" };
		SaveFileDialog sfd_txt = new SaveFileDialog { Filter = "Feed Text|*.txt;*.text|All Files|*" };
		
		// for Tree Selection Handler
		Point MousePoint {
			get { return new Point(MousePosition.X, MousePosition.Y); }
		}
		#endregion

		#region Feed App Properties

		XmlInfo xmldoc;

		[System.ComponentModel.DefaultValue("")]
		public string ErrorLog { get; set; }

		/// <summary>
		/// FileName of the current feed, as obtained by OpenFileDialog
		/// </summary>
		string CurrentFeedTextFileName { get; set; }

		/// <summary>
		/// a set of strings where key is the name, value is the url
		/// </summary>
		Dictionary<string, FeedListItem> FeedDictionary { get; set; }
		/// <summary>
		/// key is name, value is the xmlinfo
		/// </summary>
		Dictionary<string, FeedParser> XmlList { get; set; }

		#endregion

		public MainForm()
		{
			InitializeComponent();

			WindowsInterop.WindowsTheme.HandleTheme(this.treeView1, false);
			
			mrMenu.MenuItems.Add(
				"Actions",
				new MenuItem[] {
					new MenuItem("Refresh All", this.Event_ReloadAll, Shortcut.CtrlShiftL),
					new MenuItem("Load Text File", LoadTextToolStripMenuItemClick, Shortcut.CtrlL),
					new MenuItem("Load XML (*.feeds) File", LoadXMLToolStripMenuItemClick),
					new MenuItem("-"),
					new MenuItem("E&xit", delegate { Close(); })
				});
			mrMenu.MenuItems.Add("More Actions", new MenuItem[] { new MenuItem("Load OPML", Event_TryLoadOPML) });
			
			//            this.Controls.Add(mrMenu);
			this.Menu = mrMenu;

			CurrentFeedTextFileName = "initial-data-set.txt";

			SelectorTimer.Tick += Event_TimedSelection;
			// not used
			
			this.ctx0 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ctx0.Name = "ctx0";
			this.ctx0.Size = new System.Drawing.Size(61, 4);
			ctx0.Items.AddRange(
				new ToolStripItem[] { new ToolStripMenuItem { Name = "nodeLabel", Font = LabelFont },
					new ToolStripMenuItem { Text = "Show Content", Name = "browseContent" },
					new ToolStripSeparator { },
					new ToolStripMenuItem { Text = "Add Feed", Name = "n2" },
					new ToolStripSeparator { },
					new ToolStripMenuItem { Text = "Export Xml/Feed/Podcast Item", Name = "export" }
				});
			ctx1.Items.AddRange(
				new ToolStripItem[] {
					new ToolStripMenuItem { Name = "nodeLabel", Font = LabelFont },
					new ToolStripMenuItem { Text = "Parent Node: Show Content", ToolTipText = "Show Content in the Browser tab.", Name = "browseContent" }
				});
			ctx0.Items["browseContent"].Click += Event_RootContextItem;
			ctx0.Items["export"].Click += Event_RootContextItem;
			ctx1.Items["browseContent"].Click += Event_FeedContextItem;
			
			foreach (string name in TextEditorUtil.GetHighlighters()) {
				editorFormatsToolStripMenuItem.DropDownItems.Add(name, null, ChangeFormat);
			}

			textEditor.SetHighlighting("XML");

			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Event_NodeMouseClick);
			this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Event_TreeView_DoubleClick);
			//            this.refreshSelectedToolStripMenuItem.Click += new System.EventHandler(this.Event_LoadText);
			this.refreshAllToolStripMenuItem.Click += new System.EventHandler(this.Event_ReloadAll);
		}

		#region ICSharpCode.TextEditor Utility EventHandler
		/// <summary>
		/// TextEditor Text-Format changer.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		void ChangeFormat(object sender, EventArgs args)
		{
			textEditor.SetHighlighting((sender as ToolStripItem).Text);
		}

		#endregion

		#region Load Process

		/// <summary>
		/// 1.1
		/// <para>Clear TreeView Nodes</para>
		/// <para>Reset Progress Bar</para>
		/// </summary>
		void ResetControls()
		{
			treeView1.Nodes.Clear();
			//
			toolStripProgressBar1.Value = 0;
			toolStripProgressBar1.Minimum = 0;
			toolStripProgressBar1.Maximum = FeedDictionary.Count;
		}

		/// <summary>
		/// 1.2
		/// <para>Create XML List (Dictionary).</para>
		/// <para>Iterate FeedDictionary of FeedListItmes.</para>
		/// <para>Creates a blank ActionCompleted Delegate.</para>
		/// <para>Adds a TreeNode to the treeview (winforms).</para>
		/// <para></para>
		/// </summary>
		void PrepareTreeFromFeedsList()
		{
			//
			XmlList = new Dictionary<string, FeedParser>();
			// Create XML Document and TreeNode for each element in the dictionary
			foreach (KeyValuePair<string, FeedListItem> pair in FeedDictionary) {
				XmlList.Add(
					pair.Key, new FeedParser {
						ActionCompleted = delegate { },
						Xml = new XmlInfo { Doc = new XmlDocument() }
					});
				treeView1.Nodes.Add(
					new TreeNode {
						Name = pair.Key,
						Text = pair.Key,
						ImageKey = feed_unloaded,
						SelectedImageKey = feed_selected
					});
			}
		}
		/// <summary>
		/// 1.3
		/// <para>parse content and build ui tree-nodes for each dictionary-FeedListItem in the FeedDictionary.</para>
		/// </summary>
		/// <remarks>
		/// This method happens to go a bit overboard in how it manages to get the tree-node information updated for each parsed element.
		/// </remarks>
		void ProcessFeedDictionary()
		{
			foreach (KeyValuePair<string, FeedListItem> pair in FeedDictionary) {

				string k = pair.Key;
				string v = pair.Value.url;

				UriDownloader dl = new UriDownloader {
					UriAddress = pair.Value.url,
					OnComplete = delegate(UriDownloader downloader) {
						if (downloader.HasException) {
							toolStripProgressBar1.Value++;
							return;
						} else {
							System.Diagnostics.Debug.Print("Got XmlList Content, continuing");
						}
						XmlList[k].Content = downloader.Content;
						XmlList[k].ActionCompleted = delegate {
							try {
								if (!string.IsNullOrEmpty(XmlList[k].Content)) {
									pair.Value.content = XmlList[k].Content;
								}
								toolStripProgressBar1.Value++;
								if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum) {
									toolStripProgressBar1.Value = 0;
									CheckForErrors();
								}
								System.Diagnostics.Debug.Print("DownloadUrl Completed Loading/Parsing Child elements");
								GetChildren(pair.Key);
							} catch {
								MessageBox.Show("?");
							}
						};
						XmlList[pair.Key].Run();

					}
				};
				try {
					System.Diagnostics.Debug.Print("executing-downloader");
					dl.Run();
				} catch				/* (Exception ex)*/ {
					System.Diagnostics.Debug.Print("download-exception...");
				}
			}
		}
		/// <summary>
		/// 1.
		/// </summary>
		void LoadFeedSet()
		{
			ResetControls();
			PrepareTreeFromFeedsList();
			ErrorLog = string.Empty;
			ProcessFeedDictionary();
		}

		/// <summary>
		/// Load a text file.  Each line (delimited by '@') contains
		/// the title of the feed, and the URL.
		/// <para>Each entry is added to FeedsList Dictionary.</para>
		/// </summary>
		/// <param name="fileName"></param>
		public void GetFeedsFile(string fileName)
		{
			FeedDictionary = FeedListItemConverter.TextToDictionary(fileName) as Dictionary<string, FeedListItem>;
			GetGridViewFromText(fileName);
		}

		/// <summary>
		/// Once data is collected, this is called to send hierarchical
		/// data to the main Tree-Nodes's Children.
		/// <para>Also shows error information if present.</para>
		/// </summary>
		void CheckForErrors(bool refreshChildren = false)
		{
			if (ErrorLog != string.Empty) {
				webBrowser1.DocumentText = ErrorLog;
				tabControl2.SelectedTab = tab1_www;
				return;
			}
			if (refreshChildren)// never true
				foreach (TreeNode node in treeView1.Nodes) {
				try {
					GetEntryNodes(node);
				} catch {

				}
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="key"></param>
		void GetChildren(string key)
		{
			TreeNode node = GetNode(key);

			GetEntryNodes(node);

			string noderoot = XmlList[node.Name].Xml.RootType;
			System.Diagnostics.Debug.Print("Parsing “{0}”", key);

			if (noderoot == "rss") {
				if (XmlList[node.Name].Xml.HasNSValue("http://www.itunes.com/dtds/podcast-1.0.dtd")) {
					System.Diagnostics.Debug.Print("Parser: “{0}”", "podcast");
					node.ImageKey = feed_podcast;
					node.SelectedImageKey = feed_podcast;
				} else {
					System.Diagnostics.Debug.Print("Parser: “{0}”", "unknown");
					node.ImageKey = feed_loaded;
					node.SelectedImageKey = feed_loaded;
				}
			} else if (noderoot == "feed") {
				System.Diagnostics.Debug.Print("FEED: {0}", XmlList[node.Name].Xml.Namespaces[""]);

				if (XmlList[node.Name].Xml.HasNSValue("http://gdata.youtube.com/schemas/2007")) {
					System.Diagnostics.Debug.Print("Parser: “{0}”", "youtube");
					node.ImageKey = feed_youtube;
					node.SelectedImageKey = feed_youtube;
				} else if (XmlList[node.Name].Xml.Namespaces[""] == "http://www.w3.org/2005/atom") {
					System.Diagnostics.Debug.Print("Parser: “{0}”", "atom");
					node.ImageKey = feed_atom;
					node.SelectedImageKey = feed_atom;
				} else {
					System.Diagnostics.Debug.Print("Parser: “{0}”", "unknown");
				}
			} else if (noderoot == "rdf:RDF") {
				System.Diagnostics.Debug.Print("Parser: “{0}”", "rdf");
				node.ImageKey = feed_rdf;
				node.SelectedImageKey = feed_rdf;
			} else {

			}
		}

		TreeNode GetNode(string key)
		{
			return treeView1.Nodes.Find(key, false)[0];
		}

		/// <summary>
		/// Called per node to populate children.
		/// <para>Obtains a set if Children TreeNodes!</para>
		/// <para>Mainly, this is where we update the item's ImageKey and SelectedImageKey.</para>
		/// </summary>
		/// <param name="node"></param>
		void GetEntryNodes(TreeNode node)
		{
			foreach (NodeInfo n in XmlList[node.Name].Xml.Nodes) {
				if (n is YtFeedEntry) {
					node.Nodes.Add(new TreeNode {
					               	Name = n.Name,
					               	Text = n.Name,
					               	Tag = n,
					               	ImageKey = "ui-radio-button-uncheck.png",
					               	SelectedImageKey = "ui-radio-button.png"
					               });
				} else if (n is RssNode) {
					node.Nodes.Add(new TreeNode {
					               	Name = n.Name,
					               	Text = n.Name,
					               	Tag = n,
					               	ImageKey = "ui-radio-button-uncheck.png",
					               	SelectedImageKey = "ui-radio-button.png"
					               });
				} else if (n is AtomEntry) {
					node.Nodes.Add(new TreeNode {
					               	Name = n.Name,
					               	Text = n.Name,
					               	Tag = n,
					               	ImageKey = "ui-radio-button-uncheck.png",
					               	SelectedImageKey = "ui-radio-button.png"
					               });
				}
			}
			treeView1.Invalidate();
		}

		void CreateSQLiteDatabaseToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach (KeyValuePair<string, FeedListItem> kvp in FeedDictionary) {
				//                if (kvp.Value is RssNode)
				//                    SQLiteFeeds.AddFeed(
				//                        Resource.Sqlite_Db_Feeds,
				//                        new Feeds{
				//                            title=(kvp.Value as RssNode).Title,
				//                            url=(kvp.Value as RssNode).Link,
				////                            ddt=DateTime.Now,
				////                            udt=DateTime.Now,
				//                            ddt=(kvp.Value as RssNode).PubDate,
				//                            udt=kvp.Value.CheckDate((kvp.Value as RssNode).OriginalDate)??DateTime.Today,
				//                            note=(kvp.Value as RssNode).Enclosure
				//                        }
				//                    );
				//                else if (kvp.Value is FeedEntry)
				//                    SQLiteFeeds.AddFeed(
				//                        Resource.Sqlite_Db_Feeds,
				//                        new Feeds{
				//                            title=(kvp.Value as FeedEntry).Title,
				//                            url=(kvp.Value as FeedEntry).Link,
				//                            ddt=(kvp.Value as FeedEntry).DatePublished,
				//                            udt=(kvp.Value as FeedEntry).DateUpdated,
				//                            note=(kvp.Value as FeedEntry).Enclosure,
				//                        }
				//                    );
			}
		}

		#endregion

		#region Load EventHandlers

		void RefreshFeed()
		{
			// Loads feeds to dictionary.
			GetFeedsFile(CurrentFeedTextFileName);
			LoadFeedSet();
		}

		void Event_ReloadAll(object sender, EventArgs e)
		{
			RefreshFeed();
		}

		#endregion

		/// <summary>
		/// Actual Node selection handler.
		/// </summary>
		/// <param name="selection"></param>
		void ItemSelector(		/*XmlInfo xmldoc, */NodeInfo selection)
		{
			if (SelectorTimer.Enabled)
				SelectorTimer.Stop();
			if (selection == null)
				return;

			selectednode = selection;

			if (xmldoc.RootType == "rss") {

				var xnode = selectednode as RssNode;
				textBox1.Text = xnode.Link;

				label1.Text = xnode.Title;
				label2.Text = xnode.Date;

				toolTip1.SetToolTip(linkLabel1, (linkLabel1.Text = xnode.Link));
				toolTip1.SetToolTip(linkLabel2, (linkLabel2.Text = xnode.Enclosure));

				xnode.GenerateLinks();
				webBrowser1.DocumentText = xnode.HtmlText;

			} else if (xmldoc.RootType == "feed") {

				// We're expecting a YouTube feed here.
				var xnode = selectednode as YtFeedEntry;

				textBox1.Text = xnode.Link;

				label1.Text = xnode.Title;
				label2.Text = xnode.Published;

				toolTip1.SetToolTip(linkLabel1, linkLabel1.Text = xnode.Link);
				toolTip1.SetToolTip(linkLabel2, linkLabel2.Text = xnode.Enclosure);

				xnode.GenerateLinks();

				webBrowser1.DocumentText = xnode.HtmlText;

			}
		}

		#region ListView: Timer/Selection Handlers
		void ResetTimer()
		{
			if (SelectorTimer.Enabled)
				SelectorTimer.Stop();
			SelectorTimer.Start();
		}
		void Event_TimedSelection(object sender, EventArgs e)
		{
			//ItemSelector(listBox1.SelectedItem as NodeInfo);
		}
		void ListBox1MouseClick(object sender, MouseEventArgs e)
		{
			if (SelectorTimer.Enabled)
				return;
			//ItemSelector(listBox1.SelectedItem as NodeInfo);
		}
		void Event_ListBox_SelectedIndexChange(object sender, EventArgs e)
		{
			ResetTimer();
		}
		#endregion

		#region TreeView Node Selection (Via Double Click, and context-menu)

		/// <summary>
		/// To handle right-click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Event_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right) {
				if (e.Node != null) {
					if (e.Node.Level == 0) {
						var item = ctx0.Items.Find("nodeLabel", false)[0];
						item.Text = string.Format("{0}", e.Node.Text);
						contextSelection = e.Node.Text;
						ctx0.Show(treeView1, new Point(e.Node.Bounds.X, e.Node.Bounds.Top), ToolStripDropDownDirection.BelowLeft);

					} else if (e.Node.Level == 1) {
						var item = ctx1.Items.Find("nodeLabel", false)[0];
						item.Text = string.Format("Node Type: {0}", e.Node.Tag.GetType().Name);
						contextSelection = e.Node.Tag;
						ctx1.Show(treeView1, new Point(e.Node.Bounds.X, e.Node.Bounds.Top), ToolStripDropDownDirection.BelowLeft);
					}
				}
			}
		}

		void Event_TreeView_DoubleClick(object sender, MouseEventArgs e)
		{
			TreeViewHitTestInfo node = treeView1.HitTest(treeView1.PointToClient(MousePoint));

			if (node.Node != null) {
				if (node.Node.Level == 0) {
					label4.Text = node.Node.Text;
				} else if (node.Node.Level == 1) {
					label4.Text = node.Node.Parent.Text;
					this.xmldoc = this.XmlList[node.Node.Parent.Text].Xml;
					ItemSelector(node.Node.Tag as NodeInfo);
				}
			}
		}

		#endregion

		#region Xml Parser/Reformatter
		byte[] ReformatXml(string xmlContent)
		{
			return ReformatXml(xmlContent, System.Text.Encoding.UTF8);
		}
		byte[] ReformatXml(string xmlContent, System.Text.Encoding encoding)
		{
			byte[] data;
			XmlWriterSettings settings = new XmlWriterSettings {
				CheckCharacters = true,
				Encoding = encoding,
				Indent = true,
				NewLineOnAttributes = true,
				OmitXmlDeclaration = true
			};
			using (MemoryStream ms = new MemoryStream())
				using (XmlWriter xtw = XmlWriter.Create(ms, settings)) {
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(xmlContent);
				doc.WriteTo(xtw);
				xtw.Flush();
				ms.Flush();
				ms.Position = 0;
				data = ms.ToArray();
				GC.Collect();
			}
			return data;
		}

		string ReformatXmlStr(string xmlContent)
		{
			return ReformatXmlStr(xmlContent, System.Text.Encoding.UTF8);
		}
		string ReformatXmlStr(string xmlContent, System.Text.Encoding encoding)
		{
			return encoding.GetString(ReformatXml(xmlContent));
		}
		#endregion

		#region Link-Click
		void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show(linkLabel1.Text);
		}
		void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show(linkLabel2.Text);
		}
		#endregion

		#region ContextMenu Item EventHandlers
		void Event_RootContextItem(object sender, EventArgs args)
		{
			ToolStripItem itm = sender as ToolStripItem;
			if (itm.Name == "export") {
				if (sfd_xml.ShowDialog() == DialogResult.OK) {
					File.WriteAllText(sfd_xml.FileName, XmlList[contextSelection as string].Content);
				}
				return;
			}
			if (itm.Name == "browseContent") {
				textEditor.SetText(ReformatXmlStr(XmlList[contextSelection as string].Content));
				return;
			}
			if (contextSelection is FeedListItem) {

			} else if (contextSelection is RssNode) {

			} else if (contextSelection is YtFeedEntry) {

			}
		}
		void Event_FeedContextItem(object sender, EventArgs args)
		{
			ToolStripItem itm = sender as ToolStripItem;
			if (contextSelection is FeedListItem) {

			} else if (contextSelection is RssNode) {

			} else if (contextSelection is YtFeedEntry) {

			}
		}
		void Event_Export_IconList(object sender, EventArgs e)
		{
			ExportImageListForm form = new ExportImageListForm(this);
			form.ShowDialog(this);
		}
		#endregion

		#region GridViewer
		void GetGridViewFromText(string fileName)
		{
			GridViewer.Clear();
			GridViewer = new FeedDataConverter(new FileInfo(fileName));
			GridViewer.ToGrid(this.dataGridView1);
		}
		#endregion

		void ToolStripButton1Click(object sender, EventArgs e)
		{
			GridViewer.Items.Add(new FeedDataItem { Title = string.Format("New Item {0:00#}", ++counter) });
			dataGridView1.ResetBindings();
		}

		#region Save/Load Xml/Text
		void SaveXMLToolStripMenuItemClick(object sender, EventArgs e)
		{
			GridViewer.SaveXml();
		}
		void LoadXMLToolStripMenuItemClick(object sender, EventArgs e)
		{
			GridViewer.LoadXml(false);
		}
		void SaveTextToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (sfd_txt.ShowDialog() == DialogResult.OK) {
				IList<FeedListItem> list = FeedListItemConverter.GetData(GridViewer);
				FeedListItemConverter converter = new FeedListItemConverter { Items = list };
				string output = converter.GetText();
				converter = null;
				File.WriteAllText(sfd_txt.FileName, output);
				output = null;
				GC.Collect();
			}
		}
		void LoadTextToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (ofd_text.ShowDialog() == DialogResult.OK) {
				CurrentFeedTextFileName = ofd_text.FileName;
				RefreshFeed();
			}
		}
		#endregion

		void DataGridView1DragEnter(object sender, QueryContinueDragEventArgs e)
		{
			e.Action = DragAction.Continue;
		}
		void DataGridView1DragEnter(object sender, DragEventArgs e)
		{
			dataGridView2.Rows.Clear();
			//dataGridView2.DoDragDrop(null, DragDropEffects.All);
			if (e.Data.GetFormats().Contains("Text")) {
				DirectoryReader reader = new DirectoryReader((string)e.Data.GetData("Text"));
				reader.Complete = GotIt;
				MM_Sys.sndPlaySound("%windir%\\Media\\Windows Feed Discovered.wav", MM_Sys.sndFlags.NOWAIT);
				reader.Go();
			}
		}
		void GotIt(DirectoryReader reader)
		{
			this.tabControl2.SelectedTab = tab1_www;
			this.tabControl1.SelectedTab = tab2_TextEdit;

			textEditor.SetText(string.Concat(reader.Content, "\n------------------------\n", reader.Result));
			MM_Sys.sndPlaySound("%windir%\\Media\\Windows Feed Discovered.wav", MM_Sys.sndFlags.NOWAIT);
		}
		void DataGridView2DragDrop(object sender, DragEventArgs e)
		{
		}

		void Tab1_DataDragEnter(object sender, DragEventArgs e)
		{
			tabControl2.SelectedTab = tab1_Data;
		}

		#region OPML
		void Event_TryLoadOPML(object sender, EventArgs e)
		{
			if (ofd_opml.ShowDialog() == DialogResult.OK) {
				FileInfo file = new FileInfo(ofd_opml.FileName);
				OpmlReader reader = new OpmlReader(file) { Complete = GotOpml };
				System.Diagnostics.Debug.Print("Loading OPML File {0}", file.Name);
				reader.Go();
			}
		}
		void GotOpml(OpmlDocument doc)
		{
			this.treeView1.Nodes.Clear();
			if (FeedDictionary != null) {
				FeedDictionary.Clear();
			} else {
				FeedDictionary = new Dictionary<string, FeedListItem>();
			}

			// lets see if this is a hierarchical type of index
			bool IsHierarchy = false;

			foreach (OpmlOutline node in doc.ELEMENTS) {
				if (node.ELEMENTS.Count >= 1) {
					IsHierarchy = true;
					break;
				}
			}
			int indx = 0;
			foreach (OpmlOutline node in IsHierarchy ? doc.ELEMENTS[0].ELEMENTS : doc.ELEMENTS) {
				if (node.XmlUrl == null)
					continue;
				string nodeName = FeedDictionary.ContainsKey(node.Text) ? string.Format("{0} ({1})", node.Text, indx++) : node.Text;

				FeedListItem item = new FeedListItem {
					title = nodeName,
					url = node.XmlUrl
				};
				FeedDictionary.Add(nodeName, item);
			}

			LoadFeedSet();
			AppOptions.Notify(Options.OPML_LOAD);
		}

		#endregion

	}

}
