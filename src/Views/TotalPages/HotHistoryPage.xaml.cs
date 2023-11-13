using Network.Models.Totals.HotHistory;

namespace Views.TotalPages;

public sealed partial class HotHistoryPage : Page
{
    public HotHistoryPage()
    {
        this.InitializeComponent();
    }

    public HotHistoryViewModel ViewModel { get; private set; }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs args)
        {
            this.ViewModel = (HotHistoryViewModel)args.ViewModel;
            this.ViewModel.IsActive = true;
        }
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        this.ViewModel.IsActive = false;
        this.ViewModel.TokenSource.Cancel();
        this.ViewModel = null;
        base.OnNavigatedFrom(e);
    }

}
