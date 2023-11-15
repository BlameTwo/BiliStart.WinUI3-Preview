using App.Models.Enum;
using BiliStart.WinUI3.UI.Controls;
using ViewModels.AppTabViewModels;
using Views.TabViews.Bases;

namespace Views.TabViews;

public sealed partial class PlayerControlView : PlayerVideoControlBase
{
    public PlayerControlView()
    {
        this.InitializeComponent();
        this.Loaded += PlayerControlView_Loaded;
    }

    private void PlayerControlView_Loaded(object sender, RoutedEventArgs e)
    {
        this.PlayerVideoControlBase_Unloaded(sender,e);
        this.playerelement.MaxScreenClick += playerelement_MaxScreenClick;
        this.playerelement.TopScreenClick += playerelement_TopScreenClick;
        this.pagecontrol.PageSelectionEvent += Pagecontrol_PageSelectionEvent;
        this.navgrid.SelectionChanged += navgrid_SelectionChanged;
    }

    private void playerelement_MaxScreenClick(object source, bool isScreen)
    {
        setControl(isScreen);
        if (isScreen)
        {
            ViewModel.WindowManager.SetWindowState(
                Microsoft.UI.Windowing.AppWindowPresenterKind.FullScreen
            );
            this.playerelement.MediaState = App.Models.Enum.MediaState.Full;
        }
        else
        {
            ViewModel.WindowManager.SetWindowState(
                Microsoft.UI.Windowing.AppWindowPresenterKind.Default
            );
            this.playerelement.MediaState = App.Models.Enum.MediaState.Default;
        }
    }
    private void playerelement_TopScreenClick(object source, bool istop)
    {
        setControl(istop);
        if (istop)
        {
            this.ViewModel.WindowManager.ChangedMinWidth(500);
            this.ViewModel.WindowManager.ChangedMinHeight(300);
            ViewModel.WindowManager.SetWindowState(
                Microsoft.UI.Windowing.AppWindowPresenterKind.CompactOverlay
            );
            this.MediaState = App.Models.Enum.MediaState.TopFull;
        }
        else
        {
            this.ViewModel.WindowManager.ChangedMinHeight(350);
            this.ViewModel.WindowManager.ChangedMinWidth(350);
            ViewModel.WindowManager.SetWindowState(
                Microsoft.UI.Windowing.AppWindowPresenterKind.Default
            );
            this.MediaState = App.Models.Enum.MediaState.Default;
        }
            
    }
    private async void Pagecontrol_PageSelectionEvent(object source, ViewPage value)
    {
        await this.ViewModel.PagesMetadata(value);
    }

    void setControl(bool isflage)
    {
        if (isflage)
        {

            //隐藏元素化
            RightControl.Visibility = Visibility.Collapsed;
            PlayerSession.Visibility = Visibility.Collapsed;
            Grid.SetRowSpan(playerelement, 2);
            Grid.SetColumnSpan(LeftControl, 2);
            Grid.SetRow(content, 0);
            Grid.SetRowSpan(content, 2);
            content.Padding = new Thickness(0);
        }
        else
        {
            //显示元素
            RightControl.Visibility = Visibility.Visible;
            PlayerSession.Visibility = Visibility.Visible;
            Grid.SetRowSpan(playerelement, 1);
            Grid.SetColumnSpan(LeftControl, 1);
            Grid.SetRow(content, 1);
            Grid.SetRowSpan(content, 1);
            content.Padding = new Thickness(15);
        }
    }



    public MediaState MediaState
    {
        get { return (MediaState)GetValue(MediaStateProperty); }
        set { SetValue(MediaStateProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MediaState.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MediaStateProperty =
        DependencyProperty.Register("MediaState", typeof(MediaState), typeof(PlayerControlView), new PropertyMetadata(MediaState.Default));



    private void navgrid_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (sender.SelectedItem == null)
            return;
        var navigation = sender.SelectedItem as NavigationViewItem;
        if (navigation!.Tag.ToString() == "Command")
        {
            (this.DataContext as ViewModels.AppTabViewModels.PlayerViewModel).PlayerCommandVisibility = Visibility.Visible;
            (this.DataContext as ViewModels.AppTabViewModels.PlayerViewModel).PlayerRelatesVisibility = Visibility.Collapsed;
            (this.DataContext as ViewModels.AppTabViewModels.PlayerViewModel).PlayerPagesVisibility = Visibility.Collapsed;
        }
        else if (navigation.Tag.ToString() == "Relate")
        {
            (this.DataContext as ViewModels.AppTabViewModels.PlayerViewModel).PlayerCommandVisibility = Visibility.Collapsed;
            (this.DataContext as ViewModels.AppTabViewModels.PlayerViewModel).PlayerRelatesVisibility = Visibility.Visible;
            (this.DataContext as ViewModels.AppTabViewModels.PlayerViewModel).PlayerPagesVisibility = Visibility.Collapsed;
        }
        else if(navigation.Tag.ToString() == "Pages")
        {
            (this.DataContext as ViewModels.AppTabViewModels.PlayerViewModel).PlayerCommandVisibility = Visibility.Collapsed;
            (this.DataContext as ViewModels.AppTabViewModels.PlayerViewModel).PlayerRelatesVisibility = Visibility.Collapsed;
            (this.DataContext as ViewModels.AppTabViewModels.PlayerViewModel).PlayerPagesVisibility = Visibility.Visible;
        }
         (this.DataContext as ViewModels.AppTabViewModels.PlayerViewModel).PlayerReplyCommonsVisibility = Visibility.Collapsed;
    }


    private void PlayerVideoControlBase_Unloaded(object sender, RoutedEventArgs e)
    {
        this.playerelement.MaxScreenClick -= playerelement_MaxScreenClick;
        this.playerelement.TopScreenClick -= playerelement_TopScreenClick;
        this.pagecontrol.PageSelectionEvent -= Pagecontrol_PageSelectionEvent;
        this.navgrid.SelectionChanged -= navgrid_SelectionChanged;
    }
}
