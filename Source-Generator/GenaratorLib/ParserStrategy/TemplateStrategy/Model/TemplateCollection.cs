/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 5/25/2011
 * Time: 5:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Cor3.Parsers;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using Generator.Core.Entities;
using Generator.Core.Parser;
using Generator.Core.Entities.Types;
#endregion

namespace Generator.Core.Markup
{
	[XmlRoot("TemplateCollection")]//,Namespace="http://w3.tfw.co/xmlns/2011/templates"
	public class TemplateCollection
		: SerializableClass<TemplateCollection>
	{
		List<string> usingNamespace = new List<string>();
		[Category("Assembly")]
		public string[] UsingNamespace { get { return usingNamespace.ToArray(); } set { usingNamespace = new List<string>(value); } }
		
		List<string> referenceAssembly = new List<string>();
		[Category("Assembly")]
		public string[] ReferenceAssembly { get { return referenceAssembly.ToArray(); } set { referenceAssembly = new List<string>(value); } }
		
		List<TableTemplate> templates = new List<TableTemplate>();
		public List<TableTemplate> Templates { get { return templates; } set { templates = value; } }
		
		public TableTemplate FindAlias(string Alias) {
			foreach (TableTemplate tpl in this.Templates)
			{
				if (tpl.Alias==null) continue;
				if (tpl.Alias==string.Empty) continue;
				if (tpl.Alias.Trim()==Alias.Trim())
					return tpl;
			}
			return null;
		}
		
		[XmlIgnore] public TableTemplate this[string Alias] { get { return FindAlias(Alias); } }
		[XmlIgnore] public TableTemplate this[FieldMatch match] { get { return FindAlias(match.TemplateAlias); } }
		
		public void GetTableValues(DataTable table)
		{
			Templates.Clear();
			foreach (DataRow row in table.Rows)
			{
				templates.Add(new TableTemplate(row));
			}
		}
		
		public void ColumnDefaults(DataTable table)
		{
			table.Columns.Add("Name",typeof(string));
			table.Columns.Add("Alias",typeof(string));
			table.Columns.Add("Group",typeof(string));
			table.Columns.Add("Tags",typeof(string));
			table.Columns.Add("SyntaxLanguage",typeof(string));
			table.Columns.Add("ClassName",typeof(string));
			table.Columns.Add(res.elmTpl,typeof(string));
			table.Columns.Add(res.itmTpl,typeof(string));
		}
		
		public DataTable GetData()
		{
			DataTable table = new DataTable();
			ColumnDefaults(table);
			foreach (TableTemplate tt in Templates)
			{
				tt.ToTable(table);
			}
			return table;
		}
		
		public void Add(TableTemplate item)
		{
			Templates.Add(item);
		}
		
		public TemplateCollection(TemplateCollection tplBase, DataTable table)
		{
			UsingNamespace = tplBase.UsingNamespace;
			ReferenceAssembly = tplBase.ReferenceAssembly;
			this.GetTableValues(table);
		}
		public TemplateCollection()
		{
		}
	}
}
