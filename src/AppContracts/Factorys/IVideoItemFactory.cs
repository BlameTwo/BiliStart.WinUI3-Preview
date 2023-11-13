using IAppContracts.ItemsViewModels;
using Network.Models.Totals.HotHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewConverter.Models;

namespace IAppContracts.Factorys;

public interface IVideoItemFactory
{
    public IVideoHotItemViewModel CreateVideoHotItem(HotVideo video);

    public List<IVideoHotItemViewModel> CreateVideoHotItems(List<HotVideo> videos);

    public ISearchItemViewModel CreateSearchItem(SearchModelItem data);

    public List<ISearchItemViewModel> CreateSearchItems(List<SearchModelItem> data);

    public IVideoRankItemViewModel CreateVideoRankItem(RankVideo data);

    public List<IVideoRankItemViewModel> CreateVideoRankItems(List<RankVideo> data);

    public IVideoHomeItemViewModel CreateVideoHomeItem(HomeVideo data);

    public List<IVideoHomeItemViewModel> CreateVideoHomeItems(List<HomeVideo> data);

    public IHotHistoryItemViewModel CreateHotHistoryItem(HotHistoryNavItem data);

    public List<IHotHistoryItemViewModel> CreateHotHistoryItems(List<HotHistoryNavItem> data);
}
