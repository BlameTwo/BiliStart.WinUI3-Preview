using System.Text.Json.Serialization;

namespace Network.Models.ThirdApi;

public class Image
{
    [JsonPropertyName("startdate")]
    public string Startdate { get; set; }

    [JsonPropertyName("fullstartdate")]
    public string Fullstartdate { get; set; }

    [JsonPropertyName("enddate")]
    public string Enddate { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("urlbase")]
    public string Urlbase { get; set; }

    [JsonPropertyName("copyright")]
    public string Copyright { get; set; }

    [JsonPropertyName("copyrightlink")]
    public string Copyrightlink { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("quiz")]
    public string Quiz { get; set; }

    [JsonPropertyName("wp")]
    public bool Wp { get; set; }

    [JsonPropertyName("hsh")]
    public string Hsh { get; set; }

    [JsonPropertyName("drk")]
    public int Drk { get; set; }

    [JsonPropertyName("top")]
    public int Top { get; set; }

    [JsonPropertyName("bot")]
    public int Bot { get; set; }

    [JsonPropertyName("hs")]
    public List<object> Hs { get; set; }
}

/// <summary>
/// Bing Wallpaper数据返回
/// </summary>
public class BingWallpaperModel
{
    [JsonPropertyName("images")]
    public List<Image> Images { get; set; }

    [JsonPropertyName("tooltips")]
    public Tooltips Tooltips { get; set; }
}

public class Tooltips
{
    [JsonPropertyName("loading")]
    public string Loading { get; set; }

    [JsonPropertyName("previous")]
    public string Previous { get; set; }

    [JsonPropertyName("next")]
    public string Next { get; set; }

    [JsonPropertyName("walle")]
    public string Walle { get; set; }

    [JsonPropertyName("walls")]
    public string Walls { get; set; }
}
