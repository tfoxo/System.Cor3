/* oio : 12/07/2013 10:02 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
namespace mp4nfo.Library
{
	class MP4v2_Config
	{
		/// <summary>
		/// Removes unwanted text from file-names such as ' - Youtube' and the little
		/// unicode '▶ '. Default is false.
		/// </summary>
		public bool AutoRename {
			get {
				return autoRename;
			}
			set {
				autoRename = value;
			}
		}

		bool autoRename = true;

		public Dictionary<string, string> FileNameFilter {
			get {
				return fileNameFilter;
			}
			set {
				fileNameFilter = value;
			}
		}

		Dictionary<string, string> fileNameFilter = new Dictionary<string, string>() {
			{
				" - Youtube",
				""
			},
			{
				" - youtube",
				""
			},
			{
				" - YouTube",
				""
			},
			{
				"▶ ",
				""
			},
		//{ " & ", " and " },
		//{ "&", "and " },
		};
	}
}


