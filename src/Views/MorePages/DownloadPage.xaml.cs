namespace Views.MorePages;

public sealed partial class DownloadPage : Page
{
    public DownloadPage()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs value)
        {
            this.ViewModel = (DownloadViewModel)value.ViewModel;
        }
    }

    public DownloadViewModel ViewModel { get; set; }

    private void AdaptiveGridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is BiliDownload download)
        {
            ViewModel.SelectionChangedItem(download);
        }
    }
}
