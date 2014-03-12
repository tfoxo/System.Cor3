#region User/License
// oio * 8/20/2012 * 8:07 AM

// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows.Forms;

using Generator.Core.Entities;
using Generator.Core.Markup;
using ToolSuite.Lib;

namespace TemplateTool.View
{
	/// <summary>
	/// Generator application model with no constructor.
	/// </summary>
	/// <remarks>More of a Controller then a model but the semantic works fine I think.</remarks>
	class GeneratorModel
	{
		static readonly OpenFileDialog ofd = new OpenFileDialog();
		static readonly SaveFileDialog sfd = new SaveFileDialog();
		
		#region Fields
		const string filter_db  = "Database Configuration (*.xdata;*.xml)|*.xdata;*.xml|All Files (*)|*";
		const string filter_tpl = "Template Configuration (*.xml)|*.xml|All Files (*)|*";
		const string filter_cfg = "App Configuration (*.generator-config)|*.generator-config|All Files (*)|*";
		const string cat_cfg		= "config";
		const string cat_tpl		= "tpl";
		const string cat_db			= "db";
		static readonly IDictionary<string,string> OpenPaths =
			new Dictionary<string,string>(){
			{ cat_cfg,	ofd.InitialDirectory },
			{ cat_db,		ofd.InitialDirectory },
			{ cat_tpl,	ofd.InitialDirectory }
		};
		#endregion
		
		#region Configuration Files
		
		/// <summary>
		/// Configuration file locations
		/// </summary>
		public string configGen, configDb, configTpl;
		
		/// <summary>
		/// Application configuration (serializable model)
		/// </summary>
		public GeneratorConfig configfile;
		/// <summary>
		/// Database configuration file (serializable model)
		/// </summary>
		public DatabaseCollection datacollection;
		/// <summary>
		/// Template configuration file (serializable model)
		/// </summary>
		public TemplateCollection templatescollection;
		
		#endregion
		
		/// <summary>
		/// Load db and tpl configuration files (deserialize).
		/// </summary>
		public void PrepareContent()
		{
			datacollection = DatabaseCollection.Load(configDb);
			templatescollection = TemplateCollection.Load(configTpl);
		}
		
		#region Loaders
		public void LoadConfiguration()
		{
			ofd.InitialDirectory = OpenPaths[cat_cfg];
			if (!Helper.CheckFile(ofd,filter_cfg)) return;
			// 
			FileInfo f = new FileInfo(ofd.FileName);
			OpenPaths[cat_cfg] = f.Directory.FullName;
			if (f.Exists) configGen = f.FullName;
			f = null;
			LoadConfiguration(ofd.FileName);
		}
		public void LoadConfiguration(string fileName)
		{
			configfile = GeneratorConfig.Load(fileName);
			if (configfile!=null)
			{
				LoadDataConfig(configfile.datafile);
				LoadTemplateConfig(configfile.templatefile);
			}
			else {
				MessageBox.Show("The configuration file wasn't loaded!");
			}
		}
		public void LoadDataConfig()
		{
			ofd.InitialDirectory = OpenPaths[cat_db];
			if (!Helper.CheckFile(ofd,filter_db)) return;
			// 
			FileInfo f = new FileInfo(ofd.FileName);
			OpenPaths[cat_db] = f.Directory.FullName;
			f = null;
			LoadDataConfig(ofd.FileName);
		}
		public void LoadDataConfig(string fileName)
		{
			configDb = fileName;
		}
		public void LoadTemplateConfig()
		{
			ofd.InitialDirectory = OpenPaths[cat_tpl];
			if (!Helper.CheckFile(ofd,filter_tpl)) return;
			// 
			FileInfo f = new FileInfo(ofd.FileName);
			OpenPaths[cat_tpl] = f.Directory.FullName;
			f = null;
			LoadTemplateConfig(ofd.FileName);
		}
		public void LoadTemplateConfig(string fileName)
		{
			if (configfile==null) configfile = new GeneratorConfig();
			configTpl = fileName;
			if (configfile==null)
			{
				if (Helper.MessageBoxIsOK("Create Configuration file?\nDon't forget to load a Data-Configuration.\nPress OK to create a new Configuration, Cancel to ignore.","No configuration file was present",MessageBoxButtons.OKCancel,MessageBoxIcon.Information))
				{
					this.configfile = new GeneratorConfig();
				}
			}
		}
		#endregion
	}
}
