﻿#define LOCALVLC1
// delete the 1
#region Using
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Xml;

using GeneratorTool.Views;

#endregion
namespace GeneratorTool
{

	public class RectConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double width = (double)values[0];
			double height = (double)values[1];
			return new Rect(0, 0, width, height);
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
