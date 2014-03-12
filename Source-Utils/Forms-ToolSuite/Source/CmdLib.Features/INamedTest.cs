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

/*
 * This set of methods was simply put here so that I could
 * test loading a interface based class via Managed Extensibility
 * Framework.
 * 
 * The interface that I would like to see should provide a set
 * of methods that pertain to a loaded Generator/Template configuration.
 */
namespace TemplateTool.CmdLib
{
	public interface INamedTest
	{
		string Name { get; }
	}
	[Export(typeof(INamedTest))]
	public class TestName1 : INamedTest
	{
		public string Name { get { return "Sam"; } }
	}
	[Export(typeof(INamedTest))]
	public class TestName2 : INamedTest
	{
		public string Name { get { return "Bill"; } }
	}
}
