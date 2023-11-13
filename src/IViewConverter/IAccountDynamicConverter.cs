using Bilibili.App.Dynamic.V2;
using ViewConverter.Models.Dynamic;

namespace IViewConverter;

public interface IAccountDynamicConverter
{
    public UserAllModel FormatUserAllModel(DynAllReply dynAll);
}
