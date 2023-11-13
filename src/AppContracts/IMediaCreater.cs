using App.Models;
using Network.Models.Videos;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace Lib.Helper;

public interface IMediaCreater
{
    /// <summary>
    ///  创建流媒体对象
    /// </summary>
    /// <param name="Video">视频信息</param>
    /// <param name="Audio">音频信息</param>
    /// <returns></returns>
    public Task<MediaPlayer> CreateMediaSourceAsync(DashVideo Video, DashVideo Audio);

    public Task<MediaPlayer> CreateLiveMediaSourceAsync(string url);
}
