namespace Views.Dialogs;

public sealed partial class AddDownloadDialog : ContentDialog, IShowDialog
{
    public AddDownloadDialog()
    {
        this.InitializeComponent();
    }

    public void ToViewModel(object type, object value)
    {
        this.DataContext = type;
    }
}
