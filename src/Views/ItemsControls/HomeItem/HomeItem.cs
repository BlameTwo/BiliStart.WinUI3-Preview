using App.Models;

namespace Views.ItemsControls.HomeItem;

public class HomeItem : ItemVM<IVideoHomeItemViewModel>, IDynamicItemOrientation
{
    public void ChangedOrientation(Orientation orientation)
    {
        if (orientation == Orientation.Horizontal)
        {
            this.Style = ViewModel.AppResource.GetResource<Style>("HomeHorizontalStyle");
        }
        else
        {
            this.Style = ViewModel.AppResource.GetResource<Style>("HomeVerticalStyle");
        }
    }
}
