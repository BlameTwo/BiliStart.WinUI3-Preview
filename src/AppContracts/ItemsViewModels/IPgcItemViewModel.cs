using CommunityToolkit.Mvvm.Input;
using Network.Models.Bangumi;

namespace IAppContracts.ItemsViewModels;

public interface IPgcItemViewModel
{
    public ModelItems Base { get; set; }

    public IRootNavigationMethod RootNavigationMethod { get; }

    public IAppResources<BiliApplication> AppResources { get; }

    public IRelayCommand GoPGCCommand { get; }
}
