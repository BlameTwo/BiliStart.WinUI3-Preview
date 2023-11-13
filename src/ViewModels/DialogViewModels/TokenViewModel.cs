using IAppContracts;
using IAppContracts.ItemsViewModels;

namespace ViewModels.DialogViewModels;

public sealed partial class TokenViewModel : ObservableRecipient
{
    public TokenViewModel(
        ITokenManager tokenManager,
        IWindowManager windowManager,
        ICurrent current,
        ITipShow tipShow,
        IUserControlViewModelFactory userControlViewModelFactory,
        ILocalSetting localSetting
    )
    {
        TokenManager = tokenManager;
        WindowManager = windowManager;
        Current = current;
        TipShow = tipShow;
        UserControlViewModelFactory = userControlViewModelFactory;
        LocalSetting = localSetting;
    }

    [RelayCommand]
    async Task Loaded()
    {
        this.Tokens.Clear();
        var result = (await TokenManager.GetTokenList());
        foreach (var item in result)
        {
            this.Tokens.Add(
                UserControlViewModelFactory.CreateTokenItemViewModel(item.Key, item.Value)
            );
        }
        this.Title = $"共计{Tokens.Count}个验证权限";
        foreach (var item in Tokens)
        {
            if (item.TokenBase.Mid == Current.TokenName)
                this.Selectitem = item;
        }
    }

    [ObservableProperty]
    bool _IsAction = false;

    partial void OnIsActionChanged(bool oldValue, bool newValue)
    {
        this.DelectTokenCommand.NotifyCanExecuteChanged();
        this.ChangedSelectionCommand.NotifyCanExecuteChanged();
    }

    bool GetIsDelect() => IsAction;

    [RelayCommand(CanExecute = nameof(GetIsDelect))]
    async Task DelectToken()
    {
        if (this.Selectitem == null)
            return;
        var result = await this.TokenManager.DelectToken(this.Selectitem.TokenBase);
        await this.Loaded();
        if (Tokens.Count == 0)
            WeakReferenceMessenger.Default.Send<TokenSwitchMessager>(new TokenSwitchMessager(null));
    }

    [RelayCommand]
    void Close() => WindowManager.CloseDialog();

    [RelayCommand(CanExecute = nameof(GetIsDelect))]
    void ChangedSelection()
    {
        Current.TokenName = this.Selectitem.TokenBase.Mid;
        Savetoken(this.Selectitem.TokenBase.Mid);
        WindowManager.CloseDialog();
        TipShow.ShowMessage("切换账号", Microsoft.UI.Xaml.Controls.Symbol.Refresh);
        WeakReferenceMessenger.Default.Send<TokenSwitchMessager>(
            new TokenSwitchMessager(this.Selectitem.TokenBase)
        );
    }

    private async void Savetoken(long value)
    {
        if (value == 0)
            return;
        await LocalSetting.SaveConfig(SettingName.Token, value);
    }

    [RelayCommand]
    void ItemSelection()
    {
        if (this.Selectitem == null)
        {
            IsAction = false;
            return;
        }
        if (this.Selectitem.TokenBase.Mid == Current.TokenName)
        {
            IsAction = false;
            return;
        }
        IsAction = true;
    }

    [ObservableProperty]
    ObservableCollection<ITokenItemViewModel> _tokens = new();

    [ObservableProperty]
    ITokenItemViewModel _selectitem;

    [ObservableProperty]
    string _Title;

    public ITokenManager TokenManager { get; }
    public IWindowManager WindowManager { get; }
    public ICurrent Current { get; }
    public ITipShow TipShow { get; }
    public IUserControlViewModelFactory UserControlViewModelFactory { get; }
    public ILocalSetting LocalSetting { get; }
}
