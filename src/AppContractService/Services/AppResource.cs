namespace AppContractService.Services;

public sealed partial class AppResource : IAppResources<BiliApplication>
{
    BiliApplication _app = null;

    public void InitResouces(BiliApplication app)
    {
        this._app = app;
    }

    public Value GetResource<Value>(string resourceKey)
    {
        _app.Resources.TryGetValue(resourceKey, out var value);
        return (Value)value;
    }
}
