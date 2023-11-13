using App.Models.Popups;
using Bilibili.App.Dynamic.V2;
using IAppContracts.ItemsViewModels.Dynamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ItemViewModels.Dynamics
{
    public partial class DynamicForwardItemViewModel
        : ObservableRecipient,
            IDynamicForwardItemViewModel
    {
        public DynamicForwardItemViewModel(
            IAppResources<BiliApplication> appResources,
            IAccountFactory accountFactory,
        IPopupManagerService popupManagerService
        )
        {
            AppResources = appResources;
            AccountFactory = accountFactory;
            PopupManagerService = popupManagerService;
        }

        public void SetData(DynamicItem value)
        {
            RefreshData(value);
        }

        [ObservableProperty]
        ModuleAuthorForward _ModuleAuthorForward;

        [ObservableProperty]
        ModuleDynamic _ModuleDynamic;

        public IAppResources<BiliApplication> AppResources { get; }

        public IAccountFactory AccountFactory { get; }
        public IPopupManagerService PopupManagerService { get; }

        [ObservableProperty]
        public DynamicType _Card;

        [ObservableProperty]
        public ObservableCollection<Description> _HeaderDescDescription;

        [RelayCommand]
        void DrawImage(object value) 
        {
            List<ImagePopupArgs> args = new();
            foreach (var item in this.ModuleDynamic.DynDraw.Items)
            {
                args.Add(new(item.Src, item.Width, item.Height));
            }
            PopupManagerService.ShowImagePopup(args);
        }

        private void RefreshData(DynamicItem value)
        {
            this.Card = value.CardType;
            foreach (var item in value.Modules)
            {
                switch (item.ModuleType)
                {
                    case DynModuleType.ModuleAuthorForward:
                        this.ModuleAuthorForward = item.ModuleAuthorForward;
                        break;
                    case DynModuleType.ModuleDynamic:
                        this.ModuleDynamic = item.ModuleDynamic;
                        break;
                    case DynModuleType.ModuleDesc:
                        this.HeaderDescDescription = item.ModuleDesc.Desc.ToObservableCollection();
                        break;
                }
            }
        }
    }
}
