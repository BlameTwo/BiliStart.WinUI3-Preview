using Bilibili.App.Dynamic.V2;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using Windows.UI.Text;

namespace Lib.Helper;

public static class DynamicRichBoxHelper
{
    public static RichTextBlock GetAuthorForwardRichTextBlock(IEnumerable<ModuleAuthorForwardTitle> values)
    {
        RichTextBlock textBlock = new();
        Microsoft.UI.Xaml.Documents.Paragraph paragraph = new Microsoft.UI.Xaml.Documents.Paragraph();
        foreach (var item in values)
        {
            var link = new Hyperlink() { NavigateUri = new(item.Url) };
            link.Inlines.Add(new Run() {Text = item.Text, FontWeight = Microsoft.UI.Text.FontWeights.Bold });
            paragraph.Inlines.Add(link);
        }
        textBlock.Blocks.Add(paragraph);
        return textBlock;
    }

    /// <summary>
    /// 获得说明性文本的TextBlock
    /// </summary>
    /// <returns></returns>
    public static RichTextBlock GetDescRichTextBlock(IEnumerable<Description> values)
    {
        RichTextBlock textBlock = new();
        Microsoft.UI.Xaml.Documents.Paragraph paragraph = new Microsoft.UI.Xaml.Documents.Paragraph();
        foreach (Description description in values)
        {
            switch (description.Type)
            {
                case DescType.None:
                    break;
                case DescType.Text:
                    paragraph.Inlines.Add(new Run() { Text = description.Text });
                    break;
                case DescType.Aite:
                    break;
                case DescType.Lottery:
                    var loggery = new Hyperlink() { NavigateUri = new($"bilistart:/{description.Uri}") };
                    loggery.Inlines.Add(new Run() { Text = description.Text, FontWeight = Microsoft.UI.Text.FontWeights.Bold });
                    paragraph.Inlines.Add(loggery);
                    break;
                case DescType.Vote:
                    break;
                case DescType.Topic:
                    var link = new Hyperlink() { NavigateUri = new(description.Uri) };
                    link.Inlines.Add(new Run() { Text = description.Text,FontWeight = Microsoft.UI.Text.FontWeights.Bold });
                    paragraph.Inlines.Add(link);
                    break;
                case DescType.Goods:
                    break;
                case DescType.Bv:
                    break;
                case DescType.Av:
                    break;
                case DescType.Emoji:
                    InlineUIContainer image = new InlineUIContainer()
                    {
                        Child = new Border()
                        {
                            VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Center,
                            Margin = new(0, -5, 0, 0),
                            Child = new Image()
                            {
                                Source = new BitmapImage(new Uri(description.Uri)),
                                Width = 25,
                                Stretch = Microsoft.UI.Xaml.Media.Stretch.UniformToFill
                            }
                        }
                    };
                    paragraph.Inlines.Add(image);
                    break;
                case DescType.User:
                    break;
                case DescType.Cv:
                    break;
                case DescType.Vc:
                    break;
                case DescType.Web:
                    var weblink = new Hyperlink() { NavigateUri = new(description.Uri) };
                    weblink.Inlines.Add(new Run() { Text = description.Text, FontWeight = Microsoft.UI.Text.FontWeights.Bold });
                    paragraph.Inlines.Add(weblink);
                    break;
                case DescType.Taobao:
                    break;
                case DescType.Mail:
                    break;
                case DescType.OgvSeason:
                    break;
                case DescType.OgvEp:
                    break;
                case DescType.SearchWord:
                    break;
            }
        }
        textBlock.Blocks.Add(paragraph);
        return textBlock;
    }

}
