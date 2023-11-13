using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace BiliStart.WinUI3.UI.Converter;

public class SearchRankConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return value.ToString() == "0" ? Visibility.Collapsed : Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
