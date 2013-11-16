/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/16/2013
 * Time: 9:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Tasks;

namespace NormalizePathTool
{
	class Program
	{
		public static void Main(string[] args)
		{
            if (args.Length != 2)
            {
            	Console.WriteLine("Nothing to do");
            	Console.ReadKey(true);
            	return;
            }
            
            NormalizePathTask task = new NormalizePathTask(args[0],args[1]);
            	Console.ReadKey(true);
            	return;
		}
	}
}