using IAppContracts.IUserControlsViewModels.PgcControlsViewModels;
using Network.Models.Bangumi;
using System.Collections.ObjectModel;

namespace AppContractService.Services.FactorysServices;

public class PgcDataViewModelFactory : IPgcDataViewModelFactory
{
    public List<IAppContracts.ItemsViewModels.IPgcItemViewModel> CreatePgcItems(
        List<ModelItems> bangumiModel
    )
    {
        List<IAppContracts.ItemsViewModels.IPgcItemViewModel> pgcItems = new();
        foreach (var item in bangumiModel)
        {
            pgcItems.Add(CreatePgcItem(item));
        }
        return pgcItems;
    }

    public IAppContracts.ItemsViewModels.IPgcItemViewModel CreatePgcItem(ModelItems bangumiModel)
    {
        var val = AppService.GetService<IAppContracts.ItemsViewModels.IPgcItemViewModel>();
        val.Base = bangumiModel;
        return val;
    }

    public IPgcPagesViewModel CreatePgcPageViewModel(BangumiDetilyModel data)
    {
        var val = AppService.GetService<IPgcPagesViewModel>();
        val.SetData(new(data));
        return val;
    }

    public IPgcSessionViewModel CreatePgcSessionViewModel(BangumiDetilyModel data)
    {
        var val = AppService.GetService<IPgcSessionViewModel>();
        val.SetData(data);
        return val;
    }
}
