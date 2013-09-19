/* oOo * 11/28/2007 : 5:29 PM */
using System;
using System.Collections.Generic;

namespace System.Drawing
{
	public class SplinePointD : List<DPoint>
	{
		public DPoint[] VectorData { get { return ToArray(); } }
		public SplinePointD() : base() { }
		public SplinePointD(params VPointD[] value) : base(value) { }
	}
	public class SplinePointF : List<FloatPoint>
	{
		public PointF[] ToPointFArray()
		{
			List<PointF> points = new List<PointF>();
			foreach (PointF fp in this) points.Add(fp);
			PointF[] pf = points.ToArray();
			points.Clear();
			return pf;
		}

		public void TranslateTransform(FloatPoint offset)
		{
			for (int i=0; i < Count; i++)
			{
				this[i] += offset;
			}
		}
		public void ScaleTransform(FloatPoint offset)
		{
			for (int i=0; i < Count; i++)
			{
				this[i] *= offset;
			}
		}

		public PointF[] PointFData { get { return ToPointFArray(); } }
		public FloatPoint[] VectorData { get { return ToArray(); } }
		public SplinePointF() : base() { }
		public SplinePointF(params FloatPoint[] value) : base(value) { }
	}
}
