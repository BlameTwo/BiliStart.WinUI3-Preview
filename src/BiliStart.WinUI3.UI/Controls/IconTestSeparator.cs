using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace BiliStart.WinUI3.UI.Controls;

/// <summary>
/// 一个带图标的说明性分割线
/// </summary>
public class IconTestSeparator : Control
{
    public object Icon
    {
        get { return (object)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        "Icon",
        typeof(object),
        typeof(IconTestSeparator),
        new PropertyMetadata(null)
    );

    public string Header
    {
        get { return (string)GetValue(HeaderProperty); }
        set { SetValue(HeaderProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        "Header",
        typeof(string),
        typeof(IconTestSeparator),
        new PropertyMetadata(null)
    );
}
