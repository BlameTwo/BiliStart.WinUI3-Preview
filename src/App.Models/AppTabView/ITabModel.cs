namespace App.Models.AppTabView;

/// <summary>
/// TabView导航内容模型注入方法
/// </summary>
public interface ITabModel
{
    public void RegisterViewModel(object vm);

    public void GoParamter(object value);

    public void UnregisterViewModel();
}
