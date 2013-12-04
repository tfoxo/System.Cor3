/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 12/2/2013
 * Time: 8:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Internals;
using ParseTool;

namespace ParseTool.Views
{
	public class XProvider : ViewPoint<XView> {
		public MainForm Parent { get;set; }
		public XProvider() : base()
		{
		}
	}
	public class XView : UserView<MainForm> { }
}
