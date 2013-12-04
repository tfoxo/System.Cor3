/*
 * User: oIo
 * Date: 11/15/2010 – 2:33 AM
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace Generator.Core.Entities
{
	public class FieldReference : DataMapElement
	{
		#region Properties
		[XmlAttribute]
		public string database;
		[XmlAttribute]
		public string field;
		#endregion
		#region .Ctor
		public FieldReference()
		{
		}
		public FieldReference(DatabaseElement db, FieldElement field)
		{
			this.database = db.Name;
			this.field = field.DataName;
		}
		#endregion
	}
	public class UniqueKey
	{
		#region Properties

		[XmlAttribute]
		public string name;
		[XmlElement]
		public List<FieldReference> fields;
		
		#endregion
		#region .Ctor
		public UniqueKey()
		{
		}
		public UniqueKey(string name, params FieldReference[] fields)
		{
			this.name = name;
			this.fields = new List<FieldReference>(fields);
		}
		#endregion
	}
}
