using IAppContracts.Bases;

namespace AppContractService.Services;

public class FactoryBase : IFactoryBase
{
    public T SetData<T, Value>(Value data)
        where T : IItemControlVMBase<Value>
    {
        var tvalue = AppService.GetService<T>();
        tvalue.SetData(data);
        return tvalue;
    }

    public List<T> SetDataToList<T, Value>(List<Value> values)
        where T : IItemControlVMBase<Value>
    {
        var list = new List<T>();
        foreach (var v in values)
            list.Add(SetData<T, Value>(v));
        return list;
    }
}
