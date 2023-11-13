namespace ViewConverter.Models.Dynamic;

public class UserAllModel
{
    /// <summary>
    /// 最近关注的Up主动态
    /// </summary>
    public DynamicUpList DynamicUpList { get; set; }

    /// <summary>
    /// 历史偏移量
    /// </summary>
    public string HistoryOffset { get; set; } = "";

    /// <summary>
    /// 最后一个业务ID
    /// </summary>
    public string Businessid { get; set; } = "";

    public List<Bilibili.App.Dynamic.V2.DynamicItem> DynamicItems { get; set; }

    /// <summary>
    /// 是否还有动态
    /// </summary>
    public bool HasMore { get; set; }

    /// <summary>
    /// 本次更新动态数量
    /// </summary>
    public long UpdateCount { get; set; }
}
