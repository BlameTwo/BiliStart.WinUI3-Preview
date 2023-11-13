using Bilibili.App.Dynamic.V2;
using IAppContracts.ItemsViewModels;
using IAppContracts.ItemsViewModels.Dynamics;
using System.Collections.Generic;
using ViewConverter.Models.AccountHistory;

namespace IAppContracts.Factorys;

public interface IAccountFactory
{
    public IAccountVideoHistoryItemViewModel CreateHistoryItem(AccountVideoHistoryItem item);

    public List<IAccountVideoHistoryItemViewModel> CreateHistoryItems(List<AccountVideoHistoryItem> items);

    public IDynamicItemViewModel CreateDynamicItem(DynamicItem item);

    public List<IDynamicItemViewModel> CreateDynamicItems(List<DynamicItem> item);

    public IDynamicForwardItemViewModel CreateDynamicForwardItem(DynamicItem item);


    public IAccountHistoryLiveItemViewModel CreateLiveHistoryItem(AccountLiveHistoryItem item);

    public List<IAccountHistoryLiveItemViewModel> CreateLiveHistoryItems(List<AccountLiveHistoryItem> items);
}
