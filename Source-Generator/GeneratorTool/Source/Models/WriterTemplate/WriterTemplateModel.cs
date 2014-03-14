/* oio * 01/21/2014 * Time: 09:09
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using FirstFloor.ModernUI.Windows.Controls;
using Generator;
using Generator.Core;
using Generator.Core.Entities;
using Generator.Core.Markup;
using Generator.Core.Operations;
using Generator.Core.Parser;
using Microsoft.Win32;
namespace GeneratorTool
{
	class WriterTemplateModel : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string n)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(n));
		}
		#endregion

		internal static TemplateUtil util;

		public static List<string> GroupNames {
			get { return groupNames; }
			set { groupNames = value; }
		} internal static List<string> groupNames;

		internal static List<TemplateElement> rows;

		internal static void Initialize(string path)
		{
			if (util != null) Clear();
			util = new TemplateUtil(path);
			groupNames = util.GetGroups();
		}

		internal static void Clear()
		{
			if (util != null) {
				util.Templates.Clear();
				if (groupNames != null)
					groupNames.Clear();
				if (rows != null)
					rows.Clear();
				util = null;
				GC.Collect();
				// this probably happens automatically, but I'm not sure.
			}
		}

		internal static void GetRows(string tableName)
		{
			rows = util.Templates.Where(t => t.Table == tableName).ToList();
		}
	}
	
	
}




