#region User/License
// oio * 8/18/2012 * 11:45 PM

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
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace ToolSuite.Lib
{
	[Flags]
	public enum DataAction
	{
		Select	= 1,			// binary: 0000 0001, hex: 0x01, dec:  1
		Add 		= 1 << 1, // binary: 0000 0010, hex: 0x02, dec:  2
		Insert	= 1 << 2, // binary: 0000 0100, hex: 0x04, dec:  4
		Update	= 1 << 3, // binary: 0000 1000, hex: 0x08, dec:  8
		Delete	= 1 << 4, // binary: 0001 0000, hex: 0x10, dec: 16
	}
	
	/// <summary>
	/// Sets a given class or structure to be readable by the API core class.
	/// </summary>
	[AttributeUsage(AttributeTargets.Struct|AttributeTargets.Class)]
	public class ProvideDataAttribute : Attribute
	{
		public DataAction AvailableAction {
			get { return availableAction; }
			set { availableAction = value; }
		} DataAction availableAction;
	
		public ProvideDataAttribute()
		{
			this.availableAction = (DataAction)(1|2|4|8|16);
		}
		public ProvideDataAttribute(DataAction availableAction)
		{
			this.availableAction = availableAction;
		}
	}
}
