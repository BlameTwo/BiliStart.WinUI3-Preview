using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models;

public class License
{
    /// <summary>
    /// 许可名称（包名）
    /// </summary>
    public string LicenseName { get; set; }

    /// <summary>
    /// 许可证网址
    /// </summary>
    public string LicenseUrl { get; set; }

    /// <summary>
    /// 许可证项目来源
    /// </summary>
    public string LicenseProject { get; set; }

    public string Desc { get; set; }

    /// <summary>
    /// 获得当前版本所使用的包
    /// </summary>
    /// <returns></returns>
    public static List<License> GetDefault() =>
        new List<License>()
        {
            new()
            {
                LicenseName = "CommunityToolkit Mvvm",
                LicenseUrl = "https://github.com/CommunityToolkit/dotnet/blob/main/License.md",
                LicenseProject = "https://github.com/CommunityToolkit/dotnet",
                Desc = "社区Mvvm"
            },
            new()
            {
                LicenseName = "CommunityToolkit Windows",
                LicenseUrl = "https://github.com/CommunityToolkit/Windows/blob/main/License.md",
                LicenseProject = "https://github.com/CommunityToolkit/Windows",
                Desc = "社区WinUI"
            },
            new()
            {
                LicenseName = "Google.Protobuf",
                LicenseUrl = "https://github.com/protocolbuffers/protobuf/blob/main/LICENSE",
                LicenseProject = "https://github.com/protocolbuffers/protobuf",
                Desc = "gRpc proto文件格式化"
            },
            new()
            {
                LicenseName = "Grpc.Net.Client",
                LicenseUrl = "https://github.com/grpc/grpc-dotnet/blob/master/LICENSE",
                LicenseProject = "https://github.com/grpc/grpc-dotnet",
                Desc = "gRpc客户端"
            },
            new()
            {
                LicenseName = "H.NotifyIcon",
                LicenseUrl = "https://github.com/HavenDV/H.NotifyIcon/blob/master/LICENSE.md",
                LicenseProject = "https://github.com/HavenDV/H.NotifyIcon",
                Desc = "托盘图标"
            },
            new()
            {
                LicenseName = "Dotnet Extenstions",
                LicenseUrl = "https://dot.net/",
                LicenseProject = "https://licenses.nuget.org/MIT",
                Desc = "Dotnet 框架拓展"
            },
            new()
            {
                LicenseName = "WinUI Behaviors",
                LicenseUrl = "https://licenses.nuget.org/MIT",
                LicenseProject = "https://github.com/microsoft/XamlBehaviors",
                Desc = "WinUi行为"
            },
            new()
            {
                LicenseName = "QRCoder",
                LicenseUrl = "https://github.com/codebude/QRCoder/blob/master/LICENSE.txt",
                LicenseProject = "https://github.com/codebude/QRCoder/",
                Desc = "二维码生成"
            },
            new()
            {
                LicenseName = "Serilog",
                LicenseUrl = "https://github.com/serilog/serilog/blob/dev/LICENSE",
                LicenseProject = "https://github.com/serilog/serilog",
                Desc = "日志库"
            },
            new()
            {
                LicenseName = "WinUIEx",
                LicenseProject = "https://github.com/dotMorten/WinUIEx",
                LicenseUrl = "https://github.com/dotMorten/WinUIEx/blob/main/LICENSE",
                Desc = "WinUI 拓展"
            }
        };
}
