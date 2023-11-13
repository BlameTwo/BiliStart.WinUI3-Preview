using System.Text.Json.Serialization;

namespace Network.Models.ThirdApi;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class BottomSaveButton
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("success_toast")]
    public string SuccessToast { get; set; }
}

public class Config
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("sub_title")]
    public string SubTitle { get; set; }
}

public class BiliBrandModel
{
    [JsonPropertyName("set_option")]
    public SetOption SetOption { get; set; }

    [JsonPropertyName("tabs")]
    public List<Tab> Tabs { get; set; }
}

public class Empty
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("yes")]
    public string Yes { get; set; }

    [JsonPropertyName("no")]
    public string No { get; set; }
}

public class ExitDialog
{
    [JsonPropertyName("empty")]
    public Empty Empty { get; set; }

    [JsonPropertyName("selected")]
    public Selected Selected { get; set; }
}

public class BiliWallpaperList
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("thumb")]
    public string Thumb { get; set; }

    [JsonPropertyName("thumb_hash")]
    public string ThumbHash { get; set; }

    [JsonPropertyName("thumb_size")]
    public int ThumbSize { get; set; }

    [JsonPropertyName("logo_url")]
    public string LogoUrl { get; set; }

    [JsonPropertyName("logo_hash")]
    public string LogoHash { get; set; }

    [JsonPropertyName("logo_size")]
    public int LogoSize { get; set; }

    [JsonPropertyName("mode")]
    public string Mode { get; set; }

    [JsonPropertyName("thumb_name")]
    public string ThumbName { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("show_logo")]
    public bool ShowLogo { get; set; }
}

public class Page
{
    [JsonPropertyName("last_splash_biz_id")]
    public int LastSplashBizId { get; set; }
}

public class Section
{
    [JsonPropertyName("list")]
    public List<BiliWallpaperList> List { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("group_no")]
    public string GroupNo { get; set; }

    [JsonPropertyName("page")]
    public Page Page { get; set; }
}

public class Selected
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("yes")]
    public string Yes { get; set; }

    [JsonPropertyName("no")]
    public string No { get; set; }
}

public class SetOption
{
    [JsonPropertyName("config")]
    public List<Config> Config { get; set; }

    [JsonPropertyName("max_selected")]
    public int MaxSelected { get; set; }

    [JsonPropertyName("max_prompt")]
    public string MaxPrompt { get; set; }

    [JsonPropertyName("default_prompt")]
    public string DefaultPrompt { get; set; }

    [JsonPropertyName("selected_prompt")]
    public string SelectedPrompt { get; set; }

    [JsonPropertyName("overflow_toast")]
    public string OverflowToast { get; set; }

    [JsonPropertyName("empty_toast")]
    public string EmptyToast { get; set; }

    [JsonPropertyName("exit_dialog")]
    public ExitDialog ExitDialog { get; set; }

    [JsonPropertyName("bottom_save_button")]
    public BottomSaveButton BottomSaveButton { get; set; }

    [JsonPropertyName("vip")]
    public Vip Vip { get; set; }
}

public class Tab
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("sections")]
    public List<Section> Sections { get; set; }

    [JsonPropertyName("page")]
    public Page Page { get; set; }
}

public class Vip
{
    [JsonPropertyName("locked")]
    public bool Locked { get; set; }

    [JsonPropertyName("vip_order_promotion")]
    public bool VipOrderPromotion { get; set; }
}


