#region User/License
// oio * 8/27/2012 * 12:34 PM

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
using Generator.Core;
using Generator.Core.Entities;
using Generator.Core.Entities.Parser;
using Generator.Core.Markup;
#endregion

namespace SoftwareIndex.GenLib
{
	public class GenerateSource : BasicGeneratorTool
	{
		IDataConfig dcfg = null;
		
		public override string Result {
			get { return result; }
		} string result = null;
		
		public override string Name {
			get { return "Generate Source"; }
		}
		
		public override void Run()
		{
			if (dcfg!=null) result = DataCfg.Parse(dcfg);
		}
		public override void Configure(IDataConfig config)
		{
			dcfg = config;
		}
	}
}
