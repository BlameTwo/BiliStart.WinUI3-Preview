namespace Views.Selecter;

public class SearchAllSelecter : DataTemplateSelector
{
    public DataTemplate Video { get; set; }

    public DataTemplate Live { get; set; }

    public DataTemplate User { get; set; }

    public DataTemplate Movie { get; set; }

    public DataTemplate Article { get; set; }

    public DataTemplate Default { get; set; }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        if (item is not ISearchItemViewModel value)
            return Default;
        switch (value.Base.Source.Goto)
        {
            case "av":
                return Video;
            case "movie":
                return Movie;
            case "article":
                return Article;
            case "live":
                return Live;
            case "bangumi":
                return Movie;
            case "author":
                return User;
            default:
                return Default;
        }
    }
}
