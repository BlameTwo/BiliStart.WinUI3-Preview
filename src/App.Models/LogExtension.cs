using IAppExtension.Contract;
using Serilog;

namespace App.Models;

public static class LogExtension
{
    public static void LogWrite<T>(this ILogger log, string message)
    {
        log.Information($"{nameof(T)}：{message}");
    }
}
