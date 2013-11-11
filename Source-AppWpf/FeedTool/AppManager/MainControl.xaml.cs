/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 10/30/2013
 * Time: 15:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using FeedTool.Loaders;

namespace FeedTool.ViewMain
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class MainControl : UserControl, IBrowserView
	{
		public static MainControl Self;
		
		private readonly IDictionary<object, EventHandler> handlers;
		private readonly BrowserPresenter Presenter;
		
		NodeInfo selectednode;
		XmlInfo xmldoc;
		
		public ModelLoader Model {
			get { return model; }
			set { model = value; }
		} ModelLoader model;
		
		#region Main Event-Handlers
		
		// file
		public event EventHandler ShowDevToolsActivated;
		public event EventHandler CloseDevToolsActivated;
		public event EventHandler ExitActivated;

		// edit
		public event EventHandler UndoActivated;
		public event EventHandler RedoActivated;
		public event EventHandler CutActivated;
		public event EventHandler CopyActivated;
		public event EventHandler PasteActivated;
		public event EventHandler DeleteActivated;
		public event EventHandler SelectAllActivated;

		// test
		public event EventHandler TestResourceLoadActivated;
		public event EventHandler TestSchemeLoadActivated;
		public event EventHandler TestExecuteScriptActivated;
		public event EventHandler TestEvaluateScriptActivated;
		public event EventHandler TestBindActivated;
		public event EventHandler TestConsoleMessageActivated;
		public event EventHandler TestTooltipActivated;
		public event EventHandler TestPopupActivated;
		public event EventHandler TestLoadStringActivated;
		public event EventHandler TestCookieVisitorActivated;

		// navigation
		public event Action<object, string> UrlActivated;
		public event EventHandler BackActivated;
		public event EventHandler ForwardActivated;
		public event EventHandler HomeActivated;
		#endregion
		
		public MainControl()
		{
			InitializeComponent();
			Self = this;
			Presenter = new BrowserPresenter(web_view, this, invoke => Dispatcher.BeginInvoke(invoke));
			handlers = new Dictionary<object, EventHandler>
			{
				// file
				{ showDevToolsMenuItem, ShowDevToolsActivated},
				{ closeDevToolsMenuItem, CloseDevToolsActivated},
				{ exitMenuItem, ExitActivated },

				// edit
				{ undoMenuItem, UndoActivated },
				{ redoMenuItem, RedoActivated },
				{ cutMenuItem, CutActivated },
				{ copyMenuItem, CopyActivated },
				{ pasteMenuItem, PasteActivated },
				{ deleteMenuItem, DeleteActivated },
				{ selectAllMenuItem, SelectAllActivated },

				// test
				{ testResourceLoadMenuItem, TestResourceLoadActivated },
				{ testSchemeLoadMenuItem, TestSchemeLoadActivated },
				{ testExecuteScriptMenuItem, TestExecuteScriptActivated },
				{ testEvaluateScriptMenuItem, TestEvaluateScriptActivated },
				{ testBindMenuItem, TestBindActivated },
				{ testConsoleMessageMenuItem, TestConsoleMessageActivated },
				{ testTooltipMenuItem, TestTooltipActivated },
				{ testPopupMenuItem, TestPopupActivated },
				{ testLoadStringMenuItem, TestLoadStringActivated },
				{ testCookieVisitorMenuItem, TestCookieVisitorActivated },

				// navigation
				{ backButton, BackActivated },
				{ forwardButton, ForwardActivated },
				{ homeButton, HomeActivated },
			};

		}
		
		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			LoadTextData();
		}
		
		#region Browser-EventHandlers
		public void SetTitle(string title)
		{
//			(this.Parent as Window)
//				.Title = title;
		}

		public void SetAddress(string address)
		{
			urlTextBox.Text = address;
		}

		public void SetCanGoBack(bool can_go_back)
		{
			backButton.IsEnabled = can_go_back;
		}

		public void SetCanGoForward(bool can_go_forward)
		{
			forwardButton.IsEnabled = can_go_forward;
		}

		public void SetIsLoading(bool is_loading)
		{

		}

		public void ExecuteScript(string script)
		{
			web_view.ExecuteScript(script);
		}

		public object EvaluateScript(string script)
		{
			return web_view.EvaluateScript(script);
		}

		public void DisplayOutput(string output)
		{
			outputLabel.Content = output;
		}

		private void control_Activated(object sender, RoutedEventArgs e)
		{
			EventHandler handler;
			if (handlers.TryGetValue(sender, out handler) &&
			    handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}

		private void urlTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key != Key.Enter)
			{
				return;
			}

			var handler = UrlActivated;
			if (handler != null)
			{
				handler(this, urlTextBox.Text);
			}
		}

		public void SetZoomLevel(object sender, RoutedPropertyChangedEventArgs<double> zoomLevelArgs)
		{
//			web_view.ZoomLevel = zoomLevelArgs.NewValue;
		}
		public void browser_viewControls(object sender, RoutedEventArgs args)
		{
			advancedControls.Visibility = advancedControls.IsVisible ? Visibility.Collapsed : Visibility.Visible;
		}
		#endregion
		
		class LoaderWorker : BackgroundWorker
		{
			public bool FeedsLoaded {
				get { return feedsLoaded; }
				set { feedsLoaded = value; }
			} bool feedsLoaded = false;
			
			public ModelLoader LocalModel {
				get { return localModel; }
				set { localModel = value; }
			} ModelLoader localModel;
			
			public LoaderWorker(ModelLoader mdl)
			{
				localModel = mdl;
				feedsLoaded = false;
			}
			
			protected override void OnDoWork(DoWorkEventArgs e)
			{
				base.OnDoWork(e);
				if (localModel==null) localModel = new ModelLoader();
				// model.RefreshFeed();
				feedsLoaded = true;
			}
		} LoaderWorker worker;
		
		void LoaderCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (worker==null) return;
			if (worker.FeedsLoaded) {
				model = worker.LocalModel;
				model.RefreshFeed();
				listFeeds.ItemsSource = model.Items;
				loaderProgress.Visibility = Visibility.Hidden;
			}
		}
		
		void LoadTextData()
		{
			if (worker == null) { ; }
			else if (worker.IsBusy) {
				worker.CancelAsync();
				worker.Dispose();
				worker = null;
			}
			if (worker==null) {
				worker = new LoaderWorker(model);
				loaderProgress.Value = 0;
				loaderProgress.Visibility = Visibility.Visible;
			}
			worker.RunWorkerCompleted -= LoaderCompleted;
			worker.RunWorkerCompleted += LoaderCompleted;
			worker.RunWorkerAsync();
		}
		
		void Event_ClickedMenuLoadSomething(object sender, RoutedEventArgs e)
		{
			LoadTextData();
		}
		
		/// <summary>
		/// Actual Node selection handler.
		/// </summary>
		/// <param name="selection"></param>
		internal void ItemSelector(/*XmlInfo xmldoc, */ NodeInfo selection)
		{
			this.xmldoc = selection.Parent.Parser.Xml;
//			if (SelectorTimer.Enabled) SelectorTimer.Stop();
			if (selection == null) return;
			selectednode = selection;
			if (xmldoc.RootType == "rss") {
				var xnode = selectednode as RssNode;
				urlTextBox.Text = xnode.Link;
//				label1.Text = xnode.Title;
//				label2.Text = xnode.Date;
//				toolTip1.SetToolTip(linkLabel1, (linkLabel1.Text = xnode.Link));
//				toolTip1.SetToolTip(linkLabel2, (linkLabel2.Text = xnode.Enclosure));
				xnode.GenerateLinks();
				web_view.LoadHtml(xnode.HtmlText);
//				webBrowser1.DocumentText = xnode.HtmlText;

			} else if (xmldoc.RootType == "feed") {
				// We're expecting a YouTube feed here.
				var xnode = selectednode as YtFeedEntry;
				urlTextBox.Text = xnode.Link;
//				label1.Text = xnode.Title;
//				label2.Text = xnode.Published;
//				toolTip1.SetToolTip(linkLabel1, linkLabel1.Text = xnode.Link);
//				toolTip1.SetToolTip(linkLabel2, linkLabel2.Text = xnode.Enclosure);
				xnode.GenerateLinks();
				web_view.LoadHtml(xnode.HtmlText);
//				webBrowser1.DocumentText = xnode.HtmlText;

			}
		}
		void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			NodeInfo node = (sender as Hyperlink).Tag as NodeInfo;
			string temp = string.Format(
				"feed://{0}/{1}/{2}",
				node.GetType().Name,
				node.Parent.Key,
				node.Parent.Children.IndexOf(node)
			);
			web_view.Load(temp);
			outputLabel.Content = temp;
		}

	}
}