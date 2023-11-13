namespace Views.ItemsControls.HotItem;

public class HotItem : ItemVM<IVideoHotItemViewModel>, IDynamicItemOrientation
{

    public void ChangedOrientation(Orientation orientation)
    {
        if (orientation == Orientation.Horizontal)
            this.Style = ViewModel.AppResources.GetResource<Style>("HotHorizontalStyle");
        else
            this.Style = ViewModel.AppResources.GetResource<Style>("HotVerticalStyle");
    }
}
