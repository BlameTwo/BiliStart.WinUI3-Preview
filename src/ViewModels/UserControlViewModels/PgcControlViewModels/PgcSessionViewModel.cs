using Network.Models.Bangumi;

namespace ViewModels.UserControlViewModels.PgcControlViewModels;

public sealed partial class PgcSessionViewModel : ObservableObject, IPgcSessionViewModel
{
    [ObservableProperty]
    BangumiDetilyModel _DataBase;

    public void SetData(BangumiDetilyModel value)
    {
        _DataBase = value;
    }
}
