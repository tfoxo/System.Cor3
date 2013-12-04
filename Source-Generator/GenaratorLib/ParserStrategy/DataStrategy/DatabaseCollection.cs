using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using Generator.Core.Parser;

#if TREEV
using System.Windows.Forms;
#endif
namespace Generator.Core.Entities
{
	//
	[XmlRoot("DatabaseCollection"/*,Namespace=DatabaseCollection.const_ns*/)] //,Namespace="http://w3.tfw.co/xmlns/2011/dbscheme")]
	public class DatabaseCollection : SerializableClass<DatabaseCollection>
	{
		static public readonly object queryContainer = "queryContainer";
		const string const_ns = "http://w3.tfw.co/xmlns/2011";
		const string const_ns_ttl = "dbscheme";
		public const string ref_asm_node = "References";

		[XmlAttribute]
		public string DateModified
		{
			get {
				return string.Format("yyyy/MM/dd", DateTime.Now);
			}
		}

		#region ReferenceAssemblyCollection Elements (conditional pragma)
		#if ASMREF
		ReferenceAssemblyCollection itemsAsm;
		[XmlElement("Assemblies")]
		public ReferenceAssemblyCollection Assemblies
		{
			get {
				return itemsAsm;
			} set {
				itemsAsm = value;
			}
		}

		ReferenceAssemblyElement FindAsmName(string Key)
		{
			if (itemsAsm==null) return null;
			if (Assemblies.Assemblies.Count==0) return null;
			foreach (ReferenceAssemblyElement aref in this.Assemblies.Assemblies) if (aref.Name==Key) return aref;
			return null;
		}
		public bool HasAssembly(string Key)
		{
			return FindAsmName(Key)!=null;
		}
		#endif
		#endregion

		#region DatabaseElement-Collection Utilities
		public override XmlSerializerNamespaces SerializableNamespaces
		{
			get {
				XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
				xsn.Add(const_ns_ttl,const_ns);
				return xsn;
			}
		}

		public DatabaseElement this[string Key]
		{
			get {
				return Find(Key);
			}
		}

		DatabaseElement Find(string Key)
		{
			if (items==null) return null;
			if (items.Count==0) return null;
			foreach (DatabaseElement db in this.Databases) if (db.Name==Key) return db;
			return null;
		}

		public bool Contains(string Key)
		{
			return Find(Key)!=null;
		}

		#endregion

		#region DatabaseElement Elements
		List<DatabaseElement> items;
		[XmlElement("Database")]
		public List<DatabaseElement> Databases
		{
			get {
				return items;
			} set {
				items = value;
			}
		}
		#endregion

		#region QueryElement Elements (Sql, Query)
		List<QueryElement> sqlItems;
		[XmlElement("Sql")]
		public List<QueryElement> Sql
		{
			get {
				return sqlItems;
			} set {
				sqlItems = value;
			}
		}

		List<QueryElement> queries;
		[XmlElement("Query")]
		public List<QueryElement> Queries
		{
			get {
				return queries;
			} set {
				queries = value;
			}
		}
		#endregion

		#region TreeView Support
		#if TREEV
		public void ToTree(TreeView tn, bool append)
		{
			if (!append) tn.Nodes.Clear();
			if (Databases==null) return;
			TreeNode node = new TreeNode("Database Collection");
			TreeNode queries = new TreeNode(queryContainer.ToString());
			queries.ImageKey = queries.SelectedImageKey = queries.Name = queries.Text;
			queries.Tag = queryContainer;
			node.Tag = this;
			// the image correlates with the PanelTableEditor (or whatever it's called)
			node.SelectedImageKey = node.ImageKey = ImageKeyNames.Databases;
			#if ASMREF
			if (Assemblies!=null) node.Nodes.Add(Assemblies.ToNode());
			#endif
			if (Databases!=null) foreach (DatabaseElement telm in Databases) telm.ToTree(node);
//			foreach (DatabaseElement telm in Databases) telm.ToTree(node);
			if (Queries!=null) foreach (QueryElement telm in Queries) telm.ToTree(queries);
			tn.Nodes.Add(node);
		}
		public DatabaseCollection(TreeView tv)
		{
			base.useNamespaces = true;
			this.Databases = new List<DatabaseElement>();
			this.Queries = new List<QueryElement>();
			foreach (TreeNode node in tv.Nodes) {
				System.Windows.Forms.MessageBox
					.Show(
						node.Tag.ToString()
					);

				if (node.Tag is DatabaseCollection) {
					TreeNode[] nodes = tv.Nodes.Find(ref_asm_node,true);
					bool hasit = nodes.Length>0;
					Global.statR("DC");
					if (hasit) {
						MessageBox.Show("we have assembly entries");
						TreeNode found = nodes[0];
					}
					DatabaseCollection dc = node.Tag as DatabaseCollection;
					Global.statR("we're moving past the continue statement at DatabaseCollection level");
					foreach (TreeNode node1 in node.Nodes) {
						if (node1.Tag is DatabaseElement) {
							Databases.Add(new DatabaseElement(node1));
						} else if (node1.Tag == (queryContainer)) {
							foreach (TreeNode qnode in node1.Nodes) {
								QueryElement element = QueryElement.FromNode(qnode);
								Queries.Add(element);
							}
						} else if (node1.Tag is QueryElement) {
							Queries.Add(QueryElement.FromNode(node1));
						}
						#if ASMREF
						else if (node1.Tag is ReferenceAssemblyCollection) {
							Assemblies = node1.Tag as ReferenceAssemblyCollection;
						}
						#endif
					}
				}
			}
		}
		#endif
		#endregion

		/// <summary>
		/// <para>Attempts to load a file as a Database Collection.</para>
		/// <para>If no file is selected (DialogResult.Cancel) a new collection is created and loaded.</para>
		/// </summary>
		/// <returns></returns>
		static public DatabaseCollection LoadSafe()
		{
			string Filename = ControlUtil.FGet("xdata|*.xdata|Xml Document|*.xml|All Types|*.xdata;*.xml|All Files|*;");
			if (Filename==string.Empty) return new DatabaseCollection();
			return Load(Filename);
		}

		public DatabaseCollection()
		{
		}

		#region ConvertInput Utility

		#region No Longer
		#if no

		/// <summary>
		/// if a table is provided, the database knows where to start and conversion is called starting with
		/// the parameters from the particular table.
		/// </summary>
		/// <param name="dbs">(IDbConfiguration) where the List of ‘Databases’ finds the template, and sends the IDbConfiguration through to the Table.ConvertInput method.</param>
		/// <param name="tableName">the name of the table to apply ‘templating’ toward.</param>
		/// <returns>
		/// If success, the converted template is returned, otherwise an empty string or the message ‘NO TABLE NAMED [table_name] EXISTS’
		/// </returns>
		public string ConvertInput(IDbConfiguration dbs, string tableName)
		{
			foreach (DatabaseElement elm in Databases) {
				if (elm[tableName]==null) continue;
				if (elm.Contains(tableName))
					return TemplateFactory.ConvertInput( dbs, true );
			}
			return string.Format(Messages.DatabaseCollection_ConvertInput_TableNotFound,tableName.ToUpper());
		}

		#endif
		#endregion

		/// <summary></summary>
		/// <param name="dbs">(IDbConfiguration) where the List of
		/// ‘Databases’ finds the template, and sends the IDbConfiguration
		/// through to the Table.ConvertInput method.
		/// </param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string ConvertInput(IDbConfiguration4 dbs, string tableName)
		{
			// I suppose that this loop just checks weather the table exists.
			foreach (DatabaseElement elm in Databases) {
				if ( elm[tableName] == null ) continue;
				if ( elm.Contains(tableName) ) return TemplateFactory.ConvertInput( dbs, true );
			}
			return string.Format( Messages.DatabaseCollection_ConvertInput_TableNotFound , tableName.ToUpper() );
		}

		#endregion

	}
}
