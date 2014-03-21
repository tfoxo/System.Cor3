/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 3/14/2012
 * Time: 6:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;

namespace System.Cor3.WPF
{
	public class WindowsVersion
	{
		public string GetVersion()
		{
			// Get OperatingSystem information from the system namespace.
			System.OperatingSystem osInfo =System.Environment.OSVersion;
			string WinV = null;
			// Determine the platform.
			switch(osInfo.Platform)
			{
					// Platform is Windows 95, Windows 98,
					// Windows 98 Second Edition, or Windows Me.
				case System.PlatformID.Win32Windows:
					
					switch (osInfo.Version.Minor)
					{
						case 0:
							WinV = ("Windows 95");
							break;
						case 10:
							if(osInfo.Version.Revision.ToString()=="2222A")
								WinV = ("Windows 98 Second Edition");
							else
								WinV = ("Windows 98");
							break;
						case  90:
							WinV = ("Windows Me");
							break;
					}
					break;
					
					// Platform is Windows NT 3.51, Windows NT 4.0, Windows 2000,
					// or Windows XP.
				case System.PlatformID.Win32NT:
					
					switch(osInfo.Version.Major)
						
					{
						case 3:
							WinV = ("Windows NT 3.51");
							break;
						case 4:
							WinV = ("Windows NT 4.0");
							break;
						case 5:
							if (osInfo.Version.Minor==0)
								WinV = ("Windows 2000");
							else
								WinV = ("Windows XP");
							break;
					}
					break;
			}
			return WinV ?? osInfo.VersionString;
		}
	}
}
