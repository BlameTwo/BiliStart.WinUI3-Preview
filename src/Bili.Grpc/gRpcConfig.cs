using Bilibili.Metadata;
using Bilibili.Metadata.Device;
using Bilibili.Metadata.Fawkes;
using Bilibili.Metadata.Locale;
using Bilibili.Metadata.Network;
using Bilibili.Metadata.Restriction;
using Google.Protobuf;

namespace BiliStart.Grpc.Models;

public class gRpcConfig
{
    public gRpcConfig(string accessToken)
    {
        AccessToken = accessToken;
    }

    public const string OSVersion = "14.6";

    public const string Brand = "Apple";

    public const string Model = "iPhone 11";

    public const string AppVersion = "6.7.0";

    public const string Channel = "bilibili140";

    public const int NetworkType = 2;

    public const int NetworkTF = 0;

    public const string NetworkOid = "46007";

    public const string Cronet = "1.21.0";

    public const string Buvid = "XZFD48CFF1E68E637D0DF11A562468A8DC314";

    public const string MobileApp = "iphone";

    public const string Platform = "iphone";

    public const string Envorienment = "prod";

    public const int AppId = 1;

    public const string Region = "CN";

    public const string Language = "zh";

    public string AccessToken { get; }

    public string GetFawkesreqBin()
    {
        var msg = new FawkesReq();
        msg.Appkey = MobileApp;
        msg.Env = Envorienment;
        return ToBase64(msg.ToByteArray());
    }

    public string GetMetadataBin()
    {
        var msg = new Metadata();
        msg.AccessKey = AccessToken;
        msg.MobiApp = MobileApp;
        msg.Build = 7430300;
        msg.Channel = Channel;
        msg.Buvid = Buvid;
        msg.Platform = Platform;
        return ToBase64(msg.ToByteArray());
    }

    public string GetDeviceBin()
    {
        var msg = new Device();
        msg.AppId = AppId;
        msg.MobiApp = MobileApp;
        msg.Build = 7430300;
        msg.Channel = Channel;
        msg.Buvid = Buvid;
        msg.Platform = Platform;
        msg.Brand = Brand;
        msg.Model = Model;
        msg.Osver = OSVersion;
        return ToBase64(msg.ToByteArray());
    }

    public string GetNetworkBin()
    {
        var msg = new Network();
        msg.Type = Bilibili.Metadata.Network.NetworkType.Wifi;
        msg.Oid = NetworkOid;
        return ToBase64(msg.ToByteArray());
    }

    public string GetRestrictionBin()
    {
        var msg = new Restriction();

        return ToBase64(msg.ToByteArray());
    }

    public string GetLocaleBin()
    {
        var msg = new Locale();
        msg.CLocale = new LocaleIds();
        msg.SLocale = new LocaleIds();
        msg.CLocale.Language = Language;
        msg.CLocale.Region = Region;
        msg.SLocale.Language = Language;
        msg.SLocale.Region = Region;
        return ToBase64(msg.ToByteArray());
    }

    public string ToBase64(byte[] data)
    {
        return Convert.ToBase64String(data);
    }
}
