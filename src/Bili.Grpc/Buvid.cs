using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BiliStart.Grpc.Models;

public class Buvid
{
    private readonly string _mac;

    public Buvid(string macAddress) => _mac = macAddress;

    public string Generate()
    {
        var buvidPrefix = "XY";
        var inputStrMd5 = GetMd5Hash(_mac.Replace(":", string.Empty));

        var buvidRaw = new StringBuilder();
        _ = buvidRaw.Append(buvidPrefix);
        _ = buvidRaw.Append(inputStrMd5[2]);
        _ = buvidRaw.Append(inputStrMd5[12]);
        _ = buvidRaw.Append(inputStrMd5[22]);
        _ = buvidRaw.Append(inputStrMd5);

        return buvidRaw.ToString();
    }

    private static string GetMd5Hash(string input)
    {
        using var md5 = MD5.Create();
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = md5.ComputeHash(inputBytes);
        var sb = new StringBuilder();
        foreach (var b in hashBytes)
        {
            _ = sb.Append(b.ToString("x2"));
        }

        return sb.ToString();
    }
}