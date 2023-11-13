using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IAppContracts;

public interface IFFmpegFormatService
{
    /// <summary>
    /// 检查是否可用
    /// </summary>
    bool IsSupportEnable { get; }

    /// <summary>
    /// FFmpeg文件夹
    /// </summary>
    public string FFmpegFolder { get; set; }

    /// <summary>
    /// Mp4转换
    /// </summary>
    /// <returns></returns>
    public Task StartBiliHEVCProcess(
        string audio,
        string video,
        string outputpath,
        IProgress<(string, double)> progress
    );
}
