using System.Text.Json.Serialization;

namespace Network.Models.Accounts;

public class MyInfo
{
    [JsonPropertyName("mid")]
    public int Mid { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("sign")]
    public string Sign { get; set; } = "";

    /// <summary>
    /// 硬币数量
    /// </summary>
    [JsonPropertyName("coins")]
    public double Conins { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    [JsonPropertyName("birthday")]
    public string Birthday { get; set; } = "";

    /// <summary>
    /// 头像链接
    /// </summary>
    [JsonPropertyName("face")]
    public string Face_Image { get; set; } = "";

    /// <summary>
    /// 性别，1为男，2为女
    /// </summary>
    [JsonPropertyName("sex")]
    public int Sex { get; set; }

    /// <summary>
    /// 等级
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    /// <summary>
    /// 用户是否被封禁，0为正常，1为封禁
    /// </summary>
    [JsonPropertyName("silence")]
    public int Silence { get; set; }

    /// <summary>
    /// 大会员信息
    /// </summary>
    [JsonPropertyName("vip")]
    public Vip MyVIp { get; set; } = new Vip();

    /// <summary>
    /// 邮箱是否验证
    /// </summary>
    [JsonPropertyName("email_status")]
    public int EmailState { get; set; }

    /// <summary>
    /// 电话号码是否验证
    /// </summary>
    [JsonPropertyName("tel_status")]
    public int TelState { get; set; }

    /// <summary>
    /// 经验信息
    /// </summary>
    [JsonPropertyName("level_exp")]
    public Level_Exp Exp { get; set; } = new Level_Exp();

    [JsonPropertyName("official")]
    public Official Official { get; set; }
}

public class Vip
{
    /// <summary>
    /// 0为无，1月度，2年度
    /// </summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>
    /// 0无，1有
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>
    /// 会员类型
    /// </summary>
    [JsonPropertyName("label")]
    public VipLabel Label { get; set; } = new VipLabel();

    /// <summary>
    /// 大会员到期时间
    /// </summary>
    [JsonPropertyName("due_date")]
    public long Vip_Stop { get; set; }

    [JsonPropertyName("vip_pay_type")]
    public int VipType { get; set; }

    [JsonPropertyName("theme_type")]
    public int ThemeType { get; set; }

    /// <summary>
    /// 电视会员到期时间
    /// </summary>
    [JsonPropertyName("tv_due_date")]
    public long Tv_Stop { get; set; }
}

public class Official
{
    [JsonPropertyName("role")]
    public int Official_Type { get; set; }

    [JsonPropertyName("title")]
    public string Text { get; set; } = "";

    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }
}

public class VipLabel
{
    /// <summary>
    /// 会员文字
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = "";

    /// <summary>
    /// 会员类型
    /// </summary>

    [JsonPropertyName("label_theme")]
    public string Vip_Type { get; set; } = "";

    /// <summary>
    /// 文字颜色
    /// </summary>
    [JsonPropertyName("text_color")]
    public string Text_Fore { get; set; } = "";

    /// <summary>
    /// 背景颜色
    /// </summary>

    [JsonPropertyName("bg_color")]
    public string Text_Back { get; set; } = "";

    [JsonPropertyName("img_label_uri_hans_static")]
    public string ImageSZhImage { get; set; }
}

public class Level_Exp
{
    /// <summary>
    /// 当前等级
    /// </summary>
    [JsonPropertyName("current_level")]
    public int Level { get; set; }

    /// <summary>
    /// 当前的等级从多少经验开始
    /// </summary>
    [JsonPropertyName("current_min")]
    public double Crrent_Min { get; set; }

    /// <summary>
    /// 当前账户的经验
    /// </summary>
    [JsonPropertyName("current_exp")]
    public double Current_Exp { get; set; }

    /// <summary>
    /// 下一个等级需要多少经验
    /// </summary>
    [JsonPropertyName("next_exp")]
    public double Next_Exp { get; set; }
}
