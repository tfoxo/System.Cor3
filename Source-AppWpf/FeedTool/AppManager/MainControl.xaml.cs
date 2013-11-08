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
		NodeInfo selectednode;
		XmlInfo xmldoc;
		ModelLoader model;
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

		private readonly IDictionary<object, EventHandler> handlers;
		
		private readonly BrowserPresenter Presenter;
		
		public MainControl()
		{
			InitializeComponent();
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
			};

		}
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
			web_view.ZoomLevel = zoomLevelArgs.NewValue;
		}
		public void browser_viewControls(object sender, RoutedEventArgs args)
		{
			advancedControls.Visibility = advancedControls.IsVisible ? Visibility.Collapsed : Visibility.Visible;
		}
		void Event_ClickedMenuLoadSomething(object sender, RoutedEventArgs e)
		{
			if (model==null) model = new ModelLoader();
			model.RefreshFeed();
			this.listFeeds.ItemsSource = model.Items;
		}
		/// <summary>
		/// Actual Node selection handler.
		/// </summary>
		/// <param name="selection"></param>
		void ItemSelector(		/*XmlInfo xmldoc, */NodeInfo selection)
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
			ItemSelector((sender as Hyperlink).Tag as NodeInfo);
		}

	}
}