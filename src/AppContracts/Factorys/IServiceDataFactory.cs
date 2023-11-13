using Bilibili.Broadcast.Message.Main;
using IAppContracts.ItemsViewModels;
using Network.Models.Totals.HotHistory;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewConverter.Models;
using ViewConverter.Models.BiliChat;

namespace IAppContracts.Factorys;

public interface IServiceDataFactory
{
    public List<HotHistoryNavigation> FormatHotHistoryNavigation(HotHistoryNavigationModel model);


    public BiliChatBubbleModel FormatChatResult(ChatResult chatResult);
}
