using IAppContracts.ItemsViewModels.Dynamics;

namespace Views.ItemsControls.AccountDynamicItem;

public sealed partial class AccountDynamicItemUserControl : UserControl
{
    public AccountDynamicItemUserControl()
    {
        this.InitializeComponent();
        this.Loaded += AccountDynamicItemUserControl_Loaded;
        this.Unloaded += AccountDynamicItemUserControl_Unloaded;
    }

    private void AccountDynamicItemUserControl_Loaded(object sender, RoutedEventArgs e)
    {
        this.Bindings.Update();
    }

    private void AccountDynamicItemUserControl_Unloaded(object sender, RoutedEventArgs e)
    {
        this.Bindings.StopTracking();
        GC.Collect();
        GC.SuppressFinalize(this);
    }

    public IDynamicItemViewModel ViewModel
    {
        get { return (IDynamicItemViewModel)GetValue(ViewModelProperty); }
        set { SetValue(ViewModelProperty, value); }
    }

    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
        "ViewModel",
        typeof(IDynamicItemViewModel),
        typeof(AccountDynamicItemUserControl),
        new PropertyMetadata(null)
    );
}