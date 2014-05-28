/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/16/2013
 * Time: 9:19 AM
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System.Tasks
{
	class Program
	{
		[STAThread]
		static public void Main(params string[] args) {
//			MoveToApp.App(args);
//			NormalizePathApp.App(args);
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			// Begin App
			Application.Run(new NormalizePath.Form1());
		}
	}
}