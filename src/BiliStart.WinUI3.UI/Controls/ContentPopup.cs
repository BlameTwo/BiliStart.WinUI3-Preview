using IAppContracts.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace BiliStart.WinUI3.UI.Controls;

public partial class ContentPopup : ContentControl,IContentPopup
{
    public ContentPopup()
    {
        this.DefaultStyleKey = typeof(ContentPopup);
    }

    public void Hide()
    {
        this.IsOpen = false;
    }

    public void Showed()
    {
        this.IsOpen = true;
    }
    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
    }

    public bool IsOpen
    {
        get { return (bool)GetValue(IsOpenProperty); }
        set { SetValue(IsOpenProperty, value); }
    }

    public static readonly DependencyProperty IsOpenProperty =
        DependencyProperty.Register("IsOpen", typeof(bool), typeof(ContentPopup), new PropertyMetadata(false,OnOpenChanged));

    private static void OnOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if(e.NewValue is bool val && d is ContentPopup pop)
        {
            if (val)
                VisualStateManager.GoToState(pop, ShowState, false);
            else
                VisualStateManager.GoToState(pop, CloseState, false);
        }
    }
}
