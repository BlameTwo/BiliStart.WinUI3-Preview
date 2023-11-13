using App.Models.AppTabView;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace BiliStart.WinUI3.UI.Controls;

public sealed partial class BiliTabView : TabView
{
    public BiliTabView()
    {
        this.DefaultStyleKey = typeof(BiliTabView);
    }

    public Visibility TabVisibility
    {
        get { return (Visibility)GetValue(TabVisibilityProperty); }
        set { SetValue(TabVisibilityProperty, value); }
    }

    // Using a DependencyProperty as the backing store for TabVisibility.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TabVisibilityProperty =
        DependencyProperty.Register("TabVisibility", typeof(Visibility), typeof(BiliTabView), new PropertyMetadata(null));
    
    public TabAreaLength GetTabArea()
    {
        Border Area = (Border)Lib.Helper.ElementChildHelper.FindChildByName(this, "TabViewArea");
        return new(Area.ActualHeight,Area.ActualWidth,this.ActualWidth-Area.ActualWidth);
    }
}
