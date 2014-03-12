#region User/License
// oio * 8/25/2012 * 11:31 AM

// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion
namespace SoftwareIndex.Controls
{
	partial class CommandUtility
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
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tbParamValue = new System.Windows.Forms.TextBox();
			this.btnSetParam = new System.Windows.Forms.Button();
			this.comboCommandTasks = new System.Windows.Forms.ComboBox();
			this.comboParams = new System.Windows.Forms.ComboBox();
			this.btnCheck = new System.Windows.Forms.Button();
			this.btnExecute = new System.Windows.Forms.Button();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.tbParamValue);
			this.groupBox3.Controls.Add(this.btnSetParam);
			this.groupBox3.Controls.Add(this.comboCommandTasks);
			this.groupBox3.Controls.Add(this.comboParams);
			this.groupBox3.Controls.Add(this.btnCheck);
			this.groupBox3.Controls.Add(this.btnExecute);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(408, 108);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Template Actions";
			// 
			// tbParamValue
			// 
			this.tbParamValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tbParamValue.Location = new System.Drawing.Point(13, 75);
			this.tbParamValue.Name = "tbParamValue";
			this.tbParamValue.Size = new System.Drawing.Size(308, 20);
			this.tbParamValue.TabIndex = 4;
			// 
			// btnSetParam
			// 
			this.btnSetParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSetParam.Location = new System.Drawing.Point(327, 72);
			this.btnSetParam.Name = "btnSetParam";
			this.btnSetParam.Size = new System.Drawing.Size(75, 23);
			this.btnSetParam.TabIndex = 3;
			this.btnSetParam.Text = "Load/Save";
			this.btnSetParam.UseVisualStyleBackColor = true;
			this.btnSetParam.Click += new System.EventHandler(this.BtnSetParamClick);
			// 
			// comboCommandTasks
			// 
			this.comboCommandTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.comboCommandTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboCommandTasks.FormattingEnabled = true;
			this.comboCommandTasks.Location = new System.Drawing.Point(13, 20);
			this.comboCommandTasks.Name = "comboCommandTasks";
			this.comboCommandTasks.Size = new System.Drawing.Size(227, 21);
			this.comboCommandTasks.TabIndex = 1;
			// 
			// comboParams
			// 
			this.comboParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.comboParams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboParams.FormattingEnabled = true;
			this.comboParams.Location = new System.Drawing.Point(13, 47);
			this.comboParams.Name = "comboParams";
			this.comboParams.Size = new System.Drawing.Size(308, 21);
			this.comboParams.TabIndex = 1;
			// 
			// btnCheck
			// 
			this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCheck.Location = new System.Drawing.Point(246, 18);
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.Size = new System.Drawing.Size(75, 22);
			this.btnCheck.TabIndex = 0;
			this.btnCheck.Text = "Check";
			this.btnCheck.UseVisualStyleBackColor = true;
			// 
			// btnExecute
			// 
			this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExecute.Location = new System.Drawing.Point(327, 18);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(75, 22);
			this.btnExecute.TabIndex = 0;
			this.btnExecute.Text = "Execute";
			this.btnExecute.UseVisualStyleBackColor = true;
			// 
			// CommandUtility
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox3);
			this.Name = "CommandUtility";
			this.Size = new System.Drawing.Size(408, 108);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox tbParamValue;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.Button btnCheck;
		private System.Windows.Forms.ComboBox comboParams;
		private System.Windows.Forms.ComboBox comboCommandTasks;
		private System.Windows.Forms.Button btnSetParam;
		private System.Windows.Forms.GroupBox groupBox3;
	}
}
