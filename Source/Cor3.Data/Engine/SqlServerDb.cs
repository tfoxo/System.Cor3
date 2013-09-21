/*
 * User: oIo
 * Date: 11/15/2010 – 2:49 AM
 */
using System;
using System.Collections.Generic;
using System.Cor3.Data;
using System.Data.SqlClient;

namespace System.Cor3.Data.Engine
{
	public class SqlServerDb : SqlDbA
	{
		/// <summary>
		/// the input string consists of comma delimited values for:
		/// Datasource (name), Table (name)
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		static public SqlServerDb FromString(string input)
		{
			string[] dss = input.Split(',');
			List<string> list = new List<string>();
			foreach (string s in dss) list.Add(s.Trim());
			// we could just unmark SqlDbA from being abstract and all.
			SqlServerDb db = new SqlServerDb(dss.Length >= 1 ? list[0] : "", dss.Length >= 2 ? list[1] : "");
			return db;
			
		}
		public SqlServerDb():base()
		{
			
		}
		public SqlServerDb(string source, string tablename) : base(source,tablename)
		{
			
		}
	}
}
