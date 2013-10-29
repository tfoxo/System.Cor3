/*
 * oIo — 11/15/2010 — 6:23 PM
 */
namespace Flash
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
			this.axFlashPlayer = new AxShockwaveFlashObjects.AxShockwaveFlash();
			((System.ComponentModel.ISupportInitialize)(this.axFlashPlayer)).BeginInit();
			this.SuspendLayout();
			// 
			// axFlashPlayer
			// 
			this.axFlashPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.axFlashPlayer.Enabled = true;
			this.axFlashPlayer.Location = new System.Drawing.Point(0, 0);
			this.axFlashPlayer.Name = "axFlashPlayer";
			this.axFlashPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFlashPlayer.OcxState")));
			this.axFlashPlayer.Proxy = null;
			this.axFlashPlayer.Size = new System.Drawing.Size(495, 303);
			this.axFlashPlayer.TabIndex = 0;
			// 
			// FlashVidTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.axFlashPlayer);
			this.Name = "FlashVidTool";
			this.Size = new System.Drawing.Size(495, 303);
			((System.ComponentModel.ISupportInitialize)(this.axFlashPlayer)).EndInit();
			this.ResumeLayout(false);
		}
		private AxShockwaveFlashObjects.AxShockwaveFlash axFlashPlayer;
	}
}
