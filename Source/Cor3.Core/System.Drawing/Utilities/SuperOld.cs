using System;

namespace System.Drawing.Utilities.SuperOld
{
	[Flags] public enum secType { Gallery = 0, GallerySection = 1 }
	[Flags] public enum scaleFlags { autoScale = 0, sWidth = 1, sHeight = 2 }
	public enum SizeFlags { originalSize = 0, scaledSize = 1, scaledBoxed = 2 }
	public enum Format { jpg = 1, png = 0, }

	[Flags] public enum Listeners { None=0,Packets, Stroke, MouseEvent, Paint, Resize,Mouse,Position,Stack }
	public enum PosEnum { AutoCenter,Top,TopRight,Right,BottomRight,Bottom,BottomLeft,Left,TopLeft }
	public enum MouseInfo : sbyte { Down=1, Up= -1, Move=0 }
}
