using Lib.Helper;
using Microsoft.UI.Xaml.Data;
using System;
using ViewConverter.Models;

namespace BiliStart.WinUI3.UI.Converter;

public class RichTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is ReplyContent content && parameter is string paramt)
        {
            return BiliRichBoxHelper.GetViewReplyMessage(content, int.Parse(paramt));
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
