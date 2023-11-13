namespace IAppContracts.Bases;

public interface IUserControlVMBase<T>
{
    /// <summary>
    /// 设置数据
    /// </summary>
    public void SetData(T value);
}

public interface IItemControlVMBase<T>
{
    public void SetData(T value);
}
