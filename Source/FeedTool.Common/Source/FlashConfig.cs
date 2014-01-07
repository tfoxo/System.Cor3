/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/14/2013
 * Time: 10:55 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FeedTool
{
	class FlashConfig
	{
		public static readonly string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		public string ConfigFilePath { get { return Path.Combine(AppDataPath,@"Macromedia\Flash Player\#Security\FlashPlayerTrust",ConfigFileName); } }
		
		public string   ConfigFileName { get; set; }
		public string[] ConfigFileData { get; set; }
		
		public bool HasConfigFile { get { return File.Exists(ConfigFilePath); } }
		
		void WriteConfig()
		{
			// check if configfiledata is not empty!
			if (!HasConfigFile)
				File.WriteAllLines(ConfigFilePath,ConfigFileData);
		}
		
		void DeleteConfig()
		{
			try
			{
				if (HasConfigFile) File.Delete(ConfigFilePath);
			}
			catch
			{
				MessageBox.Show(string.Format("Error attempting to delete {0}",ConfigFileName));
			}
		}
		
		void CheckConfig()
		{
			// not sure what to do yet.
		}
		
		public void FullTrust()
		{
			DeleteConfig();
			//MessageBox.Show("Deleted FeedTool.cfg");
			WriteConfig();
			//MessageBox.Show("Created FeedTool.cfg");
		}
		
		public FlashConfig(string cfgFileName, params string[] cfgData)
		{
			ConfigFileName = cfgFileName;
			ConfigFileData = cfgData;
		}
		static public void Install()
		{
			string exepath = Environment.GetCommandLineArgs()[0];
			FlashConfig cfg = new FlashConfig("FeedTool.cfg",Path.GetDirectoryName(exepath));
			MessageBox.Show(cfg.ConfigFilePath,Path.GetDirectoryName(exepath));
			cfg.FullTrust();
			cfg = null;
		}
	}
}
