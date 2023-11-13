

using Bilibili.App.Dynamic.V2;

namespace ViewConverter.Models.Dynamic;

public class DynamicUpListItem
{
    /// <summary>
    /// 是否更新
    /// </summary>
    public bool HASUpdate { get; set; }

    /// <summary>
    /// 相关Uri
    /// </summary>
    public string Uri { get; set; }

    /// <summary>
    /// Uid
    /// </summary>
    public long Uid { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string Face { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public UserItemType ItemCardType { get; set; }

    public LiveState LiveState { get; set; }

    public bool IsRecall { get; set; }
}

public class DynamicUpList
{
    public string Title { get; set; }

    public List<DynamicUpListItem> Items { get; set; } = new();
}
