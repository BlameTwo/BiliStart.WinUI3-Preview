using Network.Models.Bangumi;

namespace ViewModels.UserControlViewModels.PgcControlViewModels;

public sealed partial class PgcPagesViewModel : ObservableObject, IPgcPagesViewModel
{
    [ObservableProperty]
    ObservableCollection<Network.Models.Bangumi.Data_Episodes> _DataEpisodes;

    [ObservableProperty]
    BangumiDetilyModel _DataBase;

    public IPgcDataViewModelFactory PgcDataViewModelFactory { get; }

    public PgcPagesViewModel(IPgcDataViewModelFactory pgcDataViewModelFactory)
    {
        PgcDataViewModelFactory = pgcDataViewModelFactory;
    }

    [RelayCommand]
    void OpenSession()
    {
        WeakReferenceMessenger.Default.Send<OpenPgcSession>(
            new(true, PgcDataViewModelFactory.CreatePgcSessionViewModel(this.DataBase))
        );
    }

    public void SetData(Tuple<BangumiDetilyModel> value)
    {
        this.DataBase = value.Item1;
        foreach (var item in DataBase.Modules)
        {
            if (item.Style == "positive")
            {
                this.DataEpisodes = new ObservableCollection<Data_Episodes>(item.Data.Episodes);
            }
            else if (item.Style == "season")
            {
                //To Do 精彩看点
            }
        }
    }
}
