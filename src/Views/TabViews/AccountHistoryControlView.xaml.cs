using Views.TabViews.Bases;

namespace Views.TabViews;

public sealed partial class AccountHistoryControlView : AccountHistoryControlBase
{
    public AccountHistoryControlView()
    {
        this.InitializeComponent();
    }

    public override void OnViewModelChanged()
    {
        if (this.ViewModel == null) return;
        this.ViewModel.AccountHistoryNavigationViewService.RegisterView(labelSegmented);
        this.ViewModel.AccountHistoryNavigationService.BaseFrame = _frameBase;
        this.ViewModel.AccountHistoryNavigationViewService.NavigationPage(0);
        base.OnViewModelChanged();
    }

}
