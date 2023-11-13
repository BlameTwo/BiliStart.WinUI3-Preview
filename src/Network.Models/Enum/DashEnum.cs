namespace Network.Models.Enum;

public enum DashEnum
{
    Dash240 = 6,
    Dash360 = 16,
    Dash480 = 32,
    Dash720 = 64,
    Dash720P60 = 74,
    Dash1080 = 80,
    Dash1080More = 112,
    Dash1080P60 = 116,
    Dash4K = 120,
    DashHDR = 125,
    DashDB = 126,
    None = 0
}

/// <summary>
/// 视频流格式
/// </summary>
public enum FnvalEnum
{
    FLV = 0,
    MP4 = 1,
    Dash = 16,
    HDR = 64,
    Fn4K = 128,
    FnDBAudio = 256,
    FnDBVideo = 512,
    Fn8K = 1024,
    AV1 = 2048
}
