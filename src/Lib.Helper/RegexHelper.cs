using System.Text.RegularExpressions;

namespace Lib.Helper;

public static class RegexHelper
{
    public static string RegexToString(this string str, string regexstr)
    {
        Match match = Regex.Match(str, regexstr);
        if (match.Success)
        {
            string extractedText = match.Groups[1].Value;
            return extractedText;
        }
        return "";
    }
}
