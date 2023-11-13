namespace Views.ItemsControls.LiveItem;

public class LiveItem : ItemVM<ILivePageItemViewModel>, IDynamicItemOrientation
{
    public void ChangedOrientation(Orientation orientation)
    {
        if (orientation == Orientation.Horizontal)
            this.Style = ViewModel.AppResources.GetResource<Style>("LiveHorizontalStyle");
        else
            this.Style = ViewModel.AppResources.GetResource<Style>("LiveVerticalStyle");
    }
}
