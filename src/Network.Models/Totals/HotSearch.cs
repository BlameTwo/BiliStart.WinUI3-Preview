using System.Text.Json.Serialization;

namespace Network.Models.Totals;

/// <summary>
/// 热搜数据
/// </summary>
public class HotSearch
{
    [JsonPropertyName("exp_str")]
    public string ExpStr { get; set; }

    [JsonPropertyName("hotword_egg_info")]
    public string HotWord { get; set; }

    [JsonPropertyName("trackid")]
    public string Trackid { get; set; }

    [JsonPropertyName("list")]
    public List<HotSearchData> Lists { get; set; }
}

public class HotSearchData
{
    [JsonPropertyName("hot_id")]
    public long ID { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("is_commercial")]
    public string IsCommercial { get; set; } = "0";

    [JsonPropertyName("keyword")]
    public string Keyword { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("show_name")]
    public string Title { get; set; }

    [JsonPropertyName("word_type")]
    public int WordType { get; set; }
}
