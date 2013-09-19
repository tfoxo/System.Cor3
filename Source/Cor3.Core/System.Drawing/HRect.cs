/* oOo * 11/28/2007 : 5:29 PM */
/* THIS CALSS HAS NOT YET FULLY BEEN TESTED */
using System;

namespace System.Drawing
{
	#region “ Depreceated HRect ”
	public class HRect : FloatRect {
        ////////////////////////////////////////////////////////////////////////
        //	
		static public implicit operator Rectangle(HRect a){ return new Rectangle((int)a.X,(int)a.Y,(int)a.Width,(int)a.Height); }
		static public implicit operator RectangleF(HRect a){ return new RectangleF(a.X,a.Y,a.Width,a.Height); }
		static public implicit operator HRect(Rectangle a){ return new HRect(a.X,a.Y,a.Right,a.Bottom); }
		static public implicit operator HRect(RectangleF a){ return new HRect(a.X,a.Y,a.Right,a.Bottom); }
       public HRect() :base() {}
		public HRect(float x, float y, float width, float height) : base(x,y,width,height) { Location = new FloatPoint(x,y); Size = new FloatPoint(width,height); }
		public HRect(int x, int y, int width, int height) : this((float)x,(float)y,(float)width,(float)height) {}
		public HRect(FloatPoint L, FloatPoint S) : this(L.X,L.Y,S.X,S.Y) {}
		public HRect(Rectangle R) : this(R.X,R.Y,R.Width,R.Height) { }
		public HRect(RectangleF R) : this(R.X,R.Y,R.Width,R.Height) { }
		public HRect(PointF Loc, SizeF Siz) : this(Loc.X,Loc.Y,Siz.Width,Siz.Height) {}
		
	}
	#endregion

}
