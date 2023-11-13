using IAppContracts.Bases;
using System.Collections.Generic;

namespace IAppContracts;

public interface IFactoryBase
{
    public T SetData<T, Value>(Value data)
        where T : IItemControlVMBase<Value>;

    public List<T> SetDataToList<T, Value>(List<Value> values)
        where T : IItemControlVMBase<Value>;
}
