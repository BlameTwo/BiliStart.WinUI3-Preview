namespace ViewModels.PageViewModels;

public sealed partial class MusicRankViewModel : PageViewModelBase, IAppService
{
    public MusicRankViewModel(
        IBiliServiceProvider biliServiceProvider,
        ITipShow tipShow,
        IRootNavigationMethod rootNavigationMethod
    )
        : base(rootNavigationMethod)
    {
        BiliServiceProvider = biliServiceProvider;
        TipShow = tipShow;
    }

    [RelayCommand]
    async Task Loaded()
    {
        var result = await BiliServiceProvider.GetRegisterMusicRankAsync(this.TokenSource.Token);
        this.IsRegister = result.Data.IsRegister;
        var result2 = await BiliServiceProvider.GetMusicListIDAsync(this.TokenSource.Token);
        this.IDList = result2.Data.YearData;
    }

    [ObservableProperty]
    bool? _IsRegister;

    [ObservableProperty]
    List<MusicRankIDItem> _MusicId;

    [ObservableProperty]
    List<YearData> _IDList;

    [ObservableProperty]
    YearData _selectyear;

    [ObservableProperty]
    MusicRankIDItem _selectId;

    [ObservableProperty]
    List<MusicRankCard> _musicItems = new();

    partial void OnSelectIdChanged(MusicRankIDItem? oldValue, MusicRankIDItem newValue)
    {
        refershitem(newValue);
    }

    private async void refershitem(MusicRankIDItem id)
    {
        if (id == null)
            return;
        var result = await BiliServiceProvider.GetMusicItemsAsync(id, this.TokenSource.Token);
        this.MusicItems = result;
    }

    partial void OnSelectyearChanged(YearData? oldValue, YearData newValue)
    {
        if (newValue == null)
            return;
        MusicId = newValue.MusicRankItem;
    }

    partial void OnIsRegisterChanged(bool? oldValue, bool? newValue)
    {
        if (oldValue == newValue)
            return;
        refershcheck(newValue);
    }

    async Task refcheck()
    {
        var result = await BiliServiceProvider.GetRegisterMusicRankAsync(this.TokenSource.Token);
        this.IsRegister = result.Data.IsRegister;
    }

    private async void refershcheck(bool? value)
    {
        var result = await BiliServiceProvider.GetRegisterMusicRankAsync(this.TokenSource.Token);
        if (result.Data.IsRegister != value)
        {
            await BiliServiceProvider.SetRegisterMusicRankAsync((bool)value);
        }
        switch (value)
        {
            case true:
                TipShow.ShowMessage("订阅成功", Microsoft.UI.Xaml.Controls.Symbol.Accept);
                break;
            case false:
                TipShow.ShowMessage("取消订阅成功", Microsoft.UI.Xaml.Controls.Symbol.Accept);
                break;
        }
    }

    public IBiliServiceProvider BiliServiceProvider { get; }
    public ITipShow TipShow { get; }
    public string ServiceID { get; set; } = "MusicRankViewModel";
}
