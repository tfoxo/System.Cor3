/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 1/31/2013
 * Time: 12:24 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;

namespace XmlRssTest.ThreadingDemo
{
	public class CellProd
	{
	    Cell cell;         // Field to hold cell object to be used
	    int quantity = 1;  // Field for how many items to produce in cell
	
	    public CellProd(Cell box, int request)
	    {
	        cell = box;          // Pass in what cell object to be used
	        quantity = request;  // Pass in how many items to produce in cell
	    }
	    public void ThreadRun( )
	    {
	        for(int looper=1; looper<=quantity; looper++)
	            cell.WriteToCell(looper);  // "producing"
	    }
	}
}
