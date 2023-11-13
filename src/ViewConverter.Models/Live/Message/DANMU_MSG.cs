using CommunityToolkit.Mvvm.ComponentModel;
using Network.Models.Enum;
using Network.Models.Live;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ViewConverter.Models.Live.Message;

/*
  CommentText = obj["info"][1].ToString();
                            CommentUser = obj["info"][2][1].ToString();
                            IsAdmin = obj["info"][2][2].ToString() == "1";
                            IsVip = obj["info"][2][3].ToString() == "1";
                            DmType = Convert.ToInt32(obj["info"][0][1]);
                            Fontsize = Convert.ToInt32(obj["info"][0][2]);
                            Color = Convert.ToInt32(obj["info"][0][3]);
                            SendTimestamp = Convert.ToInt64(obj["info"][0][4]);
                            UserHash = obj["info"][0][7].ToString();
                            MsgType = MsgTypeEnum.Comment;
 
 
 */

[INotifyPropertyChanged]
public partial class DANMU_MSG : ILiveMessageModel
{
    [JsonPropertyName("cmd")]
    public string Message { get; set; }

    [JsonPropertyName("info")]
    public List<object> Info
    {
        get { return _info; }
        set
        {
            _info = value;
            Format = DNAMU_MSG_Format.Format(value);
        }
    }

    [JsonPropertyName("dm_v2")]
    public string DmV2 { get; set; }

    private DNAMU_MSG_Format _format;

    private List<object> _info;

    [JsonIgnore]
    public DNAMU_MSG_Format Format
    {
        get => _format;
        set => SetProperty(ref _format, value);
    }

    [JsonIgnore]
    public LiveMessageType MessageType => LiveMessageType.DanmakuMSG;
}

public class DNAMU_MSG_Format
{
    public string MSG { get; set; }

    public long UserMid { get; set; }

    public string UserName { get; set; }

    public int MSGType { get; set; }

    public bool IsVip { get; set; }

    public int FontSize { get; set; }

    internal static DNAMU_MSG_Format Format(List<object> info)
    {
        DNAMU_MSG_Format format = new();
        if (info[0] is JsonElement statejson)
        {
            JsonArray array = JsonArray.Create(statejson)!;
            format.MSGType = array[1].GetValue<int>();
            format.FontSize = array[2].GetValue<int>();
        }
        if (info[2] is JsonElement userjson)
        {
            JsonArray array = JsonArray.Create(userjson)!;
            format.UserMid = array[0]!.GetValue<long>();
            format.UserName = array[1]!.GetValue<string>();
            format.IsVip = array[3]!.GetValue<int>() == 1;
        }
        format.MSG = info[1].ToString();
        return format;
    }
}
