using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Generator.Core.Entities
{
	public interface IDataView
	{
		string Database { get; set; }
		string Table { get; set; }
		string Fields { get;set; }
		string Alias { get;set; }
	}
	public class DataViewElement : DataMapElement, IDataView
	{
		#region Properties
		[XmlAttribute("name")]
		public string Name { get;set; }
		
		[XmlAttribute("db")]
		public string Database { get; set; }
		
		[XmlAttribute("table")]
		public string Table { get; set; }
		
		[XmlAttribute("fields")]
		public string Fields { get;set; }
		/// <summary>
		/// get|set; The alias for the primary table in the view.
		/// </summary>
		[XmlAttribute("as")]
		public string Alias { get;set; }
		
		[XmlElement("link")]
		public List<DataViewLink> LinkItems {
			get { return linkItems; }
			set { linkItems = value; }
		} List<DataViewLink> linkItems;
		
		#endregion
		#region Generate(helpers)
		
		public void GetTables()
		{
			
		}
		
		#endregion
		#region Field Utility
		
		[XmlIgnore]
		public List<string> TableFieldArray { get { return new List<string>(Fields.Split(',')); } }
		[XmlIgnore]
		public List<string> tablefieldarray { get { return new List<string>(Fields.ToLower().Split(',')); } }
		
		string Act(bool ic, string input) { return ic? input.ToLower() : input;}
		public bool HasField(TableElement table, FieldElement field, bool ignoreCase=true)
		{
			List<string> fields = ignoreCase?tablefieldarray:TableFieldArray;
			bool returnValue = fields.Contains(field.DataName);
			fields = null;
			return returnValue;
		}
		
		#endregion
		
		public DataViewElement(){}
		public DataViewElement(TreeNode node)
		{
			if (!(node.Tag is DataViewElement))
				throw new ArgumentException("Automated Element was not of type(DataViewElement)");
			var refElement = node.Tag as DataViewElement;
			Database = refElement.Database;
			Table = refElement.Table;
			Name = refElement.Name;
			Alias = refElement.Alias;
			Fields = refElement.Fields;
			linkItems = refElement.LinkItems;
		}
		
		#region public: TreeView, TreeNode (Helpers)
		#if TREEV
		public void ToTree(TreeNode tn) { tn.Nodes.Add(ToNode()); }
		
		public TreeNode ToNode()
		{
			TreeNode node = new TreeNode(this.Name){ Name=this.Name, Tag=this, ImageKey=ImageKeyNames.View, SelectedImageKey=ImageKeyNames.View };
			foreach (DataViewLink link in this.LinkItems)
			{
				node.Nodes.Add(
					new TreeNode(link.Table){
						ImageKey=ImageKeyNames.ViewLink,
						SelectedImageKey=ImageKeyNames.ViewLink
					}
				);
			}
			return node;
		}
		
		#endif
		#endregion
	}
	
	public class DataViewLink : IDataView
	{
		#region Properties
		[XmlAttribute("db")] public string Database { get; set; }
		[XmlAttribute("table")] public string Table { get; set; }
		[XmlAttribute("fields")] public string Fields { get;set; }
		/// <summary>
		/// get|set; The alias for the primary table in the view.
		/// </summary>
		[XmlAttribute("as")] public string Alias { get;set; }
		/// <summary>
		/// The name of the table being linked to including the field: alias.field.
		/// Parsed with a <tt>string.Split('.',...)</tt>.
		/// </summary>
		[XmlAttribute("on")] public string On { get;set; }
		[XmlAttribute("from")] public string From { get;set; }
		#endregion
		#region Field Utility
		
		[XmlIgnore]
		public List<string> TableFieldArray { get { return new List<string>(Fields.Split(',')); } }
		[XmlIgnore]
		public List<string> tablefieldarray { get { return new List<string>(Fields.ToLower().Split(',')); } }
		
		string Act(bool ic, string input) { return ic? input.ToLower() : input;}
		public bool HasField(TableElement table, FieldElement field, bool ignoreCase=true)
		{
			List<string> fields = ignoreCase?tablefieldarray:TableFieldArray;
			bool returnValue = fields.Contains(field.DataName);
			fields = null;
			return returnValue;
		}
		
		#endregion
	}
}
