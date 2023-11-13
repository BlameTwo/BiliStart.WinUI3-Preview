using IAppContracts.IUserControlsViewModels;

namespace ViewModels.UserControlViewModels;

public sealed partial class PlayerPagesModel :IPlayerPagesModel
{

    public PlayerView View { get; set; }
    
    public ObservableCollection<ViewPage> PlayerPages { get; set; }
    
    public ViewPage PageSelectItem { get; set; }


    public long SpaceCid { get; set; }

    public void SetData(Tuple<PlayerView> value)
    {
        this.PlayerPages = value.Item1.PlayerPages.ToObservableCollection();
    }
}
