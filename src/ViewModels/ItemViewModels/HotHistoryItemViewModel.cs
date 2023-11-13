using IAppContracts.ItemsViewModels;
using Network.Models.Totals.HotHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ItemViewModels
{
    public partial class HotHistoryItemViewModel : ObservableObject,IHotHistoryItemViewModel
    {
        public HotHistoryItemViewModel(ITabCreateMethodService tabCreateMethodService)
        {
            TabCreateMethodService = tabCreateMethodService;
        }

        [ObservableProperty]
        HotHistoryNavItem _Base;

        public ITabCreateMethodService TabCreateMethodService { get; }

        [RelayCommand]
        void GoAction()
        {
            TabCreateMethodService.GoNavigationPlayer(new() { Aid = Base.ItemId});
        }

        public void SetData(HotHistoryNavItem value)
        {
            this.Base = value;
        }
    }
}
