using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Generator.Core.Entities.Types;

#if TREEV
using System.Windows.Forms;
#endif
namespace Generator.Core.Entities
{

	public class DatabaseElement : DataMapElement
	{
		
		#region Properties
		
		#region Connection Type
		/// <summary>
		/// 
		/// </summary>
		[XmlAttribute]
		public ConnectionType ConnectionType
		{ get { return connectionType; } set { connectionType = value; }
		} ConnectionType connectionType;
		#endregion
		
		/*XmlElement here probably isn't serialized*/
		[XmlAttribute] public string Name {
			get { return name; } set { name = value; }
		} [XmlElement("info")] string name;
		
		[XmlAttribute] public string PrimaryKey {
			get { return primaryKey; } set { primaryKey = value; }
		} string primaryKey;
		
		[XmlElement] public List<UniqueKey> Keys;
		
		List<TableElement> items;
		/// <summary>
		/// A (XmlElement) collection of TableElement Items.
		/// </summary>
		[XmlElement("Table"), System.ComponentModel.Browsable(false)]
		public List<TableElement> Items { get { return items; } set { items = value; } }
		/// <summary>
		/// </summary>
		[XmlElement("View"), System.ComponentModel.Browsable(false)]
		public List<DataViewElement> Views { get { return views; } set { views = value; } }
		List<DataViewElement> views;

		#endregion

		private TableElement Find(string Key) {
			if (items==null) return null;
			if (items.Count==0) return null;
			foreach (TableElement table in this.Items) if (table.Name==Key) return table;
			return null;
		}

		#region public: Methods
		/// <summary>
		/// Checks to see if the TableElement is in the DatabaseCollection.
		/// </summary>
		/// <param name="Key">The name of the table</param>
		/// <returns>
		/// True if the table exists in the DatabaseElement checking.
		/// </returns>
		public bool Contains(string Key) { return Find(Key)!=null; }
		/// <summary>
		/// Returns the table if it exists, otherwise NULL.
		/// </summary>
		public TableElement this[string Key] { get { return Find(Key); } }
		#endregion

		#region Constructor
		#if TREEV
		/// <summary>
		/// Constructor for a Windows.Forms UI (TreeView.Node)
		/// </summary>
		/// <param name="tn"></param>
		public DatabaseElement(TreeNode tn)
		{
			if (items == null) items = new List<TableElement>();
			Name = tn.Text;
			if (tn.Tag is DatabaseElement)
			{
				DatabaseElement dt = tn.Tag as DatabaseElement;
				ConnectionType = dt.ConnectionType;
				PrimaryKey = dt.PrimaryKey;
//				PrimaryKey = dt.PrimaryKey;
			}
			foreach (TreeNode node in tn.Nodes)
			{
				if (node.Tag is TableElement) Items.Add(new TableElement(node));
				if (Views == null) views = new List<DataViewElement>();
				else if (node.Tag is DataViewElement) {
					Views.Add(new DataViewElement(node));
				}
			}
		}
		#endif
		
		/// <summary>
		/// Creates a new DatabaseElement Element with a given name.
		/// </summary>
		/// <param name="_name">An initial name for the Database.</param>
		public DatabaseElement(string _name)
		{
			Name = _name;
		}
		/// <summary>
		/// Default parameter-less constructor.
		/// </summary>
		public DatabaseElement()
		{
		}
		#endregion

		#region public: TreeView, TreeNode (Helpers)
		#if TREEV
		public void ToTree(TreeView tv)
		{
			foreach (TableElement telm in Items) tv.Nodes.Add(telm.ToNode());
			foreach (DataViewElement telm in Views) tv.Nodes.Add(telm.ToNode());
		}
		public void ToTree(TreeNode tn) { tn.Nodes.Add(ToNode()); }
		public TreeNode ToNode()
		{
			TreeNode node = new TreeNode(Name);
			node.Name = Name;
			// the image correlates with the PanelTableEditor (or whatever it's called)
			node.SelectedImageKey = node.ImageKey = ImageKeyNames.Database;
			node.Tag = this;
			foreach (TableElement telm in Items) node.Nodes.Add(telm.ToNode());
			foreach (DataViewElement telm in Views) node.Nodes.Add(telm.ToNode());
			return node;
		}
		#endif
		#endregion
		
	}
}
