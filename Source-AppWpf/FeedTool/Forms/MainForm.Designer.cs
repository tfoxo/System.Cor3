/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 1/31/2013
 * Time: 12:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FeedTool.Forms
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
		    this.components = new System.ComponentModel.Container();
		    System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
		    System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
		    		    		    treeNode1});
		    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		    this.label1 = new System.Windows.Forms.Label();
		    this.label2 = new System.Windows.Forms.Label();
		    this.label3 = new System.Windows.Forms.Label();
		    this.comboBox1 = new System.Windows.Forms.ComboBox();
		    this.textBox1 = new System.Windows.Forms.TextBox();
		    this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		    this.linkLabel2 = new System.Windows.Forms.LinkLabel();
		    this.treeView1 = new System.Windows.Forms.TreeView();
		    this.imageList1 = new System.Windows.Forms.ImageList(this.components);
		    this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		    this.label4 = new System.Windows.Forms.ToolStripStatusLabel();
		    this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		    this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
		    this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		    this.tabControl2 = new System.Windows.Forms.TabControl();
		    this.tab1_nfo = new System.Windows.Forms.TabPage();
		    this.tab1_www = new System.Windows.Forms.TabPage();
		    this.tabControl1 = new System.Windows.Forms.TabControl();
		    this.tab2_www = new System.Windows.Forms.TabPage();
		    this.webBrowser1 = new System.Windows.Forms.WebBrowser();
		    this.tab2_TextEdit = new System.Windows.Forms.TabPage();
		    this.textEditor = new ICSharpCode.TextEditor.TextEditorControl();
		    this.tabPage1 = new System.Windows.Forms.TabPage();
		    this.flashVidTool1 = new Flash.FlashVidTool();
		    this.imageList2 = new System.Windows.Forms.ImageList(this.components);
		    this.tab1_Data = new System.Windows.Forms.TabPage();
		    this.tabControl3 = new System.Windows.Forms.TabControl();
		    this.tabPage2 = new System.Windows.Forms.TabPage();
		    this.dataGridView1 = new System.Windows.Forms.DataGridView();
		    this.tabPage3 = new System.Windows.Forms.TabPage();
		    this.dataGridView2 = new System.Windows.Forms.DataGridView();
		    this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		    this.Column2 = new System.Windows.Forms.DataGridViewLinkColumn();
		    this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		    this.toolStrip1 = new System.Windows.Forms.ToolStrip();
		    this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
		    this.loadXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.saveXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
		    this.loadTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.saveTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		    this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
		    this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripButton();
		    this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripDropDownButton();
		    this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		    this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
		    this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		    this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.refreshAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.refreshSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.loadXmlFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
		    this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		    this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
		    this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
		    this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		    this.editorFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
		    this.ctx0 = new System.Windows.Forms.ContextMenuStrip(this.components);
		    this.ctx1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		    this.statusStrip1.SuspendLayout();
		    ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
		    this.splitContainer1.Panel1.SuspendLayout();
		    this.splitContainer1.Panel2.SuspendLayout();
		    this.splitContainer1.SuspendLayout();
		    this.tabControl2.SuspendLayout();
		    this.tab1_nfo.SuspendLayout();
		    this.tab1_www.SuspendLayout();
		    this.tabControl1.SuspendLayout();
		    this.tab2_www.SuspendLayout();
		    this.tab2_TextEdit.SuspendLayout();
		    this.tabPage1.SuspendLayout();
		    this.tab1_Data.SuspendLayout();
		    this.tabControl3.SuspendLayout();
		    this.tabPage2.SuspendLayout();
		    ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
		    this.tabPage3.SuspendLayout();
		    ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
		    this.toolStrip1.SuspendLayout();
		    this.tableLayoutPanel1.SuspendLayout();
		    this.menuStrip1.SuspendLayout();
		    this.SuspendLayout();
		    // 
		    // label1
		    // 
		    this.label1.AutoSize = true;
		    this.label1.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		    this.label1.Location = new System.Drawing.Point(5, 10);
		    this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		    this.label1.Name = "label1";
		    this.label1.Size = new System.Drawing.Size(60, 29);
		    this.label1.TabIndex = 2;
		    this.label1.Text = "label1";
		    // 
		    // label2
		    // 
		    this.label2.AutoEllipsis = true;
		    this.label2.AutoSize = true;
		    this.label2.Location = new System.Drawing.Point(17, 99);
		    this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		    this.label2.Name = "label2";
		    this.label2.Size = new System.Drawing.Size(35, 13);
		    this.label2.TabIndex = 2;
		    this.label2.Text = "label2";
		    // 
		    // label3
		    // 
		    this.label3.AutoSize = true;
		    this.label3.Location = new System.Drawing.Point(17, 123);
		    this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		    this.label3.Name = "label3";
		    this.label3.Size = new System.Drawing.Size(35, 13);
		    this.label3.TabIndex = 2;
		    this.label3.Text = "label3";
		    // 
		    // comboBox1
		    // 
		    this.comboBox1.FormattingEnabled = true;
		    this.comboBox1.Location = new System.Drawing.Point(186, 0);
		    this.comboBox1.Margin = new System.Windows.Forms.Padding(0);
		    this.comboBox1.Name = "comboBox1";
		    this.comboBox1.Size = new System.Drawing.Size(84, 21);
		    this.comboBox1.TabIndex = 3;
		    this.comboBox1.Visible = false;
		    // 
		    // textBox1
		    // 
		    this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.textBox1.Location = new System.Drawing.Point(270, 0);
		    this.textBox1.Margin = new System.Windows.Forms.Padding(0);
		    this.textBox1.Name = "textBox1";
		    this.textBox1.Size = new System.Drawing.Size(672, 20);
		    this.textBox1.TabIndex = 4;
		    // 
		    // linkLabel1
		    // 
		    this.linkLabel1.AutoSize = true;
		    this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		    this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
		    this.linkLabel1.Location = new System.Drawing.Point(17, 50);
		    this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		    this.linkLabel1.Name = "linkLabel1";
		    this.linkLabel1.Size = new System.Drawing.Size(55, 13);
		    this.linkLabel1.TabIndex = 5;
		    this.linkLabel1.TabStop = true;
		    this.linkLabel1.Text = "linkLabel1";
		    this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
		    this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
		    // 
		    // linkLabel2
		    // 
		    this.linkLabel2.AutoSize = true;
		    this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		    this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
		    this.linkLabel2.Location = new System.Drawing.Point(17, 68);
		    this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		    this.linkLabel2.Name = "linkLabel2";
		    this.linkLabel2.Size = new System.Drawing.Size(55, 13);
		    this.linkLabel2.TabIndex = 5;
		    this.linkLabel2.TabStop = true;
		    this.linkLabel2.Text = "linkLabel2";
		    this.linkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
		    // 
		    // treeView1
		    // 
		    this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		    this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.treeView1.FullRowSelect = true;
		    this.treeView1.HideSelection = false;
		    this.treeView1.ImageKey = "ui-radio-button.png";
		    this.treeView1.ImageList = this.imageList1;
		    this.treeView1.Indent = 16;
		    this.treeView1.Location = new System.Drawing.Point(0, 0);
		    this.treeView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.treeView1.Name = "treeView1";
		    treeNode1.Name = "Node1";
		    treeNode1.Text = "Node1";
		    treeNode2.ImageKey = "feed.png";
		    treeNode2.Name = "Node0";
		    treeNode2.Text = "Node0";
		    this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
		    		    		    treeNode2});
		    this.treeView1.SelectedImageKey = "ui-radio-button-uncheck.png";
		    this.treeView1.ShowNodeToolTips = true;
		    this.treeView1.ShowPlusMinus = false;
		    this.treeView1.ShowRootLines = false;
		    this.treeView1.Size = new System.Drawing.Size(289, 395);
		    this.treeView1.TabIndex = 6;
		    // 
		    // imageList1
		    // 
		    this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
		    this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
		    this.imageList1.Images.SetKeyName(0, "exclamation.png");
		    this.imageList1.Images.SetKeyName(1, "exclamation-button.png");
		    this.imageList1.Images.SetKeyName(2, "exclamation-diamond.png");
		    this.imageList1.Images.SetKeyName(3, "exclamation-diamond-frame.png");
		    this.imageList1.Images.SetKeyName(4, "exclamation--frame.png");
		    this.imageList1.Images.SetKeyName(5, "exclamation-octagon.png");
		    this.imageList1.Images.SetKeyName(6, "exclamation-octagon-frame.png");
		    this.imageList1.Images.SetKeyName(7, "exclamation-red.png");
		    this.imageList1.Images.SetKeyName(8, "exclamation-red-frame.png");
		    this.imageList1.Images.SetKeyName(9, "exclamation-shield.png");
		    this.imageList1.Images.SetKeyName(10, "exclamation-shield-frame.png");
		    this.imageList1.Images.SetKeyName(11, "exclamation-small.png");
		    this.imageList1.Images.SetKeyName(12, "exclamation-small-red.png");
		    this.imageList1.Images.SetKeyName(13, "exclamation-small-white.png");
		    this.imageList1.Images.SetKeyName(14, "exclamation-white.png");
		    this.imageList1.Images.SetKeyName(15, "feed.png");
		    this.imageList1.Images.SetKeyName(16, "feed-atom.png");
		    this.imageList1.Images.SetKeyName(17, "feed--arrow.png");
		    this.imageList1.Images.SetKeyName(18, "feed-balloon.png");
		    this.imageList1.Images.SetKeyName(19, "feed-document.png");
		    this.imageList1.Images.SetKeyName(20, "feed--exclamation.png");
		    this.imageList1.Images.SetKeyName(21, "feed--minus.png");
		    this.imageList1.Images.SetKeyName(22, "feed--pencil.png");
		    this.imageList1.Images.SetKeyName(23, "feed--plus.png");
		    this.imageList1.Images.SetKeyName(24, "information.png");
		    this.imageList1.Images.SetKeyName(25, "information-balloon.png");
		    this.imageList1.Images.SetKeyName(26, "information-button.png");
		    this.imageList1.Images.SetKeyName(27, "information-frame.png");
		    this.imageList1.Images.SetKeyName(28, "information-octagon.png");
		    this.imageList1.Images.SetKeyName(29, "information-octagon-frame.png");
		    this.imageList1.Images.SetKeyName(30, "information-shield.png");
		    this.imageList1.Images.SetKeyName(31, "information-small.png");
		    this.imageList1.Images.SetKeyName(32, "information-small-white.png");
		    this.imageList1.Images.SetKeyName(33, "information-white.png");
		    this.imageList1.Images.SetKeyName(34, "json.png");
		    this.imageList1.Images.SetKeyName(35, "media-player-cast.png");
		    this.imageList1.Images.SetKeyName(36, "media-player-medium.png");
		    this.imageList1.Images.SetKeyName(37, "navigation.png");
		    this.imageList1.Images.SetKeyName(38, "navigation-000-button.png");
		    this.imageList1.Images.SetKeyName(39, "navigation-000-frame.png");
		    this.imageList1.Images.SetKeyName(40, "navigation-000-white.png");
		    this.imageList1.Images.SetKeyName(41, "navigation-090.png");
		    this.imageList1.Images.SetKeyName(42, "navigation-090-button.png");
		    this.imageList1.Images.SetKeyName(43, "navigation-090-frame.png");
		    this.imageList1.Images.SetKeyName(44, "navigation-090-white.png");
		    this.imageList1.Images.SetKeyName(45, "navigation-180.png");
		    this.imageList1.Images.SetKeyName(46, "navigation-180-button.png");
		    this.imageList1.Images.SetKeyName(47, "navigation-180-frame.png");
		    this.imageList1.Images.SetKeyName(48, "navigation-180-white.png");
		    this.imageList1.Images.SetKeyName(49, "navigation-270.png");
		    this.imageList1.Images.SetKeyName(50, "navigation-270-button.png");
		    this.imageList1.Images.SetKeyName(51, "navigation-270-frame.png");
		    this.imageList1.Images.SetKeyName(52, "navigation-270-white.png");
		    this.imageList1.Images.SetKeyName(53, "notebook.png");
		    this.imageList1.Images.SetKeyName(54, "notebook--arrow.png");
		    this.imageList1.Images.SetKeyName(55, "notebook--exclamation.png");
		    this.imageList1.Images.SetKeyName(56, "notebook-medium.png");
		    this.imageList1.Images.SetKeyName(57, "notebook--minus.png");
		    this.imageList1.Images.SetKeyName(58, "notebook--pencil.png");
		    this.imageList1.Images.SetKeyName(59, "notebook--plus.png");
		    this.imageList1.Images.SetKeyName(60, "notebooks.png");
		    this.imageList1.Images.SetKeyName(61, "notebook-share.png");
		    this.imageList1.Images.SetKeyName(62, "notebook-sticky-note.png");
		    this.imageList1.Images.SetKeyName(63, "odata.png");
		    this.imageList1.Images.SetKeyName(64, "odata-balloon.png");
		    this.imageList1.Images.SetKeyName(65, "odata-document.png");
		    this.imageList1.Images.SetKeyName(66, "odata-small.png");
		    this.imageList1.Images.SetKeyName(67, "plus-button.png");
		    this.imageList1.Images.SetKeyName(68, "plus-circle.png");
		    this.imageList1.Images.SetKeyName(69, "plus-circle-frame.png");
		    this.imageList1.Images.SetKeyName(70, "plus-octagon.png");
		    this.imageList1.Images.SetKeyName(71, "plus-octagon-frame.png");
		    this.imageList1.Images.SetKeyName(72, "plus-shield.png");
		    this.imageList1.Images.SetKeyName(73, "plus-small-white.png");
		    this.imageList1.Images.SetKeyName(74, "plus-white.png");
		    this.imageList1.Images.SetKeyName(75, "question.png");
		    this.imageList1.Images.SetKeyName(76, "question-balloon.png");
		    this.imageList1.Images.SetKeyName(77, "question-button.png");
		    this.imageList1.Images.SetKeyName(78, "question-frame.png");
		    this.imageList1.Images.SetKeyName(79, "question-octagon.png");
		    this.imageList1.Images.SetKeyName(80, "question-octagon-frame.png");
		    this.imageList1.Images.SetKeyName(81, "question-shield.png");
		    this.imageList1.Images.SetKeyName(82, "question-small.png");
		    this.imageList1.Images.SetKeyName(83, "question-small-white.png");
		    this.imageList1.Images.SetKeyName(84, "question-white.png");
		    this.imageList1.Images.SetKeyName(85, "ui-radio-button.png");
		    this.imageList1.Images.SetKeyName(86, "ui-radio-button-uncheck.png");
		    this.imageList1.Images.SetKeyName(87, "podcast.png");
		    this.imageList1.Images.SetKeyName(88, "youtube.ico");
		    this.imageList1.Images.SetKeyName(89, "feed-rdf.png");
		    // 
		    // statusStrip1
		    // 
		    this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.label4,
		    		    		    this.toolStripStatusLabel1,
		    		    		    this.toolStripProgressBar1});
		    this.statusStrip1.Location = new System.Drawing.Point(0, 426);
		    this.statusStrip1.Name = "statusStrip1";
		    this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
		    this.statusStrip1.Size = new System.Drawing.Size(853, 22);
		    this.statusStrip1.TabIndex = 8;
		    this.statusStrip1.Text = "statusStrip1";
		    // 
		    // label4
		    // 
		    this.label4.IsLink = true;
		    this.label4.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
		    this.label4.Name = "label4";
		    this.label4.Size = new System.Drawing.Size(0, 17);
		    this.label4.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
		    // 
		    // toolStripStatusLabel1
		    // 
		    this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		    this.toolStripStatusLabel1.Size = new System.Drawing.Size(752, 17);
		    this.toolStripStatusLabel1.Spring = true;
		    // 
		    // toolStripProgressBar1
		    // 
		    this.toolStripProgressBar1.Name = "toolStripProgressBar1";
		    this.toolStripProgressBar1.Size = new System.Drawing.Size(86, 16);
		    // 
		    // splitContainer1
		    // 
		    this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		    this.splitContainer1.Location = new System.Drawing.Point(0, 31);
		    this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.splitContainer1.Name = "splitContainer1";
		    // 
		    // splitContainer1.Panel1
		    // 
		    this.splitContainer1.Panel1.Controls.Add(this.treeView1);
		    // 
		    // splitContainer1.Panel2
		    // 
		    this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
		    this.splitContainer1.Size = new System.Drawing.Size(853, 395);
		    this.splitContainer1.SplitterDistance = 289;
		    this.splitContainer1.TabIndex = 9;
		    // 
		    // tabControl2
		    // 
		    this.tabControl2.Controls.Add(this.tab1_nfo);
		    this.tabControl2.Controls.Add(this.tab1_www);
		    this.tabControl2.Controls.Add(this.tab1_Data);
		    this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.tabControl2.ImageList = this.imageList2;
		    this.tabControl2.Location = new System.Drawing.Point(0, 0);
		    this.tabControl2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tabControl2.Name = "tabControl2";
		    this.tabControl2.SelectedIndex = 0;
		    this.tabControl2.Size = new System.Drawing.Size(560, 395);
		    this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
		    this.tabControl2.TabIndex = 6;
		    // 
		    // tab1_nfo
		    // 
		    this.tab1_nfo.Controls.Add(this.label3);
		    this.tab1_nfo.Controls.Add(this.linkLabel1);
		    this.tab1_nfo.Controls.Add(this.label2);
		    this.tab1_nfo.Controls.Add(this.linkLabel2);
		    this.tab1_nfo.Controls.Add(this.label1);
		    this.tab1_nfo.ImageKey = "appbar.rss.png";
		    this.tab1_nfo.Location = new System.Drawing.Point(4, 31);
		    this.tab1_nfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tab1_nfo.Name = "tab1_nfo";
		    this.tab1_nfo.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tab1_nfo.Size = new System.Drawing.Size(552, 360);
		    this.tab1_nfo.TabIndex = 0;
		    this.tab1_nfo.Text = "Information";
		    this.tab1_nfo.UseVisualStyleBackColor = true;
		    // 
		    // tab1_www
		    // 
		    this.tab1_www.Controls.Add(this.tabControl1);
		    this.tab1_www.ImageKey = "appbar.ie.png";
		    this.tab1_www.Location = new System.Drawing.Point(4, 31);
		    this.tab1_www.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tab1_www.Name = "tab1_www";
		    this.tab1_www.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tab1_www.Size = new System.Drawing.Size(552, 360);
		    this.tab1_www.TabIndex = 1;
		    this.tab1_www.UseVisualStyleBackColor = true;
		    // 
		    // tabControl1
		    // 
		    this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		    this.tabControl1.Controls.Add(this.tab2_www);
		    this.tabControl1.Controls.Add(this.tab2_TextEdit);
		    this.tabControl1.Controls.Add(this.tabPage1);
		    this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.tabControl1.ImageList = this.imageList2;
		    this.tabControl1.Location = new System.Drawing.Point(2, 3);
		    this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tabControl1.Multiline = true;
		    this.tabControl1.Name = "tabControl1";
		    this.tabControl1.SelectedIndex = 0;
		    this.tabControl1.Size = new System.Drawing.Size(548, 354);
		    this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
		    this.tabControl1.TabIndex = 1;
		    // 
		    // tab2_www
		    // 
		    this.tab2_www.Controls.Add(this.webBrowser1);
		    this.tab2_www.ImageKey = "appbar.browser.ie.png";
		    this.tab2_www.Location = new System.Drawing.Point(4, 4);
		    this.tab2_www.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tab2_www.Name = "tab2_www";
		    this.tab2_www.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tab2_www.Size = new System.Drawing.Size(540, 319);
		    this.tab2_www.TabIndex = 0;
		    this.tab2_www.UseVisualStyleBackColor = true;
		    // 
		    // webBrowser1
		    // 
		    this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.webBrowser1.Location = new System.Drawing.Point(2, 3);
		    this.webBrowser1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.webBrowser1.MinimumSize = new System.Drawing.Size(17, 18);
		    this.webBrowser1.Name = "webBrowser1";
		    this.webBrowser1.ScriptErrorsSuppressed = true;
		    this.webBrowser1.Size = new System.Drawing.Size(536, 313);
		    this.webBrowser1.TabIndex = 0;
		    // 
		    // tab2_TextEdit
		    // 
		    this.tab2_TextEdit.Controls.Add(this.textEditor);
		    this.tab2_TextEdit.ImageKey = "appbar.information.circle.png";
		    this.tab2_TextEdit.Location = new System.Drawing.Point(4, 4);
		    this.tab2_TextEdit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tab2_TextEdit.Name = "tab2_TextEdit";
		    this.tab2_TextEdit.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tab2_TextEdit.Size = new System.Drawing.Size(540, 319);
		    this.tab2_TextEdit.TabIndex = 1;
		    // 
		    // textEditor
		    // 
		    this.textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.textEditor.IsReadOnly = false;
		    this.textEditor.Location = new System.Drawing.Point(2, 3);
		    this.textEditor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		    this.textEditor.Name = "textEditor";
		    this.textEditor.Size = new System.Drawing.Size(536, 313);
		    this.textEditor.TabIndex = 1;
		    // 
		    // tabPage1
		    // 
		    this.tabPage1.Controls.Add(this.flashVidTool1);
		    this.tabPage1.ImageKey = "appbar.map.location.png";
		    this.tabPage1.Location = new System.Drawing.Point(4, 4);
		    this.tabPage1.Name = "tabPage1";
		    this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		    this.tabPage1.Size = new System.Drawing.Size(540, 319);
		    this.tabPage1.TabIndex = 2;
		    this.tabPage1.Text = "tabPage1";
		    this.tabPage1.UseVisualStyleBackColor = true;
		    // 
		    // flashVidTool1
		    // 
		    this.flashVidTool1.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.flashVidTool1.Location = new System.Drawing.Point(3, 3);
		    this.flashVidTool1.Name = "flashVidTool1";
		    this.flashVidTool1.Size = new System.Drawing.Size(534, 313);
		    this.flashVidTool1.TabIndex = 0;
		    // 
		    // imageList2
		    // 
		    this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
		    this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
		    this.imageList2.Images.SetKeyName(0, "podcast.png");
		    this.imageList2.Images.SetKeyName(1, "youtube.ico");
		    this.imageList2.Images.SetKeyName(2, "appbar.alert.png");
		    this.imageList2.Images.SetKeyName(3, "appbar.app.favorite.png");
		    this.imageList2.Images.SetKeyName(4, "appbar.app.minus.png");
		    this.imageList2.Images.SetKeyName(5, "appbar.app.plus.png");
		    this.imageList2.Images.SetKeyName(6, "appbar.app.png");
		    this.imageList2.Images.SetKeyName(7, "appbar.app.remove.png");
		    this.imageList2.Images.SetKeyName(8, "appbar.arrow.collapsed.png");
		    this.imageList2.Images.SetKeyName(9, "appbar.arrow.corner.up.right.png");
		    this.imageList2.Images.SetKeyName(10, "appbar.arrow.down.png");
		    this.imageList2.Images.SetKeyName(11, "appbar.arrow.down.up.png");
		    this.imageList2.Images.SetKeyName(12, "appbar.arrow.left.png");
		    this.imageList2.Images.SetKeyName(13, "appbar.arrow.left.right.png");
		    this.imageList2.Images.SetKeyName(14, "appbar.arrow.right.left.png");
		    this.imageList2.Images.SetKeyName(15, "appbar.arrow.right.png");
		    this.imageList2.Images.SetKeyName(16, "appbar.arrow.up.down.png");
		    this.imageList2.Images.SetKeyName(17, "appbar.arrow.up.png");
		    this.imageList2.Images.SetKeyName(18, "appbar.at.png");
		    this.imageList2.Images.SetKeyName(19, "appbar.book.help.png");
		    this.imageList2.Images.SetKeyName(20, "appbar.book.open.png");
		    this.imageList2.Images.SetKeyName(21, "appbar.book.open.writing.png");
		    this.imageList2.Images.SetKeyName(22, "appbar.browser.ie.png");
		    this.imageList2.Images.SetKeyName(23, "appbar.chess.pawn.png");
		    this.imageList2.Images.SetKeyName(24, "appbar.chevron.down.png");
		    this.imageList2.Images.SetKeyName(25, "appbar.chevron.left.png");
		    this.imageList2.Images.SetKeyName(26, "appbar.chevron.right.png");
		    this.imageList2.Images.SetKeyName(27, "appbar.chevron.up.png");
		    this.imageList2.Images.SetKeyName(28, "appbar.clear.inverse.png");
		    this.imageList2.Images.SetKeyName(29, "appbar.clear.inverse.reflect.horizontal.png");
		    this.imageList2.Images.SetKeyName(30, "appbar.clear.png");
		    this.imageList2.Images.SetKeyName(31, "appbar.clear.reflect.horizontal.png");
		    this.imageList2.Images.SetKeyName(32, "appbar.clipboard.edit.png");
		    this.imageList2.Images.SetKeyName(33, "appbar.clipboard.file.png");
		    this.imageList2.Images.SetKeyName(34, "appbar.clipboard.png");
		    this.imageList2.Images.SetKeyName(35, "appbar.close.png");
		    this.imageList2.Images.SetKeyName(36, "appbar.cloud.add.png");
		    this.imageList2.Images.SetKeyName(37, "appbar.cloud.delete.png");
		    this.imageList2.Images.SetKeyName(38, "appbar.cloud.download.png");
		    this.imageList2.Images.SetKeyName(39, "appbar.cloud.pause.png");
		    this.imageList2.Images.SetKeyName(40, "appbar.cloud.play.png");
		    this.imageList2.Images.SetKeyName(41, "appbar.cloud.png");
		    this.imageList2.Images.SetKeyName(42, "appbar.cloud.upload.png");
		    this.imageList2.Images.SetKeyName(43, "appbar.cloudirc.png");
		    this.imageList2.Images.SetKeyName(44, "appbar.cog.png");
		    this.imageList2.Images.SetKeyName(45, "appbar.cogs.png");
		    this.imageList2.Images.SetKeyName(46, "appbar.column.one.png");
		    this.imageList2.Images.SetKeyName(47, "appbar.column.three.png");
		    this.imageList2.Images.SetKeyName(48, "appbar.column.two.png");
		    this.imageList2.Images.SetKeyName(49, "appbar.confirm.yes.no.png");
		    this.imageList2.Images.SetKeyName(50, "appbar.disk.png");
		    this.imageList2.Images.SetKeyName(51, "appbar.draw.pencil.png");
		    this.imageList2.Images.SetKeyName(52, "appbar.draw.pencil.reflection.png");
		    this.imageList2.Images.SetKeyName(53, "appbar.edit.png");
		    this.imageList2.Images.SetKeyName(54, "appbar.folder.png");
		    this.imageList2.Images.SetKeyName(55, "appbar.github.png");
		    this.imageList2.Images.SetKeyName(56, "appbar.globe.png");
		    this.imageList2.Images.SetKeyName(57, "appbar.globe.wire.png");
		    this.imageList2.Images.SetKeyName(58, "appbar.google.png");
		    this.imageList2.Images.SetKeyName(59, "appbar.ie.png");
		    this.imageList2.Images.SetKeyName(60, "appbar.infinite.png");
		    this.imageList2.Images.SetKeyName(61, "appbar.information.circle.png");
		    this.imageList2.Images.SetKeyName(62, "appbar.information.png");
		    this.imageList2.Images.SetKeyName(63, "appbar.map.folds.png");
		    this.imageList2.Images.SetKeyName(64, "appbar.map.gps.png");
		    this.imageList2.Images.SetKeyName(65, "appbar.map.location.add.png");
		    this.imageList2.Images.SetKeyName(66, "appbar.map.location.png");
		    this.imageList2.Images.SetKeyName(67, "appbar.map.png");
		    this.imageList2.Images.SetKeyName(68, "appbar.rss.png");
		    this.imageList2.Images.SetKeyName(69, "appbar.save.png");
		    // 
		    // tab1_Data
		    // 
		    this.tab1_Data.Controls.Add(this.tabControl3);
		    this.tab1_Data.Controls.Add(this.toolStrip1);
		    this.tab1_Data.ImageKey = "appbar.map.png";
		    this.tab1_Data.Location = new System.Drawing.Point(4, 31);
		    this.tab1_Data.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tab1_Data.Name = "tab1_Data";
		    this.tab1_Data.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tab1_Data.Size = new System.Drawing.Size(552, 360);
		    this.tab1_Data.TabIndex = 2;
		    this.tab1_Data.UseVisualStyleBackColor = true;
		    this.tab1_Data.DragEnter += new System.Windows.Forms.DragEventHandler(this.Tab1_DataDragEnter);
		    // 
		    // tabControl3
		    // 
		    this.tabControl3.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		    this.tabControl3.Controls.Add(this.tabPage2);
		    this.tabControl3.Controls.Add(this.tabPage3);
		    this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.tabControl3.Location = new System.Drawing.Point(2, 34);
		    this.tabControl3.Name = "tabControl3";
		    this.tabControl3.SelectedIndex = 0;
		    this.tabControl3.Size = new System.Drawing.Size(548, 323);
		    this.tabControl3.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
		    this.tabControl3.TabIndex = 2;
		    // 
		    // tabPage2
		    // 
		    this.tabPage2.Controls.Add(this.dataGridView1);
		    this.tabPage2.Location = new System.Drawing.Point(4, 4);
		    this.tabPage2.Name = "tabPage2";
		    this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		    this.tabPage2.Size = new System.Drawing.Size(540, 297);
		    this.tabPage2.TabIndex = 0;
		    this.tabPage2.Text = "tabPage2";
		    this.tabPage2.UseVisualStyleBackColor = true;
		    // 
		    // dataGridView1
		    // 
		    this.dataGridView1.AllowUserToOrderColumns = true;
		    this.dataGridView1.AllowUserToResizeRows = false;
		    this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
		    this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		    this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		    this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
		    this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.dataGridView1.Location = new System.Drawing.Point(3, 3);
		    this.dataGridView1.Name = "dataGridView1";
		    this.dataGridView1.RowHeadersWidth = 24;
		    this.dataGridView1.RowTemplate.Height = 24;
		    this.dataGridView1.Size = new System.Drawing.Size(534, 291);
		    this.dataGridView1.TabIndex = 0;
		    // 
		    // tabPage3
		    // 
		    this.tabPage3.Controls.Add(this.dataGridView2);
		    this.tabPage3.Location = new System.Drawing.Point(4, 4);
		    this.tabPage3.Name = "tabPage3";
		    this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
		    this.tabPage3.Size = new System.Drawing.Size(540, 297);
		    this.tabPage3.TabIndex = 1;
		    this.tabPage3.Text = "tabPage3";
		    this.tabPage3.UseVisualStyleBackColor = true;
		    // 
		    // dataGridView2
		    // 
		    this.dataGridView2.AllowDrop = true;
		    this.dataGridView2.AllowUserToOrderColumns = true;
		    this.dataGridView2.AllowUserToResizeRows = false;
		    this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
		    this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
		    this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		    this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
		    this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		    		    		    this.Column1,
		    		    		    this.Column2,
		    		    		    this.Column3});
		    this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.dataGridView2.Location = new System.Drawing.Point(3, 3);
		    this.dataGridView2.Name = "dataGridView2";
		    this.dataGridView2.RowHeadersWidth = 24;
		    this.dataGridView2.RowTemplate.Height = 24;
		    this.dataGridView2.Size = new System.Drawing.Size(534, 291);
		    this.dataGridView2.TabIndex = 0;
		    this.dataGridView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.DataGridView2DragDrop);
		    this.dataGridView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.DataGridView1DragEnter);
		    // 
		    // Column1
		    // 
		    this.Column1.HeaderText = "Column1";
		    this.Column1.Name = "Column1";
		    // 
		    // Column2
		    // 
		    this.Column2.HeaderText = "Column2";
		    this.Column2.Name = "Column2";
		    this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		    // 
		    // Column3
		    // 
		    this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		    this.Column3.HeaderText = "Column3";
		    this.Column3.Name = "Column3";
		    this.Column3.ReadOnly = true;
		    // 
		    // toolStrip1
		    // 
		    this.toolStrip1.BackColor = System.Drawing.Color.White;
		    this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		    this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		    this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.toolStripDropDownButton1,
		    		    		    this.toolStripSeparator1,
		    		    		    this.toolStripSplitButton1,
		    		    		    this.toolStripSplitButton2,
		    		    		    this.toolStripMenuItem6});
		    this.toolStrip1.Location = new System.Drawing.Point(2, 3);
		    this.toolStrip1.Name = "toolStrip1";
		    this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		    this.toolStrip1.Size = new System.Drawing.Size(548, 31);
		    this.toolStrip1.TabIndex = 1;
		    this.toolStrip1.Text = "toolStrip1";
		    // 
		    // toolStripDropDownButton1
		    // 
		    this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		    this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.loadXMLToolStripMenuItem,
		    		    		    this.saveXMLToolStripMenuItem,
		    		    		    this.toolStripMenuItem2,
		    		    		    this.loadTextToolStripMenuItem,
		    		    		    this.saveTextToolStripMenuItem});
		    this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
		    this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
		    this.toolStripDropDownButton1.ShowDropDownArrow = false;
		    this.toolStripDropDownButton1.Size = new System.Drawing.Size(28, 28);
		    // 
		    // loadXMLToolStripMenuItem
		    // 
		    this.loadXMLToolStripMenuItem.Name = "loadXMLToolStripMenuItem";
		    this.loadXMLToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
		    this.loadXMLToolStripMenuItem.Text = "Load XML";
		    this.loadXMLToolStripMenuItem.Click += new System.EventHandler(this.LoadXMLToolStripMenuItemClick);
		    // 
		    // saveXMLToolStripMenuItem
		    // 
		    this.saveXMLToolStripMenuItem.Name = "saveXMLToolStripMenuItem";
		    this.saveXMLToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
		    this.saveXMLToolStripMenuItem.Text = "Save XML";
		    this.saveXMLToolStripMenuItem.Click += new System.EventHandler(this.SaveXMLToolStripMenuItemClick);
		    // 
		    // toolStripMenuItem2
		    // 
		    this.toolStripMenuItem2.Name = "toolStripMenuItem2";
		    this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 6);
		    // 
		    // loadTextToolStripMenuItem
		    // 
		    this.loadTextToolStripMenuItem.Name = "loadTextToolStripMenuItem";
		    this.loadTextToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
		    this.loadTextToolStripMenuItem.Text = "Load Text";
		    this.loadTextToolStripMenuItem.Click += new System.EventHandler(this.LoadTextToolStripMenuItemClick);
		    // 
		    // saveTextToolStripMenuItem
		    // 
		    this.saveTextToolStripMenuItem.Name = "saveTextToolStripMenuItem";
		    this.saveTextToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
		    this.saveTextToolStripMenuItem.Text = "Save Text";
		    this.saveTextToolStripMenuItem.Click += new System.EventHandler(this.SaveTextToolStripMenuItemClick);
		    // 
		    // toolStripSeparator1
		    // 
		    this.toolStripSeparator1.Name = "toolStripSeparator1";
		    this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
		    // 
		    // toolStripSplitButton1
		    // 
		    this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		    this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.toolStripMenuItem4,
		    		    		    this.toolStripMenuItem5});
		    this.toolStripSplitButton1.Image = global::FeedTool.Resource.appbar_sort_alphabetical_ascending;
		    this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.toolStripSplitButton1.Name = "toolStripSplitButton1";
		    this.toolStripSplitButton1.Size = new System.Drawing.Size(40, 28);
		    this.toolStripSplitButton1.Text = "toolStripSplitButton1";
		    // 
		    // toolStripMenuItem4
		    // 
		    this.toolStripMenuItem4.Image = global::FeedTool.Resource.appbar_sort_alphabetical_ascending;
		    this.toolStripMenuItem4.Name = "toolStripMenuItem4";
		    this.toolStripMenuItem4.Size = new System.Drawing.Size(160, 22);
		    this.toolStripMenuItem4.Text = "Sort Ascending";
		    // 
		    // toolStripMenuItem5
		    // 
		    this.toolStripMenuItem5.Image = global::FeedTool.Resource.appbar_sort_alphabetical_descending;
		    this.toolStripMenuItem5.Name = "toolStripMenuItem5";
		    this.toolStripMenuItem5.Size = new System.Drawing.Size(160, 22);
		    this.toolStripMenuItem5.Text = "Sort Descending";
		    // 
		    // toolStripSplitButton2
		    // 
		    this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		    this.toolStripSplitButton2.Image = global::FeedTool.Resource.appbar_radar;
		    this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.toolStripSplitButton2.Name = "toolStripSplitButton2";
		    this.toolStripSplitButton2.Size = new System.Drawing.Size(28, 28);
		    this.toolStripSplitButton2.Text = "toolStripSplitButton2";
		    // 
		    // toolStripMenuItem6
		    // 
		    this.toolStripMenuItem6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		    this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.toolStripMenuItem7,
		    		    		    this.toolStripSeparator3,
		    		    		    this.toolStripMenuItem10,
		    		    		    this.toolStripMenuItem11});
		    this.toolStripMenuItem6.Image = global::FeedTool.Resource.appbar_settings;
		    this.toolStripMenuItem6.Name = "toolStripMenuItem6";
		    this.toolStripMenuItem6.Size = new System.Drawing.Size(67, 28);
		    this.toolStripMenuItem6.Text = "Utils";
		    // 
		    // toolStripMenuItem7
		    // 
		    this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.toolStripMenuItem8,
		    		    		    this.toolStripMenuItem9});
		    this.toolStripMenuItem7.Name = "toolStripMenuItem7";
		    this.toolStripMenuItem7.Size = new System.Drawing.Size(151, 22);
		    this.toolStripMenuItem7.Text = "Import/Export";
		    // 
		    // toolStripMenuItem8
		    // 
		    this.toolStripMenuItem8.Name = "toolStripMenuItem8";
		    this.toolStripMenuItem8.Size = new System.Drawing.Size(198, 22);
		    this.toolStripMenuItem8.Text = "Import SQLite Database";
		    // 
		    // toolStripMenuItem9
		    // 
		    this.toolStripMenuItem9.Name = "toolStripMenuItem9";
		    this.toolStripMenuItem9.Size = new System.Drawing.Size(198, 22);
		    this.toolStripMenuItem9.Text = "Export SQLite Database";
		    // 
		    // toolStripSeparator3
		    // 
		    this.toolStripSeparator3.Name = "toolStripSeparator3";
		    this.toolStripSeparator3.Size = new System.Drawing.Size(148, 6);
		    // 
		    // toolStripMenuItem10
		    // 
		    this.toolStripMenuItem10.Name = "toolStripMenuItem10";
		    this.toolStripMenuItem10.Size = new System.Drawing.Size(151, 22);
		    this.toolStripMenuItem10.Text = "Editor Formats";
		    // 
		    // toolStripMenuItem11
		    // 
		    this.toolStripMenuItem11.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.toolStripMenuItem12});
		    this.toolStripMenuItem11.Name = "toolStripMenuItem11";
		    this.toolStripMenuItem11.Size = new System.Drawing.Size(151, 22);
		    this.toolStripMenuItem11.Text = "Miscelaneous";
		    // 
		    // toolStripMenuItem12
		    // 
		    this.toolStripMenuItem12.Name = "toolStripMenuItem12";
		    this.toolStripMenuItem12.Size = new System.Drawing.Size(118, 22);
		    this.toolStripMenuItem12.Text = "Icon List";
		    // 
		    // tableLayoutPanel1
		    // 
		    this.tableLayoutPanel1.AutoSize = true;
		    this.tableLayoutPanel1.ColumnCount = 3;
		    this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		    this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		    this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		    this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 0);
		    this.tableLayoutPanel1.Controls.Add(this.textBox1, 2, 0);
		    this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
		    this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
		    this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		    this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		    this.tableLayoutPanel1.RowCount = 1;
		    this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		    this.tableLayoutPanel1.Size = new System.Drawing.Size(853, 31);
		    this.tableLayoutPanel1.TabIndex = 10;
		    // 
		    // menuStrip1
		    // 
		    this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
		    this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.actionsToolStripMenuItem,
		    		    		    this.toolStripSeparator2,
		    		    		    this.toolStripButton1,
		    		    		    this.toolStripDropDownButton2});
		    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		    this.menuStrip1.Name = "menuStrip1";
		    this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
		    this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		    this.menuStrip1.Size = new System.Drawing.Size(186, 31);
		    this.menuStrip1.TabIndex = 5;
		    this.menuStrip1.Text = "menuStrip1";
		    // 
		    // actionsToolStripMenuItem
		    // 
		    this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.refreshAllToolStripMenuItem,
		    		    		    this.refreshSelectedToolStripMenuItem,
		    		    		    this.loadXmlFileToolStripMenuItem,
		    		    		    this.toolStripMenuItem3,
		    		    		    this.exitToolStripMenuItem});
		    this.actionsToolStripMenuItem.Image = global::FeedTool.Resource.appbar_folder;
		    this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
		    this.actionsToolStripMenuItem.Size = new System.Drawing.Size(83, 31);
		    this.actionsToolStripMenuItem.Text = "Actions";
		    // 
		    // refreshAllToolStripMenuItem
		    // 
		    this.refreshAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshAllToolStripMenuItem.Image")));
		    this.refreshAllToolStripMenuItem.Name = "refreshAllToolStripMenuItem";
		    this.refreshAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
		    		    		    | System.Windows.Forms.Keys.L)));
		    this.refreshAllToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
		    this.refreshAllToolStripMenuItem.Text = "Refresh All";
		    // 
		    // refreshSelectedToolStripMenuItem
		    // 
		    this.refreshSelectedToolStripMenuItem.Name = "refreshSelectedToolStripMenuItem";
		    this.refreshSelectedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
		    this.refreshSelectedToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
		    this.refreshSelectedToolStripMenuItem.Text = "Load Text File";
		    this.refreshSelectedToolStripMenuItem.Click += new System.EventHandler(this.LoadTextToolStripMenuItemClick);
		    // 
		    // loadXmlFileToolStripMenuItem
		    // 
		    this.loadXmlFileToolStripMenuItem.Name = "loadXmlFileToolStripMenuItem";
		    this.loadXmlFileToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
		    this.loadXmlFileToolStripMenuItem.Text = "Load Xml File (*.feeds)";
		    this.loadXmlFileToolStripMenuItem.ToolTipText = "Not just any text file:\r\nWe load a *.feeds file (native to this app).";
		    this.loadXmlFileToolStripMenuItem.Click += new System.EventHandler(this.LoadXMLToolStripMenuItemClick);
		    // 
		    // toolStripMenuItem3
		    // 
		    this.toolStripMenuItem3.Name = "toolStripMenuItem3";
		    this.toolStripMenuItem3.Size = new System.Drawing.Size(199, 6);
		    // 
		    // exitToolStripMenuItem
		    // 
		    this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
		    this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
		    this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
		    this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
		    this.exitToolStripMenuItem.Text = "Exit";
		    // 
		    // toolStripSeparator2
		    // 
		    this.toolStripSeparator2.Name = "toolStripSeparator2";
		    this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
		    // 
		    // toolStripButton1
		    // 
		    this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		    this.toolStripButton1.Image = global::FeedTool.Resource.appbar_radar;
		    this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		    this.toolStripButton1.Name = "toolStripButton1";
		    this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
		    this.toolStripButton1.Text = "toolStripSplitButton2";
		    this.toolStripButton1.Click += new System.EventHandler(this.Event_TryLoadOPML);
		    // 
		    // toolStripDropDownButton2
		    // 
		    this.toolStripDropDownButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		    this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.toolStripMenuItem1,
		    		    		    this.toolStripSeparator4,
		    		    		    this.editorFormatsToolStripMenuItem,
		    		    		    this.toolStripMenuItem16});
		    this.toolStripDropDownButton2.Image = global::FeedTool.Resource.appbar_settings;
		    this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
		    this.toolStripDropDownButton2.Size = new System.Drawing.Size(67, 28);
		    this.toolStripDropDownButton2.Text = "Utils";
		    // 
		    // toolStripMenuItem1
		    // 
		    this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.toolStripMenuItem13,
		    		    		    this.toolStripMenuItem14});
		    this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		    this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
		    this.toolStripMenuItem1.Text = "Import/Export";
		    // 
		    // toolStripMenuItem13
		    // 
		    this.toolStripMenuItem13.Name = "toolStripMenuItem13";
		    this.toolStripMenuItem13.Size = new System.Drawing.Size(198, 22);
		    this.toolStripMenuItem13.Text = "Import SQLite Database";
		    // 
		    // toolStripMenuItem14
		    // 
		    this.toolStripMenuItem14.Name = "toolStripMenuItem14";
		    this.toolStripMenuItem14.Size = new System.Drawing.Size(198, 22);
		    this.toolStripMenuItem14.Text = "Export SQLite Database";
		    // 
		    // toolStripSeparator4
		    // 
		    this.toolStripSeparator4.Name = "toolStripSeparator4";
		    this.toolStripSeparator4.Size = new System.Drawing.Size(148, 6);
		    // 
		    // editorFormatsToolStripMenuItem
		    // 
		    this.editorFormatsToolStripMenuItem.Name = "editorFormatsToolStripMenuItem";
		    this.editorFormatsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
		    this.editorFormatsToolStripMenuItem.Text = "Editor Formats";
		    // 
		    // toolStripMenuItem16
		    // 
		    this.toolStripMenuItem16.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
		    		    		    this.toolStripMenuItem17});
		    this.toolStripMenuItem16.Name = "toolStripMenuItem16";
		    this.toolStripMenuItem16.Size = new System.Drawing.Size(151, 22);
		    this.toolStripMenuItem16.Text = "Miscelaneous";
		    // 
		    // toolStripMenuItem17
		    // 
		    this.toolStripMenuItem17.Name = "toolStripMenuItem17";
		    this.toolStripMenuItem17.Size = new System.Drawing.Size(118, 22);
		    this.toolStripMenuItem17.Text = "Icon List";
		    // 
		    // ctx0
		    // 
		    this.ctx0.Name = "ctx0";
		    this.ctx0.Size = new System.Drawing.Size(61, 4);
		    // 
		    // ctx1
		    // 
		    this.ctx1.Name = "contextMenuStrip1";
		    this.ctx1.Size = new System.Drawing.Size(61, 4);
		    // 
		    // MainForm
		    // 
		    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		    this.BackColor = System.Drawing.Color.White;
		    this.ClientSize = new System.Drawing.Size(853, 448);
		    this.Controls.Add(this.splitContainer1);
		    this.Controls.Add(this.tableLayoutPanel1);
		    this.Controls.Add(this.statusStrip1);
		    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		    this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		    this.Name = "MainForm";
		    this.Text = "FeedTool";
		    this.statusStrip1.ResumeLayout(false);
		    this.statusStrip1.PerformLayout();
		    this.splitContainer1.Panel1.ResumeLayout(false);
		    this.splitContainer1.Panel2.ResumeLayout(false);
		    ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
		    this.splitContainer1.ResumeLayout(false);
		    this.tabControl2.ResumeLayout(false);
		    this.tab1_nfo.ResumeLayout(false);
		    this.tab1_nfo.PerformLayout();
		    this.tab1_www.ResumeLayout(false);
		    this.tabControl1.ResumeLayout(false);
		    this.tab2_www.ResumeLayout(false);
		    this.tab2_TextEdit.ResumeLayout(false);
		    this.tabPage1.ResumeLayout(false);
		    this.tab1_Data.ResumeLayout(false);
		    this.tab1_Data.PerformLayout();
		    this.tabControl3.ResumeLayout(false);
		    this.tabPage2.ResumeLayout(false);
		    ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
		    this.tabPage3.ResumeLayout(false);
		    ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
		    this.toolStrip1.ResumeLayout(false);
		    this.toolStrip1.PerformLayout();
		    this.tableLayoutPanel1.ResumeLayout(false);
		    this.tableLayoutPanel1.PerformLayout();
		    this.menuStrip1.ResumeLayout(false);
		    this.menuStrip1.PerformLayout();
		    this.ResumeLayout(false);
		    this.PerformLayout();
		}
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewLinkColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabControl tabControl3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
		private System.Windows.Forms.ToolStripMenuItem editorFormatsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
		private System.Windows.Forms.ToolStripDropDownButton toolStripMenuItem6;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolStripSplitButton2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private Flash.FlashVidTool flashVidTool1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem loadXmlFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadXMLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadTextToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem saveTextToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveXMLToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
		private ICSharpCode.TextEditor.TextEditorControl textEditor;
		private System.Windows.Forms.TabPage tab2_TextEdit;
		private System.Windows.Forms.TabPage tab2_www;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tab1_Data;
		private System.Windows.Forms.ContextMenuStrip ctx1;
		private System.Windows.Forms.ContextMenuStrip ctx0;
		internal System.Windows.Forms.ImageList imageList2;
		internal System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel label4;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshSelectedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tab1_nfo;
		private System.Windows.Forms.TabPage tab1_www;
		private System.Windows.Forms.WebBrowser webBrowser1;
	}
}
