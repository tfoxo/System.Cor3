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

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Microsoft.Win32;
using TemplateTool.CmdLib;
using ToolSuite.Lib;
#endregion


namespace SoftwareIndex.Controls
{
	/// <summary>
	/// Description of CommandUtility.
	/// </summary>
	public partial class CommandUtility : UserControl
	{
		BindingSource bs = null;
		BindingSource textBinding = null;
		
		public ITaskCommandProvider Commandtask {
			get { return commandtask; }
		} ITaskCommandProvider commandtask = null;
		
		#region CommandTasks
		[Browsable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public List<Type> CommandTasks {
			get { return commandTasks; }
			set { commandTasks = value; SetCommandSource(commandTasks); }
		} List<Type> commandTasks = null;
		#endregion
		#region Combo Data Sources
		[Browsable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object ComboCommandData {
			get { return comboCommandTasks.DataSource; }
			set { comboCommandTasks.DataSource = value; }
		}
		[Browsable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object ComboCommandParams {
			get { return comboParams.DataSource; }
			set { comboParams.DataSource = value; }
		}
		[Browsable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Type CurrentCommandTask {
			get { return currentCommandTask; }
			set { currentCommandTask = value; }
		} Type currentCommandTask;

		#endregion
		
		void SetCommandSource(object dataSource)
		{
			ComboCommandData = dataSource;
			this.comboCommandTasks.DisplayMember = "Name";
		}
		
		public CommandUtility()
		{
			InitializeComponent();
			this.comboCommandTasks.SelectedIndexChanged += this.Event_Check;
			this.Event_Check(this,EventArgs.Empty);
			this.comboParams.SelectedIndexChanged += Event_ParamChanged;
		}
		
		/// <summary>
		/// Tests the creation of a command with no params sent.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Event_Check(object sender, EventArgs e)
		{
			ClearCommandAndBindings();
			if (comboCommandTasks.SelectedValue==null)
				// must be initialization
			{
				Debug.Print("Nothing could be done.");
				return;
			}
			
			commandtask = CommandHelper.TaskFromType(comboCommandTasks.SelectedValue as Type, "");
			bs = new BindingSource(commandtask.ParameterTypes,null);
			comboParams.DataSource = bs;
			comboParams.DisplayMember = "Value";
		}

		public void ClearCommandAndBindings()
		{
			try
			{
				commandtask = null;
				tbParamValue.DataBindings.Clear();
				if (bs!=null)
				{
					bs.Clear();
					bs = null;
				}
				comboParams.DataSource = null;
			}
			catch (Exception error)
			{
				Debug.Print("{0}",error);
			}
			finally
			{
				GC.Collect();
			}
		}

		void GetBindingInfo(Control control)
		{
			IEnumerator x = control.DataBindings.GetEnumerator();
			Debug.Print("-------------- binding info ---------------------");
			while (x.MoveNext())
			{
				Debug.Print("{0}",x.Current);
			}
		}
		
		void Event_ParamChanged(object sender, EventArgs e)
		{
			tbParamValue.DataBindings.Clear();
			KeyValuePair<string,ParamType> k = CommandHelper.GetIndexedPair<string,ParamType>(
				commandtask.ParameterTypes, comboParams.SelectedIndex
			);
			
			tbParamValue.DataBindings.Add("Text",commandtask.InputParameters[k.Key],null);
			
			Debug.Print("{0} = “{1}”",k.Key,commandtask.InputParameters[k.Key]);
		}
		void BtnSetParamClick(object sender, EventArgs e)
		{
			if (commandtask==null) return;
			
			KeyValuePair<string,ParamType> k = CommandHelper.GetIndexedPair<string,ParamType>(
				commandtask.ParameterTypes,comboParams.SelectedIndex);
			
			// only strings are supported.
			string value = CommandHelper.TryGetParameterValue(commandtask,k.Key) as string;
			
			if (commandtask.ParameterTypes[k.Key] == ParamType.String)
			{
				value = tbParamValue.Text;
				CommandHelper.TrySetParameterValue(commandtask,k.Key,value);
			} else {
				if (value!=null) {
					CommandHelper.TrySetParameterValue(commandtask,k.Key,value);
				}
			}
			
			if (value!=null)
			{
				// Set the value to the textbox
				tbParamValue.Text = value;
			}
		}
	}
}
