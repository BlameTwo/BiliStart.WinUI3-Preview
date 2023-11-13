using Bilibili.App.Show.V1;
using Network.Models.Totals;
using Network.Models.Videos;
using ViewConverter.Models;
using ViewConverter.Models.VideoModel;

namespace IViewConverter;

/// <summary>
/// 视频视图转换器
/// </summary>
public interface IVideoViewModelConverter
{
    /// <summary>
    /// 热门视频转换
    /// </summary>
    /// <returns></returns>
    public Task<List<HotVideo>> HotConverterToVideo(List<Bilibili.App.Card.V1.Card> cards);
    public Task<List<RankVideo>> RankConverterToVideo(List<Item> items);

    public Task<HomeVideoBase> HomeConverterToVideo(List<VideoItem> videoItems);

    public Task<SearchModel> SearchAllConverter(
        Bilibili.Polymer.App.Search.V1.SearchAllResponse value,
        string selectstr
    );

    public Task<List<MusicRankCard>> MusicRankToVideo(List<MusicRankItem> items);

    public Task<SearchModel> SearchTypeConverter(
        Bilibili.Polymer.App.Search.V1.SearchByTypeResponse value
    );
}
