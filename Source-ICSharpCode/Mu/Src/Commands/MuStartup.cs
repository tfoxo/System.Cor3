/*
* Created by SharpDevelop.
* User: oio
* Date: 11/20/2012
* Time: 2:43 PM
* 
* To change this template use Tools | Options | Coding | Edit Standard Headers.
*/
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

using ICSharpCode.Core;

namespace Mu
{
	public class MuStartup : AbstractMenuCommand
	{
		public BackgroundWorker bw;
		public override void Run()
		{
			try
			{
				//				string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(AboutSharpDevelopTabPage.GetType()).Location);
				//				System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(path, "ICSharpCode.Core.dll"));
				//				System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(path, "ICSharpCode.SharpDevelop.dll"));
				//				System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(path, "ICSharpCode.SharpDevelop.Dom.dll"));
				//				System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(path, "ICSharpCode.AvalonEdit.dll"));
				//				System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(path, "AvalonDock.Themes.dll"));
				bw = new BackgroundWorker();
				bw.DoWork += delegate
				{
					try
					{
						while (ICSharpCode.SharpDevelop.Gui.WorkbenchSingleton.MainWindow == null)
						{
							Thread.Sleep(100);
						}
						ICSharpCode.SharpDevelop.Gui.WorkbenchSingleton.MainWindow.Dispatcher.Invoke
						(DispatcherPriority.Normal, new System.Threading.ThreadStart
							(
								delegate
								{
//									MessageBox.Show(
//										"Attempted to initialize!\n\n" +
//										"Note that this message is only for testing and shows " +
//										"that we succeeded in initializing the plugin and accessing " +
//										"load-time!");
									//string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ToolSettings)).Location);
									//string uri = "/AvalonDock.Themes;component/themes/dev2010.xaml";
									//ThemeFactory.ChangeTheme(new Uri(uri, UriKind.RelativeOrAbsolute));
									//							 		var settings = new ToolSettings();
									//							 		var theme = settings.LoadSettings();
									//							 		settings.SetTheme(theme);
								}
							)
						);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString(), "ToolCommandStartup.Run()");
					}
				};
				bw.RunWorkerAsync();
			}
			catch
			{
			}
		}
	}
}
