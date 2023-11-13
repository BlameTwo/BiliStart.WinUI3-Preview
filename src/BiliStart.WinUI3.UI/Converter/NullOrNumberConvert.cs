using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;

namespace BiliStart.WinUI3.UI.Converter;

public class NullOrNumberConvert : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value == null)
        {
            return new SolidColorBrush(Colors.Gray);
        }
        else if (value is int val && val == 0)
        {
            return new SolidColorBrush(Colors.Gray);
        }
        else
        {
            return new SolidColorBrush(Colors.DeepPink);
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

public class BooleanToVisibiltyConvert : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool val)
        {
            if (val)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
