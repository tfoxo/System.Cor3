/*
 * oIo — 1/16/2011 — 8:29 PM
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace System.Cor3.Drawing
{
	// Line Generalization Algorithms
	/// <summary>
	/// • Nothing to say
	/// </summary>
	public class McMaster // Smoothing
	{
		/// <summary>
		/// Line Generalization Algorighm: McMaster
		/// <para>1) Average the number of ‘ahead’ points to P1' (note that the average used is 5)</para>
		/// <para>2) Get a line for P1 to S1 (which is the middle point or the third point)</para>
		/// <para>2.1) P1 slides to the center of the new Line</para>
		/// --- This is our new Smoothed point ‘S1’ : s1 is the shifted position of P(i)
		/// </summary>
		/// <param name="pts">the number of points to average</param>
		/// <returns></returns>
		static public FloatPoint[] McMasterX(params FloatPoint[] pts)
		{
			// Averate the number of look-ahead points
			if (pts.Length <= 4) return pts;
			FloatPoint[] n5 = new FloatPoint[5];
			List<FloatPoint> S = new List<FloatPoint>();
			S.Add(pts[0]);
			for (int x = 0; x < pts.Length-5; x++)
			{
				n5 = Next(x,5,pts);
				FloatPoint avg = FloatPoint.Average(n5);
				FloatPoint SW = avg+(avg-pts[x+3])*0.5D;
				S.Add(SW);
			}
			S.Add(pts[pts.Length-1]);
			Array.Clear(n5,0,5);
			FloatPoint[] XS = S.ToArray();
			S.Clear(); S=null;
			return XS;
			
		}
		/// • Nothing to say
		static public FloatPoint[] McMasterH(params FloatPoint[] pts)
		{
			// Averate the number of look-ahead points
			if (pts.Length <= 4) return pts;
			FloatPoint[] n5 = new FloatPoint[5];
			List<FloatPoint> S = new List<FloatPoint>();
			for (int x = 0; x < pts.Length-5; x++)
			{
				n5 = Next(x,5,pts);
				FloatPoint avg = (PointF)FloatPoint.Average(n5);
				FloatPoint SW = avg+(avg-pts[x+3])*0.5D;
				S.Add((PointF)SW);
			}
			Array.Clear(n5,0,5);
			FloatPoint[] XS = S.ToArray();
			S.Clear(); S=null;
			return XS;
		}
		/// <summary>Do your checking before calling on me</summary>
		static public FloatPoint[] Next(long start, long len, params FloatPoint[] Pts)
		{
			FloatPoint[] tp = new FloatPoint[5];
			Array.Copy(Pts,start,tp,0,len);
			return tp;
		}
		/// 
		static public double Avg(params double[] points)
		{
			double temp = 0;
			foreach (double point in points) temp += point;
			return temp / points.Length;
		}
		
	}
}
