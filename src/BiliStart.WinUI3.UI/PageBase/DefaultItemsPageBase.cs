using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace BiliStart.WinUI3.UI.PageBase;

public partial class DefaultItemsPageBase : Page
{
    public DefaultItemsPageBase()
    {
        this.DefaultStyleKey = typeof(DefaultItemsPageBase);
    }

    public object Header
    {
        get { return (object)GetValue(HeaderProperty); }
        set { SetValue(HeaderProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        "Header",
        typeof(object),
        typeof(DefaultItemsPageBase),
        new PropertyMetadata(null)
    );

    public object Footer
    {
        get { return (object)GetValue(FooterProperty); }
        set { SetValue(FooterProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Footer.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty FooterProperty = DependencyProperty.Register(
        "Footer",
        typeof(object),
        typeof(DefaultItemsPageBase),
        new PropertyMetadata(null)
    );
}
