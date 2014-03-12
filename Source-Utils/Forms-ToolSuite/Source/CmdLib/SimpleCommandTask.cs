#region User/License
// oio * 8/20/2012 * 8:17 AM

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
using System.Collections.Generic;
using System.Windows.Forms;

namespace TemplateTool.CmdLib
{
	public abstract class SimpleCommandTask : ITaskCommandProvider
	{
		/// <inheritdoc/>
		abstract public string[] InputParamKeys { get; }
		
		/// <inheritdoc/>
		public IDictionary<string,ParamType> ParameterTypes {
			get { return dic; } internal set { dic = value; }
		} IDictionary<string,ParamType> dic = new Dictionary<string,ParamType>();
		
		
		/// <inheritdoc/>
		public IDictionary<string,string> InputParameters {
			get { return pdic; } set { pdic = value; }
		} IDictionary<string,string> pdic = new Dictionary<string,string>();
		
		/// <inheritdoc/>
		virtual public IDictionary<string, string> ParameterFilters {
			get { return paramFilters; } internal set { paramFilters = value as Dictionary<string, string>; }
		} Dictionary<string,string> paramFilters = new Dictionary<string, string>();
		
		/// <inheritdoc/>
		public int InputParamCount { get { return this.InputParamKeys.Length; } }
		
		/// <inheritdoc/>
		abstract public string TaskName { get; }
		
		/// <inheritdoc/>
		public string  OutputText  { get; set; }
		
		virtual public bool IsExecutionReady {
			get { return (executeAction != null); }
		}
		
		/// <inheritdoc/>
		public Action ExecuteAction {
			get { return executeAction; }
			internal set { executeAction = value; }
		} Action executeAction;
		
		/// <summary>
		/// See IsExecutionReady: this method only checks if IsExecutionReady
		/// and executes if possible.
		/// </summary>
		virtual public void Execute()
		{
			if (executeAction!=null)
			{
				executeAction.Invoke();
			}
		}

		/// <summary>
		/// inputs must be ordered in the same fasion as the key-array.
		/// <para>in the future we will use an optional parser to get
		/// input values based on a provided switch (optionally).</para>
		/// </summary>
		/// <param name="inputs"></param>
		internal void InitializeInputs(string[] inputs)
		{
			if (InputParamKeys!=null) foreach (string key in InputParamKeys)
				InputParameters.Add(key,string.Empty);
			if (inputs!=null)
				for (int i=0; i < inputs.Length; i++)
					InputParameters[InputParamKeys[i]] = inputs[i];
		}
	}

	public abstract class SimpleCommandTask<TOutput> : SimpleCommandTask
	{
		public TOutput OutputValue { get; set; }
	}
	
}
