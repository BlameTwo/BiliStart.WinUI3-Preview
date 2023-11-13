using System.Text.Json.Serialization;

namespace Network.Models.Accounts;

public class UserInfo
{
    [JsonPropertyName("mid")]
    public long Mid { get; set; }

    [JsonPropertyName("uname")]
    public string Name { get; set; }

    [JsonPropertyName("face")]
    public string Face { get; set; }
}
