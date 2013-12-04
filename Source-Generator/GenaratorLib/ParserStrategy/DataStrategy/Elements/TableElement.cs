#region Using
/*
 * User: oIo
 * Date: 11/15/2010 – 2:33 AM
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Cor3.Data;
using Generator.Core.Entities.Types;
using System.Windows.Forms;
using System.Xml.Serialization;

#if USEMYSQL
// using ...
#endif
#endregion
namespace Generator.Core.Entities
{
	public class TableElement : DataMapElement
	{
		#region Properties
		/// <summary>
		/// A helper method used to transform our internal variable dictionary
		/// for parser addons.
		/// </summary>
		[XmlIgnore]
		public Action<DICT<string,object>> Transform { get;set; }

		[XmlElement("Field"), System.ComponentModel.Browsable(false)]
		public List<FieldElement> Fields {
			get { return items; }
			set { items = new List<FieldElement>(value); }
		} List<FieldElement> items;
		
		/// <summary>
		/// Gets a Keyed element or Null if no matching Key was found.
		/// </summary>
		public FieldElement this[string key] {
			get { return Find(key); }
		}
		
		#region Table Definition
		[XmlAttribute()]
		public string Name {
			get { return name; }
			set { name = value; }
		} string name;
		
		[XmlAttribute("base")] public string BaseClass { get;set; }

		[XmlAttribute] public string Inherits {
			get { return _inherits; } set { _inherits = value; }
		} string _inherits;

		[DefaultValue(""), XmlAttribute()]
		public string Description {
			get { return description; }
			set { name = description; }
		} string description;
		
		[XmlIgnore()] public string FriendlyName {
			get { return Name.Clean(); }
		}
		
		[XmlAttribute()] public string PrimaryKey {
			get { return primaryKey; }
			set { primaryKey = value; }
		} string primaryKey;
		
		[XmlIgnore()]
		public FieldElement PrimaryKeyElement {
			get { return Find(PrimaryKey); }
		}
		static readonly string DefaultDatabaseTypeNames = "Unspecified,ClassObject,SqlServer,MySql,OleAccess_2007,OleDb,OleAccess,SQLite";
		/// <summary>
		/// Specify the type for a current selection, such as the type of database
		/// currently in operation/view.
		/// </summary>
		[XmlAttribute]
		public /*DatabaseType*/string DbType {
			get { return dbType; }
			set { dbType = value; }
		} /*DatabaseType*/string dbType = "Unspecified";

		/// <summary>
		/// get;set;
		/// <para>Returns a table view if present;</para>
		/// <para>This should only be set internally by the parser;</para>
		/// </summary>
		[XmlIgnore] public DataViewElement View {
			get { return view; }
			set { view = value; }
		} DataViewElement view;
		/// <summary>
		/// get;set;
		/// <para>Returns a table link if present;</para>
		/// <para>This should only be set internally by the parser;</para>
		/// </summary>
		[XmlIgnore] public DataViewLink Link {
			get { return link; }
			set { link = value; }
		} DataViewLink link;
		
		#endregion
		
		#region TypeName Helpers (See Namespace Provider Properties)
		public static string TypeName(Type t)
		{
			return string.Format("{0}.{1}", t.Namespace, t.Name);
		}
		public static string TypeN(Type t)
		{
			return t.Name;
		}
		public static string NsName(Type t)
		{
			return t.Namespace;
		}
		#endregion
		// IDbCommand, IDbConnection, IDbField, IDbDataAdapter
		#region Namespace Provided Properties
		#region Command
		[XmlIgnore]
		public string NsCommand
		{
			get
			{
				switch (dbType) {
						case "SQLite": return NsName(typeof(System.Data.SQLite.SQLiteCommand));
					case "OleAccess":
						case "OleDb": return NsName(typeof(System.Data.OleDb.OleDbCommand));
						case "SqlServer": return NsName(typeof(System.Data.SqlClient.SqlCommand));
						#if USEMYSQL
						case "MySql": return NsName(typeof(MySqlCommand));
						#endif
						default: return "ClassObject";
				}
			}
		}
		[XmlIgnore()]
		public string TypeCommand {
			get {
				switch (dbType) {
					case "SQLite":
						return TypeName(typeof(System.Data.SQLite.SQLiteCommand));
					case "OleAccess":
					case "OleDb":
						return TypeName(typeof(System.Data.OleDb.OleDbCommand));
					case "SqlServer":
						return TypeName(typeof(System.Data.SqlClient.SqlCommand));
						#if USEMYSQL
					case "MySql":
						return TypeName(typeof(MySqlCommand));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		[XmlIgnore()]
		public string TCommand {
			get {
				switch (dbType) {
					case "SQLite":
						return TypeN(typeof(System.Data.SQLite.SQLiteCommand));
					case "OleAccess":
					case "OleDb":
						return TypeN(typeof(System.Data.OleDb.OleDbCommand));
					case "SqlServer":
						return TypeN(typeof(System.Data.SqlClient.SqlCommand));
						#if USEMYSQL
					case "MySql":
						return TypeN(typeof(MySqlCommand));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		#endregion
		#region Adapter
		[XmlIgnore()]
		public string NsAdapter {
			get {
				switch (dbType) {
					case "SQLite":
						return NsName(typeof(System.Data.SQLite.SQLiteDataAdapter));
					case "OleAccess":
					case "OleDb":
						return NsName(typeof(System.Data.OleDb.OleDbDataAdapter));
					case "SqlServer":
						return NsName(typeof(System.Data.SqlClient.SqlDataAdapter));
						#if USEMYSQL
					case "MySql":
						return NsName(typeof(MySqlDataAdapter));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		[XmlIgnore()]
		public string TypeAdapter {
			get {
				switch (dbType) {
					case "SQLite":
						return TypeName(typeof(System.Data.SQLite.SQLiteDataAdapter));
					case "OleAccess":
					case "OleDb":
						return TypeName(typeof(System.Data.OleDb.OleDbDataAdapter));
					case "SqlServer":
						return TypeName(typeof(System.Data.SqlClient.SqlDataAdapter));
						#if USEMYSQL
					case "MySql":
						return TypeName(typeof(MySqlDataAdapter));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		[XmlIgnore()]
		public string TAdapter {
			get {
				switch (dbType) {
					case "SQLite":
						return TypeN(typeof(System.Data.SQLite.SQLiteDataAdapter));
					case "OleAccess":
					case "OleDb":
						return TypeN(typeof(System.Data.OleDb.OleDbDataAdapter));
					case "SqlServer":
						return TypeN(typeof(System.Data.SqlClient.SqlDataAdapter));
						#if USEMYSQL
					case "MySql":
						return TypeN(typeof(MySqlDataAdapter));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		#endregion
		#region Connection
		[XmlIgnore()]
		public string NsConnection {
			get {
				switch (dbType) {
					case "SQLite":
						return NsName(typeof(System.Data.SQLite.SQLiteConnection));
					case "OleAccess":
					case "OleDb":
						return NsName(typeof(System.Data.OleDb.OleDbConnection));
					case "SqlServer":
						return NsName(typeof(System.Data.SqlClient.SqlConnection));
						#if USEMYSQL
					case "MySql":
						return NsName(typeof(MySqlConnection));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		[XmlIgnore()]
		public string TypeConnection {
			get {
				switch (dbType) {
					case "SQLite":
						return TypeName(typeof(System.Data.SQLite.SQLiteConnection));
					case "OleAccess":
					case "OleDb":
						return TypeName(typeof(System.Data.OleDb.OleDbConnection));
					case "SqlServer":
						return TypeName(typeof(System.Data.SqlClient.SqlConnection));
						#if USEMYSQL
					case "MySql":
						return TypeName(typeof(MySqlConnection));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		[XmlIgnore()]
		public string TConnection {
			get {
				switch (dbType) {
					case "SQLite":
						return TypeN(typeof(System.Data.SQLite.SQLiteConnection));
					case "OleAccess":
					case "OleDb":
						return TypeN(typeof(System.Data.OleDb.OleDbConnection));
					case "SqlServer":
						return TypeN(typeof(System.Data.SqlClient.SqlConnection));
						#if USEMYSQL
					case "MySql":
						return TypeN(typeof(MySqlConnection));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		[XmlIgnore()]
		public string TParameter {
			get {
				switch (dbType) {
					case "SQLite":
						return TypeN(typeof(System.Data.SQLite.SQLiteParameter));
					case "OleAccess":
					case "OleDb":
						return TypeN(typeof(System.Data.OleDb.OleDbParameter));
					case "SqlServer":
						return TypeN(typeof(System.Data.SqlClient.SqlParameter));
						#if USEMYSQL
					case "MySql":
						return TypeN(typeof(MySqlConnection));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		#endregion
		#region Reader
		[XmlIgnore()]
		public string NsReader {
			get {
				switch (dbType) {
					case "SQLite":
						return NsName(typeof(System.Data.SQLite.SQLiteDataReader));
					case "OleAccess":
					case "OleDb":
						return NsName(typeof(System.Data.OleDb.OleDbDataReader));
					case "SqlServer":
						return NsName(typeof(System.Data.SqlClient.SqlDataReader));
						#if USEMYSQL
					case "MySql":
						return NsName(typeof(MySqlDataReader));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		[XmlIgnore()]
		public string TypeReader {
			get {
				switch (dbType) {
					case "SQLite":
						return TypeName(typeof(System.Data.SQLite.SQLiteDataReader));
					case "OleAccess":
					case "OleDb":
						return TypeName(typeof(System.Data.OleDb.OleDbDataReader));
					case "SqlServer":
						return TypeName(typeof(System.Data.SqlClient.SqlDataReader));
						#if USEMYSQL
					case "MySql":
						return TypeName(typeof(MySqlDataReader));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		[XmlIgnore()]
		public string TReader {
			get {
				switch (dbType) {
					case "SQLite":
						return TypeN(typeof(System.Data.SQLite.SQLiteDataReader));
					case "OleAccess":
					case "OleDb":
						return TypeN(typeof(System.Data.OleDb.OleDbDataReader));
					case "SqlServer":
						return TypeN(typeof(System.Data.SqlClient.SqlDataReader));
						#if USEMYSQL
					case "MySql":
						return TypeN(typeof(MySqlDataReader));
						#endif
					default:
						return "ClassObject";
				}
			}
		}
		#endregion
		#endregion
		
		#endregion
		#region Methods: FieldElement Find(string Key), bool Contains(string Key)
		/// <summary>
		/// Find FieldElement from Key or Null
		/// </summary>
		/// <param name="Key">(string) FieldElement.DataName</param>
		/// <returns>a FieldElement or Null</returns>
		FieldElement Find(string Key)
		{
			if (items == null) return null;
			if (items.Count == 0) return null;
			foreach (FieldElement field in this.Fields) {
				if (field.DataName == Key)
					return field;
			}
			return null;
		}
		/// <summary>
		/// The given Key is found in Field list.
		/// </summary>
		/// <param name="Key">see the FieldElement.DataName property</param>
		/// <returns>True if the DataName is found</returns>
		public bool Contains(string Key)
		{
			return Find(Key) != null;
		}
		#endregion
		#region Methods: TreeNode ToNode(), void ToTree(TreeNode tn)
		#if TREEV
		public TreeNode ToNode()
		{
			TreeNode tn = new TreeNode(name);
			tn.Name = Name;
			// the image correlates with the PanelTableEditor (or whatever it's called)
			tn.SelectedImageKey = tn.ImageKey = "table";
			tn.Tag = this;
			foreach (FieldElement fe in items)
				tn.Nodes.Add(fe.ToNode());
			return tn;
		}
		public void ToTree(TreeNode tn)
		{
			TreeNode tblelement = tn.Nodes.Add(this.name);
			tblelement.Name = this.Name;
//			tblelement.BaseClass = this.BaseClass;
			// the image correlates with the PanelTableEditor (or whatever it's called)
			tblelement.SelectedImageKey = tblelement.ImageKey = "table";
			foreach (FieldElement item in items)
				tblelement.Nodes.Add(item.ToNode());
		}
		#endif
		#endregion
		#region .ctor
		#if TREEV
		// .ctor
		public TableElement(TreeNode node)
		{
			name = node.Text;
			if (items == null)
				items = new List<FieldElement>();
			if (node.Tag is TableElement) {
				TableElement te = node.Tag as TableElement;
				DbType = te.DbType;
				BaseClass = te.BaseClass;
				Name = te.Name;
				PrimaryKey = te.PrimaryKey;
			}
			foreach (TreeNode tn in node.Nodes) {
				if (tn.Tag is FieldElement)
					items.Add(new FieldElement(tn));
			}
		}
		#endif
		public TableElement()
		{
		}
		#endregion
		#region PARAMETER DICTIONARY (Template/Replacement functions)

		internal DICT<string, object> conversionElements = new DICT<string, object>();
		
		void Add(string keyName, object value)
		{
			conversionElements.Add(keyName, value);
		}
		
		virtual public void InitializeDictionary()
		{
			conversionElements.Clear();
			
			// ac_table
			
			//
			#region Table Type
			Add("TableType", DbType);
			Add("tabletype", string.Format("{0}", DbType).ToLower());
			#endregion
			//
			#region Primary Key
			// see the primary key related tags below
			Add("PK", PrimaryKey);
			Add("pk", PrimaryKey == null ? string.Empty : PrimaryKey.ToLower());
			Add("PrimaryKey", PrimaryKey == null ? string.Empty : PrimaryKey);
			Add("PrimaryKeyCleanC", PrimaryKey == null ? string.Empty : PrimaryKey.ToStringCapitolize().Clean());
			Add("primarykey", PrimaryKey == null ? string.Empty : PrimaryKey.ToLower());
			#endregion
			//
			#region TableName
			//
			Add("Name", Name);
			Add("Table", Name.Replace("-", "_"));
			
			try {
				
				Add("TableAlias", View!=null ? View.Alias : Link!=null ? Link.Alias : Name);
				Add("_TableAlias", View!=null ? View.Alias : Link!=null ? Link.Alias : Name.Replace("-", "_"));
				Add("tablealias", (conversionElements["TableAlias"] as string).ToLower());
				//
				Add("TableAliasC", conversionElements["TableAlias"].ToStringCapitolize());
				Add("FriendlyTableAlias", (conversionElements["TableAlias"] as string).Clean());
				Add("TableAliasClean", conversionElements["FriendlyTableAlias"]);
				Add("tablealiasclean", (conversionElements["TableAlias"] as string).ToLower());
				Add("TableAliasCClean", conversionElements["TableAlias"].ToStringCapitolize());
				Add("TABLEALIASCLEAN", (conversionElements["TableAlias"] as string).ToUpper());
				//
//				Add("AliasCClean", conversionElements["FriendlyAlias"].ToStringCapitolize());
				//
				Add("TableAliasCName", (conversionElements["TableAlias"] as string).Clean());
				Add("TableAliasCNameC", (conversionElements["TableAliasCName"] as string).ToStringCapitolize());
			} catch (Exception error) {
				Logger.Warn("Parse Exception",error.Message);
			}
			
			//
			Add("TableName", Name);
			Add("tablename", Name.ToLower());
			//
			Add("TableNameC", Name.ToStringCapitolize());
			Add("TableNameClean", FriendlyName);
			Add("tablenameclean", FriendlyName.ToLower());
			Add("TableNameCClean", FriendlyName.ToStringCapitolize());
			//
			Add("TableCleanName", Name.Clean());
			Add("TableCleanNameC", Name.Clean().ToStringCapitolize());
			#endregion
			//
			#region Namespace Types
			Add("AdapterNs", NsAdapter);
			Add("AdapterT", TAdapter);
			Add("AdapterNsT", TypeAdapter);
			//
			Add("CommandNs", NsCommand);
			Add("CommandT", TCommand);
			Add("CommandNsT", TypeCommand);
			//
			Add("ConnectionNs", NsConnection);
			Add("ConnectionT", TConnection);
			Add("ConnectionNsT", TypeConnection);
			//
			Add("ParameterT", TParameter);
			//
			Add("ReaderNs", NsReader);
			Add("ReaderT", TReader);
			Add("ReaderNsT", TypeReader);
			#endregion
			//
			GeneratorTypeProvider.GetTypes<GeneratorDateTimeFieldProvider>(conversionElements);
			
			#region Primary Key Automated Reference (NOT FOR VIEWS)
			//
			if (PrimaryKey == null) {
				MessageBox.Show("Table must provide a primary key", "Please check the table.");
				return;
			} else if (PrimaryKey != string.Empty && PrimaryKey != "%PKUNKNOWN%") {
				Add("PKDataName",			PrimaryKeyElement.DataName);
				Add("PKDataType",			PrimaryKeyElement.DataType);
				Add("PKDataTypeNative",		PrimaryKeyElement.DataTypeNative);
				Add("PKNativeNullType",		NullableTypeUtility.GetNativeNullType(PrimaryKeyElement["Native"].ToString()));
				Add("PKNativeNullValue",	NullableTypeUtility.IsNativeNullable(PrimaryKeyElement["Native"].ToString()) ? ".Value" : "");
//				Add("PKDataTypeNative",PrimaryKeyElement.DataTypeNative);
				Add("PKDescription",		PrimaryKeyElement.Description);
				//
				Add("PKDataNameC",			PrimaryKeyElement.DataName.ToStringCapitolize());
				Add("PKCleanName",			PrimaryKeyElement.DataName.Replace("-", "_"));
				Add("PKCleanName,Nodash",	PrimaryKeyElement.DataName.Clean());
				Add("PKFriendlyName",		PrimaryKeyElement.DataName.Clean());
				Add("PKFriendlyNameC",		PrimaryKeyElement.DataName.Clean().ToStringCapitolize());
			} else {
				Global.statR(Generator.Messages.TableElement_PrimaryKeyNotFound, name);
			}
			#endregion
			
			if (Transform!=null) Transform(conversionElements);
		}
		/// <summary>
		/// used from the Reformat(string input) method.
		/// </summary>
		/// <param name="Key">in the conversionElements dictionary.</param>
		/// <param name="inputString">string basis for replace method.</param>
		/// <returns></returns>
		string Reformat(string Key, string inputString)
		{
			return inputString.Replace(
				string.Format("$({0})", Key),
				string.Format("{0}", conversionElements[Key])
			);
		}
		/// <summary>
		/// in preparation for a field-template, a field template is parsed
		/// for table-template parameters.
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public string Reformat(string input)
		{
			string clone = string.Copy(input);
			string[] vals = conversionElements.KeyArray;
			foreach (string key in vals) clone = Reformat(key, clone);
			vals = null;
			return clone.Replace("@id", "@xid");
		}
		
		/// <summary>
		/// Initializes the dictionary `InitializeDictionary()`, and calls `Reformat()`.
		/// </summary>
		/// <param name="table">TableElement</param>
		/// <param name="tableTemplate">(string) TableTemplate</param>
		/// <returns></returns>
		public string ReplaceValues(string tableTemplate, Action<DICT<string,object>> action=null)
		{
			InitializeDictionary();
			return Reformat(tableTemplate);
		}
		#endregion
	}
	#region Obsolete
	// This is never used
	public interface IContextProvider
	{
		Type ConnectionType { get; }
	}
	#endregion
}
