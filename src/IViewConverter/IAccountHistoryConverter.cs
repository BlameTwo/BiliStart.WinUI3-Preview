using Bilibili.App.Interface.V1;
using ViewConverter.Models.AccountHistory;

namespace IViewConverter;

public interface IAccountHistoryConverter
{
    public AccountVideoHistoryModel ConverterModel(CursorV2Reply v2Reply);
}
