using System;
using System.Globalization;
using System.IO;
using System.Reflection;

using AvalonDock;

namespace Mu
{
	/// <summary>
	/// Description of ToolSettings.
	/// </summary>
	public partial class ToolSettings
	{
		private string AssemblyFolderName { get { return Path.GetDirectoryName(Assembly.GetAssembly(typeof(Mu.ToolSettings)).Location); } }
		public string SettingsFileName { get { return "mu-settings.config"; } }
		public string LoadSettings()
		{
			string result = string.Empty;
			try
			{
				var settingsFileName= Path.Combine(AssemblyFolderName, SettingsFileName);
				if (File.Exists(settingsFileName))
				{
					using (var sr = new StreamReader(settingsFileName))
					{
						result = sr.ReadLine();
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("There was some error during loading settings:" + Environment.NewLine + ex, "ThemeTool Error");
			}
			return result;
		}
		public void SaveSettings(string themeName)
		{
			try
			{
				using (var sw = new StreamWriter(Path.Combine(AssemblyFolderName, SettingsFileName)))
				{
					sw.WriteLine(themeName);
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("There was some error during saving settings:" + Environment.NewLine + ex, "ThemeTool Error");
			}
		}
		public void SetTheme(string themeName)
		{
			try
			{
				if (themeName == "dev2010")
				{
					string uri = "/Mu;component/src/assets/dev2010.xaml";
					ThemeFactory.ChangeTheme(new Uri(uri, UriKind.RelativeOrAbsolute));
				}
				else if (themeName == "dev2o11")
				{
					string uri = "/Mu;component/src/assets/dev2o11.xaml";
					ThemeFactory.ChangeTheme(new Uri(uri, UriKind.RelativeOrAbsolute));
				}
				else if (themeName == "dev2o11v2")
				{
					string uri = "/Mu;component/src/assets/dev2o11v2.xaml";
					ThemeFactory.ChangeTheme(new Uri(uri, UriKind.RelativeOrAbsolute));
				}
				else if (themeName == "dev2010green")
				{
					string uri = "/Mu;component/src/assets/dev2010green.xaml";
					ThemeFactory.ChangeTheme(new Uri(uri, UriKind.RelativeOrAbsolute));
				}
				else if (themeName == "dev2010red")
				{
					string uri = "/Mu;component/src/assets/dev2010red.xaml";
					ThemeFactory.ChangeTheme(new Uri(uri, UriKind.RelativeOrAbsolute));
				}
				else if (themeName == "ExpressionDark")
				{
					string uri = "/Mu;component/src/assets/ExpressionDark.xaml";
					ThemeFactory.ChangeTheme(new Uri(uri, UriKind.RelativeOrAbsolute));
				}
				else if (themeName == "ExpressionLight")
				{
					string uri = "/Mu;component/src/assets/ExpressionLight.xaml";
					ThemeFactory.ChangeTheme(new Uri(uri, UriKind.RelativeOrAbsolute));
				}
				else if (themeName == "classic" || themeName == "generic" || themeName == "luna.normalcolor" || themeName == "aero.normalcolor")
				{
					ThemeFactory.ChangeTheme(themeName);
				}
				else if (themeName.StartsWith("#"))
				{
					//System.Windows.Forms.MessageBox.Show(themeName);
					byte a = byte.Parse(themeName.Substring(1, 2), NumberStyles.HexNumber);
					byte r = byte.Parse(themeName.Substring(3, 2), NumberStyles.HexNumber);
					byte g = byte.Parse(themeName.Substring(5, 2), NumberStyles.HexNumber);
					byte b = byte.Parse(themeName.Substring(7, 2), NumberStyles.HexNumber);
					ThemeFactory.ChangeColors(System.Windows.Media.Color.FromArgb(a, r, g, b));
				}
				else if (themeName == "default")
				{
					ThemeFactory.ResetTheme();
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("There was some error during applying theme:" + Environment.NewLine + ex, "ThemeTool Error");
			}
		}
	}

}
