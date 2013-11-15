using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace Mu
{
	sealed class ZoomLevelToTextFormattingModeConverter : IValueConverter
	{
		public static readonly ZoomLevelToTextFormattingModeConverter Instance = new ZoomLevelToTextFormattingModeConverter();
		
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (((double)value) == 1.0)
				return TextFormattingMode.Display;
			else
				return TextFormattingMode.Ideal;
		}
		
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
