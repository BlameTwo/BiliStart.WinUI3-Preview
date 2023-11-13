using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewConverter.Models;

namespace IAppContracts.ItemsViewModels
{
    public interface IVideoRankItemViewModel : IItemControlVMBase<RankVideo>
    {
        public IAppResources<BiliApplication> AppResources { get; }

        public RankVideo Base { get; set; }

        IRelayCommand GoActionCommand { get; }
    }
}
