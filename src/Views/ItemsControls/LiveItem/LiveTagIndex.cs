using App.Models;

namespace Views.ItemsControls.LiveItem;

public class LiveTagIndex : ItemVM<ILiveTagAreaIndexViewModel>, IDynamicItemOrientation
{
    public void ChangedOrientation(Orientation orientation)
    {
        this.Style =
            orientation == Orientation.Horizontal
                ? this.ViewModel.AppResources.GetResource<Style>("LiveTagIndexHorizontalStyle")
                : this.ViewModel.AppResources.GetResource<Style>("LiveTagIndexVerticalStyle");
    }
}
