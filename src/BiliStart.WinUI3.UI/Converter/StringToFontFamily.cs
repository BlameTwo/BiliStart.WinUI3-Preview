using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;

namespace BiliStart.WinUI3.UI.Converter;

public class StringToFontFamily : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is string val)
        {
            FontFamily fontFamily = new(val);
            return fontFamily;
        }
        return default;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is FontFamily font)
        {
            return font.Source;
        }
        return default;
    }
}
