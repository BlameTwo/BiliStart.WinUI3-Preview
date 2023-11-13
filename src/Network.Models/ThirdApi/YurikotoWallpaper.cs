using System.Text.Json.Serialization;

namespace Network.Models.ThirdApi;

public class YurikotoWallpaperModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("orientation")]
    public string Orientation { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}
