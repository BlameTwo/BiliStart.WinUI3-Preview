using System.Text.Json.Serialization;

namespace Network.Models.Live;

public class LiveAuthenticationModel
{
    public LiveAuthenticationModel(int uid, int roomid, string key)
    {
        this.Uid = uid;
        this.Roomid = roomid;
        this.Key = key;
    }

    [JsonPropertyName("uid")]
    public long Uid { get; set; }

    [JsonPropertyName("roomid")]
    public int Roomid { get; set; }

    [JsonPropertyName("protover")]
    public int Protover { get; set; } = 3;

    [JsonPropertyName("platform")]
    public string Platform { get; set; } = "web";

    [JsonPropertyName("type")]
    public int Type { get; set; } = 2;

    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;
}
