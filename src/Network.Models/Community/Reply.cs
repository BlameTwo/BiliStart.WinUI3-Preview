using System.Text.Json.Serialization;

namespace Network.Models.Community;

public class LikeReplyResult
{
    [JsonPropertyName("suc_pic")]
    public string SupPic { get; set; }

    [JsonPropertyName("suc_toast")]
    public string Toast { get; set; }

    /// <summary>
    /// 是否成功
    /// </summary>
    public bool IsFlage { get; set; } = false;
}
