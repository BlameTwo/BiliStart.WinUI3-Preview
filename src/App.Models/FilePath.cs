using System;
using System.IO;

namespace App.Models;

public static class FilePath
{
    public static string AppPath { get; } = AppDomain.CurrentDomain.BaseDirectory;
    public static string PluginPath { get; } =
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "\\BiliStartDesktop\\",
            "Plugins"
        );

    public static string VideoDownloadPath { get; } =
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) + "\\BIliStartDownload"
        );

    public static string LogPath { get; } =
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "\\BiliStartDesktop\\"
                + "\\logs"
        );

    /// <summary>
    /// 检查文件夹是否存在
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns>-1为不存在后创建，0为存在不创建</returns>
    public static int CheckFolder(this string path)
    {
        if (Directory.Exists(path))
        {
            return 0;
        }
        Directory.CreateDirectory(path);
        return -1;
    }
}
