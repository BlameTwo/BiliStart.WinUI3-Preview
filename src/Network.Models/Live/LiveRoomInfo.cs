using System.Text.Json.Serialization;

namespace Network.Models.Live;

public class LiveRoomInfo
{
    [JsonPropertyName("group")]
    public string Group { get; set; }

    [JsonPropertyName("business_id")]
    public int BusinessId { get; set; }

    [JsonPropertyName("refresh_row_factor")]
    public double RefreshRowFactor { get; set; }

    [JsonPropertyName("refresh_rate")]
    public int RefreshRate { get; set; }

    [JsonPropertyName("max_delay")]
    public int MaxDelay { get; set; }

    [JsonPropertyName("token")]
    public string Token { get; set; }

    [JsonPropertyName("host_list")]
    public List<HostList> HostList { get; set; }
}

public class HostList
{
    [JsonPropertyName("host")]
    public string Host { get; set; }

    [JsonPropertyName("port")]
    public int Port { get; set; }

    [JsonPropertyName("wss_port")]
    public int WssPort { get; set; }

    [JsonPropertyName("ws_port")]
    public int WsPort { get; set; }

    [JsonIgnore]
    public Uri ServerWss => new($"wss://{Host}:{WssPort}/sub");
}
