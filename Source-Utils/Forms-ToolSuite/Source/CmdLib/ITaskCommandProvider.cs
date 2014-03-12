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
	public interface ITaskCommandProvider
	{
		/// <summary>
		/// OutputText should be present to all commands, and always show
		/// a textual representation of the OutputValue (provided by a
		/// derived class)
		/// </summary>
		/// <remarks>
		/// A value should be provided to the OutputText Property regardless
		/// of weather the actual command result is text.
		/// </remarks>
		string  OutputText { get; }
		
		/// <summary>
		/// A unique name for the task. 
		/// </summary>
		string TaskName { get; }
		
		/// <summary>
		/// This is used as a reference point for all dictionaries.
		/// Note that each of these names should be unique to the array as the values
		/// are used in a dictionary.
		/// </summary>
		string[] InputParamKeys { get; }
		
		/// <summary>
		/// This is to be an automated helper based on the number of parameter-types.
		/// </summary>
		int InputParamCount { get; }
		
		/// <summary>
		/// Storage for our values.
		/// </summary>
		IDictionary<string,string> InputParameters { get;set; }
		
		/// <summary>
		/// A list of parameter types.
		/// This provides the foundation for our class.
		/// </summary>
		IDictionary<string,ParamType> ParameterTypes { get; }
		
		/// <summary>
		/// We could in the future implement something along the terms of the meta-content
		/// collection here, where we have extended type information along with file-filter
		/// information.
		/// </summary>
		IDictionary<string,string> ParameterFilters { get; }
		
		/// <summary>
		/// This is our command
		/// </summary>
		Action ExecuteAction { get; }
		
		/// <summary>
		/// When called, this should provide a value to <see cref="OutputText" />.
		/// </summary>
		void Execute();
		// void InitializeInternals();
	}
}
