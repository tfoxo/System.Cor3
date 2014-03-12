#region User/License
// oio * 8/27/2012 * 9:06 AM

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
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TemplateTool;

namespace SoftwareIndex.View
{
	/// <summary>
	/// Description of SoftwareInfoView.
	/// </summary>
	public partial class SoftwareInfoView : UserControl
	{
		#region Registry
		
		const string reg_last_db	= "SoftwareInfo.LastDB";
		
		public string LastUsedDatabase {
			get { return Reg.GetKeyValueString(Program.regpath,reg_last_db); }
			set { Reg.SetKeyValueString(Program.regpath,reg_last_db,value); }
		}
		
		#endregion

		public SoftwareInfoView()
		{
			InitializeComponent();
		}
		
		void InitializeData(string dbFile)
		{
			
		}
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (!string.IsNullOrEmpty(LastUsedDatabase) && System.IO.File.Exists(LastUsedDatabase))
				InitializeData(LastUsedDatabase);
		}
	}
}
