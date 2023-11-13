using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Markup;
using System.Text.RegularExpressions;
using ViewConverter.Models;
using Windows.Devices.Power;

namespace Lib.Helper;

public static class BiliRichBoxHelper
{
    internal static readonly string EmojiRegex = @"\[(.*?)\]";

    internal static readonly string LinkRegex =
        @"(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]";

    /// <summary>
    /// 流文档RichTextBlock
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static RichTextBlock GetViewReplyMessage(ReplyContent values, int Maxline = 0)
    {
        string message = values.Message
            .Replace("&", "&amp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\r\n", "<LineBreak/>")
            .Replace("\n", "<LineBreak/>");
        //创建一个页对象
        MatchCollection linkmatches = Regex.Matches(message, LinkRegex);
        foreach (Match item in linkmatches)
        {
            string link = string.Format(
                "<InlineUIContainer><HyperlinkButton Margin=\"0 -4 4 -4\" Padding=\"1\" FontSize=\"13\" ToolTipService.ToolTip=\"在浏览器中打开\" Content=\"{0}\" NavigateUri=\"{1}\" /></InlineUIContainer>",
                "链接",
                item.Value
            );
            message = message.Replace(item.Value, link);
        }
        foreach (var item in values.EmoteItems)
        {
            MatchCollection matches = Regex.Matches(message, EmojiRegex);
            foreach (Match match in matches)
            {
                var emoji = string.Format(
                    @"<InlineUIContainer><Border  Margin=""0 -4 4 -4""><Image Source=""{0}"" Width=""{1}"" Height=""{1}"" /></Border></InlineUIContainer>",
                    item.Url,
                    item.Size == 1 ? "20" : "36"
                );
                message = message.Replace(item.Name, emoji);
            }
        }
        foreach (var item in values.AltUp)
        {
            string link = string.Format(
                "<InlineUIContainer><HyperlinkButton Margin=\"0 -4 4 -4\" Padding=\"1\" FontSize=\"13\" ToolTipService.ToolTip=\"在浏览器中打开\" Content=\"{0}\" NavigateUri=\"{1}\" /></InlineUIContainer>",
                item.Item1,
                $"https://space.bilibili.com/{item.Item2.Mid}"
            );
            message = message.Replace("@" + item.Item1, link);
        }
        return FormatToRichTextBlock(message, Maxline);
    }

    /// <summary>
    /// 初始化一个RichTextBlock流文本块
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    internal static RichTextBlock FormatToRichTextBlock(string text, int maxline)
    {
        var xaml = string.Format(
            @"<RichTextBlock HorizontalAlignment=""Stretch"" 
                                            xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                            xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" 
                                            xmlns:d=""http://schemas.microsoft.com/expression/blend/2008""
                                            xmlns:mc = ""http://schemas.openxmlformats.org/markup-compatibility/2006"" LineHeight=""20"">
                                          <Paragraph>{0}</Paragraph>
                                      </RichTextBlock>",
            text
        );
        var p = (RichTextBlock)XamlReader.Load(xaml);
        p.TextWrapping = TextWrapping.Wrap;
        if (maxline > 0)
            p.MaxLines = maxline;
        p.TextTrimming = TextTrimming.CharacterEllipsis;
        return p;
    }
}
