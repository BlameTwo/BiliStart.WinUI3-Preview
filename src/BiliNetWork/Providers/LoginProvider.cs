using INetwork;
using INetwork.IProviders;
using Network;
using Network.Models;
using Network.Models.Accounts;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BiliNetWork.Providers;

public sealed class LoginProvider : ILoginProvider
{
    public LoginProvider(
        ICurrent current,
        IRequestMessage requestMessage,
        IHttpClientProvider httpClientProvider,
        IBIliDocument bIliDocument
    )
    {
        Current = current;
        RequestMessage = requestMessage;
        HttpClientProvider = httpClientProvider;
        BIliDocument = bIliDocument;
    }

    public ICurrent Current { get; }
    public IRequestMessage RequestMessage { get; }
    public IHttpClientProvider HttpClientProvider { get; }
    public IBIliDocument BIliDocument { get; }

    public async Task<LoginTrueString> PollAutoQRAsync(
        string Qrkey,
        CancellationToken canceltoken = default
    )
    {
        var key = new Dictionary<string, string>();
        key.Add("auth_code", Qrkey);
        key.Add("local_id", Current.LocalID);
        var result = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.BILIBILI_TV_QR_POLL,
            RequestType.Login,
            HttpMethod.Post,
            key,
            false,
            false,
            true
        );
        var dataresult = await HttpClientProvider.SendAsync(result);
        dataresult.EnsureSuccessStatusCode();
        var content = await dataresult.Content.ReadAsStringAsync()!;
        var jsonobj = JsonNode.Parse(content)!;
        switch (jsonobj["code"].GetValue<int>())
        {
            case 0:
                return new LoginTrueString()
                {
                    Check = Checkenum.Yes,
                    Body = jsonobj["data"]!.ToJsonString()
                };
            case 86039:
                return new() { Check = Checkenum.YesOrNo };
            case 86038:
                return new() { Check = Checkenum.OnTime };
        }
        return new();
    }

    public async Task<ResultCode<AccountLoginData>> RefQRAsync(
        CancellationToken canceltoken = default
    )
    {
        var key = new Dictionary<string, string>();
        key.Add("local_id", Current.LocalID);
        var result = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.BILIBILI_TV_LOGIN,
            RequestType.Login,
            HttpMethod.Post,
            key,
            false,
            false,
            true
        );
        var dataresult = await HttpClientProvider.SendAsync(result);
        dataresult.EnsureSuccessStatusCode();
        return await BIliDocument.CheckDataCode<AccountLoginData>(result, dataresult)!;
    }
}
