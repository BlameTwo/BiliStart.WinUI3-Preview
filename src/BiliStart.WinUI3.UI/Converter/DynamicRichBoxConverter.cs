using Bilibili.App.Dynamic.V2;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;

namespace BiliStart.WinUI3.UI.Converter;

public class DynamicRichBoxConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value == null) return null;
        if(value is IEnumerable<Description> descriptions)
        {
            return Lib.Helper.DynamicRichBoxHelper.GetDescRichTextBlock(descriptions);
        }
        return new TextBlock() { Text = "转换错误" };
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

public class DynamicAuthorForwardRichBoxConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value == null) return null;
        if (value is IEnumerable<ModuleAuthorForwardTitle> descriptions)
        {
            return Lib.Helper.DynamicRichBoxHelper.GetAuthorForwardRichTextBlock(descriptions);
        }
        return new TextBlock() { Text = "转换错误" };
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
