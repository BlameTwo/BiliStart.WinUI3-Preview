using App.Models.AppTabView;

namespace Views.TabViews.Bases;

public class PgcPlayerControlBase
    : TabViewItemControl<ViewModels.AppTabViewModels.PgcPlayerViewModel>
        
{
    public override async void GoParamter(object value)
    {
        if(value is long sid)
        {
            await this.ViewModel.RefershDataAsync(sid);
        }
    }

    public override async void UnregisterViewModel()
    {
        await this.ViewModel.Element.CloseAsync();
        this.ViewModel.TokenSource.Cancel();
        base.UnregisterViewModel();
    }
}
