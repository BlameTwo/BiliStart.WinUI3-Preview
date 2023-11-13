using App.Models.AppTabView;

namespace Views.TabViews.Bases;

public class LiveTagControlBase : TabViewItemControl<ViewModels.AppTabViewModels.LiveTagViewModel>
{
    public override void UnregisterViewModel()
    {
        this.ViewModel.TokenSource.Cancel();
        base.UnregisterViewModel();
    }
}
