#region Using
/* User: oio * Date: 9/18/2013 * Time: 12:54 AM */
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;
#endregion
#region AssemblyProperties
//using System.Reflection;
//using System.Runtime.InteropServices;
//
//[assembly: AssemblyTitle("xrename")]
//[assembly: AssemblyProduct("xrename")]
//[assembly: ComVisible(false)]
//[assembly: AssemblyVersion("1.0.*")]
#endregion AssemblyProperties

// 
namespace xrename
{
	//    public interface ILesserAction {
	//    	void Run();
//	}
	
	/// <summary>
	/// <para>A batch tool for renaming multiple files to a format such as "file000.ext"</para>
	/// </summary>
	class Rename : Commander /*, ILesserAction*/
	{
		#region Node
		
		class Node
		{
			public FileInfo OldFile;
			/// <summary>
			/// the new name identity of the file.
			/// </summary>
			public string Name;
			public string NameExt { get { return string.Concat(Name,OldFile.Extension); } }
			public string NameFull { get { return OldFile.FullName.Replace(OldFile.Name,NameExt); } }
			public bool HasMatch = false;
		}
		
		#endregion
		
		#region Settings
		class Setting
		{
			/// <summary>
			/// default state is un-initialized.
			/// </summary>
			public List<string> Items {
				get { return items; }
				set { items = value; }
			} List<string> items;
			
			// OPTIONS
			// ================================================================
			/// <summary>
			/// default = 'false'
			/// </summary>
			public bool Recursive {
				get { return recursive; }
				set { recursive = value; }
			} bool recursive = false;
			/// <summary>
			/// default = 'false'
			/// </summary>
			public bool Reverse {
				get { return reverse; }
				set { reverse = value; }
			} bool reverse = false;
			/// <summary>
			/// default = 'false'
			/// </summary>
			public bool OnlyUseMatches {
				get { return onlyUseMatches; }
				set { onlyUseMatches = value; }
			} bool onlyUseMatches = false;
			/// <summary>
			/// default = 'false'
			/// </summary>
			public bool SortPost {
				get { return sortPost; }
				set { sortPost = value; }
			} bool sortPost = false;
			public bool SortPre {
				get { return sortPre; }
				set { sortPre = value; }
			} bool sortPre = false;
			/// <summary>
			/// default = 'null'
			/// </summary>
			public string Expression {
				get { return expression; }
				set { expression = value; }
			} string expression = null;
			/// <summary>
			/// default = 'rename-temp'
			/// </summary>
			public string OutputDir {
				get { return outputDir; }
				set { outputDir = value; }
			} string outputDir = "rename-temp";
			/// <summary>
			/// default = 'null'
			/// </summary>
			public string ExpressionReplace {
				get { return expressionReplace; }
				set { expressionReplace = value; }
			} string expressionReplace = null;
			
			#region Automate
			
			const RegexOptions DefaultRegexOptions = RegexOptions.Singleline|RegexOptions.Compiled;
			/// <summary>
			/// 
			/// </summary>
			public Regex RegularExpression { get { return new Regex(Expression,DefaultRegexOptions); } }
			
			bool IsMatch(string input) { return string.IsNullOrEmpty(Expression) ? false : RegularExpression.IsMatch(input); }
			
			#endregion
		}
		Setting Settings { get; set; }
		
		#endregion
		
		
		// -sort -r -i "c:\blah\blah\blah\" -x "a-title-([0-9.-]*)" -xr "SortIndex=$1"
		// -spr -i "c:\blah\blah\blah\" -x "a-title-([0-9.-]*)" -xr "a-title-{0:000}" -o "newer"
		
		virtual public void Run()
		{
			// initialize some stuff
			DirectoryInfo dir;
			Setting settings = new Setting();
			List<Node> list = new List<Node>();
			
			#region Set Variables from Input
			
			string arg = null;
			int index = -1;
			
			// input directories
			List<string> InputDirectories = null;
			InputDirectories = GetValuesForArgument("-i");
			// input expression
			settings.Expression = GetValue(true,"-x");
			Console.WriteLine("expression     : {0}",settings.Expression);
			// replacement expression
			settings.ExpressionReplace = GetValue(true, "-xr");
			settings.OutputDir = GetValue(true, "-o");
			// pre sorting?
			settings.SortPre = HasValue("-spr"); GetValue(false,"-spr");
			Console.WriteLine("sort-pre       : {0}",settings.SortPre);
			// post sorting?
			settings.SortPost = HasValue("-spo"); GetValue(false,"-spo");
			
			Console.WriteLine("sort-post      : {0}",settings.SortPost);
			// order 'asc' | 'desc'
			settings.Reverse = HasValue("-r"); GetValue(false,"-r");
			Console.WriteLine("reverse        : {0}",settings.Reverse);
			
			#endregion
			
			// Throw Exception (write to StdError)
			if (InputDirectories==null) return;
			if (InputDirectories.Count==0) return;
			
			foreach (var d in InputDirectories)
			{
				dir = new DirectoryInfo(d);
				if (!dir.Exists) {
					Console.Error.WriteLine("Directory \"{0}\" does not exist.",dir.FullName);
					continue;
				}
				Console.WriteLine("directory-name : {0}",dir.Name);
				Console.WriteLine("directory-path : {0}",dir.Parent.FullName);
				Console.WriteLine("------------------------------------------------------------");
				
				if (InputDirectories.Count > 0)
				{
					
					foreach (FileInfo f in dir.GetFiles())
					{
						Node node = new Node(){ OldFile=f, Name=Path.GetFileNameWithoutExtension(f.Name) };
						if (string.IsNullOrEmpty(settings.Expression) && !settings.OnlyUseMatches) {
							list.Add(node);
						}
						else if (settings.RegularExpression.IsMatch(f.Name))
						{
							node.HasMatch = true;
							if (!string.IsNullOrEmpty(settings.ExpressionReplace))
								node.Name=settings.RegularExpression.Replace(node.Name,settings.ExpressionReplace);
							else if (!settings.OnlyUseMatches) {
								node.Name = f.Name;
							}
						}
						list.Add(node);
					}
					
					// the rest of the code following the '} ... }' could go in here to be able to handle more than
					// one input directory.
					
					if (settings.SortPre) list.Sort(delegate(Node a, Node b){ return a.OldFile.Name.CompareTo(b.OldFile.Name); });
					if (settings.SortPost) list.Sort(delegate(Node a, Node b){ return a.OldFile.Name.CompareTo(b.NameExt); });
					if (settings.Reverse) list.Reverse();
					
					if (list.Count > 0) {
						
						DirectoryInfo newout = new DirectoryInfo(Settings.OutputDir);
						
						string temp = list[0].OldFile.Directory.Parent.FullName;
						
						if (settings.OutputDir[1]==':') newout = new DirectoryInfo(settings.OutputDir);
						else newout = new DirectoryInfo(Path.Combine(temp,settings.OutputDir));
						
						if (!newout.Exists) newout.Create();
						
						Console.WriteLine(newout.FullName);
						
						int i=0;
						foreach (Node s in list)
						{
							s.OldFile.CopyTo(Path.Combine(newout.FullName,string.Format(s.NameExt,i)),true);
							Console.WriteLine("Old: {0,-9}, New: {1,-9}",s.OldFile.Name,string.Format(s.NameExt,i++));
						}
						list.Clear();
					}
				}
			}
			
			Console.ReadKey();
		}
		
	}
	class Program
	{
//		public FileInfo AppExecutable { get { return new FileInfo(Assembly.GetExecutingAssembly().Location); } }
//		public FileInfo AppCaller { get { return new FileInfo(Assembly.GetCallingAssembly().Location); } }
//		public FileInfo AppEntry { get { return new FileInfo(Assembly.GetEntryAssembly().Location); } }
		
		// Environment.CurrentDirectory
		
		// things that are needed:
		// (1) only rename matched regular expressions.
		//     only regex flag
		// (2) cbz/cbr compression configuration
		//     look in windows registry
		//     look for uninstall
		//     look in environment
		// (2A) CBZ/R Creation From Directory as input COMMAND STRING
		// (2B) Execute the command
//		[STAThread]
//		public static void Main(string[] args)
//		{
//			Rename r = new Rename(){ Args=new List<string>(args) };
//			
//			r.Run();
//		}
	}
}