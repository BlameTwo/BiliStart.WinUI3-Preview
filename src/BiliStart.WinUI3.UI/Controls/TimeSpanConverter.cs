using Microsoft.UI.Xaml.Data;
using System;

namespace BiliStart.WinUI3.UI.Controls;

public class TimeSpanToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is TimeSpan val)
        {
            return val.ToString(@"hh\:mm\:ss");
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

public class DoubleTimeSpanToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is double val)
        {
            try
            {
                return TimeSpan.FromSeconds(val).ToString(@"hh\:mm\:ss");
            }
            catch
            {
                return TimeSpan.FromMilliseconds(val).ToString(@"hh\:mm\:ss");
            }
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

public class BoolBackConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool val)
        {
            return !val;
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return Convert(value, targetType, parameter, language);
    }
}
