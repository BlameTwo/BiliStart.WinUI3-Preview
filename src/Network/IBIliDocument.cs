using Google.Protobuf;
using LanguageExt;
using Network.Models;
using System.Text.Json;

namespace INetwork;

/// <summary>
/// Bili请求数据序列化
/// </summary>
public interface IBIliDocument
{
    /// <summary>
    /// 序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="cancelltoken"></param>
    /// <returns></returns>
    public Task<string> JsonSerializeAsync<T>(
        T value,
        JsonSerializerOptions options = null,
        CancellationToken cancelltoken = default
    )
        where T : class;

    /// <summary>
    /// 反序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <param name="options"></param>
    /// <param name="cancelltoken"></param>
    /// <returns></returns>
    public Task<T> JsonDeserializeAsync<T>(
        string json,
        JsonSerializerOptions options = null,
        CancellationToken cancelltoken = default
    )
        where T : class;

    /// <summary>
    /// 检查Data数据是否合法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="Message"></param>
    /// <param name="Responsemessage"></param>
    /// <returns></returns>
    public Task<ResultCode<T>> CheckDataCode<T>(
        HttpRequestMessage Message,
        HttpResponseMessage Responsemessage
    )
        where T : class;

    public Task<ResultData<T>> CheckDataResult<T>(
        HttpRequestMessage Message,
        HttpResponseMessage Responsemessage
    )
        where T : class;
    public Task<T> ParseMessageAsync<T>(HttpResponseMessage response, MessageParser<T> parser)
        where T : IMessage<T>;
}
