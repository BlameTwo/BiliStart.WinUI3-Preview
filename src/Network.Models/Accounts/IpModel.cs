using System.Text.Json.Serialization;

namespace Network.Models.Accounts;

public class IpModel
{
    [JsonPropertyName("addr")]
    public string Address { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("province")]
    public string Province { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("isp")]
    public string ISP { get; set; }

    [JsonPropertyName("zone_id")]
    public long Server_Zone { get; set; }

    [JsonPropertyName("country_code")]
    public int CountryCode { get; set; }
}
