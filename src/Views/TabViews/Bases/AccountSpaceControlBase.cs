using App.Models.AppTabView;

namespace Views.TabViews.Bases;

public class AccountSpaceControlBase : TabViewItemControl<ViewModels.AppTabViewModels.AccountSpaceViewModel>
{
    public override void GoParamter(object value)
    {
        ViewModel.Mid = (long)value;
        ViewModel.RefershAccount();
        base.GoParamter(value);
    }

    public override void UnregisterViewModel()
    {
        this.ViewModel.TokenSource.Cancel();
        base.UnregisterViewModel();
    }
}
