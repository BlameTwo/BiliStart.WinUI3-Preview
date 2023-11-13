namespace BiliNetWork.Providers;

public sealed class MessagerProvider : IMessagerProvider
{
    public MessagerProvider(
        IHttpClientProvider httpClientProvider,
        IRequestMessage requestMessage,
        IBIliDocument bIliDocument
    )
    {
        HttpClientProvider = httpClientProvider;
        RequestMessage = requestMessage;
        BIliDocument = bIliDocument;
    }

    public IHttpClientProvider HttpClientProvider { get; }
    public IRequestMessage RequestMessage { get; }
    public IBIliDocument BIliDocument { get; }

    public async Task<ResultCode<AccountMessage>> GetAccountMessageAsync(
        CancellationToken canceltoken = default
    )
    {
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.ACCOUNT_MESSAGE_DATA,
            RequestType.IOS,
            HttpMethod.Get,
            new(),
            true,
            false,
            true
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<AccountMessage>(request, reponse)!;
    }

    public Task<string> GetMessageDataAsync(CancellationToken canceltoken = default)
    {
        throw new NotImplementedException();
    }
}
