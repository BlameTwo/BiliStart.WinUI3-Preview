namespace Views.Dialogs;

public sealed partial class DownloadItemDialog : ContentDialog, IShowDialog
{
    public DownloadItemDialog()
    {
        this.InitializeComponent();
    }

    public void ToViewModel(object type, object value)
    {
        if (type is DownloadItemViewModel vm && value is string guid)
        {
            this.ViewModel = vm;
            ViewModel.RefershDownloadItem(guid);
        }
    }

    public DownloadItemViewModel ViewModel { get; set; }
}
