/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/16/2013
 * Time: 6:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace System.Tasks
{
	// http://stackoverflow.com/questions/1395205/better-way-to-check-if-path-is-a-file-or-a-directory-c-net
	public class NormalizePathOptions
	{
		public bool MatchCase {
			get { return matchCase; }
			set { matchCase = value; }
		} bool matchCase = true;
	}
	/// <summary>
	/// Description of NormalizePathTask.
	/// </summary>
	public class NormalizePathTask
	{
		static public readonly NormalizePathOptions DefaultOptions = new NormalizePathOptions{ MatchCase=true };
		
		public NormalizePathOptions Options {
			get { return options; }
			set { options = value; }
		} NormalizePathOptions options = DefaultOptions;
		
		string pathTarget;
		List<string> listTarget;
		
		string pathBase;
		List<string> listBase;
		
		string pathCommon;
		List<string> listCommon = new List<string>();
		
		string pathRemainderTarget;
		List<string> listRemainderTarget = new List<string>();
		
		string pathRemainderBase;
		List<string> listRemainderBase = new List<string>();
		
		int  IntCompare        = 0;
		bool IsEqualLength     = false;
		bool IsBaseLonger      = false;
		
		bool IsTargetRooted    = false;
		bool IsBaseRooted      = false;
		
		bool IsTargetFile      = false;
		bool IsTargetDir       = false;
		
		bool IsBaseFile        = false;
		bool IsBaseDir         = false;
		
		int Max = 0;
		int LastSimilarIndex = 0;
		
		// 1 for the file name or to leave the directory in tact.
		// 1 to normalize zero-inclusive index.
		// if one of the paths is a file, this number might be different.
		// is path file or directory, and how would we cater to either of them.
		const int added = 2;
		
		bool IsPathRooted(string path)
		{
			return path !=null && path.Length >= 2 && path[1]==':';
		}
		
		bool IsFilePath(string path)
		{
			if (File.Exists(path)) return true;
			if (Directory.Exists(path)) return false;
			return false;
		}
		bool IsDirectoryPath(string path)
		{
			if (File.Exists(path)) return false;
			if (Directory.Exists(path)) return true;
			return false;
		}
		
		/// <summary>
		/// both input paths must contain the root element such as 'c:'.
		/// <para>target path is the one that is returned only it is returned relating to/from the base-path.</para>
		/// <para>another way to look at this process is traveling from pathBase to pathTarget.</para>
		/// </summary>
		/// <param name="pathTarget">The path we're traveling to.</param>
		/// <param name="pathBase">The path we're starting out at.</param>
		public NormalizePathTask(string pathTarget, string pathBase)
		{
			this.pathTarget    = pathTarget.Replace("\\","/");
			this.pathBase      = pathBase.Replace("\\","/");
			this.listTarget    = new List<string>(this.pathTarget.Split('/'));
			this.listBase      = new List<string>(this.pathBase.Split('/'));
			
			IntCompare         = listTarget.Count - listBase.Count;
			IsEqualLength      = IntCompare == 0;
			IsBaseLonger       = IntCompare < 0;
			Max                = Math.Max(listTarget.Count, listBase.Count);
			
			IsTargetRooted     = IsPathRooted(this.pathTarget);
			IsTargetFile       = IsFilePath(this.pathTarget);
			IsTargetDir        = IsDirectoryPath(this.pathTarget);
			
			IsBaseRooted       = IsPathRooted(this.pathBase);
			IsBaseFile         = IsFilePath(this.pathBase);
			IsBaseDir          = IsDirectoryPath(this.pathBase);
			
			LastSimilarIndex   = 0;
			
			if (!(IsTargetRooted || IsBaseRooted))
			{
				Console.WriteLine("Both paths must begin with drive-letter + semi-colon. (EG: c:/)");
				Console.WriteLine("EG: 'c:/'");
				Console.WriteLine();
				Console.ReadKey(true);
				return;
			}
			
			for (int i = 0; i < Max; i++)
			{
				if (!IsBound(listTarget,i)) break;
				if (!IsBound(listBase,  i)) break;
				Console.WriteLine("[{0}] {1}", i, listTarget[i]);
				if (CompareSegment(listTarget,listBase,i)) LastSimilarIndex = i;
			}
			
			Console.WriteLine();
			Console.WriteLine("Similar Index    = {0}", LastSimilarIndex + added);
			Console.WriteLine("Target Length    = {0}", listTarget.Count);
			Console.WriteLine("Target is dir    = {0}", IsTargetFile);
			Console.WriteLine("Target is file   = {0}", IsTargetFile);
			Console.WriteLine("Base is file     = {0}", IsBaseFile);
			Console.WriteLine("Target Remainder = {0}", listTarget.Count-(LastSimilarIndex + added));
			Console.WriteLine();
			
			for (int i=0; i <= LastSimilarIndex; i++) listCommon.Add(listTarget[i]);
			if (LastSimilarIndex > listTarget.Count) return;
			for (int i=LastSimilarIndex+1; i < listTarget.Count; i++) listRemainderTarget.Add(listTarget[i]);
			for (int i=LastSimilarIndex+1; i < listBase.Count; i++) listRemainderBase.Add(listBase[i]);
			
			Console.WriteLine("target:\n{0}\n",this.pathTarget);
			Console.WriteLine("ref:\n{0}\n",this.pathBase);
			
			pathCommon = string.Join("/",listCommon.ToArray());
			Console.WriteLine("Similar:");
			Console.WriteLine(pathCommon);
			Console.WriteLine();
			
			pathRemainderTarget = string.Join("/",listRemainderTarget.ToArray());
			Console.WriteLine("Remains-target:");
			Console.WriteLine(pathRemainderTarget);
			Console.WriteLine();
			
			pathRemainderBase = string.Join("/",listRemainderBase.ToArray());
			Console.WriteLine("Remains-base:");
			Console.WriteLine(pathRemainderBase);
			Console.WriteLine();
		}
		bool IsBound(IList<string> a, int l) { return l < a.Count; }
		/// <summary>
		/// only compares against string values contained.
		/// if you send in an index point not contained in the array, results in error.
		/// </summary>
		/// <param name="a">array a</param>
		/// <param name="b">array b</param>
		/// <param name="i">array index position</param>
		/// <returns></returns>
		bool CompareSegment(IList<string> a, IList<string> b, int i)
		{
			if (Options.MatchCase && a[i]==b[i]) { return true; }
			else if (a[i].ToLower()==b[i].ToLower()) { return true; }
			
			return false;
		}
	}
}
