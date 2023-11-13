using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Runtime.CompilerServices;

namespace BiliStart.WinUI3.UI.Controls;

public class IconText : Control
{
    public IconText()
    {
        this.DefaultStyleKey = typeof(IconText);
    }

    public string Icon
    {
        get { return (string)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        "Icon",
        typeof(string),
        typeof(IconText),
        new PropertyMetadata(null)
    );

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        "Text",
        typeof(string),
        typeof(IconText),
        new PropertyMetadata("")
    );
}
