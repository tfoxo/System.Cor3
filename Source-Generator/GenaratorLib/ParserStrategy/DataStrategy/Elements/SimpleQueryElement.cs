/*
 * User: oIo
 * Date: 11/15/2010 – 2:32 AM
 */
#region Using
using System;
#if TREEV
using System.Windows.Forms;
#endif
#endregion

namespace Generator.Core.Entities
{
	/// <summary>
	/// Description of TypeMap.
	/// </summary>
	[Obsolete]
	public class SimpleQueryElement
	{
		string queryName;
		public string Name { get { return queryName; } set { queryName = value; } }

		string query;
		public string Query { get { return query; } set { query = value; } }

		#if TREEV
		public void ToTree(TreeNode node)
		{
			TreeNode element = node.Nodes.Add(Name);
			element.Tag = this;
		}
		#endif
		
		public SimpleQueryElement(string name, string queryvalue)
		{
			queryName = name;
			query = queryvalue;
		}
		public SimpleQueryElement()
		{
		}
	}
}
