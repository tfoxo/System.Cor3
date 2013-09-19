/* User: oIo * Date: 9/21/2010 * Time: 10:22 AM */
using System;
using System.ComponentModel;

namespace System.Drawing
{
	public class CORNERS
	{
		float[] cornerpoints;
		public float[] Cornerpoints { get { return cornerpoints; } set { cornerpoints = value; } }
		public enum EDGE { TopLeft, TopRight, BottomRight, BottomLeft }
	
		
		#region all
		bool HasIdenticalValues
		{
			get
			{
				int i = 1;
				float lastvalue = cornerpoints[0];
				while (i++ < cornerpoints.Length)
				{
					if (lastvalue.CompareTo(cornerpoints[i])!=0) return false;
					lastvalue = cornerpoints[i];
				}
				return true;
			}
		}
		[DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
		public float All { get { return HasIdenticalValues? TopLeft: -1f; } set { if (value== -1f) return; cornerpoints = new float[]{value,value,value,value}; } }
		#endregion
		public float this[EDGE Key]
		{
			get
			{
				switch (Key)
				{
						case EDGE.TopLeft: return TopLeft;
						case EDGE.TopRight: return TopRight;
						case EDGE.BottomLeft: return BottomLeft;
						case EDGE.BottomRight: return BottomRight;
						default : throw new ArgumentException();
				}
			}
		}
		public float this[int Index] { get { return this.cornerpoints[Index]; } set { this.cornerpoints[Index]=value; } }
		
		#region The Corners
		public float TopLeft { get { return cornerpoints[0]; } set { cornerpoints[0] = value; } }
		public float TopRight { get { return cornerpoints[1]; } set { cornerpoints[1] = value; } }
		public float BottomRight { get { return cornerpoints[2]; } set { cornerpoints[2] = value; } }
		public float BottomLeft { get { return cornerpoints[3]; } set { cornerpoints[3] = value; } }
		#endregion
	
		public CORNERS(float all) : this(all,all,all,all)
		{
		}
		public CORNERS(float tl, float tr, float br, float bl)
		{
			cornerpoints = new float[4]{tl,tr,br,bl};
		}
	}
}
