using IAppContracts.IUserControlsViewModels;

namespace ViewModels.UserControlViewModels;

public partial class PlayerRelatesViewModel : UserControlViewModelBase, IPlayerRelatesViewModel
{
    public PlayerRelatesViewModel(ITabCreateMethodService tabCreateMethodService)
    {
        TabCreateMethodService = tabCreateMethodService;
    }

    [ObservableProperty]
    ObservableCollection<PlayerRelatesVideo> _RelatesVideo = new();

    public ITabCreateMethodService TabCreateMethodService { get; }

    public void ClickChanged(PlayerRelatesVideo video)
    {
        TabCreateMethodService.GoNavigationPlayer(
            new VideoPlayerArgs()
            {
                Aid = long.Parse(video.Aid),
                Bvid = video.Bvid,
            }
        );
    }

    public void SetData(IEnumerable<PlayerRelatesVideo> value)
    {
        this.RelatesVideo.ObservableAddRange(value);
    }
}
