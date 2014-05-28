/*
* Created by SharpDevelop.
* User: oio
* Date: 11/20/2012
* Time: 2:43 PM
* 
* To change this template use Tools | Options | Coding | Edit Standard Headers.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Xml.Serialization;

using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Workbench;
using Mu.View;

namespace Mu.Commands
{
	public class ShowMuControl : AbstractMenuCommand
	{
		static ShowMuControl()
		{
			//			ProjectService.SolutionLoaded += delegate {
			//				// close all start pages when loading a solution
			//				foreach (IViewContent v in WorkbenchSingleton.Workbench.ViewContentCollection.ToArray()) {
			//					if (v is StartPageViewContent) {
			//						v.WorkbenchWindow.CloseWindow(true);
			//					}
			//				}
			//			};
		}
		
		public override void Run()
		{
			string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ICSharpCode.SharpDevelop.Gui.AboutSharpDevelopTabPage)).Location);
			string muPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ShowMuControl)).Location);
			MessageBox.Show(muPath);
			// for sd4
			//System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(path, "ICSharpCode.SharpDevelop.Dom.dll"));
//			System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(path, "AvalonDock.Themes.dll"));
			System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(path, "ICSharpCode.Core.dll"));
			System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(path, "ICSharpCode.SharpDevelop.dll"));
			System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(path, "ICSharpCode.AvalonEdit.dll"));
			System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(muPath, "System.Data.SQLite.dll"));
			System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(muPath, "System.Cor3.dll"));
			System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(muPath, "System.Cor3.Parsers.dll"));
			System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(muPath, "System.Cor3.Data.dll"));
			System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(muPath, "Generator.Lib.dll"));
			System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(muPath, "FirstFloor.ModernUI.dll"));
			foreach (IViewContent view in ICSharpCode.SharpDevelop.Gui.WorkbenchSingleton.Workbench.ViewContentCollection) {
				if (view is EditorControlViewContent) {
					view.WorkbenchWindow.SelectWindow();
					return;
				}
			}
			ICSharpCode.SharpDevelop.Gui.WorkbenchSingleton.Workbench.ShowView(new EditorControlViewContent());
		}
	}
}
