namespace Views.ItemsControls.PgcItem;

public class PgcItem : ItemVM<IPgcItemViewModel>, IDynamicItemOrientation
{

    public void ChangedOrientation(Orientation orientation)
    {
        this.Style =
            orientation == Orientation.Horizontal
                ? ViewModel.AppResources.GetResource<Style>("PgcHorizontalStyle")
                : ViewModel.AppResources.GetResource<Style>("PgcVerticalStyle");
    }
}
