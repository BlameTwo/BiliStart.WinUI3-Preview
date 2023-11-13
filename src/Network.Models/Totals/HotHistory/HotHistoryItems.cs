using System.Text.Json.Serialization;

namespace Network.Models.Totals.HotHistory;

public class HotHistoryItems
{
    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    [JsonPropertyName("has_more")]
    public int HasMore { get; set; }

    [JsonPropertyName("dy_offset")]
    public string DyOffset { get; set; }

    [JsonPropertyName("cards")]
    public List<HotHsitoryNavCard> Cards { get; set; }

    [JsonPropertyName("attr_bit")]
    public AttrBit AttrBit { get; set; }

    [JsonPropertyName("color")]
    public object Color { get; set; }
}
