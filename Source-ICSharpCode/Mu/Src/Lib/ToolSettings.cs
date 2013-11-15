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
		
	}

}
