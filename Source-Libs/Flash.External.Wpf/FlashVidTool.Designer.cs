/*
 * oIo — 11/15/2010 — 6:23 PM
 */
namespace wpv
{
	partial class FlashVidTool
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlashVidTool));
			this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
			((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
			this.SuspendLayout();
			// 
			// axShockwaveFlash1
			// 
			this.axShockwaveFlash1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.axShockwaveFlash1.Enabled = true;
			this.axShockwaveFlash1.Location = new System.Drawing.Point(0, 0);
			this.axShockwaveFlash1.Name = "axShockwaveFlash1";
			this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
			this.axShockwaveFlash1.Size = new System.Drawing.Size(493, 293);
			this.axShockwaveFlash1.TabIndex = 0;
			// 
			// FlashVidTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.axShockwaveFlash1);
			this.Name = "FlashVidTool";
			this.Size = new System.Drawing.Size(493, 293);
			((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
			this.ResumeLayout(false);
		}
		private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
	}
}
