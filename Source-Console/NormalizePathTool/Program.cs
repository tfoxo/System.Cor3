/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/16/2013
 * Time: 9:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Threading.Tasks;

namespace System.Tasks
{

	class Program
	{
		[STAThread] static public void Main(string[] args) {
			MoveToApp.App(args);
			Program.Main();
		}
	}
}