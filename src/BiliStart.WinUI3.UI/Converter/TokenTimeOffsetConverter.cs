using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Network.Models.Accounts;
using System;

namespace BiliStart.WinUI3.UI.Converter;

public class TokenTimeOffsetConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        bool flage = false;
        if (value is AccountToken token)
        {
            string offsetstr = token.LastTokenSaveTime.ToString();
            var lastoffset = DateTimeOffset.Parse(offsetstr);
            //检查token是否可用
            flage = (DateTimeOffset.Now - lastoffset).TotalSeconds < token.Expires_in;
        }
        if (parameter.ToString() == "0" && value != null) //0表示是否是通过
        {
            if (flage)
                return "有效";
            else
                return "失效";
        }
        else if (parameter.ToString() == "1") //1表示颜色
        {
            if (flage)
                return Colors.Green;
            else
                return Colors.Red;
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
