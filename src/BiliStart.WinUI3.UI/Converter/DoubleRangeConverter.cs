using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliStart.WinUI3.UI.Converter
{
    public class DoubleRangeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is double originalValue)
            {
                double originalMin = 0.0;
                double originalMax = 10.0;
                double newMin = 0.0;
                double newMax = 5.0;

                double normalizedValue =
                    (originalValue - originalMin) / (originalMax - originalMin);
                double convertedValue = (normalizedValue * (newMax - newMin)) + newMin;

                return convertedValue;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
