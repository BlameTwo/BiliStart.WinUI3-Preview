using System.Text.Json.Serialization;

namespace Network.Models;

/// <summary>
/// 综合性返回类型
/// </summary>
/// <typeparam name="T"></typeparam>
public class ResultCode<T> : ResultBase
    where T : class
{
    [JsonPropertyName("ttl")]
    public int TTl { get; set; }

    /// <summary>
    /// 数据本体
    /// </summary>
    [JsonPropertyName("data")]
    public T Data { get; set; }
}

public class ResultData<T> : ResultBase
    where T : class
{
    [JsonPropertyName("result")]
    public T Result { get; set; }
}

public class LiveMessageData<T>
{
    [JsonPropertyName("cmd")]
    public string Message { get; set; }

    [JsonPropertyName("data")]
    public T Data { get; set; }
}

public class ResultBase
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// 消息
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }
}
