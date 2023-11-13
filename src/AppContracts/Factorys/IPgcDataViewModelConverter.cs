using IAppContracts.IUserControlsViewModels.PgcControlsViewModels;
using Network.Models.Bangumi;
using System.Collections.Generic;

namespace IAppContracts.Factorys;

public interface IPgcDataViewModelFactory
{
    public List<ItemsViewModels.IPgcItemViewModel> CreatePgcItems(List<ModelItems> bangumiModel);

    public ItemsViewModels.IPgcItemViewModel CreatePgcItem(ModelItems bangumiModel);

    public IPgcPagesViewModel CreatePgcPageViewModel(BangumiDetilyModel data);

    public IPgcSessionViewModel CreatePgcSessionViewModel(BangumiDetilyModel data);
}
