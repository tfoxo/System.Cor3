/*
 * User: oIo
 * Date: 11/15/2010 – 2:33 AM
 */
#region Using
using System;
#endregion

namespace Generator.Core.Entities.Types
{
	// note also System.Data.Common.StorageType
	// note also System.Data.DbType
	// note also System.Data.FunctionId
	// note also System.Data.SqlDbType (of course)
	// note also System.Data.StatementType
	// note also System.Data.ValueType
	// note also System.Data.Odbc.OdbcType
	public enum SchemaMapTypes
	{
		 /// 2
		@Short = System.Data.OleDb.OleDbType.SmallInt,
		///3,
		@Long = System.Data.OleDb.OleDbType.Integer,
		///4,
		@Single = System.Data.OleDb.OleDbType.Single,
		///5,
		@Double = System.Data.OleDb.OleDbType.Double,
		///6,
		@Currency = System.Data.OleDb.OleDbType.Currency,
		///7
		@DateTime = 7,//System.Data.OleDb.OleDbType.Date,  // I know that Date maps correctly to 7, but just in case…
		///11
		@Bit = System.Data.OleDb.OleDbType.Boolean,// is this correct? Guess so.
		///17
		@Byte = System.Data.OleDb.OleDbType.UnsignedTinyInt,
		///72
		@GUID = System.Data.OleDb.OleDbType.Guid,
		///128
		@BigBinary = System.Data.OleDb.OleDbType.Binary, //204 (Ole.Binary is 128)
		///128
		@LongBinary = System.Data.OleDb.OleDbType.Binary, //205
		///128
		@VarBinary = System.Data.OleDb.OleDbType.Binary, //204
		///130
		@LongText = System.Data.OleDb.OleDbType.WChar,//203
		///130
		@VarChar = System.Data.OleDb.OleDbType.WChar,//202
		///131
		@Decimal = System.Data.OleDb.OleDbType.Decimal,
	}
}
