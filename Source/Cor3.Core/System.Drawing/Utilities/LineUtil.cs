using System;

namespace System.Drawing.Utilities
{
	public class LineUtil
	{
		public double Length(FloatPoint p1)
		{
			return Math.Sqrt(Math.Pow(p1.X,2)+Math.Pow(p1.Y,2));
		}
	}
}
