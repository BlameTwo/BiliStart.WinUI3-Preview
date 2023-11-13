using IAppContracts.ItemsViewModels;
using Network.Models.Live;

namespace ViewModels.ItemViewModels;

public partial class LiveTagAreaItemViewModel : ObservableObject, ILiveTagAreaItemViewModel
{
    public LiveTagAreaItemViewModel(IRootNavigationMethod rootNavigationMethod)
    {
        RootNavigationMethod = rootNavigationMethod;
    }

    [ObservableProperty]
    LiveTagAreaList _Base;

    public IRootNavigationMethod RootNavigationMethod { get; }

    [RelayCommand]
    void GoAction()
    {
        //发送信息到直播标签页面
        WeakReferenceMessenger.Default.Send(new LiveTagItemGo(Base));
    }

    public void SetData(LiveTagAreaList data)
    {
        this.Base = data;
    }
}
