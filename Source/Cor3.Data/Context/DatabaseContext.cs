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
using System.Cor3.Data.Engine;
using System.Data;
using System.Runtime.Remoting.Contexts;
using System.Xml.Serialization;

namespace System.Cor3.Data.Context
{

	public class DatabaseContext<TConnection,TCommand,TAdapter,TParameter> : QueryDatabaseContext, IDisposable
		where TConnection:IDbConnection
		where TCommand:IDbCommand, new()
		where TAdapter:class,IDbDataAdapter,IDisposable,new()
		where TParameter:IDbDataParameter
	{
		public QueryContext<TConnection,TCommand,TAdapter,TParameter>.TCommandParamsCallback TableRowParams = null;
		public QueryContext<TConnection,TCommand,TAdapter,TParameter>.TQueryInfoCallback TableAdapterParams = null;
		
		void IDisposable.Dispose()
		{
		}

		public DatabaseContext()
		{
		}
		public DatabaseContext(QueryContextInfo clone)
		{
			SetContext(clone);
		}

	}

}
