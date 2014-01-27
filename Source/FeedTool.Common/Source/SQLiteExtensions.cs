//#define SQLITE
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace FeedTool
{
	using System.ComponentModel;
	using System.Data;
	using System.ComponentModel.DataAnnotations;
	using System.Data.SQLite;
	using System.Windows.Forms.VisualStyles;

	public class QueryEnclosure
	{
		
	}
	
	static class SQLiteExtensions
	{
		static public List<SQLiteParameter> GetParameters(this object instance)
		{
			var list = new List<SQLiteParameter>();
			foreach (var x in instance.GetType().GetProperties()) {
				var s = (DisplayAttribute)(x.GetCustomAttributes(attributeType: typeof(DisplayAttribute), inherit: false).First());
				var i = new SQLiteParameter(parameterName: s.Name, value: GetType().GetProperty(s.Name).GetValue(this, null));
				list.Add(item: i);
			}
			return list;
		}

		static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
		{
			var attrType = typeof(T);
			var property = instance.GetType().GetProperty(name: propertyName);
			return (T)property.GetCustomAttributes(attributeType: attrType, inherit: false).First();
		}
	}
}


