/* oio : 1/8/2014 10:39 PM */
namespace Pdf2Png
{
	partial class ColorMatrixControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.cm00 = new System.Windows.Forms.NumericUpDown();
			this.cm01 = new System.Windows.Forms.NumericUpDown();
			this.cm02 = new System.Windows.Forms.NumericUpDown();
			this.cm12 = new System.Windows.Forms.NumericUpDown();
			this.cm11 = new System.Windows.Forms.NumericUpDown();
			this.cm10 = new System.Windows.Forms.NumericUpDown();
			this.cm22 = new System.Windows.Forms.NumericUpDown();
			this.cm21 = new System.Windows.Forms.NumericUpDown();
			this.cm20 = new System.Windows.Forms.NumericUpDown();
			this.cm32 = new System.Windows.Forms.NumericUpDown();
			this.cm31 = new System.Windows.Forms.NumericUpDown();
			this.cm30 = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.cm44 = new System.Windows.Forms.NumericUpDown();
			this.cm43 = new System.Windows.Forms.NumericUpDown();
			this.cm34 = new System.Windows.Forms.NumericUpDown();
			this.cm33 = new System.Windows.Forms.NumericUpDown();
			this.cm24 = new System.Windows.Forms.NumericUpDown();
			this.cm23 = new System.Windows.Forms.NumericUpDown();
			this.cm14 = new System.Windows.Forms.NumericUpDown();
			this.cm13 = new System.Windows.Forms.NumericUpDown();
			this.cm04 = new System.Windows.Forms.NumericUpDown();
			this.cm03 = new System.Windows.Forms.NumericUpDown();
			this.cm42 = new System.Windows.Forms.NumericUpDown();
			this.cm41 = new System.Windows.Forms.NumericUpDown();
			this.cm40 = new System.Windows.Forms.NumericUpDown();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tbInputFile = new System.Windows.Forms.TextBox();
			this.btnBrowsePdf = new System.Windows.Forms.Button();
			this.nZoom = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nDpi = new System.Windows.Forms.NumericUpDown();
			this.btnProcess = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.cbMatrixMode = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.nPageStart = new System.Windows.Forms.NumericUpDown();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.button1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.nPagesCount = new System.Windows.Forms.NumericUpDown();
			this.button2 = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.cm00)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm01)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm02)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm12)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm22)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm21)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm20)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm32)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm31)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm30)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cm44)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm43)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm34)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm33)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm24)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm23)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm14)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm13)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm04)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm03)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm42)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm41)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cm40)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nZoom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nDpi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nPageStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nPagesCount)).BeginInit();
			this.SuspendLayout();
			// 
			// cm00
			// 
			this.cm00.DecimalPlaces = 2;
			this.cm00.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm00.Location = new System.Drawing.Point(11, 45);
			this.cm00.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm00.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm00.Name = "cm00";
			this.cm00.Size = new System.Drawing.Size(48, 20);
			this.cm00.TabIndex = 0;
			this.cm00.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm01
			// 
			this.cm01.DecimalPlaces = 2;
			this.cm01.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm01.Location = new System.Drawing.Point(59, 45);
			this.cm01.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm01.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm01.Name = "cm01";
			this.cm01.Size = new System.Drawing.Size(48, 20);
			this.cm01.TabIndex = 1;
			this.cm01.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm02
			// 
			this.cm02.DecimalPlaces = 2;
			this.cm02.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm02.Location = new System.Drawing.Point(107, 45);
			this.cm02.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm02.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm02.Name = "cm02";
			this.cm02.Size = new System.Drawing.Size(48, 20);
			this.cm02.TabIndex = 2;
			this.cm02.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm12
			// 
			this.cm12.DecimalPlaces = 2;
			this.cm12.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm12.Location = new System.Drawing.Point(107, 65);
			this.cm12.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm12.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm12.Name = "cm12";
			this.cm12.Size = new System.Drawing.Size(48, 20);
			this.cm12.TabIndex = 5;
			this.cm12.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm11
			// 
			this.cm11.DecimalPlaces = 2;
			this.cm11.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm11.Location = new System.Drawing.Point(59, 65);
			this.cm11.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm11.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm11.Name = "cm11";
			this.cm11.Size = new System.Drawing.Size(48, 20);
			this.cm11.TabIndex = 4;
			this.cm11.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm10
			// 
			this.cm10.DecimalPlaces = 2;
			this.cm10.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm10.Location = new System.Drawing.Point(11, 65);
			this.cm10.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm10.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm10.Name = "cm10";
			this.cm10.Size = new System.Drawing.Size(48, 20);
			this.cm10.TabIndex = 3;
			this.cm10.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm22
			// 
			this.cm22.DecimalPlaces = 2;
			this.cm22.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm22.Location = new System.Drawing.Point(107, 85);
			this.cm22.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm22.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm22.Name = "cm22";
			this.cm22.Size = new System.Drawing.Size(48, 20);
			this.cm22.TabIndex = 8;
			this.cm22.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm21
			// 
			this.cm21.DecimalPlaces = 2;
			this.cm21.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm21.Location = new System.Drawing.Point(59, 85);
			this.cm21.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm21.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm21.Name = "cm21";
			this.cm21.Size = new System.Drawing.Size(48, 20);
			this.cm21.TabIndex = 7;
			this.cm21.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm20
			// 
			this.cm20.DecimalPlaces = 2;
			this.cm20.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm20.Location = new System.Drawing.Point(11, 85);
			this.cm20.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm20.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm20.Name = "cm20";
			this.cm20.Size = new System.Drawing.Size(48, 20);
			this.cm20.TabIndex = 6;
			this.cm20.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm32
			// 
			this.cm32.DecimalPlaces = 2;
			this.cm32.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm32.Location = new System.Drawing.Point(107, 105);
			this.cm32.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm32.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm32.Name = "cm32";
			this.cm32.Size = new System.Drawing.Size(48, 20);
			this.cm32.TabIndex = 11;
			this.cm32.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm31
			// 
			this.cm31.DecimalPlaces = 2;
			this.cm31.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm31.Location = new System.Drawing.Point(59, 105);
			this.cm31.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm31.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm31.Name = "cm31";
			this.cm31.Size = new System.Drawing.Size(48, 20);
			this.cm31.TabIndex = 10;
			this.cm31.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm30
			// 
			this.cm30.DecimalPlaces = 2;
			this.cm30.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm30.Location = new System.Drawing.Point(11, 105);
			this.cm30.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm30.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm30.Name = "cm30";
			this.cm30.Size = new System.Drawing.Size(48, 20);
			this.cm30.TabIndex = 9;
			this.cm30.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.cm44);
			this.groupBox1.Controls.Add(this.cm43);
			this.groupBox1.Controls.Add(this.cm34);
			this.groupBox1.Controls.Add(this.cm33);
			this.groupBox1.Controls.Add(this.cm24);
			this.groupBox1.Controls.Add(this.cm23);
			this.groupBox1.Controls.Add(this.cm14);
			this.groupBox1.Controls.Add(this.cm13);
			this.groupBox1.Controls.Add(this.cm04);
			this.groupBox1.Controls.Add(this.cm03);
			this.groupBox1.Controls.Add(this.cm42);
			this.groupBox1.Controls.Add(this.cm41);
			this.groupBox1.Controls.Add(this.cm40);
			this.groupBox1.Controls.Add(this.cm00);
			this.groupBox1.Controls.Add(this.cm32);
			this.groupBox1.Controls.Add(this.cm01);
			this.groupBox1.Controls.Add(this.cm31);
			this.groupBox1.Controls.Add(this.cm02);
			this.groupBox1.Controls.Add(this.cm30);
			this.groupBox1.Controls.Add(this.cm10);
			this.groupBox1.Controls.Add(this.cm22);
			this.groupBox1.Controls.Add(this.cm11);
			this.groupBox1.Controls.Add(this.cm21);
			this.groupBox1.Controls.Add(this.cm12);
			this.groupBox1.Controls.Add(this.cm20);
			this.groupBox1.Location = new System.Drawing.Point(400, 11);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(263, 158);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "COLOR MATRIX";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(13, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 16);
			this.label5.TabIndex = 23;
			this.label5.Text = "KEY";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(67, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(184, 20);
			this.textBox1.TabIndex = 25;
			// 
			// cm44
			// 
			this.cm44.DecimalPlaces = 2;
			this.cm44.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm44.Location = new System.Drawing.Point(203, 125);
			this.cm44.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm44.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm44.Name = "cm44";
			this.cm44.Size = new System.Drawing.Size(48, 20);
			this.cm44.TabIndex = 24;
			this.cm44.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm43
			// 
			this.cm43.DecimalPlaces = 2;
			this.cm43.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm43.Location = new System.Drawing.Point(155, 125);
			this.cm43.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm43.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm43.Name = "cm43";
			this.cm43.Size = new System.Drawing.Size(48, 20);
			this.cm43.TabIndex = 23;
			this.cm43.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm34
			// 
			this.cm34.DecimalPlaces = 2;
			this.cm34.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm34.Location = new System.Drawing.Point(203, 105);
			this.cm34.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm34.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm34.Name = "cm34";
			this.cm34.Size = new System.Drawing.Size(48, 20);
			this.cm34.TabIndex = 22;
			this.cm34.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm33
			// 
			this.cm33.DecimalPlaces = 2;
			this.cm33.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm33.Location = new System.Drawing.Point(155, 105);
			this.cm33.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm33.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm33.Name = "cm33";
			this.cm33.Size = new System.Drawing.Size(48, 20);
			this.cm33.TabIndex = 21;
			this.cm33.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm24
			// 
			this.cm24.DecimalPlaces = 2;
			this.cm24.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm24.Location = new System.Drawing.Point(203, 85);
			this.cm24.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm24.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm24.Name = "cm24";
			this.cm24.Size = new System.Drawing.Size(48, 20);
			this.cm24.TabIndex = 20;
			this.cm24.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm23
			// 
			this.cm23.DecimalPlaces = 2;
			this.cm23.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm23.Location = new System.Drawing.Point(155, 85);
			this.cm23.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm23.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm23.Name = "cm23";
			this.cm23.Size = new System.Drawing.Size(48, 20);
			this.cm23.TabIndex = 19;
			this.cm23.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm14
			// 
			this.cm14.DecimalPlaces = 2;
			this.cm14.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm14.Location = new System.Drawing.Point(203, 65);
			this.cm14.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm14.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm14.Name = "cm14";
			this.cm14.Size = new System.Drawing.Size(48, 20);
			this.cm14.TabIndex = 18;
			this.cm14.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm13
			// 
			this.cm13.DecimalPlaces = 2;
			this.cm13.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm13.Location = new System.Drawing.Point(155, 65);
			this.cm13.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm13.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm13.Name = "cm13";
			this.cm13.Size = new System.Drawing.Size(48, 20);
			this.cm13.TabIndex = 17;
			this.cm13.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm04
			// 
			this.cm04.DecimalPlaces = 2;
			this.cm04.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm04.Location = new System.Drawing.Point(203, 45);
			this.cm04.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm04.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm04.Name = "cm04";
			this.cm04.Size = new System.Drawing.Size(48, 20);
			this.cm04.TabIndex = 16;
			this.cm04.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm03
			// 
			this.cm03.DecimalPlaces = 2;
			this.cm03.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm03.Location = new System.Drawing.Point(155, 45);
			this.cm03.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm03.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm03.Name = "cm03";
			this.cm03.Size = new System.Drawing.Size(48, 20);
			this.cm03.TabIndex = 15;
			this.cm03.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm42
			// 
			this.cm42.DecimalPlaces = 2;
			this.cm42.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm42.Location = new System.Drawing.Point(107, 125);
			this.cm42.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm42.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm42.Name = "cm42";
			this.cm42.Size = new System.Drawing.Size(48, 20);
			this.cm42.TabIndex = 14;
			this.cm42.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm41
			// 
			this.cm41.DecimalPlaces = 2;
			this.cm41.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm41.Location = new System.Drawing.Point(59, 125);
			this.cm41.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm41.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm41.Name = "cm41";
			this.cm41.Size = new System.Drawing.Size(48, 20);
			this.cm41.TabIndex = 13;
			this.cm41.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// cm40
			// 
			this.cm40.DecimalPlaces = 2;
			this.cm40.Increment = new decimal(new int[] {
			5,
			0,
			0,
			131072});
			this.cm40.Location = new System.Drawing.Point(11, 125);
			this.cm40.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.cm40.Minimum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.cm40.Name = "cm40";
			this.cm40.Size = new System.Drawing.Size(48, 20);
			this.cm40.TabIndex = 12;
			this.cm40.Value = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(386, 392);
			this.panel1.TabIndex = 6;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.tbInputFile);
			this.groupBox2.Controls.Add(this.btnBrowsePdf);
			this.groupBox2.Location = new System.Drawing.Point(8, 406);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(661, 48);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "INPUT FILE (PDF)";
			// 
			// tbInputFile
			// 
			this.tbInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbInputFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.tbInputFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.tbInputFile.Location = new System.Drawing.Point(8, 16);
			this.tbInputFile.Name = "tbInputFile";
			this.tbInputFile.Size = new System.Drawing.Size(571, 20);
			this.tbInputFile.TabIndex = 0;
			// 
			// btnBrowsePdf
			// 
			this.btnBrowsePdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowsePdf.Location = new System.Drawing.Point(580, 14);
			this.btnBrowsePdf.Name = "btnBrowsePdf";
			this.btnBrowsePdf.Size = new System.Drawing.Size(75, 23);
			this.btnBrowsePdf.TabIndex = 1;
			this.btnBrowsePdf.Text = "BROWSE";
			this.btnBrowsePdf.UseVisualStyleBackColor = true;
			this.btnBrowsePdf.Click += new System.EventHandler(this.BtnBrowsePdfClick);
			// 
			// nZoom
			// 
			this.nZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nZoom.DecimalPlaces = 3;
			this.nZoom.Location = new System.Drawing.Point(537, 269);
			this.nZoom.Name = "nZoom";
			this.nZoom.Size = new System.Drawing.Size(116, 20);
			this.nZoom.TabIndex = 0;
			this.nZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nZoom.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(473, 269);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 16;
			this.label1.Text = "ZOOM";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(473, 293);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 18;
			this.label2.Text = "DPI";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nDpi
			// 
			this.nDpi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nDpi.Location = new System.Drawing.Point(537, 293);
			this.nDpi.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.nDpi.Minimum = new decimal(new int[] {
			30,
			0,
			0,
			0});
			this.nDpi.Name = "nDpi";
			this.nDpi.Size = new System.Drawing.Size(116, 20);
			this.nDpi.TabIndex = 1;
			this.nDpi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nDpi.Value = new decimal(new int[] {
			300,
			0,
			0,
			0});
			// 
			// btnProcess
			// 
			this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnProcess.Location = new System.Drawing.Point(574, 377);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(91, 23);
			this.btnProcess.TabIndex = 4;
			this.btnProcess.Text = "PROCESS";
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += new System.EventHandler(this.BtnProcessClick);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdate.Location = new System.Drawing.Point(478, 377);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(91, 23);
			this.btnUpdate.TabIndex = 3;
			this.btnUpdate.Text = "GO";
			this.toolTip1.SetToolTip(this.btnUpdate, "Main execution process,");
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.BtnUpdateClick);
			// 
			// cbMatrixMode
			// 
			this.cbMatrixMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbMatrixMode.FormattingEnabled = true;
			this.cbMatrixMode.Location = new System.Drawing.Point(461, 175);
			this.cbMatrixMode.Name = "cbMatrixMode";
			this.cbMatrixMode.Size = new System.Drawing.Size(192, 21);
			this.cbMatrixMode.TabIndex = 19;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(405, 176);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 20;
			this.label3.Text = "MODE";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Location = new System.Drawing.Point(461, 202);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 16);
			this.label4.TabIndex = 22;
			this.label4.Text = "PAGE NO.";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nPageStart
			// 
			this.nPageStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nPageStart.Location = new System.Drawing.Point(537, 202);
			this.nPageStart.Maximum = new decimal(new int[] {
			0,
			0,
			0,
			0});
			this.nPageStart.Name = "nPageStart";
			this.nPageStart.Size = new System.Drawing.Size(116, 20);
			this.nPageStart.TabIndex = 21;
			this.nPageStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip1.SetToolTip(this.nPageStart, "Set the number of pages to generate.");
			this.nPageStart.ValueChanged += new System.EventHandler(this.NPageStartValueChanged);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(400, 322);
			this.progressBar1.Maximum = 1;
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(263, 23);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 23;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(400, 351);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 24;
			this.button1.Text = "ABOUT";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.ButtonAboutClick);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(461, 228);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 16);
			this.label6.TabIndex = 26;
			this.label6.Text = "PAGE CT.";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nPagesCount
			// 
			this.nPagesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nPagesCount.Location = new System.Drawing.Point(537, 228);
			this.nPagesCount.Maximum = new decimal(new int[] {
			0,
			0,
			0,
			0});
			this.nPagesCount.Name = "nPagesCount";
			this.nPagesCount.Size = new System.Drawing.Size(116, 20);
			this.nPagesCount.TabIndex = 25;
			this.nPagesCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip1.SetToolTip(this.nPagesCount, "The (or maxumum allowed) number of pages\r\ngenerated taking into consideration the" +
		" starting page\r\nnumber (PAGE NO.).");
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(478, 351);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(185, 23);
			this.button2.TabIndex = 27;
			this.button2.Text = "UPDATE PAGE CT/LEN";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.ButtonUpdatePageCountLength);
			// 
			// ColorMatrixControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(677, 462);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.nPagesCount);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.nPageStart);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbMatrixMode);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.nDpi);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nZoom);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.MinimumSize = new System.Drawing.Size(693, 500);
			this.Name = "ColorMatrixControl";
			this.Text = "PDF Matrix Filter";
			((System.ComponentModel.ISupportInitialize)(this.cm00)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm01)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm02)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm12)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm22)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm21)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm20)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm32)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm31)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm30)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cm44)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm43)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm34)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm33)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm24)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm23)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm14)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm13)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm04)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm03)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm42)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm41)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cm40)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nZoom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nDpi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nPageStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nPagesCount)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown nPagesCount;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.NumericUpDown cm03;
		private System.Windows.Forms.NumericUpDown cm04;
		private System.Windows.Forms.NumericUpDown cm13;
		private System.Windows.Forms.NumericUpDown cm14;
		private System.Windows.Forms.NumericUpDown cm23;
		private System.Windows.Forms.NumericUpDown cm24;
		private System.Windows.Forms.NumericUpDown cm33;
		private System.Windows.Forms.NumericUpDown cm34;
		private System.Windows.Forms.NumericUpDown cm43;
		private System.Windows.Forms.NumericUpDown cm44;
		private System.Windows.Forms.NumericUpDown cm40;
		private System.Windows.Forms.NumericUpDown cm41;
		private System.Windows.Forms.NumericUpDown cm42;
		private System.Windows.Forms.NumericUpDown nPageStart;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbMatrixMode;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.NumericUpDown nDpi;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nZoom;
		private System.Windows.Forms.Button btnBrowsePdf;
		private System.Windows.Forms.TextBox tbInputFile;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown cm30;
		private System.Windows.Forms.NumericUpDown cm31;
		private System.Windows.Forms.NumericUpDown cm32;
		private System.Windows.Forms.NumericUpDown cm20;
		private System.Windows.Forms.NumericUpDown cm21;
		private System.Windows.Forms.NumericUpDown cm22;
		private System.Windows.Forms.NumericUpDown cm10;
		private System.Windows.Forms.NumericUpDown cm11;
		private System.Windows.Forms.NumericUpDown cm12;
		private System.Windows.Forms.NumericUpDown cm02;
		private System.Windows.Forms.NumericUpDown cm01;
		private System.Windows.Forms.NumericUpDown cm00;
	}
}
