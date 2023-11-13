using Bilibili.App.Dynamic.V2;
using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using IAppContracts.Factorys;
using System.Collections.ObjectModel;

namespace IAppContracts.ItemsViewModels.Dynamics;

public interface IDynamicForwardItemViewModel: IItemControlVMBase<DynamicItem>
{
    IAppResources<BiliApplication> AppResources { get; }

    IAccountFactory AccountFactory { get; }

    ModuleAuthorForward ModuleAuthorForward { get; set; }


    DynamicType Card { get; set; }

    ObservableCollection<Description> HeaderDescDescription { get; set; }


    ModuleDynamic ModuleDynamic { get; set; }

    IRelayCommand<object> DrawImageCommand { get; }
}
