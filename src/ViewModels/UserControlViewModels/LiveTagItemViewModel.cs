using Google.Protobuf.WellKnownTypes;
using IAppContracts.ItemsViewModels;
using IAppContracts.IUserControlsViewModels.LiveControlsViewModels;
using Microsoft.Extensions.DependencyInjection;
using Network.Models.Live;

namespace ViewModels.UserControlViewModels;

public sealed partial class LiveTagItemViewModel : ObservableRecipient, ILiveTagItemViewModel
{
    public LiveTagItemViewModel(
        ILiveProvider liveProvider,
        ILiveItemFactory liveItemFactory
    )
    {
        LiveProvider = liveProvider;
        LiveItemFactory = liveItemFactory;
    }

    int _page = 1;

    [ObservableProperty]
    LiveTagAreaList _DataBase;

    [ObservableProperty]
    ObservableCollection<LiveTagItemNewTag> _Tags = new();

    [ObservableProperty]
    LiveTagItemNewTag _SelectTag;

    [ObservableProperty]
    ObservableCollection<ILiveTagAreaIndexViewModel> _TagItemLists;


    [RelayCommand]
    void Back()
    {
        WeakReferenceMessenger.Default.Send(new LiveTagItemBack(true));
        this.SelectTag = null;
        this.TagItemLists = null;
        this.Tags = null;
    }

    public ILiveProvider LiveProvider { get; }
    public ILiveItemFactory LiveItemFactory { get; }

    [RelayCommand]
    async Task AddData()
    {
        this._page++;
        var result = await LiveProvider.GetLiveTagItemDataAsync(
            DataBase.ParentId,
            DataBase.Id,
            SelectTag.SortType,
            _page
        );
        TagItemLists.ObservableAddRange(LiveItemFactory.CreateLiveTagAreaIndexs(result.Data.List));
    }

    public void GoLivePlayer(LiveTagItemList model)
    {
        
    }

    public async Task RefershDataAsync(LiveTagAreaList data)
    {
        this.DataBase = data;
        ResultCode<LiveTagItemDataModel>? result = await LiveProvider.GetLiveTagItemDataAsync(
            data.ParentId,
            data.Id
        );
        this.Tags = result.Data.NewTags.ToObservableCollection();
        this.SelectTag = Tags[0];
    }
    async partial void OnSelectTagChanged(LiveTagItemNewTag value)
    {
        await RefershOrderByAsync(value);
    }

    async Task RefershOrderByAsync(LiveTagItemNewTag value)
    {
        if (value == null) return;
        this._page = 1;
        ResultCode<LiveTagItemDataModel>? result = await LiveProvider.GetLiveTagItemDataAsync(
            DataBase.ParentId,
            DataBase.Id,
            value.SortType,
            this._page
        );
        this.TagItemLists = LiveItemFactory
            .CreateLiveTagAreaIndexs(result.Data.List)
            .ToObservableCollection();
    }


    [RelayCommand]
    async Task SelectTagChanged(LiveTagItemNewTag value)
    {
        await RefershOrderByAsync(value);
    }

}
