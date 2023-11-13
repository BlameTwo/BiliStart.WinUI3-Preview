using Bilibili.App.Dynamic.V2;
using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using IAppContracts.Factorys;
using System.Collections.ObjectModel;

namespace IAppContracts.ItemsViewModels.Dynamics;

public interface IDynamicItemViewModel: IItemControlVMBase<Bilibili.App.Dynamic.V2.DynamicItem>
{
    IAppResources<BiliApplication> AppResources { get; }

    IAccountFactory AccountFactory { get; }

    /// <summary>
    /// 类型
    /// </summary>
    DynamicType Card { get; set; }

    /// <summary>
    /// Up主信息
    /// </summary>
    ModuleAuthor ModuleAuthor { get; set; }



    void RefreshData(DynamicItem item);

    /// <summary>
    /// 动态控制字段
    /// </summary>
    ModuleStat ModuleStat { get; set; }


    /// <summary>
    /// 主动态内容
    /// </summary>
    ModuleDynamic ModuleDynamic { get; set; }


    ObservableCollection<Description> HeaderDescDescription { get; set; }

    /// <summary>
    /// 文字说明是否展示
    /// </summary>
    bool DescVisibility { get; set; }

    bool StatVisibility { get; set; }

    IRelayCommand<object> DrawImageCommand { get; }

}
