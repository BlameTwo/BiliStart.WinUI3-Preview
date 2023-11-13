using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Bases
{
    /// <summary>
    /// 跳转页面的Vm基类
    /// </summary>
    public partial class RootViewModelBases : PageViewModelBase
    {
        public RootViewModelBases(
            IRootNavigationMethod rootNavigationMethod,
            INavigationService navigationService
        )
            : base(rootNavigationMethod)
        {
            NavigationService = navigationService;
        }

        [RelayCommand]
        void Back() => NavigationService.GoBack();

        [RelayCommand]
        void BackMain() => RootNavigationMethod.BackMain();

        public INavigationService NavigationService { get; }
    }
}
