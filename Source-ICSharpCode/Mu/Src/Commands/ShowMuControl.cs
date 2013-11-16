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
using ICSharpCode.SharpDevelop.Gui;
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
			foreach (IViewContent view in WorkbenchSingleton.Workbench.ViewContentCollection) {
				if (view is EditorControlViewContent) {
					view.WorkbenchWindow.SelectWindow();
					return;
				}
			}
			WorkbenchSingleton.Workbench.ShowView(new EditorControlViewContent());
//			WorkbenchSingleton.Workbench.ShowView(new IncludeLinkGeneratorView());
		}
	}
}
