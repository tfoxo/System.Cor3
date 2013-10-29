/*
 * oIo — 11/15/2010 — 6:23 PM
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace wpv
{
	class FileLoader
	{
		static public string[] fmts = new string[]{"aac","bin","flv","mp4","m4a","m4v","mp3","mov","webm","avi"};
		static public string[] FromRoot(string rootpath)
		{
			return Directory.GetDirectories(rootpath,"*.*",SearchOption.AllDirectories);
		}
		static public List<DirectoryInfo> GetDrives()
		{
			List<DirectoryInfo> drives = new List<DirectoryInfo>();
			foreach (DriveInfo di in System.IO.DriveInfo.GetDrives())
			{
				if (di.IsReady) drives.Add(di.RootDirectory);
			}
			foreach (string dir in FromRoot(@"C:\Documents and Settings\oIo\Desktop"))
				drives.Add(new DirectoryInfo(dir));
			foreach (string dir in FromRoot(@"F:\Multimedia\Movies"))
				drives.Add(new DirectoryInfo(dir));
			foreach (string dir in FromRoot(@"F:\Musiq\__radio"))
				drives.Add(new DirectoryInfo(dir));
			foreach (string dir in FromRoot(@"\\ooo\THREE\Movies"))
				drives.Add(new DirectoryInfo(dir));
			return drives;
		}
		static public FileInfo[] GetFiles(string path, params string[] extensions)
		{
//			List<string> dirs;
			if (!System.IO.Directory.Exists(path)) return null;
			if (extensions==null) extensions = fmts;
			List<string> files = new List<string>();
			List<FileInfo> filei = new List<FileInfo>();
			foreach (string ext in extensions)
			{
				files.AddRange(System.IO.Directory.GetFiles(path,"*.$(ext)".Replace("$(ext)",ext),System.IO.SearchOption.TopDirectoryOnly));
			}
			
			foreach (string f in files)
			{
				filei.Add(new FileInfo(f));
			}
			return filei.ToArray();
		}
	}
}
