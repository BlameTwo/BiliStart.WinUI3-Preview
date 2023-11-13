using System.Text.Json.Serialization;

namespace Network.Models.Live;

public class LiveTagAreaList
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("pic")]
    public string Pic { get; set; }

    [JsonPropertyName("parent_id")]
    public int ParentId { get; set; }

    [JsonPropertyName("parent_name")]
    public string ParentName { get; set; }

    [JsonPropertyName("area_type")]
    public int AreaType { get; set; }

    [JsonPropertyName("tag_type")]
    public int TagType { get; set; }

    [JsonPropertyName("hot_status")]
    public int HotStatus { get; set; }

    [JsonPropertyName("is_new")]
    public bool IsNew { get; set; }

    [JsonPropertyName("update_time")]
    public string UpdateTime { get; set; }
}

public class LiveTagDataModel
{
    [JsonPropertyName("list")]
    public List<LiveTagList> List { get; set; }
}

public class LiveTagList
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("parent_area_type")]
    public int ParentAreaType { get; set; }

    [JsonPropertyName("area_list")]
    public List<LiveTagAreaList> AreaList { get; set; }
}
