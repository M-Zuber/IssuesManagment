using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace IssuesManagment.UI.POC.Utils
{
    public class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                var stringRep = (string)value;

                if (!stringRep.StartsWith("#"))
                {
                    stringRep = "#" + stringRep;
                }
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(stringRep));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
