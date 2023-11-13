namespace AppContractService.Services;

public class SearchDataTemplateManager : ISearchDataTemplateManager, IAppService
{
    public DataTemplate Video { get; set; }
    public DataTemplate Movie { get; set; }
    public DataTemplate Article { get; set; }
    public DataTemplate Live { get; set; }
    public DataTemplate User { get; set; }
    public DataTemplate PGC { get; set; }
    public DataTemplate Default { get; set; }
    public NavigationView SearchItemControl { get; set; }

    public string ServiceID { get; set; } = nameof(SearchDataTemplateManager);

    public DataTemplate GetDataTemplate(SearchTypeEnum _enum)
    {
        switch (_enum)
        {
            case SearchTypeEnum.Animation:
                return PGC;
            case SearchTypeEnum.Live:
                return Live;
            case SearchTypeEnum.User:
                return User;
            case SearchTypeEnum.Movie:
                return Movie;
            case SearchTypeEnum.Article:
                return Article;
            default:
                return Default;
        }
    }

    public void RegisterDt(DataTemplate template, SearchTypeEnum _enum)
    {
        switch (_enum)
        {
            case SearchTypeEnum.Animation:
                this.PGC = template;
                break;
            case SearchTypeEnum.Live:
                this.Live = template;
                break;
            case SearchTypeEnum.User:
                this.User = template;
                break;
            case SearchTypeEnum.Movie:
                this.Movie = template;
                break;
            case SearchTypeEnum.Article:
                this.Article = template;
                break;
            default:
                this.Default = template;
                break;
        }
    }
}
