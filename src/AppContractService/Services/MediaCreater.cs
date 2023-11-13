/*
 2023.7.9
方法来源于云之幻
此类主要为流媒体的创建和管理，使用MPD流媒体协议组装播放请求。
 */



using Windows.Web.Http;

namespace AppContractService.Services;

public sealed class MediaCreater : IMediaCreater, IAppService
{
    public string ServiceID { get; set; } = nameof(MediaCreater);

    public async Task<MediaPlayer> CreateMediaSourceAsync(DashVideo Video, DashVideo Audio)
    {
        Windows.Web.Http.HttpClient httpClient = new();
        httpClient.DefaultRequestHeaders.Referer = new Uri("https://www.bilibili.com");
        httpClient.DefaultRequestHeaders.Add(
            "User-Agent",
            "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36"
        );
        var mpdStr =
            $@"<MPD xmlns=""urn:mpeg:DASH:schema:MPD:2011""  profiles=""urn:mpeg:dash:profile:isoff-on-demand:2011"" type=""static"">
                                  <Period  start=""PT0S"">
                                    <AdaptationSet>
                                      <ContentComponent contentType=""video"" id=""1"" />
                                      <Representation bandwidth=""{Video.BandWidth}"" codecs=""{Video.Codecs}"" height=""{Video.Height}"" id=""{Video.ID}"" mimeType=""{Video.VideoType}"" width=""{Video.Width}"">
                                        <BaseURL></BaseURL>
                                        <SegmentBase indexRange=""{Video.SegmentBase.indexRange}"">
                                          <Initialization range=""{Video .SegmentBase .Initialization}"" />
                                        </SegmentBase>
                                      </Representation>
                                    </AdaptationSet>
                                    {{audio}}
                                  </Period>
                                </MPD>
                                ";

        if (Audio == null)
            mpdStr = mpdStr.Replace("{audio}", "");
        else
        {
            mpdStr = mpdStr.Replace(
                "{audio}",
                $@"<AdaptationSet>
                                      <ContentComponent contentType=""audio"" id=""2"" />
                                      <Representation bandwidth=""{Audio.BandWidth}"" codecs=""{Audio.Codecs}"" id=""{Audio.ID}"" mimeType=""{Audio.VideoType}"" >
                                        <BaseURL></BaseURL>
                                        <SegmentBase indexRange=""{Audio.SegmentBase.indexRange}"">
                                          <Initialization range=""{Audio .SegmentBase .Initialization}"" />
                                        </SegmentBase>
                                      </Representation>
                                    </AdaptationSet>"
            );
        }
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(mpdStr)).AsInputStream();
        var source = await AdaptiveMediaSource.CreateFromStreamAsync(
            stream,
            new Uri(Video.BaseUrl),
            "application/dash+xml",
            httpClient
        );
        var s = source.Status;
        source.MediaSource.DownloadRequested += (s, e) =>
        {
            if (e.ResourceContentType == "audio/mp4" && Audio != null)
            {
                e.Result.ResourceUri = new Uri(Audio.BaseUrl);
            }
        };

        var _videoSource = MediaSource.CreateFromAdaptiveMediaSource(source.MediaSource);
        var MediaPlaybackItem = new MediaPlaybackItem(_videoSource);
        return new MediaPlayer() { Source = MediaPlaybackItem };
    }

    public async Task<MediaPlayer> CreateLiveMediaSourceAsync(string url)
    {
        var httpClient = new HttpClient();
        MediaPlayer player = new();
        httpClient.DefaultRequestHeaders.Add("Referer", "https://live.bilibili.com/");
        httpClient.DefaultRequestHeaders.Add(
            "User-Agent",
            "Mozilla/5.0 BiliDroid/1.12.0 (bbcallen@gmail.com)"
        );
        var source = await AdaptiveMediaSource.CreateFromUriAsync(new Uri(url), httpClient);
        var _videoSource = MediaSource.CreateFromAdaptiveMediaSource(source.MediaSource);
        var _videoPlaybackItem = new MediaPlaybackItem(_videoSource);
        player.Source = _videoPlaybackItem;
        return player;
    }
}
