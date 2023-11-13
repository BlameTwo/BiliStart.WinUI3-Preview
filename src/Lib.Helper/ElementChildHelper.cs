using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml;

namespace Lib.Helper;

public class ElementChildHelper
{
    public static DependencyObject FindChildByName(DependencyObject parent, string name)
    {
        int count = VisualTreeHelper.GetChildrenCount(parent);

        for (int i = 0; i < count; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);
            if (child is FrameworkElement frameworkElement && frameworkElement.Name == name)
            {
                return child;
            }
            DependencyObject result = FindChildByName(child, name);
            if (result != null)
            {
                return result;
            }
        }
        return null;
    }
}
