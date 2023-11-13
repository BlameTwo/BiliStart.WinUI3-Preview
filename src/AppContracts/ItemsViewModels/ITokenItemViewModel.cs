using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using Network.Models.Accounts;
using System;

namespace IAppContracts.ItemsViewModels;

public interface ITokenItemViewModel : IItemControlVMBase<Tuple<AccountToken, string>>
{
    AccountToken TokenBase { get; set; }

    string TokenFilePath { get; set; }

    MyInfo MyData { get; set; }
    IAsyncRelayCommand LoadedCommand { get; }

    IRelayCommand OpenSourceCommand { get; }
}
