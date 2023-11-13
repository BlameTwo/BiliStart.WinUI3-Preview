using IAppContracts.ItemsViewModels;

namespace ViewModels.ItemViewModels;

public sealed partial class TokenItemViewModel : ObservableObject, ITokenItemViewModel
{
    public TokenItemViewModel(IAccountProvider accountProvider)
    {
        AccountProvider = accountProvider;
    }

    [RelayCommand]
    async Task Loaded()
    {
        this.MyData = (await AccountProvider.GetTokenInfoAsync(this.TokenBase)).Data;
    }

    [ObservableProperty]
    MyInfo _MyData;

    [ObservableProperty]
    AccountToken _TokenBase;

    [ObservableProperty]
    string _TokenFilePath;

    [RelayCommand]
    void OpenSource()
    {
        System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(
            "Explorer.exe"
        );
        psi.Arguments = "/e,/select," + TokenFilePath;
        System.Diagnostics.Process.Start(psi);
    }

    public IAccountProvider AccountProvider { get; }

    public void SetData(Tuple<AccountToken, string> value)
    {
        this.TokenBase = value.Item1;
        this.TokenFilePath = value.Item2;
    }
}
