namespace Views.PgcPages;

public sealed partial class MoviePage : Page
{
    public MoviePage()
    {
        InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs value)
        {
            ViewModel = (ViewModels.PageViewModels.MovieViewModel)value.ViewModel;
            await ViewModel.Refersh((string)value.Paramter, true);
        }
    }


    public MovieViewModel ViewModel { get; private set; }
}
