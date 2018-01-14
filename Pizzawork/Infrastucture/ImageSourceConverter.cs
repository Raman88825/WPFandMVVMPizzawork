using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Pizzawork.Infrastructure
{
    public class ImageSourceConverter : IValueConverter
    {
        string imageDirectory = Directory.GetCurrentDirectory();
        string ImageDirectory
        {
            get
            {
                return Path.Combine(imageDirectory, "images");
            }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            return Path.Combine(ImageDirectory, (string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
