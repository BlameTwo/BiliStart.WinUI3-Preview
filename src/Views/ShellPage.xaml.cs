using App.Models.AppTabView;
using BiliStart.WinUI3.UI.Controls;
using CommunityToolkit.Mvvm.Messaging;
using System.Diagnostics;
using Windows.Graphics;
using WinUIEx;

namespace Views;

public sealed partial class ShellPage : Page
{
    public ShellPage()
    {
        this.InitializeComponent();
        Loaded += MainPage_Loaded;
        WeakReferenceMessenger.Default.Register<ShellPage, TabLengthChangedMessager>(this, (r, m) =>
        {
            SetDragArea(tabview.GetTabArea());
        });
    }

    private void MainPage_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        UserBth.Flyout.Opening += Flyout_Opening;
        this.AppTitleBar.Window = ViewModel.WindowManager.GetWindow();
    }

    private void Flyout_Opening(object sender, object e)
    {
        if (!ViewModel.Islogin)
        {
            UserFlyout.Hide();
        }
    }



    public List<RectInt32> ContentRect
    {
        get { return (List<RectInt32>)GetValue(ContentRectProperty); }
        set { SetValue(ContentRectProperty, value); }
    }

    public static readonly DependencyProperty ContentRectProperty =
        DependencyProperty.Register("ContentRect", typeof(List<RectInt32>), typeof(ShellPage), new PropertyMetadata(null));



    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs value)
        {
            this.ViewModel = (ShellViewModel)value.ViewModel;
            this.ViewModel.TabViewService.RegisterView(tabview);

        }
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        Loaded -= MainPage_Loaded;
        this.ViewModel.NavigationViewService.UnRegister();
        this.ViewModel.NavigationService.BaseFrame = null;
        WeakReferenceMessenger.Default.UnregisterAll(this);
        base.OnNavigatedFrom(e);
    }

    public ShellViewModel ViewModel { get; private set; }

    private async void AutoSuggestBox_TextChanged(
        AutoSuggestBox sender,
        AutoSuggestBoxTextChangedEventArgs args
    )
    {
        var result = await ViewModel.SearchProvider.GetSearchSuggestionAsync(sender.Text);
        List<string> keyworkds = new();
        result.List
            .ToList()
            .ForEach(
                (val) =>
                {
                    keyworkds.Add(val.Keyword);
                }
            );
        autosuggest.ItemsSource = keyworkds;
    }

    private void tabview_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (sender is BiliTabView view)
        {
            SetDragArea(view.GetTabArea());
        }
    }

    private void SetDragArea(TabAreaLength tabAreaLength)
    {
        var window = ViewModel.WindowManager.GetWindow();
        List<RectInt32> rects = new List<RectInt32>();  
        RectInt32 rect = new();
        var ScaleAdjustment = TitleBar.GetScaleAdjustment(window);
        rect.Y = ((int)(AppTitleBar.ActualHeight * ScaleAdjustment));
        rect.X = (int)(tabAreaLength.x * ScaleAdjustment);
        rect.Height = (int)(tabAreaLength.height*ScaleAdjustment);
        rect.Width = (int)(tabAreaLength.width*ScaleAdjustment);
        rects.Add(rect);
        this.ContentRect = rects;
    }
}
