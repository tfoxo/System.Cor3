using System;

namespace Generator.Core.Entities.Types
{
	/// <summary>
	/// See Generator.Core.Entities.Types
	/// </summary>
	public enum DatabaseType
	{
		Unspecified,
		ClassObject,
		SqlServer,
		#if USEMYSQL
		MySql,
		#endif
		//OleAccess_2007,
		OleDb,
		OleAccess,
		SQLite
	}
	
}
