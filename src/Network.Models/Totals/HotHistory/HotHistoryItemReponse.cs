using System.Text.Json.Serialization;

namespace Network.Models.Totals.HotHistory;

public class HotHistoryItemReponse
{
    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    [JsonPropertyName("has_more")]
    public int HAS_MORE { get; set; }

    [JsonPropertyName("dy_offset")]
    public string Dyoffset { get; set; }

    [JsonPropertyName("attr_bit")]
    public AttrBit AttrBit { get; set; }

    [JsonPropertyName("cards")]
    public List<HotHsitoryNavCard> HotHsitoryNavCards { get; set; }
}
