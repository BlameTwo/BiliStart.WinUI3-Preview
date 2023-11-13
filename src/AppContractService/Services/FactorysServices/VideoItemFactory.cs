using Bilibili.Polymer.App.Search.V1;
using IAppContracts.Bases;
using Network.Models.Totals.HotHistory;
using ViewConverter.Models;
using Windows.UI.WebUI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppContractService.Services.FactorysServices;

public sealed class VideoItemFactory : IVideoItemFactory
{
    public IFactoryBase FactoryBase { get; }

    public VideoItemFactory(IFactoryBase factoryBase)
    {
        FactoryBase = factoryBase;
    }

    public IVideoHotItemViewModel CreateVideoHotItem(HotVideo video) =>
        FactoryBase.SetData<IVideoHotItemViewModel, HotVideo>(video);

    public List<IVideoHotItemViewModel> CreateVideoHotItems(List<HotVideo> videos) =>
        FactoryBase.SetDataToList<IVideoHotItemViewModel, HotVideo>(videos);

    public ISearchItemViewModel CreateSearchItem(SearchModelItem data) =>
        FactoryBase.SetData<ISearchItemViewModel, SearchModelItem>(data);

    public List<ISearchItemViewModel> CreateSearchItems(List<SearchModelItem> data) =>
        FactoryBase.SetDataToList<ISearchItemViewModel, SearchModelItem>(data);

    public IVideoRankItemViewModel CreateVideoRankItem(RankVideo data) =>
        FactoryBase.SetData<IVideoRankItemViewModel, RankVideo>(data);

    public List<IVideoRankItemViewModel> CreateVideoRankItems(List<RankVideo> data) =>
        FactoryBase.SetDataToList<IVideoRankItemViewModel, RankVideo>(data);

    public IVideoHomeItemViewModel CreateVideoHomeItem(HomeVideo data) =>
        FactoryBase.SetData<IVideoHomeItemViewModel, HomeVideo>(data);

    public List<IVideoHomeItemViewModel> CreateVideoHomeItems(List<HomeVideo> data) =>
        FactoryBase.SetDataToList<IVideoHomeItemViewModel, HomeVideo>(data);

    public IHotHistoryItemViewModel CreateHotHistoryItem(HotHistoryNavItem data)=>
        FactoryBase.SetData<IHotHistoryItemViewModel,HotHistoryNavItem>(data);

    public List<IHotHistoryItemViewModel> CreateHotHistoryItems(List<HotHistoryNavItem> data) =>
        FactoryBase.SetDataToList<IHotHistoryItemViewModel, HotHistoryNavItem>(data);

}
