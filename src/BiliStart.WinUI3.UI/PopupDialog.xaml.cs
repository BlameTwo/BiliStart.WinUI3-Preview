using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace BiliStart.WinUI3.UI.Controls;

public sealed partial class PopupDialog : UserControl
{
    private string _popupContent;
    private readonly Panel uIElement;

    private Popup _popup = null;

    public PopupDialog()
    {
        this.InitializeComponent();
        _popup = new Popup();
        _popup.Child = this;
        this.Loaded += PopupNoticeLoaded;
    }

    public PopupDialog(string popupContentString, Panel uIElement, Symbol symbol)
        : this()
    {
        PopupIcon.Symbol = symbol;
        _popupContent = popupContentString;
        this.uIElement = uIElement;
        _popup.XamlRoot = uIElement.XamlRoot;
    }

    public void ShowPopup()
    {
        _popup.IsOpen = true;
    }

    private void PopupNoticeLoaded(object sender, RoutedEventArgs e)
    {
        PopupContent.Text = _popupContent;
        this.PopupIn.Begin();
        this.PopupIn.Completed += PopupInCompleted;
        this.Width = uIElement.ActualWidth;
        this.Height = uIElement.ActualHeight;
    }

    public async void PopupInCompleted(object sender, object e)
    {
        await Task.Delay(1000);

        this.PopupOut.Begin();
        this.PopupOut.Completed += PopupOutCompleted;
    }

    public void PopupOutCompleted(object sender, object e)
    {
        _popup.IsOpen = false;
    }
}
