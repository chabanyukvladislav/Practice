using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp1
{
    public class CollectionToCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<string, string> dictionary = (Dictionary<string, string>)value;
            return dictionary?.Count ?? 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}