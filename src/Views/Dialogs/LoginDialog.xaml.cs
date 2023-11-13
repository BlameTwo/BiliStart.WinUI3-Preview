namespace Views.Dialogs;

public sealed partial class LoginDialog : ContentDialog, IShowDialog
{
    public LoginDialog()
    {
        this.InitializeComponent();
    }

    public LoginViewModel ViewModel { get; set; }

    public void ToViewModel(object type, object value)
    {
        this.ViewModel = (LoginViewModel)type;
    }
}
