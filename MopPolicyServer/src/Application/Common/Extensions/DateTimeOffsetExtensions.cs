using System.Globalization;

namespace MopPolicyServer.Application.Common.Extensions;

public static class DateTimeOffsetExtensions
{
    public static string ToShortDateTimeString(this DateTimeOffset @this)
    {
        return @this.ToString("g", DateTimeFormatInfo.CurrentInfo);
    }
}
