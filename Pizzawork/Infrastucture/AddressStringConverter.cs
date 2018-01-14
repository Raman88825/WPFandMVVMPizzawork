using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Geocoding;

namespace Pizzawork.Infrastructure
{
    public class AddressStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<Address> addresses)
            {
                IEnumerable<string> result = new List<string>();
                foreach (Address address in addresses)
                {
                    ((List<string>)result).Add($"{address.FormattedAddress}");
                }
                return result;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

