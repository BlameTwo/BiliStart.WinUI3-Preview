using System.Text.Json.Serialization;

namespace Network.Models;

public class TidData : TidDataBase
{
    [JsonPropertyName("uri")]
    public string Uri { get; set; }

    [JsonPropertyName("children")]
    public List<TidDataBase> Children { get; set; }

    [JsonPropertyName("config")]
    public List<TidRegionConfig> Configs { get; set; }

    /// <summary>
    /// 是否为动画相关
    /// </summary>
    [JsonPropertyName("is_bangumi")]
    public int IsAnimation { get; set; }
}

public class TidRegionConfig
{
    [JsonPropertyName("scenes_name")]
    public string Region_Type { get; set; }

    /// <summary>
    /// 布局属性，不用
    /// </summary>
    [JsonPropertyName("scenes_type")]
    public string PanelType { get; set; }
}

public class TidDataBase
{
    [JsonPropertyName("tid")]
    public int Tid { get; set; }

    [JsonPropertyName("reid")]
    public long Region { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("logo")]
    public string Logo { get; set; }

    [JsonPropertyName("goto")]
    public string GoTo { get; set; }

    [JsonPropertyName("param")]
    public string Param { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }
}
