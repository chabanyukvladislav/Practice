using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace App1
{
    internal class UriToUrlInfoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            UrlInfo info = new UrlInfo { Arguments = new Dictionary<string, string>() };
            string url = value.ToString();
            int indexOfHttp = url.IndexOf("://", StringComparison.Ordinal);
            if (indexOfHttp == -1)
                return info;
            info.Protocol = url.Remove(indexOfHttp);
            url = url.Remove(0, indexOfHttp + 3);
            int indexOfAddress = url.IndexOf('?');
            if (indexOfAddress == -1)
            {
                info.Address = url;
                return info;
            }
            info.Address = url.Remove(indexOfAddress);
            List<string> arguments = new List<string>();
            arguments.AddRange(url.Remove(0, indexOfAddress + 1).Split('&'));
            foreach (string argument in arguments)
            {
                if(argument.IndexOf('=') == -1)
                    continue;
                string[] pair = argument.Split('=');
                info.Arguments.Add(pair[0], pair[1]);
            }
            return info;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}