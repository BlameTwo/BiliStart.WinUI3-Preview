using Bilibili.App.Dynamic.V2;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ViewConverter.Models.BiliChat;
using Windows.System;

namespace Lib.Helper;

public static class BiliChatRichBoxHelper
{
    public static RichTextBlock FormatContent(BiliChatBubbleModel model)
    {
        RichTextBlock richTextBlock = new RichTextBlock();
        Microsoft.UI.Xaml.Documents.Paragraph paragraph =
            new Microsoft.UI.Xaml.Documents.Paragraph();
        foreach (var item in model.Content.Paragraphs)
        {
            if (item.ParaType == Bilibili.App.Dynamic.V2.Paragraph.Types.ParagraphType.Text)
            {
                foreach (var node in item.Text.Nodes)
                {
                    if (node.NodeType == Bilibili.App.Dynamic.V2.TextNode.Types.TextNodeType.Words)
                        paragraph.Inlines.Add(GetTextRun(node));
                    else if (
                        node.NodeType == Bilibili.App.Dynamic.V2.TextNode.Types.TextNodeType.Emote
                    )
                    {
                        InlineUIContainer image = new InlineUIContainer()
                        {
                            Child = new Image()
                            {
                                Source = new BitmapImage(new Uri(node.Emote.EmoteUrl)),
                                Width = 20,
                                Stretch = Microsoft.UI.Xaml.Media.Stretch.UniformToFill
                            }
                        };
                        paragraph.Inlines.Add(image);
                    }
                }
            }
        }
        richTextBlock.Blocks.Add(paragraph);
        return richTextBlock;
    }

    static Run GetTextRun(TextNode node)
    {
        return new Run() { Text = node.RawText, FontSize = node.Word.FontSize };
    }

    static Run GetTextRun(string str, double fontsize) =>
        new Run() { Text = str, FontSize = fontsize };

    public static RichTextBlock FormatUsingList(BiliChatBubbleModel model)
    {
        RichTextBlock richTextBlock = new RichTextBlock();
        foreach (var par in model.UsingList.Paragraphs)
        {
            if (par.ParaType == Bilibili.App.Dynamic.V2.Paragraph.Types.ParagraphType.Text)
            {

                Microsoft.UI.Xaml.Documents.Paragraph paragraph =
                            new Microsoft.UI.Xaml.Documents.Paragraph();
                foreach (var node in par.Text.Nodes)
                {
                    if (node.NodeType == Bilibili.App.Dynamic.V2.TextNode.Types.TextNodeType.Words)
                    {
                        paragraph.Inlines.Add(GetTextRun(node));
                    }
                }
                richTextBlock.Blocks.Add(paragraph);
            }
            else if (
                par.ParaType == Bilibili.App.Dynamic.V2.Paragraph.Types.ParagraphType.SortedList
            )
            {
                Microsoft.UI.Xaml.Documents.Paragraph paragraph =
                            new Microsoft.UI.Xaml.Documents.Paragraph();
                paragraph.Inlines.Add(new LineBreak() );
                foreach (var item in par.Text.Nodes)
                {
                    if (item.NodeType == TextNode.Types.TextNodeType.Words)
                    {
                        var run = GetTextRun(item);
                        paragraph.Inlines.Add(run);
                    }
                    else if (item.NodeType == TextNode.Types.TextNodeType.BizLink)
                    {
                        InlineUIContainer icon = new InlineUIContainer()
                        {
                            Child = new Image()
                            {
                                Source = new BitmapImage(new Uri(item.Link.Icon)),
                                Width = 16,
                                Stretch = Microsoft.UI.Xaml.Media.Stretch.UniformToFill
                            }
                        };
                        paragraph.Inlines.Add(icon);
                        var hyper = new Hyperlink();
                        hyper.Click += async (sender, value) =>
                        {
                            var uriBing = new Uri(item.Link.Link);
                            var success = await Windows.System.Launcher.LaunchUriAsync(uriBing);
                        };
                        hyper.Inlines.Add(new Run() { Text = item.RawText });
                        paragraph.Inlines.Add(hyper);
                    }
                }
                richTextBlock.Blocks.Add(paragraph);
            }
        }
        return richTextBlock;
    }
}
