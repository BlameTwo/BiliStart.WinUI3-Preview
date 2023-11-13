using Microsoft.UI.Xaml.Data;
using System;

namespace BiliStart.WinUI3.UI.Converter;

public class IntToBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is int val && val == 1)
            return true;
        else
            return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
