/*
 * oIo ? 11/15/2010 ? 6:23 PM
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Flash
{
	class FileLoader
	{
		static public string[] fmts = new string[]{"bin","flv","mp4","m4a","m4v","m4a","mp3","mov"};
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
			foreach (string dir in FromRoot(@"D:\_dirt\Downloads\New Folder"))
				drives.Add(new DirectoryInfo(dir));
			foreach (string dir in FromRoot(@"D:\musica"))
				drives.Add(new DirectoryInfo(dir));
			//foreach (string dir in FromRoot(@"H:\_dirt"))
			//	drives.Add(new DirectoryInfo(dir));
			foreach (string dir in FromRoot(@"H:\mov"))
				drives.Add(new DirectoryInfo(dir));
			foreach (string dir in FromRoot(@"H:\musica"))
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
