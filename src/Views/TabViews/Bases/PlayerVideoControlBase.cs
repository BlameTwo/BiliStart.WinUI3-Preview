using App.Models.AppTabView;
using ViewModels.AppTabViewModels;

namespace Views.TabViews.Bases;

public class PlayerVideoControlBase : TabViewItemControl<ViewModels.AppTabViewModels.PlayerViewModel>
{
    public override void GoParamter(object value)
    {
        if (value is VideoPlayerArgs player)
        {
            this.ViewModel.RefershMediaPlayer(player);
        }
    }


    public override void UnregisterViewModel()
    {
        this.ViewModel.Element.CloseAsync();
        this.ViewModel.TokenSource.Cancel();
        base.UnregisterViewModel();
    }
}
