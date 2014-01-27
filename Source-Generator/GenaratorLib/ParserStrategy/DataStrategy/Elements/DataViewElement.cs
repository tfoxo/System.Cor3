using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Generator.Core.Entities
{
	public class DataViewElement : DatabaseChildElement, IDataView 
	{
		[XmlIgnore]
		public DatabaseElement Parent {
			get {
				return parent;
			}
			set {
				parent = value;
				OnPropertyChanged("Parent");
			}
		}
		DatabaseElement parent;
		#region Properties
		[XmlAttribute("name")] public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } } string name;
		[XmlAttribute("db")] public string Database { get { return database; } set { database = value; OnPropertyChanged("Database"); } } string database;
		[XmlAttribute("table")] public string Table { get { return table; } set { table = value; OnPropertyChanged("Table"); } } string table;
		[XmlAttribute("fields")] public string Fields { get { return fields; } set { fields = value; OnPropertyChanged("Fields"); } } string fields;
		/// <summary>get|set; The alias for the primary table in the view.</summary>
		[XmlAttribute("as")] public string Alias { get { return alias; } set { alias = value; OnPropertyChanged("Alias"); } } string alias;
		[XmlElement("link")] public List<DataViewLink> LinkItems { get { return linkItems; } set { linkItems = value; OnPropertyChanged("LinkItems"); } } List<DataViewLink> linkItems;
		#endregion
		#region Generate(helpers)
		
		public void GetTables()
		{
			
		}
		
		#endregion
		#region Field Utility
		
		[XmlIgnore] public List<string> TableFieldArray { get { return new List<string>(Fields.Split(',')); } }
		[XmlIgnore] public List<string> tablefieldarray { get { return new List<string>(Fields.ToLower().Split(',')); } }
		
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
			var node = new TreeNode(this.Name){ Name=this.Name, Tag=this, ImageKey=ImageKeyNames.View, SelectedImageKey=ImageKeyNames.View };
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
	
	public class DataViewLink : IDataView, INotifyPropertyChanged
	{
		#region PropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected internal void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
		
		#region Properties
		[XmlAttribute("db")]
		public string Database { get { return database; } set { database = value; OnPropertyChanged("Database"); } } string database;
		[XmlAttribute("table")]
		public string Table { get { return table; } set { table = value; OnPropertyChanged("Table"); } } string table;
		[XmlAttribute("fields")]
		public string Fields { get { return fields; } set { fields = value; OnPropertyChanged("LinkItems"); } } string fields;
		/// <summary>
		/// get|set; The alias for the primary table in the view.
		/// </summary>
		[XmlAttribute("as")]
		public string Alias { get { return alias; } set { alias = value; OnPropertyChanged("Alias"); } } string alias;
		/// <summary>
		/// The name of the table being linked to including the field: alias.field.
		/// Parsed with a <tt>string.Split('.',...)</tt>.
		/// </summary>
		[XmlAttribute("on")]
		public string On { get { return _on; } set { _on = value;  OnPropertyChanged("On"); } } string _on;
		[XmlAttribute("from")]
		public string From { get { return _from; } set { _from = value; OnPropertyChanged("From"); } } string _from;
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
