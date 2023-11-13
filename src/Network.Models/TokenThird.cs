using Network.Models.Accounts;
using System.Text.Json.Serialization;

namespace Network.Models;

public class TokenThird
{
    [JsonPropertyName("api_host")]
    public string ApiHost { get; set; }

    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("ts")]
    public long Ts { get; set; }

    [JsonPropertyName("data")]
    public ThirdData Data { get; set; }
}

public class ThirdData
{
    [JsonPropertyName("user_info")]
    public UserInfo UserInfo { get; set; }

    [JsonPropertyName("confirm_uri")]
    public string ConfirmUrl { get; set; }
}
