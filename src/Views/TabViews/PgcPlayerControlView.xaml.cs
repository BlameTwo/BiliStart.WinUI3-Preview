using BiliStart.WinUI3.UI.Controls;
using Views.TabViews.Bases;

namespace Views.TabViews;

public sealed partial class PgcPlayerControlView : PgcPlayerControlBase
{
    public PgcPlayerControlView()
    {
        this.InitializeComponent();
    }

    private void element_MaxScreenClick(object source, bool isScreen)
    {
        SetScreen(isScreen);
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

    private void element_TopScreenClick(object source, bool istop)
    {
        SetScreen(istop);
        if (istop)
        {
            ViewModel.WindowManager.SetWindowState(
                Microsoft.UI.Windowing.AppWindowPresenterKind.CompactOverlay
            );
            this.ViewModel.Element.MediaState = App.Models.Enum.MediaState.TopFull;
        }
        else
        {
            ViewModel.WindowManager.SetWindowState(
                Microsoft.UI.Windowing.AppWindowPresenterKind.Default
            );
            this.ViewModel.Element.MediaState = App.Models.Enum.MediaState.Default;
        }
    }

    private void NavigationView_SelectionChanged(
        NavigationView sender,
        NavigationViewSelectionChangedEventArgs args
    )
    {
        switch (args.SelectedItemContainer.Tag.ToString())
        {
            case "Pages":
                this.ViewModel.PgcPagesVisibility = Visibility.Visible;
                this.ViewModel.PgcReplyVisibility = Visibility.Collapsed;
                break;
            case "Reply":
                this.ViewModel.PgcPagesVisibility = Visibility.Collapsed;
                this.ViewModel.PgcReplyVisibility = Visibility.Visible;
                break;
            case "LikeLook":
                this.ViewModel.PgcPagesVisibility = Visibility.Collapsed;
                this.ViewModel.PgcReplyVisibility = Visibility.Collapsed;
                break;
        }
    }

    private async void PgcPagesControl_ViewControlPageSelectioned(
        object source,
        object SelectionItem
    )
    {
        await this.ViewModel.RefershDashAsync(SelectionItem);
    }

    private void splitview_PaneClosed(SplitView sender, object args)
    {
        this.ViewModel.SessionOpen = false;
        sender.Visibility = Visibility.Collapsed;
    }

    private void splitview_PaneOpening(SplitView sender, object args)
    {
        sender.Visibility = Visibility.Visible;
    }

    void SetScreen(bool isScreen)
    {
        if (isScreen)
        {
            RightControl.Visibility = Visibility.Collapsed;
            Grid.SetColumnSpan(element, 2);
            content.Padding = new Thickness(0);
        }
        else
        {
            RightControl.Visibility = Visibility.Visible;
            Grid.SetColumnSpan(element, 1);
            content.Padding = new Thickness(15);
        }
    }

    private void PgcPlayerControlBase_Loaded(object sender, RoutedEventArgs e)
    {
        this.ViewModel.LoadedCommand.Execute(element);
        PgcPlayerControlBase_Unloaded(sender, e);
        this.splitview.PaneOpening += splitview_PaneOpening;
        this.splitview.PaneClosed += splitview_PaneClosed;
        this.pgcpages.ViewControlPageSelectioned += PgcPagesControl_ViewControlPageSelectioned;
        this.navigation.SelectionChanged += NavigationView_SelectionChanged;
        this.element.MaxScreenClick += element_MaxScreenClick;
        this.element.TopScreenClick += element_TopScreenClick;
    }

    private void PgcPlayerControlBase_Unloaded(object sender, RoutedEventArgs e)
    {
        this.splitview.PaneOpening -= splitview_PaneOpening;
        this.splitview.PaneClosed -= splitview_PaneClosed;
        this.pgcpages.ViewControlPageSelectioned -= PgcPagesControl_ViewControlPageSelectioned;
        this.navigation.SelectionChanged -= NavigationView_SelectionChanged;
        this.element.MaxScreenClick -= element_MaxScreenClick;
        this.element.TopScreenClick -= element_TopScreenClick;
    }
}
