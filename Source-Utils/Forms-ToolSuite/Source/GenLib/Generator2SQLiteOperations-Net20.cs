#region Using
/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 12/26/2011
 * Time: 8:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Cor3.Data;
using System.Cor3.Data.Context;
using System.Cor3.Data.Engine;
using System.Data;
using System.Data.SQLite;

using Generator.Core.Entities;
using Generator.Core.Entities.Types;
using Generator.Core.Markup;
#endregion
namespace VisualEditor.SQLite
{
	/// <summary>
	/// Now that this is implemented in Generator application/lib it is no
	/// longer necessary here.
	/// </summary>
	public class Generator2SQLiteOperations
	{
		
		#region const
		const string sql_drop_gen_db_tbl_fld = @"
		DROP TABLE IF EXISTS [$(db)];
		DROP TABLE IF EXISTS [$(table)];
		DROP TABLE IF EXISTS [$(field)];
",
		sql_gen_db_tbl_fld = @"
CREATE TABLE ""$(field)"" (
			id					INTEGER PRIMARY KEY AUTOINCREMENT,
			pid					INTEGER,
			'crd'				DATETIME DEFAULT NULL,
			'mod'				DATETIME DEFAULT NULL,
			summary				LONGVARCHAR DEFAULT NULL,
			mmd					LONGVARCHAR DEFAULT NULL,
			'Name'				VARCHAR DEFAULT NULL,
			'BlockAction'		VARCHAR DEFAULT NULL,
			'CodeBlock'			LONGVARCHAR DEFAULT NULL,
			'DataName'			VARCHAR DEFAULT NULL,
			'DataType'			VARCHAR DEFAULT NULL,
			DataTypeNative		VARCHAR DEFAULT NULL,
			DefaultValue		VARCHAR DEFAULT NULL,
			Description			VARCHAR DEFAULT NULL,
			FormatString		LONGVARCHAR DEFAULT NULL,
			FormType			VARCHAR DEFAULT NULL,
			IsNullable			BOOLEAN,
			MaxLength			INTEGER,
			UseFormat		BOOLEAN DEFAULT 0,
			Tags			VARCHAR DEFAULT NULL
		);
CREATE TABLE ""$(table)"" (
			id					INTEGER PRIMARY KEY AUTOINCREMENT,
			pid					INTEGER,
			'crd'				DATETIME DEFAULT NULL,
			'mod'				DATETIME DEFAULT NULL,
			summary				LONGVARCHAR DEFAULT NULL,
			mmd					LONGVARCHAR DEFAULT NULL,
			'Name'				VARCHAR DEFAULT NULL,
			'Description'		VARCHAR DEFAULT NULL,
			'PrimaryKey'		VARCHAR DEFAULT NULL,
			'DbType'			VARCHAR DEFAULT NULL
		);
CREATE TABLE ""$(db)"" (
			id					INTEGER PRIMARY KEY AUTOINCREMENT,
			pid					INTEGER,
			'crd'				DATETIME DEFAULT NULL,
			'mod'				DATETIME DEFAULT NULL,
			summary				LONGVARCHAR DEFAULT NULL,
			mmd					LONGVARCHAR DEFAULT NULL,
			'Name'				VARCHAR DEFAULT NULL,
			'PrimaryKey'		VARCHAR DEFAULT NULL,
			'ConnectionType'	VARCHAR DEFAULT NULL
		);
",
		sql_ins_gen_field = @"
				insert into [$(field)] (
					[crd], [mod], [pid], [BlockAction],
					[CodeBlock], [DataName], [Name], [DataType],
					[DataTypeNative], [DefaultValue], [Description], [FormatString],
					[FormType], [IsNullable], [MaxLength], [Tags],
					[UseFormat]
				) VALUES (
					@crd, @mod, @pid, @BlockAction,
					@CodeBlock, @DataName, @DataName, @DataType,
					@DataTypenative, @DefaultValue, @Description, @FormatString,
					@FormType, @IsNullable, @MaxLength, @Tags,
					@UseFormat);
",
		sql_gen_ins_db = "insert into [gen-data-db] ([crd],[mod],[Name],[PrimaryKey],[ConnectionType]) values(@crd,@mod,@Name,@PrimaryKey,@ConnectionType);",
		sql_gen_ins_table = "insert into [$(table)] ([pid],[crd],[mod],[Name],[DbType],[Description],[PrimaryKey]) values(@pid,@crd,@mod,@Name,@DbType,@Description,@PrimaryKey);",
		query_ins_gen_tpl = @"insert into [generator-templates] (
	[Name],[Group],[Alias],
	ElementTemplate,ItemsTemplate,SyntaxLanguage ) values (
	@Name,@Group,@Alias,
	@ElementTemplate,@ItemsTemplate,
	@SyntaxLanguage);
",
		sql_gen_ins_tpl = @"
DROP TABLE [generator-templates];
CREATE TABLE ""[generator-templates]"" (
			id INTEGER PRIMARY KEY AUTOINCREMENT, pid INTEGER,
			'crd'				DATETIME DEFAULT NULL,
			'mod'				DATETIME DEFAULT NULL,
			summary				LONGVARCHAR DEFAULT NULL,
			mmd					LONGVARCHAR DEFAULT NULL,
			'Name'				VARCHAR DEFAULT NULL,
			'Alias'				VARCHAR DEFAULT NULL,
			'Group'				VARCHAR DEFAULT NULL,
			'SyntaxLanguage'	VARCHAR DEFAULT NULL,
			'Tags'				VARCHAR DEFAULT NULL,
			'ItemsTemplate'		VARCHAR DEFAULT NULL,
			'ElementTemplate'	VARCHAR DEFAULT NULL,
			'file-project'		LONGVARCHAR DEFAULT NULL,
			'file-type'			LONGVARCHAR DEFAULT NULL,
			'file-name'			LONGVARCHAR DEFAULT NULL
		);
";
		#endregion
		
		#if Net4 || WPF4
		static public Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
		static public Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
		#else
		static public System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
		static public System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
		#endif
		
		#region Generator Template
		/// <summary>
		/// Drops and re-creates templates.
		/// </summary>
		static public void GeneratorTemplatesDestroy()
		{
			string cr_t = sql_gen_ins_tpl;
			string query = cr_t;
			using (SQLiteDb db = new SQLiteDb(QueryDatabaseContext.sqlitedb))
			{
				using (SQLiteConnection C = db.Connection)
				{
					using (SQLiteDataAdapter A = new SQLiteDataAdapter(query,C))
					{
						C.Open();
						A.SelectCommand = new SQLiteCommand(query,C);
						try {
							A.SelectCommand.ExecuteNonQuery();
						}
						catch (Exception exc)
						{
							#if WPF4
							System.Windows.MessageBox.Show(exc.ToString());
							#else
							System.Windows.Forms.MessageBox.Show(exc.ToString());
							#endif
						}
						C.Close();
					}
				}
			}
		}
		
		static public void GeneratorTemplatesCreate()
		{
			#if WPF4
			throw new Exception();
			#else
			if (!Helper.DialogResultIsOK(ofd,"")) return;
			#endif
		}
		static public void GeneratorTemplatesCreate(string pathSQLiteDatabase)
		{
			#if WPF4
			throw new Exception();
			#else
			if (!Helper.DialogResultIsOK(ofd,"Xml-Template Configuration|*.xml|All files|*")) return;
			TemplateCollection dc = TemplateCollection.Load(ofd.FileName);
			GeneratorTemplatesCreate(dc,pathSQLiteDatabase);
			#endif
		}
		
		/// <summary>
		/// Uses openfiledialog to load a xml file to be appended to a particular
		/// sqlite database.
		/// </summary>
		static public void GeneratorTemplatesCreate(TemplateCollection xmlTemplateCollection, string pathSQLiteDatabase)
		{
			string query = string.Concat(query_ins_gen_tpl);
			using (SQLiteDb db = new SQLiteDb( pathSQLiteDatabase /*QueryDatabaseContext.sqlitedb*/))
				using (SQLiteConnection C = db.Connection)
					using (SQLiteDataAdapter A = new SQLiteDataAdapter(string.Empty,C))
			{
				C.Open();
				
				foreach (TableTemplate tpl in xmlTemplateCollection.Templates)
				{
					A.InsertCommand = new SQLiteCommand(query,C);
					
					#region Parameters
					A.InsertCommand.Parameters.AddWithValue("@Name",tpl.Name);
					A.InsertCommand.Parameters.AddWithValue("@ElementTemplate",tpl.ElementTemplate);
					A.InsertCommand.Parameters.AddWithValue("@ItemsTemplate",tpl.ItemsTemplate);
					A.InsertCommand.Parameters.AddWithValue("@Alias",tpl.Alias);
					A.InsertCommand.Parameters.AddWithValue("@Group",tpl.Group);
					A.InsertCommand.Parameters.AddWithValue("@SyntaxLanguage",tpl.SyntaxLanguage);
					A.InsertCommand.Parameters.AddWithValue("@Tags",tpl.Tags);
					#endregion
					
					try { A.InsertCommand.ExecuteNonQuery(); }
					#if WPF4
					catch (Exception exc) {
						Helper.MessageBoxIsOK(
							exc.ToString(),
							"Error",
							System.Windows.MessageBoxButton.OK,
							System.Windows.MessageBoxImage.Error
						);
					}
					#else
					catch (Exception exc) {
						Helper.MessageBoxIsOK(
							exc.ToString(),
							"Error",
							System.Windows.Forms.MessageBoxButtons.OK,
							System.Windows.Forms.MessageBoxIcon.Error
						);
					}
					#endif
				}
				
				C.Close();
			}
		}
		#endregion
		
		#region ExportSQLiteCreateSnippit
		static public void ExportSQLiteCreateSnippit()
		{
//			if (!sfd.ShowDialog().Value) return;
			#if WPF4
			throw new Exception();
			#else
			if (!Helper.DialogResultIsOK(sfd,"xdata|*.xdata|xml|*.xml|all files|*")) return;
			#endif
			
			List<string> list = new List<string>();
			
			string output = string.Empty;
			using (SQLiteContext c = new SQLiteContext())
			{
				c.Select("select * from sqlite_master");
				using (DataView v = c.Data.GetDataView(0))
				{
					foreach (DataRowView row in v)
					{
						list.Add(string.Format("# {0}",row["name"]));
						list.Add("");
						list.Add(row["sql"].ToString());
						list.Add("");
					}
				}
			}
			System.IO.File.WriteAllText(sfd.FileName,string.Join("\r\n",list.ToArray()),System.Text.Encoding.UTF8);
		}
		#endregion
		
		#region InsertCollection
		/// <summary>
		/// uses default table names
		/// </summary>
		static public void InsertCollection()
		{
			if (!Helper.DialogResultIsOK(ofd,"xdata|*.xdata|xml|*.xml|all files|*")) return;
			// List<string> list = new List<string>();
			
			string fname = ofd.FileName;
			DatabaseCollection c = DatabaseCollection.Load(fname);

			int countdb = 0, counttable = 0, countfield = 0;
			foreach (DatabaseElement elmDb in c.Databases)
			{
				string query = null;
				using (SQLiteDb db = new SQLiteDb(QueryDatabaseContext.sqlitedb))
				{
					using (SQLiteConnection C = db.Connection)
					{
						query = sql_gen_ins_db;
						using (SQLiteDataAdapter A = new SQLiteDataAdapter(string.Empty,C))
						{
							C.Open();
							A.InsertCommand = new SQLiteCommand(query,C);
							A.InsertCommand.Parameters.AddWithValue("@crd",DateTime.Now);
							A.InsertCommand.Parameters.AddWithValue("@mod",DateTime.Now);
							A.InsertCommand.Parameters.AddWithValue("@Name",elmDb.Name);
							A.InsertCommand.Parameters.AddWithValue("@PrimaryKey",elmDb.PrimaryKey);
							A.InsertCommand.Parameters.AddWithValue("@ConnectionType",elmDb.ConnectionType== ConnectionType.None?"":elmDb.ConnectionType.ToString());
							try {
								A.InsertCommand.ExecuteNonQuery();
								countdb++;
							}
							catch (Exception exc)
							{
								if ( Helper.MessageBoxIsOK(exc.ToString(),"db") ) return; ;
							}
							
							C.Close();
						}
						// we can iterate again
						foreach (TableElement tpl in elmDb.Items)
						{
							using (SQLiteDataAdapter A = new SQLiteDataAdapter(string.Empty,C))
							{
								query = ReplaceTableNames(sql_gen_ins_table);
								C.Open();
								A.InsertCommand = new SQLiteCommand(query,C);
								A.InsertCommand.Parameters.AddWithValue("@crd",DateTime.Now);
								A.InsertCommand.Parameters.AddWithValue("@mod",DateTime.Now);
								A.InsertCommand.Parameters.AddWithValue("@pid",countdb);
								A.InsertCommand.Parameters.AddWithValue("@Name",tpl.Name);
								A.InsertCommand.Parameters.AddWithValue("@DbType",tpl.DbType==DatabaseType.Unspecified?"":tpl.DbType.ToString());
								A.InsertCommand.Parameters.AddWithValue("@Description",tpl.Description);
								A.InsertCommand.Parameters.AddWithValue("@PrimaryKey",tpl.PrimaryKey);
								try {
									A.InsertCommand.ExecuteNonQuery();
									counttable++;
								}
								catch (Exception exc)
								{
									if (Helper.MessageBoxIsOK(exc.ToString(),"table")) return; ;
								}
								C.Close();
							}
							foreach (FieldElement fld in tpl.Fields)
							{
								query = ReplaceTableNames(sql_ins_gen_field);
								using (SQLiteDataAdapter A = new SQLiteDataAdapter(string.Empty,C))
								{
									C.Open();
									A.InsertCommand = new SQLiteCommand(query,C);
									#region Parameterization
									A.InsertCommand.Parameters.AddWithValue("@crd",DateTime.Now);
									A.InsertCommand.Parameters.AddWithValue("@mod",DateTime.Now);
									A.InsertCommand.Parameters.AddWithValue("@pid",counttable);
									A.InsertCommand.Parameters.AddWithValue("@BlockAction",fld.BlockAction);
									A.InsertCommand.Parameters.AddWithValue("@CodeBlock",fld.CodeBlock);
									A.InsertCommand.Parameters.AddWithValue("@DataName",fld.DataName);
									A.InsertCommand.Parameters.AddWithValue("@DataType",fld.DataType);
									A.InsertCommand.Parameters.AddWithValue("@DataTypeNative",fld.DataTypeNative);
									A.InsertCommand.Parameters.AddWithValue("@DefaultValue",fld.DefaultValue);
									A.InsertCommand.Parameters.AddWithValue("@Description",fld.Description);
									A.InsertCommand.Parameters.AddWithValue("@FormatString",fld.FormatString);
									A.InsertCommand.Parameters.AddWithValue("@FormType",fld.FormType);
									A.InsertCommand.Parameters.AddWithValue("@IsNullable",fld.IsNullable);
									A.InsertCommand.Parameters.AddWithValue("@MaxLength",fld.MaxLength);
									A.InsertCommand.Parameters.AddWithValue("@Tags",fld.Tags);
//									A.InsertCommand.Parameters.AddWithValue("@ToolTip",fld.ToolTip);
									A.InsertCommand.Parameters.AddWithValue("@UseFormat",fld.UseFormat);
									#endregion
//									A.InsertCommand.Parameters.AddWithValue("@DataName",fld.);
									try {
										A.InsertCommand.ExecuteNonQuery();
										countfield++;
									}
									catch (Exception exc)
									{
										if (Helper.MessageBoxIsOK(exc.ToString(),"gen-data-field")) return;
									}
									C.Close();
								}
							}
						}
					}
				}
			}
		}
		#endregion
		
		#region GeneratorDataCollectionCreate
		static public void GeneratorDataCollectionCreate()
		{
//			sfd.Filter = "xconfig|*.xconfig|xml|*.xml|all files|*";
//			if (!sfd.ShowDialog().Value) return;
			if (!Helper.DialogResultIsOK(sfd,"xconfig|*.xconfig|xml|*.xml|all files|*")) return;
			List<string> list = new List<string>();
			
			string fname = sfd.FileName;
			DatabaseCollection c = DatabaseCollection.Load(fname);
			int dbid = 1,tid=1;
			foreach (DatabaseElement elmDb in c.Databases)
			{
				using (SQLiteContext ct = new SQLiteContext())
				{
					
					foreach (TableElement elmT in elmDb.Items)
					{
						foreach (FieldElement elmF in elmT.Fields)
						{
							
						}
						tid++;
					}
				}
				dbid++;
			}
			
//			string output = string.Empty;
//			using (SQLiteContext c0 = new SQLiteContext())
//			{
//				c.Select("select * from sqlite_master");
//				using (DataView v = c.Data.GetDataView(0))
//				{
//					foreach (DataRowView row in v)
//					{
//						list.Add(string.Format("# {0}",row["name"]));
//						list.Add("");
//						list.Add(row["sql"].ToString());
//						list.Add("");
//					}
//				}
//			}
		}
		#endregion
		
		#region GeneratorDataCollectionDestroy
		/// <summary>
		/// replaces '$(db)', '$(table)' and '$(field)' with respect to parameter names.
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		static string ReplaceTableNames(string input)
		{
			return ReplaceTableNames(input,"gen-data-db","gen-data-table","gen-data-field");
		}
		/// <summary>
		/// replaces '$(db)', '$(table)' and '$(field)' with respect to parameter names.
		/// </summary>
		/// <param name="input">input query</param>
		/// <param name="db">replacement 1</param>
		/// <param name="table">replacement 2</param>
		/// <param name="field">replacement 3</param>
		/// <returns></returns>
		static string ReplaceTableNames(string input, string db, string table, string field)
		{
			return input
				.Replace("$(db)",db)
				.Replace("$(table)",table)
				.Replace("$(field)",field)
				;
		}
		
		/// <summary>
		/// This overload calls the overload forcing creation
		/// of new tables once the tables are dropped.
		/// </summary>
		static public void GeneratorDataCollectionDestroy()
		{
			GeneratorDataCollectionDestroy(true);
		}
		static public void GeneratorDataCollectionDestroy(bool andCreate)
		{
			GeneratorDataCollectionDestroy("gen-data-db","gen-data-table","gen-data-field",andCreate);
		}
		/// <summary>
		/// Drops all data from the database and creates a new table named
		/// gen-data-field, gen-data-table and gen-data-db.
		/// </summary>
		/// <param name="andCreate"></param>
		/// <remarks>This method does not check to see if the given tables exist.</remarks>
		static public void GeneratorDataCollectionDestroy(string sdb, string stable, string sfield, bool andCreate)
		{
			using (SQLiteDb db = new SQLiteDb(QueryDatabaseContext.sqlitedb))
			{
				using (SQLiteConnection C = db.Connection)
				{
					//query = "insert into [gen-data-db] ([Name],[PrimaryKey],[ConnectionType]) values(@Name,@PrimaryKey,@ConnectionType);";
					using (SQLiteDataAdapter A = new SQLiteDataAdapter(ReplaceTableNames(sql_drop_gen_db_tbl_fld,sdb,stable,sfield),C))
					{
						C.Open();
						
						try { A.SelectCommand.ExecuteNonQuery(); } catch {  }
						
						using (A.SelectCommand = new SQLiteCommand(ReplaceTableNames(sql_gen_db_tbl_fld,sdb,stable,sfield),C))
						{
							// a “not reccomended” using block(s) — ¡heeh
						}
						
						try { A.SelectCommand.ExecuteNonQuery(); } catch { }
						
						C.Close();
					}
				}
			}
		}
		#endregion
		
	}
}
