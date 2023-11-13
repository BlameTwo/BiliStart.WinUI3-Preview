namespace Views.Dialogs;

public sealed partial class TokenDialog : ContentDialog, IShowDialog
{
    public TokenDialog()
    {
        InitializeComponent();
    }

    public TokenViewModel ViewModel { get; private set; }

    public void ToViewModel(object type, object value)
    {
        this.ViewModel = (TokenViewModel)type;
    }
}
