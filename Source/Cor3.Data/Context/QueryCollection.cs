/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/30/2011
 * Time: 14:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml.Serialization;

namespace System.Cor3.Data.Context
{
	[Serializable,XmlRoot]
	public class QueryCollection : SerializableClass<QueryCollection>
	{
		List<QueryContextInfo> _context;
		
		[XmlElement]
		public List<QueryContextInfo> context {
			get { return _context; }
			set { _context = value; }
		}
		
		public QueryCollection()
		{
		}
	}
}
