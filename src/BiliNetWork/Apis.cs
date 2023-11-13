using System.Security;

namespace BiliNetWork;

public class Apis
{
    #region 登录
    public static string BILIBILI_TV_LOGIN =
        "https://passport.bilibili.com/x/passport-tv-login/qrcode/auth_code";

    public static string BILIBILI_TV_QR_POLL =
        "https://passport.bilibili.com/x/passport-tv-login/qrcode/poll";

    public static string BILIBILI_TV_Third_API = "http://link.acg.tv/forum.php";

    /// <summary>
    /// 因为此key为固定，校验sign也没有任何动态参数，及固定。
    /// </summary>
    public static string BILIBILI_TV_Third =
        "https://passport.bilibili.com/login/app/third?appkey=27eb53fc9058f8c3&api=http%3A%2F%2Flink.acg.tv%2Fforum.php&sign=67ec798004373253d60114caaad89a8c";

    public static string CHECK_TOKEN_AUTO = "https://passport.bilibili.com/x/api/oauth2/info";
    #endregion

    #region 首页推荐
    public static string BILIBILI_FIND_HOME_VIDEO = "https://app.bilibili.com/x/v2/feed/index";
    #endregion

    #region 综合
    public const string VIDEO_RANK =
        "https://grpc.biliapi.net/bilibili.app.show.v1.Rank/RankRegion";

    public const string VIDEO_HOT = "https://grpc.biliapi.net/bilibili.app.show.v1.Popular/Index";
    #endregion


    #region 个人信息
    /// <summary>
    /// 我的历史纪录
    /// </summary>
    public const string HISTORY_CURSOR =
        "https://grpc.biliapi.net/bilibili.app.interface.v1.History/CursorV2";

    /// <summary>
    /// 我的基本信息
    /// </summary>
    public const string ACCOUNT_INFO_URL = "https://app.bilibili.com/x/v2/account/myinfo";

    /// <summary>
    /// 我的头部信息
    /// </summary>
    public const string ACCOUNT_MY_DATA = "https://app.bilibili.com/x/v2/account/mine";

    /// <summary>
    /// 个人消息API
    /// </summary>
    public const string ACCOUNT_MESSAGE = "https://api.bilibili.com/x/msgfeed/unread";

    /// <summary>
    /// 个人消息数据API
    /// </summary>
    public const string ACCOUNT_MESSAGE_DATA = "https://api.bilibili.com/x/msgfeed/reply";

    /// <summary>
    /// 个人空间API
    /// </summary>
    public const string ACCOUNT_SPACE = "https://app.bilibili.com/x/v2/space";

    public const string ACCOUNT_IP = "https://app.bilibili.com/x/resource/ip";
    #endregion

    #region 搜索

    public const string SEARCH_SUGGESTIONS =
        "https://grpc.biliapi.net/bilibili.app.interface.v1.Search/Suggest3";

    public const string SEARCH_ALL =
        "https://grpc.biliapi.net/bilibili.polymer.app.search.v1.Search/SearchAll";

    public const string SEARCH_TYPE =
        "https://grpc.biliapi.net/bilibili.polymer.app.search.v1.Search/SearchByType";

    public const string SEARCH_DEFAULT =
        "https://grpc.biliapi.net/bilibili.app.interface.v1.Search/DefaultWords";

    /// <summary>
    /// 搜索发现
    /// </summary>
    public const string SEARCH_SHOW = "https://app.bilibili.com/x/v2/search/recommend";
    #endregion

    #region 评论
    /// <summary>
    /// 主评论区
    /// </summary>
    public const string REPLY_MAIN =
        "https://grpc.biliapi.net/bilibili.main.community.reply.v1.Reply/MainList";

    /// <summary>
    /// 二级评论区
    /// </summary>
    public const string REPLY_Detail =
        "https://grpc.biliapi.net/bilibili.main.community.reply.v1.Reply/DetailList";

    public const string LIKE_REPLY = "https://api.bilibili.com/x/v2/reply/action";
    #endregion


    /// <summary>
    ///  分区图标
    /// </summary>
    public const string TID_ICON = "https://app.bilibili.com/x/v2/region/index";

    public const string HOT_HISTORY_NAV = "https://app.bilibili.com/x/v2/activity/index";

    public const string HOT_HISTORY_Model = "https://app.bilibili.com/x/v2/activity/inline";

    public const string HOT_HISTORY_LISTITEM = "https://app.bilibili.com/x/v2/activity/like/list";

    #region Bili订阅服务
    /// <summary>
    /// 检查音乐是否订阅
    /// </summary>
    public const string CHECK_MUSIC_RANK_REGISTER =
        "https://api.bilibili.com/x/copyright-music-publicity/toplist/detail";

    public const string BILIBILI_HOT_SEARCH_LIST =
        "https://app.bilibili.com/x/v2/search/trending/ranking";

    /// <summary>
    /// 设置音乐订阅
    /// </summary>
    public const string MUSIC_RANK_REGISTER =
        "https://api.bilibili.com/x/copyright-music-publicity/toplist/subscribe/update";

    public const string MUSCI_RANK_IDLIST =
        "https://api.bilibili.com/x/copyright-music-publicity/toplist/all_period";

    public const string MUSIC_RANKMUSICITEM =
        "https://api.bilibili.com/x/copyright-music-publicity/toplist/music_list";


    public const string BILI_LOTTERY_RESULT =
        "https://api.vc.bilibili.com/lottery_svr/v1/lottery_svr/lottery_notice";
    #endregion

    /// <summary>
    /// 获得视频源
    /// </summary>
    public const string VIDEO_PLAYRUL = "https://api.bilibili.com/x/player/playurl";

    public const string VIDEO_PLAYVIEW = "https://grpc.biliapi.net/bilibili.app.view.v1.View/View";

    #region 视频弹幕
    /// <summary>
    /// 分段视频弹幕
    /// </summary>
    public const string BILI_DANMAKU =
        "https://grpc.biliapi.net/bilibili.community.service.dm.v1.DM/DmSegMobile";

    /// <summary>
    /// 发送视频弹幕
    /// </summary>
    public const string BILI_SEND_DANMAKU = "https://api.bilibili.com/x/v2/dm/post";
    #endregion


    #region PGC
    public const string PGC_VIEW = "https://api.bilibili.com/pgc/view/v2/app/season";

    public const string PGC_PAGE = "https://api.bilibili.com/pgc/page";

    public const string PGC_PLAYURL = "https://api.bilibili.com/pgc/player/web/playurl";
    #endregion


    public const string LIVE_ROOM_INFO =
        "https://api.live.bilibili.com/xlive/web-room/v1/index/getDanmuInfo";

    public const string LIVE_PAGE_FEED =
        "https://api.live.bilibili.com/xlive/app-interface/v2/index/feed";

    public const string LIVE_TAG_DATA =
        "https://api.live.bilibili.com/xlive/app-interface/v2/index/getAreaList";

    public const string LIVE_TAG_DATA_ITEM =
        "https://api.live.bilibili.com/xlive/app-interface/v2/second/getList";

    public const string LIVE_ROOM_GetByINFO =
        "https://api.live.bilibili.com/xlive/app-room/v1/index/getInfoByRoom";

    public const string LIVE_ROOM_GETPLAYINFO =
        "https://api.live.bilibili.com/xlive/app-room/v2/index/getRoomPlayInfo";

    #region Chat
    public const string CHAT_SUBTITLE =
        "https://app.bilibili.com/bilibili.app.search.v2.Search/SubmitChatTask";
    public const string CHAT_RESULT =
        "https://app.bilibili.com/bilibili.app.search.v2.Search/GetChatResult";
    #endregion


    #region 动态相关

    public const string DYNAMICA_TOP_TAB =
        "https://app.bilibili.com/bilibili.app.dynamic.v2.Dynamic/DynTab";

    public const string DYNAMIC_ALL_TYPE =
        "https://app.bilibili.com/bilibili.app.dynamic.v2.Dynamic/DynAll";

    public const string DYNAMIC_VIDEO_TYPE =
        "https://app.bilibili.com/bilibili.app.dynamic.v2.Dynamic/DynVideo";
    #endregion


    public const string APP_SPLASH = "https://app.bilibili.com/x/v2/splash/brand/config";
}

/// <summary>
/// 媒体参数
/// </summary>
public class BangumiParamter
{
    /// <summary>
    /// 纪录片
    /// </summary>
    public const string MoviePlayer = "documentary-operation";

    /// <summary>
    /// TV
    /// </summary>
    public const string TvPlayer = "tv-operation";

    /// <summary>
    /// 电影
    /// </summary>
    public const string Movie = "movie-operation";

    /// <summary>
    /// 番剧
    /// </summary>
    public const string JpAnimation = "bangumi-operation";

    /// <summary>
    /// 国创
    /// </summary>
    public const string ChinaAnimation = "gc-operation";

    /// <summary>
    /// 综艺
    /// </summary>
    public const string Variety = "variety-operation";
}
