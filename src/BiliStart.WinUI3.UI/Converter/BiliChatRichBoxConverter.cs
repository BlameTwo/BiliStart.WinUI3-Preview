using Lib.Helper;
using Microsoft.UI.Xaml.Data;
using System;
using ViewConverter.Models.BiliChat;

namespace BiliStart.WinUI3.UI.Converter;

public class BiliContentChatRichBoxConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if(value is BiliChatBubbleModel bubble && parameter is string par && par == "Content")
        {
            return BiliChatRichBoxHelper.FormatContent(bubble);
        }
        return "空的内容 (❁´◡`❁)";
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

public class BiliUsingListChatRichBoxConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is BiliChatBubbleModel bubble && parameter is string par && par == "Content")
        {
            return BiliChatRichBoxHelper.FormatUsingList(bubble);
        }
        return "空的内容引用内容（￣︶￣）↗　";
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
