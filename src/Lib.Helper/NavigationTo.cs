using Microsoft.UI.Xaml;

namespace Lib.Helper;

public class NavigationTo
{
    public static string GetNavigationTo(DependencyObject obj)
    {
        return (string)obj.GetValue(NavigationToProperty);
    }

    public static void SetNavigationTo(DependencyObject obj, string value)
    {
        obj.SetValue(NavigationToProperty, value);
    }

    public static readonly DependencyProperty NavigationToProperty =
        DependencyProperty.RegisterAttached(
            "NavigationTo",
            typeof(string),
            typeof(NavigationTo),
            new PropertyMetadata(null)
        );
}

public class Paramter
{
    public static string GetNavigationToParamter(DependencyObject obj)
    {
        return (string)obj.GetValue(NavigationToParamterProperty);
    }

    public static void SetNavigationToParamter(DependencyObject obj, string value)
    {
        obj.SetValue(NavigationToParamterProperty, value);
    }

    public static readonly DependencyProperty NavigationToParamterProperty =
        DependencyProperty.RegisterAttached(
            "NavigationToParamter",
            typeof(string),
            typeof(Paramter),
            new PropertyMetadata("")
        );
}
