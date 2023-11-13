using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using App.Models.Popups;
using IAppContracts.ItemsViewModels.Dynamics;
using System.Collections.ObjectModel;
using System.Linq;
using Lib.Helper;
using System.Runtime.CompilerServices;


namespace BiliStart.WinUI3.UI.DynamicSelecter;

public sealed partial class DynamicContentPresenter : UserControl
{
    public DynamicContentPresenter()
    {
        this.InitializeComponent();
    }


    public IDynamicItemViewModel Base
    {
        get { return (IDynamicItemViewModel)GetValue(BaseProperty); }
        set { SetValue(BaseProperty, value); }
    }

    public static readonly DependencyProperty BaseProperty = DependencyProperty.Register(
        "Base",
        typeof(IDynamicItemViewModel),
        typeof(DynamicContentPresenter),
        new PropertyMetadata(null, OnBaseChanged)
    );



    private static void OnBaseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is DynamicContentPresenter obj && e.NewValue is IDynamicItemViewModel vm)
        {
            if (vm.Card == Bilibili.App.Dynamic.V2.DynamicType.Av) 
            {
                obj.MainPresent.Content = obj.Base.ModuleDynamic.DynArchive;
                obj.MainPresent.ContentTemplate = vm.AppResources.GetResource<DataTemplate>("AvContentCT");
            }
            else if (vm.Card == Bilibili.App.Dynamic.V2.DynamicType.Draw) 
            {
                obj.MainPresent.Content = obj.Base;
                obj.MainPresent.ContentTemplate = vm.AppResources.GetResource<DataTemplate>("DrawContentCT");
            }
            else if (vm.Card == Bilibili.App.Dynamic.V2.DynamicType.Forward)
            {
                //创建转发属性
                var forwardcard = vm.AccountFactory.CreateDynamicForwardItem(vm.ModuleDynamic.DynForward.Item);
                if (vm.ModuleDynamic.DynForward.Item.CardType ==   Bilibili.App.Dynamic.V2.DynamicType.Av)
                {
                    obj.MainPresent.Content = forwardcard;
                    obj.MainPresent.ContentTemplate = vm.AppResources.GetResource<DataTemplate>("ForwardAvContentCT");
                    
                }
                else if (vm.ModuleDynamic.DynForward.Item.CardType ==  Bilibili.App.Dynamic.V2.DynamicType.Draw)
                {
                    obj.MainPresent.Content = forwardcard;
                    obj.MainPresent.ContentTemplate = vm.AppResources.GetResource<DataTemplate>("ForwardDrawContentCT");
                }
            }
        }
    }
}
