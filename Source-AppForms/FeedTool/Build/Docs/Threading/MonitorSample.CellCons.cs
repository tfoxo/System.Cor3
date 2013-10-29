/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 1/31/2013
 * Time: 12:24 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
namespace XmlRssTest.ThreadingDemo
{
	public class CellCons
	{
	    Cell cell;         // Field to hold cell object to be used
	    int quantity = 1;  // Field for how many items to consume from cell
		
	    public CellCons(Cell box, int request)
	    {
	        cell = box;          // Pass in what cell object to be used
	        quantity = request;  // Pass in how many items to consume from cell
	    }
	    public void ThreadRun( )
	    {
	        int valReturned;
	        for(int looper=1; looper<=quantity; looper++)
	            // Consume the result by placing it in valReturned.
	            valReturned=cell.ReadFromCell( );
	    }
	}
}
