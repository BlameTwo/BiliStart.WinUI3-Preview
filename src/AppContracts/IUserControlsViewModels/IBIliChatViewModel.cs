using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using IAppContracts.ItemsViewModels;
using INetwork;
using System.Collections.ObjectModel;
using ViewConverter.Models.BiliChat;

namespace IAppContracts.IUserControlsViewModels;

public interface IBIliChatViewModel: IUserControlVMBase<object>
{
    ICurrent Current { get; }

    IAsyncRelayCommand<string> RefreshAskCommand { get; }

    IAsyncRelayCommand LoadedCommand { get; }

    IRelayCommand ClearAskCommand { get; }

    string AskTip { get; set; }
    string SSID { get; set;}
    BiliChatBubbleModel Model { get; set; }
}
