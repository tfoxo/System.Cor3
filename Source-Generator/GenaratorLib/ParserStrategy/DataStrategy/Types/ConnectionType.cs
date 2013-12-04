/*
 * User: oIo
 * Date: 11/15/2010 – 2:33 AM
 */
#region Using
using System;
#endregion

namespace Generator.Core.Entities.Types
{
	public enum ConnectionType
	{
		None,
		OleDb,
		#if USEMYSQL
		MySql,
		#endif
		SQLite,
		Sql,
	}

}
