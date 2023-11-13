using Bilibili.App.Dynamic.V2;
using IAppContracts.ItemsViewModels.Dynamics;
using ViewConverter.Models.AccountHistory;

namespace AppContractService.Services.FactorysServices;

public sealed partial class AccountFactory : IAccountFactory
{
    public AccountFactory(IFactoryBase factoryBase)
    {
        FactoryBase = factoryBase;
    }

    public IFactoryBase FactoryBase { get; }

    public IAccountVideoHistoryItemViewModel CreateHistoryItem(AccountVideoHistoryItem item) =>
        FactoryBase.SetData<IAccountVideoHistoryItemViewModel, AccountVideoHistoryItem>(item);

    public List<IAccountVideoHistoryItemViewModel> CreateHistoryItems(
        List<AccountVideoHistoryItem> items
    ) => FactoryBase.SetDataToList<IAccountVideoHistoryItemViewModel, AccountVideoHistoryItem>(items);

    public IAccountHistoryLiveItemViewModel CreateLiveHistoryItem(AccountLiveHistoryItem item)
        => FactoryBase.SetData<IAccountHistoryLiveItemViewModel, AccountLiveHistoryItem>(item);

    public List<IAccountHistoryLiveItemViewModel> CreateLiveHistoryItems(List<AccountLiveHistoryItem> items)
        => FactoryBase.SetDataToList<IAccountHistoryLiveItemViewModel, AccountLiveHistoryItem>(items);

    public IDynamicItemViewModel CreateDynamicItem(DynamicItem item) =>
        FactoryBase.SetData<IDynamicItemViewModel, DynamicItem>(item);



    public List<IDynamicItemViewModel> CreateDynamicItems(List<DynamicItem> item) =>
        FactoryBase.SetDataToList<IDynamicItemViewModel, DynamicItem>(item);

    public IDynamicForwardItemViewModel CreateDynamicForwardItem(DynamicItem item)
        =>FactoryBase.SetData<IDynamicForwardItemViewModel,DynamicItem>(item);
}
