using System;

namespace Lib.Helper;

public static class TimeSpanConvert
{
    public static TimeSpan AddTimeSpanPart(TimeSpan time1, TimeSpan time2)
    {
        bool sign1 = time1 < TimeSpan.Zero,
            sign2 = time2 < TimeSpan.Zero;

        if (sign1 && sign2)
        {
            if (TimeSpan.MinValue - time1 > time2)
            {
                return TimeSpan.MinValue;
            }
        }
        else if (!sign1 && !sign2)
        {
            if (TimeSpan.MaxValue - time1 < time2)
            {
                return TimeSpan.MaxValue;
            }
        }

        return time1 + time2;
    }
}
