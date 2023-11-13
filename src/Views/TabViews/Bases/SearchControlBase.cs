using App.Models.AppTabView;
using ViewModels.AppTabViewModels;

namespace Views.TabViews.Bases;

public class SearchControlBase : TabViewItemControl<SearchViewModel>
{
    public override void GoParamter(object value)
    {
        this.ViewModel.Keyword = value.ToString();
    }


    public override void UnregisterViewModel()
    {
        this.ViewModel.TokenSource.Cancel();
        this.ViewModel = null;
    }
}
