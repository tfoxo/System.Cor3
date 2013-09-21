/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/30/2011
 * Time: 14:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.SQLite;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace System.Cor3.Data.Context
{
	[XmlRoot]
	public class DatabaseContextCollection : SerializableClass<DatabaseContextCollection>
	{
		string _name = "database-context-collection";
		[XmlAttribute] public string Name { get { return _name; } set { _name = value; } }
		
		
		QueryContextInfo[] list = new QueryContextInfo[0];
		[XmlElement(typeof(QueryContextInfo))]
		public QueryContextInfo[] Contexts { get { return list; } set { list = value; } }
		
		[XmlIgnore]
		public QueryContextInfo[] Parameters {
			get { return contexts; }
			set { contexts = value; }
		} QueryContextInfo[] contexts;
//
//		[XmlElement(Type=typeof(DatabaseContextSerializer))]
////		[XmlElement("Parameters")]
//		public DatabaseContextSerializer XmlParameters {
//			get {
//				if (Parameters == null)
//					return null;
//				else {
//					return new DatabaseContextSerializer(Parameters);
//				}
//			}
//			set {
//				contexts = value.Parameters;
//			}
//		}
		public DatabaseContextCollection()
		{
		}
		public DatabaseContextCollection(params QueryContextInfo[] contexts)
		{
			list = contexts;
		}

	}

}
