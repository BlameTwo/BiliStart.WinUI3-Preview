using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliStart.WinUI3.UI.Controls
{
    public class VolumeConverter : IValueConverter
    {
        double minValue = 0; // Slider 的最小值
        double maxValue = 100; // Slider 的最大值
        double convertedMinValue = 0.1;
        double convertedMaxValue = 1.0;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is double doubleValue)
            {
                double convertedValue =
                    convertedMinValue
                    + (convertedMaxValue - convertedMinValue)
                        * (doubleValue - minValue)
                        / (maxValue - minValue);
                return convertedValue;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is double doubleValue)
            {
                double convertedValue =
                    minValue
                    + (maxValue - minValue)
                        * (doubleValue - convertedMinValue)
                        / (convertedMaxValue - convertedMinValue);
                return convertedValue;
            }
            return value;
        }
    }
}
