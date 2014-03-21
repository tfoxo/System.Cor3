/*
 * User: oIo
 * Date: 11/15/2010 – 2:33 AM
 */
#region Using
using System;
using System.IO;
using System.Xml.Serialization;
using Generator;

//using System.Windows.Forms;

#endregion

namespace Generator.Core.Entities
{
	[XmlRoot("config")]
	public class GeneratorConfig : SerializableClass<GeneratorConfig>
	{
		[XmlElement("file-data")] public string datafile;
		[XmlElement("file-template")] public string templatefile;
		
		public class configuration
		{
			[XmlElement()] public string selectTable;
			[XmlElement] public string selectTemplate;
			public configuration()
			{
				
			}
		}
		[XmlElement("selection")] public configuration selection;
		
		public GeneratorConfig()
		{
			base.fileFilter = "generator-config|*.generator-config;";
		}
		public GeneratorConfig(IDbConfiguration4 win)
		{
			if (win.SelectedCollection!=null)
				datafile = win.SelectedCollection.FileLoadedOrSaved;
			if (win.Templates!=null)
				templatefile = win.Templates.FileLoadedOrSaved;
		}
	}
}
