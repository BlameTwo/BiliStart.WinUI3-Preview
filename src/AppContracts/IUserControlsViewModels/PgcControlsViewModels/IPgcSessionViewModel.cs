using IAppContracts.Bases;
using Network.Models.Bangumi;

namespace IAppContracts.IUserControlsViewModels.PgcControlsViewModels;

public interface IPgcSessionViewModel : IUserControlVMBase<BangumiDetilyModel>
{
    BangumiDetilyModel DataBase { get; set; }
}
