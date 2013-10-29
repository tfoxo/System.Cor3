﻿/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace System
{
	static class AnimateFormExtension
	{
		static public void Animate(this Form form, Point location, int speed, AnimationType flags)
		{
			form.Location = location;
			form.Animate(speed,flags);
		}
		static public void Animate(this Form form, int speed, AnimationType flags)
		{
			WindowsInterop.AnimateWindow(
				form.Handle,
				speed,
				flags
			);
		}
	}
	public enum AnimationType : uint
	{
		/// <summary>
		/// Activates the window. Do not use this value with AW_HIDE.
		/// </summary>
		AW_ACTIVATE = 0x00020000,
		/// <summary>
		/// Uses a fade effect. This flag can be used only if hwnd is a top-level window.
		/// </summary>
		AW_BLEND = 0x00080000,
		/// <summary>
		/// Makes the window appear to collapse inward if AW_HIDE is used or expand outward if the AW_HIDE is not used. The various direction flags have no effect.
		/// </summary>
		AW_CENTER = 0x00000010,
		/// <summary>
		/// Hides the window. By default, the window is shown.
		/// </summary>
		AW_HIDE = 0x00010000,
		/// <summary>
		/// Animates the window from left to right. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
		/// </summary>
		AW_HOR_POSITIVE = 0x00000001,
		/// <summary>
		/// Animates the window from right to left. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
		/// </summary>
		AW_HOR_NEGATIVE = 0x00000002,
		/// <summary>
		/// Uses slide animation. By default, roll animation is used. This flag is ignored when used with AW_CENTER.
		/// </summary>
		AW_SLIDE = 0x00040000,
		/// <summary>
		/// Animates the window from top to bottom. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
		/// </summary>
		AW_VER_POSITIVE = 0x00000004,
		/// <summary>
		/// Animates the window from bottom to top. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
		/// </summary>
		AW_VER_NEGATIVE = 0x00000008,
	}
	partial class WindowsInterop
	{
		// introduced to me by my google result:
		// http://www.c-sharpcorner.com/uploadfile/kirtan007/sliding-effect-in-windows-form-application/
//		public class AnimateWindow32
//		{
		[DllImport("user32")]
		static public extern bool AnimateWindow(IntPtr hwnd, int time, AnimationType flags);
		
//		}
	}
}
