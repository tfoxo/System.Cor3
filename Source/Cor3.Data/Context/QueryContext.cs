/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/30/2011
 * Time: 14:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Cor3.Data.Engine;
using System.Data;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml.Serialization.Configuration;
using System.Xml.Serialization.Advanced;

namespace System.Cor3.Data.Context
{

	public abstract class QueryContext : IQueryContext1
	{
		public delegate DataSet TSqlExecute(string q);
		//;
		internal string datafile = null;
		
		[XmlIgnore]
		abstract public QueryContextInfo ContextData { get; }

		internal DataSet category = null;
		[XmlIgnore]
		public DataSet Category {
			get { return category; }
			set { category = value; }
		}
		public abstract DataSet InsertCategory(string q);
		public abstract DataSet SelectCategory(string q);
		public abstract DataSet UpdateCategory(string q);
		public abstract DataSet DeleteCategory(string q);

		internal DataSet data = null;
		[XmlIgnore] public DataSet Data {
			get { return data; }
			set { data = value; }
		}
		public abstract DataSet Insert(string q);
		public abstract DataSet Select(string q);
		public abstract DataSet Delete(string q);
		public abstract DataSet Update(string q);

		public abstract void Initialize();
		
	}


}
