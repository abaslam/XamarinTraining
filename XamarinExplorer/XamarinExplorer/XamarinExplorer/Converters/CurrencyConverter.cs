using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace XamarinExplorer.Converters
{
    public class CurrencyConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				return ((decimal)value).ToString("C");
			}

			return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				var valueFromString = Regex.Replace(value.ToString(), @"\D", string.Empty);

				if (valueFromString.Length <= 0)
				{
					return 0m;
				}

				if (!long.TryParse(valueFromString, out var valueLong))
				{
					return 0m;
				}

				if (valueLong <= 0)
				{
					return 0m;
				}

				return valueLong / 100m;
			}

			return 0m;
		}
	}
}
