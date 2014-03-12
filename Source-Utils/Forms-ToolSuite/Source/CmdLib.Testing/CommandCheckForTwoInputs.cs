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
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace TemplateTool.CmdLib
{
	/// <summary>
	/// this and its brother, CheckForTwoInputs is just a template
	/// for other calls.
	/// </summary>
	[Export(typeof(ITaskCommandProvider))]
	public class CommandCheckForTwoInputs: SimpleCommandTask<bool>
	{
		public override string[] InputParamKeys {
			get { return inputParamKeys; }
		} readonly string[] inputParamKeys = new string[]{"XML Template Configuration","SQLite Template Database"};
		
		override public string TaskName {
			get { return name; }
		} const string name = "Check for two inputs";
		
		public CommandCheckForTwoInputs()
		{
			this.ExecuteAction = SetOutput;
			this.ParameterTypes = new Dictionary<string,ParamType>(){
				{ InputParamKeys[0], ParamType.InputFile },
				{ InputParamKeys[1], ParamType.InputFile }
			};
		}
		public CommandCheckForTwoInputs(params string[] inputs) : this()
		{
			InitializeInputs(inputs);
		}
		
		void SetOutput()
		{
			this.OutputValue = this.IsExecutionReady;
			this.OutputText = string.Format(
				"[{0}]\nCommand is ready for processing: {1}",
				this.TaskName,
				this.OutputValue
			);
		}
	}
}
