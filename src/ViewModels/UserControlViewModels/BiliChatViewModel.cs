using IAppContracts.ItemsViewModels;
using System.Net.WebSockets;
using ViewConverter.Models.BiliChat;
using Windows.ApplicationModel;

namespace ViewModels.UserControlViewModels;

public partial class BiliChatViewModel : ObservableObject, IBIliChatViewModel
{
    public BiliChatViewModel(
        ICurrent current,
        IBiliServiceProvider biliServiceProvider,
        IServiceDataFactory serviceDataFactory
    )
    {
        Current = current;
        BiliServiceProvider = biliServiceProvider;
        ServiceDataFactory = serviceDataFactory;
        this.AskTip = "输入一个问题创建会话";
    }

    public ICurrent Current { get; }
    public IBiliServiceProvider BiliServiceProvider { get; }
    public IServiceDataFactory ServiceDataFactory { get; }

    [RelayCommand]
    async Task RefreshAskAsync(string content)
    {
        var result = await BiliServiceProvider.CreateChat(
            content,
            Network.Models.Enum.ChatSourceEnum.App_Search
        );
        this.SSID = result.SessionId;
        this.AskTip = "再问一句或者结束会话";
        var Chatresult = await BiliServiceProvider.AskChat(
            content,
            Network.Models.Enum.ChatSourceEnum.App_Search,
            SSID
        );
        this.SSID = Chatresult.SessionId;
        this.Model = ServiceDataFactory.FormatChatResult(Chatresult);
    }

    [RelayCommand]
    async Task Loaded()
    {
        //https://genshinvoice.top/api ，原神VIST
        
        var jsonpath = Path.Combine(Package.Current.InstalledLocation.Path, "Assets/Vits.json");
        List<string> peoper = JsonSerializer.Deserialize<List<string>>(await File.ReadAllTextAsync(jsonpath));
    }

    [RelayCommand]
    void ClearAsk()
    {
        this.SSID = null;
        this.Model = null;
    }

    [ObservableProperty]
    string _AskTip;

    [ObservableProperty]
    string _SSID;

    [ObservableProperty]
    BiliChatBubbleModel _Model;

    public void SetData(object value) { }
}
