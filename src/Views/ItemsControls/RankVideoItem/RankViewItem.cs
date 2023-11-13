namespace Views.ItemsControls.RankVideoItem;

public class RankViewItem : ItemVM<IVideoRankItemViewModel>, IDynamicItemOrientation
{
    public void ChangedOrientation(Orientation orientation)
    {
        if (orientation == Orientation.Horizontal)
        {
            this.Style = ViewModel.AppResources.GetResource<Style>("RankHorizontalStyle");
        }
        else
        {
            this.Style = ViewModel.AppResources.GetResource<Style>("RankVerticalStyle");
        }
    }
}
