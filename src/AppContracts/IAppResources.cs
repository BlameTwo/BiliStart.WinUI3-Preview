namespace IAppContracts;

public interface IAppResources<T>
    where T : BiliApplication
{
    void InitResouces(T app);

    public Value GetResource<Value>(string resourceKey);
}
