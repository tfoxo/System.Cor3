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
#endregion
using System;
using Generator.Core;
using Generator.Core.Entities;
using Generator.Core.Entities.Parser;
using Generator.Core.Markup;

namespace SoftwareIndex.GenLib
{
	

	abstract public class BasicGeneratorTool : IGenTool
	{
		public DatabaseCollection ConfigDb {
			get { return cfgDb; } internal set { cfgDb = value; }
		} internal DatabaseCollection cfgDb;
		
		public TemplateCollection ConfigTpl {
			get { return cfgTpl; } internal set { cfgTpl = value; }
		} internal TemplateCollection cfgTpl;
		
		public Action Execute { get { return this.Run; } }
		
		abstract public string Result { get; }
		abstract public string Name { get; }
		abstract public void Configure(IDataConfig config);
		abstract public void Run();
		
	}
}
