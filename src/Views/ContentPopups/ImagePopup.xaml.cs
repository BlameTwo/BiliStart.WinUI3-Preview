using App.Models.Popups;
using BiliStart.WinUI3.UI.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using ViewModels.ContentPopupViewModels;

namespace Views.ContentPopups;

public sealed partial class ImagePopup : ContentPopup
{
    public ImagePopup(ImagePopupViewModels viewModel)
    {
        this.InitializeComponent();
        ViewModel = viewModel;
    }

    /// <summary>
    /// …Ë÷√Uri◊ ‘¥
    /// </summary>
    /// <param name="url"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void SetUri(List<ImagePopupArgs> args)
    {
        this.gridview.ItemsSource = args;
    }

    public ImagePopupViewModels ViewModel { get; }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.ViewModel.WindowManager.CloseContentPopup(this);
    }

    private void viewer_ViewChanged(ScrollView sender, object args)
    {

        this.Facoty.Text = viewer.ZoomFactor.ToString("p00");
    }

    private void gridview_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        this.image.Source = new BitmapImage(new((e.AddedItems[0] as ImagePopupArgs).Uri));
    }
}
