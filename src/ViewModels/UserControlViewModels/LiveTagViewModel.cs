using IAppContracts.ItemsViewModels;
using IAppContracts.IUserControlsViewModels.LiveControlsViewModels;
using Network.Models.Live;

namespace ViewModels.UserControlViewModels;

public sealed partial class LiveTagViewModel : ObservableObject, ILiveTagViewModel
{
    public LiveTagViewModel(
        ILiveProvider liveProvider,
        IRootNavigationMethod rootNavigationMethod,
        ILiveItemFactory liveItemFactory
    )
    {
        LiveProvider = liveProvider;
        RootNavigationMethod = rootNavigationMethod;
        LiveItemFactory = liveItemFactory;
    }

    [ObservableProperty]
    LiveTagList _DataBase = null;

    [ObservableProperty]
    ObservableCollection<ILiveTagAreaItemViewModel> _AreaItems = new();

    partial void OnDataBaseChanged(LiveTagList value)
    {
        this.AreaItems.ObservableAddRange(LiveItemFactory.CreateLiveTagAreaItems(value.AreaList));
    }

    public ILiveProvider LiveProvider { get; }
    public IRootNavigationMethod RootNavigationMethod { get; }
    public ILiveItemFactory LiveItemFactory { get; }

    public void SetData(LiveTagList value)
    {
        this.DataBase = value;
    }
}
