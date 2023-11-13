using App.Models.AppTabView;
using ViewModels.AppTabViewModels;
namespace Views.TabViews.Bases;

public class AccountHistoryControlBase : TabViewItemControl<ViewModels.AppTabViewModels.AccountHistoryViewModel>
{
    public AccountHistoryControlBase()
    {
        this.Loaded += AccountHistoryControlBase_Loaded;
    }

    private void AccountHistoryControlBase_Loaded(object sender, RoutedEventArgs e)
    {
        this.ViewModel.IsLoaded = true;
    }

    public override void GoParamter(object value)
    {

    }

    public override void UnregisterViewModel()
    {
        this.ViewModel.AccountHistoryNavigationViewService.UnRegisterView();
        this.ViewModel.AccountHistoryNavigationService.BaseFrame = null;
        this.ViewModel.TokenSource.Cancel();
        base.UnregisterViewModel();
    }
}
