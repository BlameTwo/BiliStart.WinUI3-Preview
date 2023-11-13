using Microsoft.UI.Xaml.Data;
using System;

namespace BiliStart.WinUI3.UI.Converter;

public class DurationConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is long val)
        {
            var time = TimeSpan.FromSeconds(val);
            return $"{time.Hours}:{time.Minutes}:{time.Seconds}";
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

public class MissDurationConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is long val)
        {
            var time = TimeSpan.FromMilliseconds(val);
            return $"{time.Hours}:{time.Minutes}:{time.Seconds}";
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
