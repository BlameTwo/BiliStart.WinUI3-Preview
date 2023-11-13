using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;
using System.Data;

namespace AppContractService.Services;

public class AppNotificationService : IAppNotificationService
{
    AppNotificationManager _manager = null;

    public ILogger Logger { get; }

    public AppNotificationService(ILogger logger)
    {
        _manager = AppNotificationManager.Default;
        _manager.NotificationInvoked += _manager_NotificationInvoked;
        _manager.Register();
        Logger = logger;
        Logger.Information("Windows通知监听启动");
    }

    private void _manager_NotificationInvoked(
        AppNotificationManager sender,
        AppNotificationActivatedEventArgs args
    ) 
    { 
        
    }

    public Task SendLoginToken(AccountToken token)
    {
        var newdt = new DateTime();
        newdt.AddSeconds(token.Expires_in);
        var builder = new AppNotificationBuilder()
            .AddText($"检测到登录账号：{token.Mid}")
            .AddText($"Token有效时长为:{newdt.Year}年{newdt.Year}月{newdt.Year}日")
            .BuildNotification();
        _manager.Show(builder);
        return Task.CompletedTask;
    }
}
