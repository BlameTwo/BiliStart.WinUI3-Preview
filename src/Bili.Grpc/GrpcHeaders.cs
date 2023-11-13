namespace BiliStart.Grpc.Models;

public class GrpcHeaders
{
    public const string Bearer = "Bearer";
    public const string Identify = "identify_v1";
    public const string FormUrlEncodedContentType = "application/x-www-form-urlencoded";
    public const string JsonContentType = "application/json";
    public const string GRPCContentType = "application/grpc";
    public const string UserAgent = "User-Agent";
    public const string Referer = "Referer";
    public const string AppKey = "APP-KEY";
    public const string BiliMeta = "x-bili-metadata-bin";
    public const string Authorization = "authorization";
    public const string BiliDevice = "x-bili-device-bin";
    public const string BiliNetwork = "x-bili-network-bin";
    public const string BiliRestriction = "x-bili-restriction-bin";
    public const string BiliLocale = "x-bili-locale-bin";
    public const string BiliFawkes = "x-bili-fawkes-req-bin";
    public const string GRPCAcceptEncodingKey = "grpc-accept-encoding";
    public const string GRPCAcceptEncodingValue = "identity,deflate,gzip";
    public const string GRPCTimeOutKey = "grpc-timeout";
    public const string GRPCTimeOutValue = "20100m";
    public const string Envoriment = "env";
    public const string TransferEncodingKey = "Transfer-Encoding";
    public const string TransferEncodingValue = "chunked";
    public const string TEKey = "TE";
    public const string TEValue = "trailers";
}
