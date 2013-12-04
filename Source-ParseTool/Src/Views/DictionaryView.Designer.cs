/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 12/1/2013
 * Time: 11:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ParseTool.Views
{
	partial class DictionaryView
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
			this.lPrev = new System.Windows.Forms.LinkLabel();
			this.lNext = new System.Windows.Forms.LinkLabel();
			this.tNext = new System.Windows.Forms.TextBox();
			this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.lSave = new System.Windows.Forms.LinkLabel();
			this.lRevert = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// lPrev
			// 
			this.lPrev.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lPrev.AutoSize = true;
			this.lPrev.Font = new System.Drawing.Font("Segoe Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lPrev.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lPrev.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lPrev.Location = new System.Drawing.Point(270, 8);
			this.lPrev.Name = "lPrev";
			this.lPrev.Size = new System.Drawing.Size(36, 19);
			this.lPrev.TabIndex = 2;
			this.lPrev.TabStop = true;
			this.lPrev.Text = "Prev";
			this.lPrev.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkPrevClick);
			// 
			// lNext
			// 
			this.lNext.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lNext.AutoSize = true;
			this.lNext.Font = new System.Drawing.Font("Segoe Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lNext.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lNext.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lNext.Location = new System.Drawing.Point(314, 8);
			this.lNext.Name = "lNext";
			this.lNext.Size = new System.Drawing.Size(37, 19);
			this.lNext.TabIndex = 3;
			this.lNext.TabStop = true;
			this.lNext.Text = "Next";
			this.lNext.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkNextClick);
			// 
			// tNext
			// 
			this.tNext.Location = new System.Drawing.Point(4, 5);
			this.tNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tNext.Name = "tNext";
			this.tNext.Size = new System.Drawing.Size(258, 20);
			this.tNext.TabIndex = 0;
			this.toolTip1.SetToolTip(this.tNext, "Key");
			// 
			// textEditorControl1
			// 
			this.textEditorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.textEditorControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textEditorControl1.IsReadOnly = false;
			this.textEditorControl1.Location = new System.Drawing.Point(4, 32);
			this.textEditorControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textEditorControl1.Name = "textEditorControl1";
			this.textEditorControl1.Size = new System.Drawing.Size(519, 274);
			this.textEditorControl1.TabIndex = 1;
			this.textEditorControl1.Text = "textEditorControl1";
			this.toolTip1.SetToolTip(this.textEditorControl1, "Description");
			// 
			// lSave
			// 
			this.lSave.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lSave.AutoSize = true;
			this.lSave.Font = new System.Drawing.Font("Segoe Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lSave.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lSave.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lSave.Location = new System.Drawing.Point(486, 8);
			this.lSave.Name = "lSave";
			this.lSave.Size = new System.Drawing.Size(37, 19);
			this.lSave.TabIndex = 4;
			this.lSave.TabStop = true;
			this.lSave.Text = "Save";
			this.lSave.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SaveAction);
			// 
			// lRevert
			// 
			this.lRevert.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lRevert.AutoSize = true;
			this.lRevert.Font = new System.Drawing.Font("Segoe Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lRevert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lRevert.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lRevert.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lRevert.Location = new System.Drawing.Point(430, 8);
			this.lRevert.Name = "lRevert";
			this.lRevert.Size = new System.Drawing.Size(48, 19);
			this.lRevert.TabIndex = 5;
			this.lRevert.TabStop = true;
			this.lRevert.Text = "Revert";
			this.lRevert.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.lRevert.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RevertAction);
			// 
			// DictionaryView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lRevert);
			this.Controls.Add(this.lSave);
			this.Controls.Add(this.lPrev);
			this.Controls.Add(this.lNext);
			this.Controls.Add(this.tNext);
			this.Controls.Add(this.textEditorControl1);
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "DictionaryView";
			this.Size = new System.Drawing.Size(529, 311);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.LinkLabel lRevert;
		private System.Windows.Forms.LinkLabel lSave;
		private System.Windows.Forms.ToolTip toolTip1;
		private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
		private System.Windows.Forms.TextBox tNext;
		private System.Windows.Forms.LinkLabel lNext;
		private System.Windows.Forms.LinkLabel lPrev;
	}
}
