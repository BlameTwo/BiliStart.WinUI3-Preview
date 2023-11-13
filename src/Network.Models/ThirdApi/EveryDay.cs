using System.Text.Json.Serialization;

namespace Network.Models.ThirdApi;

/// <summary>
/// 每日一言数据返回
/// </summary>
public class EveryDayModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("hitokoto")]
    public string Hitokoto { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("from")]
    public string From { get; set; }

    [JsonPropertyName("from_who")]
    public string FromWho { get; set; }

    [JsonPropertyName("creator")]
    public string Creator { get; set; }

    [JsonPropertyName("creator_uid")]
    public int CreatorUid { get; set; }

    [JsonPropertyName("reviewer")]
    public int Reviewer { get; set; }

    [JsonPropertyName("commit_from")]
    public string CommitFrom { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    [JsonPropertyName("length")]
    public int Length { get; set; }
}

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class Datum
{
    [JsonPropertyName("sets")]
    public List<Set> Sets { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }
}

public class EveryDayTotalModel
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("data")]
    public List<Datum> Data { get; set; }

    [JsonPropertyName("ts")]
    public long Ts { get; set; }
}

public class Set
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("created_time")]
    public DateTime CreatedTime { get; set; }
}
