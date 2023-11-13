using Network.Models.Live;

namespace AppContractService.Services.FactorysServices;

public sealed partial class LiveItemFactory : ILiveItemFactory
{
    public LiveItemFactory(IFactoryBase factoryBase)
    {
        FactoryBase = factoryBase;
    }

    public IFactoryBase FactoryBase { get; }

    public ILivePageItemViewModel CreateLivePageItem(LiveCardList card) =>
        FactoryBase.SetData<ILivePageItemViewModel, LiveCardList>(card);

    public List<ILivePageItemViewModel> CreateLivePageItems(List<LiveCardList> cards) =>
        FactoryBase.SetDataToList<ILivePageItemViewModel, LiveCardList>(cards);

    public ILiveTagAreaItemViewModel CreateLiveTagAreaItem(LiveTagAreaList list) =>
        FactoryBase.SetData<ILiveTagAreaItemViewModel, LiveTagAreaList>(list);

    public List<ILiveTagAreaItemViewModel> CreateLiveTagAreaItems(List<LiveTagAreaList> list) =>
        FactoryBase.SetDataToList<ILiveTagAreaItemViewModel, LiveTagAreaList>(list);

    public ILiveTagAreaIndexViewModel CreateLiveTagAreaIndex(LiveTagItemList list) =>
        FactoryBase.SetData<ILiveTagAreaIndexViewModel, LiveTagItemList>(list);

    public List<ILiveTagAreaIndexViewModel> CreateLiveTagAreaIndexs(List<LiveTagItemList> list) =>
        FactoryBase.SetDataToList<ILiveTagAreaIndexViewModel, LiveTagItemList>(list);
}
