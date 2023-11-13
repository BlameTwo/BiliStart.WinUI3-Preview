/*
 2023.7.9

此类主要是异步保存应用的设置信息，可以是对象，也可以是值。
同时异步读取设置信息
*/

using System.Text.Json.Serialization;

namespace AppContractService.Services;

public sealed class LocalSetting : ILocalSetting, IAppService
{
    public LocalSetting(IBIliDocument bIliDocument)
    {
        BIliDocument = bIliDocument;
    }

    public string ServiceID { get; set; } = nameof(LocalSetting);

    /// <summary>
    /// 保存文件名称
    /// </summary>
    public string LocalSettingFileName => "Setting.json";

    /// <summary>
    /// 保存文件夹
    /// </summary>
    public string LocalSettingFolder =>
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BiliStartDesktop\\";

    string file
    {
        get { return Path.Combine(LocalSettingFolder, LocalSettingFileName); }
    }

    public Dictionary<string, object> Config { get; set; }
    public IBIliDocument BIliDocument { get; }

    public async Task<bool> InitSetting(Dictionary<string, object> values)
    {
        var source = Path.Combine(LocalSettingFolder, LocalSettingFileName);
        if (!Directory.Exists(LocalSettingFolder))
            Directory.CreateDirectory(LocalSettingFolder);
        if (!File.Exists(source))
        {
            //不存在文件首先创建
            await initWrite();
            //获取到传入的默认值然后写入并保存
            if (values != null && values.Count > 0)
            {
                this.Config = values;
                save();
            }
            return true;
        }
        await refresh();
        bool saveFlage = false;
        foreach (var item in values)
        {
            if (this.Config.ContainsKey(item.Key))
                continue;
            this.Config.Add(item.Key, item.Value);
            saveFlage = true;
        }
        if (saveFlage)
            save();
        return true;
    }

    public async Task<bool> InitSetting()
    {
        var source = Path.Combine(LocalSettingFolder, LocalSettingFileName);
        if (!Directory.Exists(LocalSettingFolder))
            Directory.CreateDirectory(LocalSettingFolder);
        if (!File.Exists(source))
        {
            await initWrite();
            return true;
        }
        string filestr = File.ReadAllText(file);
        await refresh();
        return true;
    }

    private async Task initWrite()
    {
        await File.WriteAllTextAsync(Path.Combine(LocalSettingFolder, LocalSettingFileName), "");
    }

    async Task refresh()
    {
        await Task.Run(async () =>
        {
            lock (this)
            {
                JsonSerializerOptions options = new(JsonSerializerDefaults.Web);
                options.WriteIndented = true;
                options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
                if (!File.Exists(file))
                    return;
                StreamReader reader = new(file);
                var str = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                if (!string.IsNullOrWhiteSpace(str))
                {
                    Config = JsonSerializer.Deserialize<Dictionary<string, object>>(str, options)!;
                }
                else
                    Config = new();
            }
        });
    }

    public async Task<object> ReadConfig(string key)
    {
        try
        {
            await refresh();
            if (Config.ContainsKey(key))
            {
                object ob = null;
                Config.TryGetValue(key, out ob);
                return ob;
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<T> ReadObjectConfig<T>(string key)
    {
        try
        {
            await refresh();
            if (Config.ContainsKey(key))
            {
                object ob = null;
                Config.TryGetValue(key, out ob);
                if (
                    ob is JsonElement json
                    && (
                        json.ValueKind == JsonValueKind.Object
                        || json.ValueKind == JsonValueKind.Array
                    )
                )
                {
                    return json.Deserialize<T>();
                }
                else
                {
                    throw new Exception("值类型请使用ReadConfig方法");
                }
            }
            else
            {
                return default;
            }
        }
        catch (Exception ex)
        {
            return default;
        }
    }

    public async Task SaveConfig<T>(string key, T value)
    {
        try
        {
            await refresh();
            if (Config.ContainsKey(key))
            {
                Config[key] = value;
            }
            else
            {
                Config.Add(key, value);
            }
            save();
        }
        catch (Exception)
        {
            return;
        }
    }

    public void save()
    {
        File.WriteAllText(
            Path.Combine(LocalSettingFolder, LocalSettingFileName),
            JsonSerializer.Serialize(Config)
        );
    }

    public async Task<bool> DelectConfig(string key)
    {
        if (Config.ContainsKey(key))
        {
            Config.Remove(key);
            save();
            return true;
        }
        return false;
    }
}
