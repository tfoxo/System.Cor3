/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/16/2013
 * Time: 9:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading.Tasks;

namespace System.Tasks
{
	class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length != 2)
			{
				Console.WriteLine("Nothing to do");
				return;
			}
			NormalizePathTool task = new NormalizePathTool(args[0],args[1],new NormalizePathOptions { IsConsoleEnabled=true, UseFullPathWhenShorter=true });
			task.Run();
			task = null;
			return;
		}
	}
}