/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 12/2/2013
 * Time: 4:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace FeedTool
{
	public class ImageHelper : DependencyObject
	{
		public static string GetSourcePath(DependencyObject obj) { return (string)obj.GetValue(SourcePathProperty); }
		public static void SetSourcePath(DependencyObject obj, string value) { obj.SetValue(SourcePathProperty, value); }
		
		public static readonly DependencyProperty SourcePathProperty = DependencyProperty.RegisterAttached(
			"SourcePath",
			typeof(string),
			typeof(ImageHelper),
			new PropertyMetadata
			{
				PropertyChangedCallback = (obj, e) => {
					var n = obj.GetType().Name;
					System.Diagnostics.Debug.WriteLine("ObjInfo: {0}", obj.GetType().Name);
					((Image)obj).Source = BitmapFrame.Create(new BitmapImage(new Uri("/images/appbar.home.png", UriKind.RelativeOrAbsolute)));
//					((Image)obj).Source = BitmapFrame.Create(new Uri(((IUriContext)obj).BaseUri, (string)e.NewValue));
				}
			});
		
	}
}
