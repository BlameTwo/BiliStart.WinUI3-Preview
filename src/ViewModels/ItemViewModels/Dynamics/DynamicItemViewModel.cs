using App.Models.Popups;
using Bilibili.App.Dynamic.V2;
using IAppContracts.ItemsViewModels.Dynamics;
using ViewConverter.Models.Dynamic;

namespace ViewModels.ItemViewModels.Dynamics;

/// <summary>
/// 动态Item
/// </summary>
public partial class DynamicItemViewModel : ObservableObject, IDynamicItemViewModel
{
    public DynamicItemViewModel(
        IPopupManagerService popupManagerService,
        IAppResources<BiliApplication> appResources,
        IAccountFactory accountFactory
    )
    {
        PopupManagerService = popupManagerService;
        AppResources = appResources;
        AccountFactory = accountFactory;
    }

    [ObservableProperty]
    DynamicType _Card;

    [ObservableProperty]
    ModuleAuthor _ModuleAuthor;


    [ObservableProperty]
    ModuleDynamic _ModuleDynamic;

    [ObservableProperty]
    ModuleStat _ModuleStat;

    Module _ModuleDesc;

    [ObservableProperty]
    ObservableCollection<Description> _HeaderDescDescription;

    /// <summary>
    /// 简介是否显示（视频转发无效）
    /// </summary>
    [ObservableProperty]
    bool _DescVisibility;

    /// <summary>
    /// 状态栏是否显示 （转发无效）
    /// </summary>
    [ObservableProperty]
    bool _StatVisibility = true;

    public IPopupManagerService PopupManagerService { get; }

    public IAppResources<BiliApplication> AppResources { get; }

    public IAccountFactory AccountFactory { get; }

    public void SetData(Bilibili.App.Dynamic.V2.DynamicItem value)
    {
        this.Card = value.CardType;
        RefreshData(value);
    }

    [RelayCommand]
    void DrawImage(object value)
    {
        List<ImagePopupArgs> args = new();
        foreach (var item in ModuleDynamic.DynDraw.Items)
        {
            args.Add(new(item.Src, item.Width, item.Height));
        }
        PopupManagerService.ShowImagePopup(args);
    }

    public void RefreshData(DynamicItem item)
    {
        foreach (var model in item.Modules)
        {
            if (model.ModuleType == DynModuleType.ModuleAuthor)
            {
                //动态头
                this.ModuleAuthor = model.ModuleAuthor;
            }
            else if (model.ModuleType == DynModuleType.ModuleStat)
            {
                //动态控制字段
                this.ModuleStat = model.ModuleStat;
            }
            else if (model.ModuleType == DynModuleType.ModuleDynamic)
            {
                //动态具体
                this.ModuleDynamic = model.ModuleDynamic;
            }
            else if (model.ModuleType == DynModuleType.ModuleDesc)
            {
                this._ModuleDesc = model;
                foreach (var desc in _ModuleDesc.ModuleDesc.Desc)
                {
                    if (
                        desc.Type == DescType.Goods
                        || desc.Type == DescType.Topic
                        || desc.Type == DescType.Taobao
                    )
                        continue;
                }
                this.HeaderDescDescription = _ModuleDesc.ModuleDesc.Desc.ToObservableCollection();
                this.DescVisibility = true;
            }
            else
            {
                this.DescVisibility = false;
            }
        }
    }
}
