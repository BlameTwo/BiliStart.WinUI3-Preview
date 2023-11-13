using Bilibili.Broadcast.Message.Main;
using Network.Models.Totals.HotHistory;
using ViewConverter.Models;
using ViewConverter.Models.BiliChat;

namespace AppContractService.Services.FactorysServices;

public class ServiceDataFactory : IServiceDataFactory
{
    public ICurrent Current { get; }
    public IAccountProvider AccountProvider { get; }

    public ServiceDataFactory(ICurrent current)
    {
        Current = current;
    }

    public List<HotHistoryNavigation> FormatHotHistoryNavigation(HotHistoryNavigationModel model)
    {
        var list = new List<HotHistoryNavigation>();
        foreach (var item in model.Cards)
        {
            foreach (var card in item.Item)
            {
                if (card.Goto == "inline_tab")
                {
                    foreach (var it in card.Items)
                    {
                        list.Add(
                            new HotHistoryNavigation()
                            {
                                Id = it.ItemId.ToString(),
                                Name = it.Title
                            }
                        );
                    }
                }
            }
        }
        return list;
    }


    public BiliChatBubbleModel FormatChatResult(ChatResult chatResult)
    {
        if (chatResult.Code != 0) return null;
        BiliChatBubbleModel model = new();
        model.Ssid = chatResult.SessionId;
        model.Title =  chatResult.Title;
        model.Content = chatResult.Bubble[0];
        model.UsingList = chatResult.Bubble[1];
        return model;
        //foreach (var item in chatResult.Bubble)
        //{
        //    foreach (var paragraph in item.Paragraphs)
        //    {
        //        //目前分为三种，数组0为主回答，数组1为检索该回答使用的一些参考资料，数组3为B站安卓客户端固定的内容
        //        if (paragraph.ParaType == Bilibili.App.Dynamic.V2.Paragraph.Types.ParagraphType.Text)
        //        {//如果类型为Text
        //         //foreach (var node in paragraph.Text.Nodes)
        //         //{
        //         //    if (node.NodeType == Bilibili.App.Dynamic.V2.TextNode.Types.TextNodeType.Words)
        //         //    {//纯文字
        //         //        var fontsize = node.Word.FontSize;
        //         //        var text = node.RawText;
        //         //    }else if(node.NodeType == Bilibili.App.Dynamic.V2.TextNode.Types.TextNodeType.Emote)
        //         //    {//表情包
        //         //        var emotetxt = node.RawText; //表情包文本
        //         //        var emoteurl = node.Emote.EmoteUrl;
        //         //    }else if(node.NodeType == Bilibili.App.Dynamic.V2.TextNode.Types.TextNodeType.BizLink)
        //         //    {//链接
        //         //        //原始文本
        //         //        var bizstr = node.RawText;
        //         //        var icon = node.Link.Icon;
        //         //        var bizurl = node.Link.Link;
        //         //    }

        //            //}
        //        }
        //        if (paragraph.ParaType == Bilibili.App.Dynamic.V2.Paragraph.Types.ParagraphType.SortedList)
        //        {

        //        }
        //    }
        //}
    }
   

}
