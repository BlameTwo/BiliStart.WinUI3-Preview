using Network.Models.Videos;
using System.Text.Json.Serialization;

namespace Network.Models.Accounts;

public class HomeVideoModel
{
    [JsonPropertyName("items")]
    public List<VideoItem> Items { get; set; }
}
