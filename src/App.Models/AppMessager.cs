using Network.Models.Accounts;
using Network.Models.Live;

namespace App.Models;

/// <summary>
/// 登录消息
/// </summary>
/// <param name="token">携带token</param>
/// <param name="IsLoginAsync">是否登录，为false是可以标注退出登录。</param>
public record LoginMessager(AccountToken token, bool IsLoginAsync);

public record TokenSwitchMessager(AccountToken token);

/// <summary>
/// 刷新Total页面中的数据
/// </summary>
/// <param name="key"></param>
/// <param name="isrfresh"></param>
public record TotalRefresh(string key, bool isrfresh);

public record AccountHistoryRefresh(bool isRefersh);

public record CreateMediaSourceModel(
    int BardWidth,
    SeqmentBase Base,
    int Codecs,
    int Height,
    int Id,
    string VideoType,
    int Width,
    string BaseUrl
);

/// <summary>
/// 背景图片相关消息
/// </summary>
/// <param name="imagename"></param>
/// <param name="opacity">透明度</param>
public record ChangedNavigationContentImage(int imagename, double opacity, bool isenable);

public record SeqmentBase(int IndexRange, string Initalization);

public record OpenPgcSession(bool isOpen, object sender);

public record WindowMaxMesssager(bool IsMax);

public record LiveTagItemBack(bool isBack);

public record LiveTagItemGo(LiveTagAreaList data);
