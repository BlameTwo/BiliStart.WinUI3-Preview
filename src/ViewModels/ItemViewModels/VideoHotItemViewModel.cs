using IAppContracts.ItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ItemViewModels
{
    public partial class VideoHotItemViewModel : ObservableObject, IVideoHotItemViewModel
    {
        public VideoHotItemViewModel(
            IAppResources<BiliApplication> appResources,ITabCreateMethodService tabCreateMethodService
        )
        {
            AppResources = appResources;
            TabCreateMethodService = tabCreateMethodService;
        }

        [ObservableProperty]
        HotVideo _Base;


        public IAppResources<BiliApplication> AppResources { get; }
        public ITabCreateMethodService TabCreateMethodService { get; }

        [RelayCommand]
        void GoVideo()
        {
            TabCreateMethodService.GoNavigationPlayer(
                new VideoPlayerArgs()
                {
                    Aid = this.Base.Aid,
                    Bvid = this.Base.Bvid,
                }
            );
        }

        public void SetData(HotVideo value)
        {
            this.Base = value;
        }
    }
}
