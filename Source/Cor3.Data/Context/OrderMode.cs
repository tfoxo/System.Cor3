/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/30/2011
 * Time: 14:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml.Serialization;

namespace System.Cor3.Data.Context
{
	[Serializable]
	public enum SqlOrderMode
	{
		[XmlEnum]
		Undefined,
		[XmlEnum]
		Ascending,
		[XmlEnum]
		Descending
	}
}
