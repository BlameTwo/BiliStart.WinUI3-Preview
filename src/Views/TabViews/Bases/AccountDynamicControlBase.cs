using App.Models.AppTabView;
using ViewModels.AppTabViewModels;

namespace Views.TabViews.Bases;

public class AccountDynamicControlBase: TabViewItemControl<AccountDynamicViewModel>
{
    public override void UnregisterViewModel()
    {
        this.ViewModel.TokenSource.Cancel();
        this.ViewModel.DynamicLists = null;
        this.ViewModel.UpList = null;
        base.UnregisterViewModel();
    }
}
