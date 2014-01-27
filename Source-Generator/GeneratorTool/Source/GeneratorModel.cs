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
using Generator.Core;
using Generator.Core.Entities;
using Generator.Core.Markup;
using Generator.Core.Operations;
using Generator.Core.Parser;
using Microsoft.Win32;
namespace GeneratorTool
{
	public class GeneratorModel : INotifyPropertyChanged
	{
		#region Properties
		public string FileName {
			get {
				return fileName;
			}
			set {
				fileName = value;
				OnPropertyChanged("FileName");
			}
		}

		string fileName;

		public GeneratorConfig Configuration {
			get {
				return configuration;
			}
			set {
				configuration = value;
				OnPropertyChanged("Configuration");
			}
		}

		GeneratorConfig configuration;

		public DatabaseCollection Databases {
			get {
				return databases;
			}
			set {
				databases = value;
				OnPropertyChanged("Databases");
			}
		}

		DatabaseCollection databases;

		public TemplateCollection Templates {
			get {
				return templates;
			}
			set {
				templates = value;
				OnPropertyChanged("Templates");
			}
		}

		TemplateCollection templates;

		#endregion
		#region Groupings
		void GetTemplate(string groupKey)
		{
		}

		//		IDictionary RefreshGroups()
		//		{
		//			IDictionary <string,TableTemplate> list = new List<string>();
		//			foreach (TableTemplate t in Templates.Templates)
		//			{
		//				if (list.Contains(t.Group)) continue;
		//				list.Add
		//			}
		//		}
		#endregion
		#region PropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		virtual protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	#endregion
	}
}


