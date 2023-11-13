using App.Models.AppTabView;
using ViewModels.AppTabViewModels;
namespace Views.TabViews.Bases;

public partial class MainControlBase : TabViewItemControl<ViewModels.AppTabViewModels.MainViewModel>
{
    public override void GoParamter(object value)
    {
        base.GoParamter(value);
    }


    public override void UnregisterViewModel()
    {
        this.ViewModel.TokenSource.Cancel();
        base.UnregisterViewModel();
    }
}
