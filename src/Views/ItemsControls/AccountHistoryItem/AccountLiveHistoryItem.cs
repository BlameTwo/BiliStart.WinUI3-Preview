
namespace Views.ItemsControls.AccountHistoryItem;

public class AccountLiveHistoryItem : ItemVM<IAccountHistoryLiveItemViewModel>, IDynamicItemOrientation
{
    public void ChangedOrientation(Orientation orientation)
    {
        this.Style =
            orientation == Orientation.Horizontal
                ? ViewModel.AppResources.GetResource<Style>("AccountLiveHistoryHorizontalStyle")
                : ViewModel.AppResources.GetResource<Style>("AccountLiveHistoryVerticalStyle");
    }
}
