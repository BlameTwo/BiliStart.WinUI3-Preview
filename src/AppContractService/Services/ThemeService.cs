/*
 2023.7.9

应用主题管理服务，其中T类型为BiliApplication
 */


using CommunityToolkit.WinUI.Helpers;
using IAppContracts;
using Windows.UI.ViewManagement;

namespace AppContractService.Services;

public sealed class ThemeService<T> : IThemeService<T>
    where T : BiliApplication
{
    public ElementTheme Theme
    {
        get => _theme;
        set => _theme = value;
    }

    private T _app;
    private ElementTheme _theme;

    public ILocalSetting LocalSetting { get; }
    public string ServiceID { get; set; } = "主体服务";

    public ThemeService(ILocalSetting localSetting)
    {
        LocalSetting = localSetting;
    }

    public async Task InitializeAsync(T app)
    {
        try
        {
            var themestr =
                (await LocalSetting.ReadConfig("AppTheme")).ToString()
                ?? ElementTheme.Default.ToString();
            if (!string.IsNullOrWhiteSpace(themestr.ToString()))
            {
                Theme = (ElementTheme)Enum.Parse(typeof(ElementTheme), themestr.ToString());
            }
        }
        catch (Exception)
        {
            Theme = ElementTheme.Default;
        }
        _app = app;

        await Task.CompletedTask;
    }


    public async Task SetRequestedThemeAsync()
    {
        if (_app.MainWindow.Content is FrameworkElement rootelemet)
        {
            rootelemet.RequestedTheme = Theme;
        }

        await Task.CompletedTask;
    }

    private async Task SaveThemeSetting(ElementTheme theme)
    {
        await LocalSetting.SaveConfig("AppTheme", theme.ToString());
    }

    public async Task SetThemeAsync(ElementTheme theme)
    {
        Theme = theme;
        await SetRequestedThemeAsync();
        await SaveThemeSetting(theme);
    }
}
