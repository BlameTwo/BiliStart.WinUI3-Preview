using BiliStart.WinUI3.UI.Controls;
using Views.TabViews.Bases;

namespace Views.TabViews;

public sealed partial class LivePlayerControlView : LivePlayerControlBase
{
    public LivePlayerControlView()
    {
        this.InitializeComponent();
    }

    private void LivePlayerControlBase_Loaded(object sender, RoutedEventArgs e)
    {
        this.Media.MaxScreenClick += Media_MaxScreenClick;
        this.Media.TopScreenClick += Media_TopScreenClick;
    }

    private void Media_TopScreenClick(object source, bool istop)
    {
        MaxScreen(istop);
        if (istop)
        {
            ViewModel.WindowManager.SetWindowState(
                Microsoft.UI.Windowing.AppWindowPresenterKind.CompactOverlay
            );
            this.ViewModel.Element.MediaState = App.Models.Enum.MediaState.TopFull;
            this.ViewModel.WindowManager.ChangedMinWidth(500);
            this.ViewModel.WindowManager.ChangedMinHeight(300);
        }
        else
        {
            ViewModel.WindowManager.SetWindowState(
                Microsoft.UI.Windowing.AppWindowPresenterKind.Default
            );
            this.ViewModel.WindowManager.ChangedMinHeight(350);
            this.ViewModel.WindowManager.ChangedMinWidth(350);
            this.ViewModel.Element.MediaState = App.Models.Enum.MediaState.Default;
        }
    }

    private void Media_MaxScreenClick(object source, bool isScreen)
    {
        MaxScreen(isScreen);
        if (isScreen)
        {
            ViewModel.WindowManager.SetWindowState(
                Microsoft.UI.Windowing.AppWindowPresenterKind.FullScreen
            );
            this.ViewModel.Element.MediaState = App.Models.Enum.MediaState.Full;
        }
        else
        {
            ViewModel.WindowManager.SetWindowState(
                Microsoft.UI.Windowing.AppWindowPresenterKind.Default
            );
            this.ViewModel.Element.MediaState = App.Models.Enum.MediaState.Default;
        }
    }

    void MaxScreen(bool isScreen)
    {
        if (isScreen)
        {
            RightControl.Visibility = Visibility.Collapsed;
            LiveHeaderImage.Visibility = Visibility.Collapsed;
            LiveHeader.Visibility = Visibility.Collapsed;
            MediaControl.Margin = new(0);
            Grid.SetColumnSpan(MediaControl, 2);
        }
        else
        {
            RightControl.Visibility = Visibility.Visible;
            LiveHeaderImage.Visibility = Visibility.Visible;
            LiveHeader.Visibility = Visibility.Visible;
            MediaControl.Margin = new(15);
            Grid.SetColumnSpan(MediaControl, 1);
        }
    }

    private void LivePlayerControlBase_Unloaded(object sender, RoutedEventArgs e)
    {

        this.Media.MaxScreenClick -= Media_MaxScreenClick;
        this.Media.TopScreenClick -= Media_TopScreenClick;
    }
}
