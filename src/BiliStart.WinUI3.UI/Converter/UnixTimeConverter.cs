using Lib.Helper;
using Microsoft.UI.Xaml.Data;
using System;

namespace BiliStart.WinUI3.UI.Converter;

public class UnixTimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return TickSpanHelper.UnixConvertToDateTime(value).ToString(parameter.ToString());
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
