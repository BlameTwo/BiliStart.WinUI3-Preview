using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace BiliStart.WinUI3.UI.Converter;

public sealed class BoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool? && value != null)
        {
            var val = (bool?)value;
            return val.GetValueOrDefault();
        }
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is bool boolean)
        {
            return (bool?)boolean;
        }
        return null;
    }
}

public sealed class CountBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is int val && val > 0)
        {
            return true;
        }
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

public sealed class BoolToVisibiltyConverter : IValueConverter
{
    /// <summary>
    /// 是否反转
    /// </summary>
    public bool IsBack { get; set; }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool val && val && IsBack == false)
        {
            return Visibility.Visible;
        }
        else if (value is bool backval && backval && IsBack)
        {
            return Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is Visibility visibility && visibility == Visibility.Visible && IsBack == false)
            return true;
        else if (
            value is Visibility backvisibility
            && backvisibility == Visibility.Visible
            && IsBack == true
        )
            return false;
        else
            return false;
    }
}
