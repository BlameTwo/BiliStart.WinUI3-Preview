using IAppContracts.ItemsViewModels;
using Network.Models.Live;
using System.Collections.Generic;

namespace IAppContracts.Factorys;

public interface ILiveItemFactory
{
    public ILivePageItemViewModel CreateLivePageItem(LiveCardList card);

    public List<ILivePageItemViewModel> CreateLivePageItems(List<LiveCardList> cards);

    public ILiveTagAreaItemViewModel CreateLiveTagAreaItem(LiveTagAreaList list);

    public List<ILiveTagAreaItemViewModel> CreateLiveTagAreaItems(List<LiveTagAreaList> list);

    public ILiveTagAreaIndexViewModel CreateLiveTagAreaIndex(LiveTagItemList list);

    public List<ILiveTagAreaIndexViewModel> CreateLiveTagAreaIndexs(List<LiveTagItemList> list);
}
