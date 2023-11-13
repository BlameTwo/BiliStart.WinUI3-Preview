using System.Text.Json;
using System.Text.Json.Serialization;

namespace Network.Models.Bangumi;

public class BangumiModel
{
    [JsonPropertyName("has_next")]
    public int HAS_Next { get; set; }

    [JsonPropertyName("jump_module_id")]
    public int JumpModuleId { get; set; }

    [JsonPropertyName("next_cursor")]
    [JsonConverter(typeof(BangumiCursorConverter))]
    public BangumiCursor Cursor { get; set; }

    [JsonPropertyName("modules")]
    public List<BangumiModelModule> Modules { get; set; }

    [JsonPropertyName("report")]
    public BangumiReport Report { get; set; }
}

public class BangumiModelModule
{
    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("style")]
    public string Style { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("headers")]
    public List<object> Headers { get; set; }

    [JsonPropertyName("module_id")]
    public int ModuleId { get; set; }

    [JsonPropertyName("module_tag")]
    public string Tag { get; set; }

    [JsonPropertyName("report")]
    public ModuleReport ModuleReport { get; set; }

    [JsonPropertyName("Title")]
    public string Title { get; set; }

    [JsonPropertyName("wid")]
    public List<int> Wid { get; set; }

    [JsonPropertyName("items")]
    public List<ModelItems> Items { get; set; }
}

public class ModelItems
{
    /// <summary>
    /// 左上角角标
    /// </summary>
    [JsonPropertyName("badge")]
    public string Badge { get; set; }

    [JsonPropertyName("badge_type")]
    public int BadgeType { get; set; }

    [JsonPropertyName("cardMaterialId")]
    public int CardMaterialId { get; set; }

    [JsonPropertyName("cover")]
    public string Cover { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("is_preview")]
    public int IsPreview { get; set; }

    [JsonPropertyName("item_show_status")]
    public int ItemShowStatus { get; set; }

    [JsonPropertyName("item_show_type")]
    public int ItemShowType { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("link_type")]
    public int LinkType { get; set; }

    [JsonPropertyName("link_value")]
    public long LinkValue { get; set; }

    [JsonPropertyName("oid")]
    public int Oid { get; set; }

    [JsonPropertyName("score")]
    public int Score { get; set; }

    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("season_styles")]
    public string MovieSession { get; set; }

    [JsonPropertyName("season_type")]
    public int SeasonType { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("unique_id")]
    public string UniqueId { get; set; }

    [JsonPropertyName("new_ep")]
    public NewEp NewEp { get; set; }

    [JsonPropertyName("stat")]
    public BangumiStat Stat { get; set; }

    [JsonPropertyName("report")]
    public BangumiItemReport Report { get; set; }
}

public class BangumiItemReport
{
    [JsonPropertyName("card_type")]
    public string CardType { get; set; }

    [JsonPropertyName("content_type")]
    public string ContentType { get; set; }

    [JsonPropertyName("epid")]
    public string Epid { get; set; }

    [JsonPropertyName("index")]
    public string Index { get; set; }

    [JsonPropertyName("item_id")]
    public string ItemId { get; set; }

    [JsonPropertyName("module_id")]
    public string ModuleId { get; set; }

    [JsonPropertyName("module_type")]
    public string ModuleType { get; set; }

    [JsonPropertyName("oid")]
    public string Oid { get; set; }

    [JsonPropertyName("playlist_id")]
    public string PlaylistId { get; set; }

    [JsonPropertyName("position_id")]
    public string PositionId { get; set; }

    [JsonPropertyName("season_id")]
    public string SeasonId { get; set; }

    [JsonPropertyName("season_type")]
    public string SeasonType { get; set; }
}

public class BangumiStat
{
    [JsonPropertyName("danmaku")]
    public int Danmaku { get; set; }

    [JsonPropertyName("follow")]
    public int Follow { get; set; }

    [JsonPropertyName("follow_view")]
    public string FollowView { get; set; }

    [JsonPropertyName("view")]
    public int View { get; set; }
}

public class NewEp
{
    [JsonPropertyName("Cover")]
    public string Cover { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("index_show")]
    public string IndexShow { get; set; }
}

public class ModuleReport
{
    [JsonPropertyName("module_id")]
    public string ModuleId { get; set; }

    [JsonPropertyName("module_type")]
    public string ModuleType { get; set; }
}

public class BangumiReport
{
    [JsonPropertyName("page_id")]
    public string PageId { get; set; }
}

/// <summary>
/// 游标
/// </summary>
public class BangumiCursor
{
    [JsonPropertyName("feed_line_index")]
    public int FindLine { get; set; }

    [JsonPropertyName("feed_playlist_index")]
    public int FeedPlaylistIndex { get; set; }

    [JsonPropertyName("feed_season_index")]
    public long FeedSeasonIndex { get; set; }
}

public class BangumiCursorConverter : JsonConverter<BangumiCursor>
{
    public override BangumiCursor? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var str = reader.GetString();
        return JsonSerializer.Deserialize<BangumiCursor>(str, options);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BangumiCursor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
