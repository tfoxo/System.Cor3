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
	/// <summary>
	/// <para>
	/// Lets get some image based on a particular input.
	/// </para>
	/// <para>In this case we're dealing with FeedNode which can be of various types.</para>
	/// Taken from Ray Burns stack-overflow response:
	/// <para>http://stackoverflow.com/questions/3140404/xaml-image-source-set-dynamically-based-on-content</para>
	/// </summary>
	public class ImageSourceLoader : IValueConverter
	{
		public static ImageSourceLoader Instance = new ImageSourceLoader();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
//			RssNode itm;
			System.Diagnostics.Debug.WriteLine("== Image Info ==", value.GetType().Name);
			System.Diagnostics.Debug.WriteLine("Item Type = {0}", value.GetType().Name);
			System.Diagnostics.Debug.WriteLine("Para Type = {0}", parameter.GetType().Name);
			//\Images\{0}.png
//			var path = string.Format((string)parameter, value.ToString());
//			var path = string.Format("/images/appbar.sort.png", value.ToString());
			return BitmapFrame.Create(new Uri("/images/appbar.sort.png", UriKind.Absolute));
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

}
