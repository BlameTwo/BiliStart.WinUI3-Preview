using System;

namespace Lib.Helper;

public static class TickSpanHelper
{
    public static DateTime UnixConvertToDateTime(object value)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = long.Parse(long.Parse(value.ToString()) + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);
        DateTime targetDt = dtStart.Add(toNow);
        return targetDt;
    }

}
