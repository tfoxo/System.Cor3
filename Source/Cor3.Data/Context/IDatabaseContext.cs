/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/30/2011
 * Time: 14:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Xml.Serialization;

namespace System.Cor3.Data.Context
{
	public interface IDatabaseContext
	{
		string statementSelect();
		string statementCategories();
		string statementTables();
		string statementInsert();
		string statementInsert(params string[] fields);
		string statementDelete();
		string statementDelete(bool asString);
		string statementUpdate(DataRowView row);
		string statementUpdate(DataRowView row, params string[] fields);
		void SetFields(params string[] TableFields);
		[XmlAttributeAttribute()]
		string CategoryName { get; set; }
		[XmlAttributeAttribute()]
		string CategoryTitle { get; set; }
		[XmlAttributeAttribute()]
		string CategoryPk { get; set; }
		[XmlIgnoreAttribute()]
		DataRowView TableRow { get; set; }
		[XmlAttributeAttribute()]
		string TableName { get; set; }
		[XmlAttributeAttribute()]
		string TablePk { get; set; }
		[XmlAttributeAttribute()]
		string TableTitle { get; set; }
		[XmlAttributeAttribute()]
		string TableContent { get; set; }
		[XmlIgnoreAttribute()]
		string[] TableFields { get; set; }
		[XmlAttributeAttribute()]
		string TableCategory { get; set; }
		[XmlAttributeAttribute()]
		string TableFieldsAttribute { get; set; }
		SqlOrderMode OrderMode { get; set; }
		string OrderValue { get; set; }
		[XmlIgnoreAttribute()]
		string SELECT { get; }
		[XmlIgnoreAttribute()]
		string CATEGORIES { get; }
		[XmlIgnoreAttribute()]
		string TABLES { get; }
		event EventHandler TableCategoryChanged;
	}
}
