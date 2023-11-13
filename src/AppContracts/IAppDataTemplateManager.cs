using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Network.Models.Enum;

namespace IAppContracts;

public interface ISearchDataTemplateManager
{
    public NavigationView SearchItemControl { get; set; }
    public void RegisterDt(DataTemplate template, SearchTypeEnum _enum);

    public DataTemplate Video { get; set; }

    public DataTemplate Movie { get; set; }

    public DataTemplate Article { get; set; }
    public DataTemplate Live { get; set; }
    public DataTemplate User { get; set; }

    public DataTemplate PGC { get; set; }

    public DataTemplate GetDataTemplate(SearchTypeEnum _enum);
}
