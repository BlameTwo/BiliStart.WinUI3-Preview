namespace App.Models.AppTabView;
/// <summary>
/// 视图参数
/// </summary>
/// <param name="ViewKey">ViewKey</param>
/// <param name="Header">标题</param>
/// <param name="IsCloseVisibility">是否支持关闭</param>
/// <param name="Icon">图标</param>
/// <param name="ServiceKey">服务Key</param>
public record TabViewArgs(string ViewKey,string Header,bool IsCloseVisibility,string Icon,string ServiceKey);

/// <summary>
/// TabView长度改变
/// </summary>
public record TabLengthChangedMessager(bool args);