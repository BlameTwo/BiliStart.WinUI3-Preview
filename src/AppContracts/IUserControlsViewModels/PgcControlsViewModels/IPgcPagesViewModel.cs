using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using Network.Models.Bangumi;
using System;
using System.Collections.ObjectModel;

namespace IAppContracts.IUserControlsViewModels.PgcControlsViewModels;

public interface IPgcPagesViewModel : IUserControlVMBase<Tuple<BangumiDetilyModel>>
{
    public ObservableCollection<Network.Models.Bangumi.Data_Episodes> DataEpisodes { get; set; }

    public BangumiDetilyModel DataBase { get; set; }

    public IRelayCommand OpenSessionCommand { get; }
}
