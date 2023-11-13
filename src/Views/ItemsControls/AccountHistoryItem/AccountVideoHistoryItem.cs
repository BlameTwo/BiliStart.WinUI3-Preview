namespace Views.ItemsControls.AccountVideoHistoryItem;

public class AccountVideoHistoryItem : ItemVM<IAccountVideoHistoryItemViewModel>, IDynamicItemOrientation
{

    public void ChangedOrientation(Orientation orientation)
    {
        this.Style =
            orientation == Orientation.Horizontal
                ? ViewModel.AppResources.GetResource<Style>("AccountVideoHistoryHorizontalStyle")
                : ViewModel.AppResources.GetResource<Style>("AccountVideoHistoryVerticalStyle");
    }
}
