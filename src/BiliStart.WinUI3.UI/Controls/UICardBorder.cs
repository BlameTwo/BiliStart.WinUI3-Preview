using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Animation;

namespace BiliStart.WinUI3.UI.Controls;

[TemplateVisualState(GroupName = "CommonStates", Name ="PointerOver")]
[TemplateVisualState(GroupName = "CommonStates", Name = "Normal")]
[TemplateVisualState(GroupName = "CommonStates", Name = "Pressed")]
[TemplateVisualState(GroupName = "CommonStates", Name = "Disabled")]
public class UICardBorder : Button
{
    public UICardBorder()
    {
        DefaultStyleKey = typeof(UICardBorder);
    }

    Border grid = null;



    public bool IsAnimation
    {
        get { return (bool)GetValue(IsAnimationProperty); }
        set { SetValue(IsAnimationProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsAnimation.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsAnimationProperty =
        DependencyProperty.Register("IsAnimation", typeof(bool), typeof(UICardBorder), new PropertyMetadata(false));


    protected override void OnApplyTemplate()
    {
        grid = (Border)GetTemplateChild("CardContainer");
        grid.PointerEntered += UICardBorder_PointerEntered;
        grid.PointerExited += UICardBorder_PointerExited;
    }


    private void UICardBorder_PointerExited(object sender, PointerRoutedEventArgs e)
    {;
        if(this.IsAnimation)
            (grid.Resources["MouseOutMove"] as Storyboard).Begin();
        VisualStateManager.GoToState(this, "Normal", false);
    }

    private void UICardBorder_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        if (this.IsAnimation)
            (grid.Resources["MouseOverMove"] as Storyboard).Begin();
        VisualStateManager.GoToState(this, "PointerOver", false);
    }
}
