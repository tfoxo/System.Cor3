/*
 * User: oIo
 * Date: 11/15/2010 – 2:49 AM
 */
using System;
using System.Data;

namespace System.Cor3.Data.Engine
{
	/*
	  * this class does not seem to be used anywhere here or there.
	  * */
	public abstract class TableParams<TCommand>
		where TCommand:IDbCommand
	{
		public delegate void ParameterizationProcedure(System.Data.DataRowView row, TCommand cmd);
		public ParameterizationProcedure DeleteParams;
		public ParameterizationProcedure InsertParams;
		public ParameterizationProcedure SelectParams;
		public ParameterizationProcedure UpdateParams;
		
//		void AddParams(string tableName, ParameterizationProcedure del, ParameterizationProcedure sel, ParameterizationProcedure upd);
		
		public TableParams(
			ParameterizationProcedure del,
			ParameterizationProcedure ins,
			ParameterizationProcedure sel,
			ParameterizationProcedure upd)
		{
			DeleteParams = del;
			InsertParams = ins;
			SelectParams = sel;
			UpdateParams = upd;
		}

		public TableParams(
			ParameterizationProcedure del,
			ParameterizationProcedure ins,
			ParameterizationProcedure upd)
		{
			DeleteParams = del;
			InsertParams = ins;
			UpdateParams = upd;
		}
	}
}
