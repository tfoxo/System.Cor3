/* oio : 1/21/2014 9:33 AM */
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Generator.Core.Entities;

namespace GeneratorTool.Views
{
	
	public class VisibilityToBooleanConverter : IValueConverter
	{
//		public object Convert(object value)
//		{
//		}
		
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return (Visibility)value == Visibility.Visible;
//			throw new NotImplementedException();
		}
		
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}



