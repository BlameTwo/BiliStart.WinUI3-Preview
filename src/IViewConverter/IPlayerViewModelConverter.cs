using Bilibili.App.View.V1;
using ViewConverter.Models;

namespace IViewConverter;

public interface IPlayerViewModelConverter
{
    public Task<PlayerView> GetPlayerViewToModel(ViewReply view);
}
