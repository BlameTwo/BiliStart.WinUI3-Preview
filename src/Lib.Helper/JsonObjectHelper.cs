using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lib.Helper;

public static class JsonObjectHelper
{
    public static async Task<string> JsonSerializeAsync<T>(T value)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            await JsonSerializer.SerializeAsync(stream, value);
            var str = Encoding.UTF8.GetString(stream.ToArray());
            return str;
        }
        ;
    }
}
