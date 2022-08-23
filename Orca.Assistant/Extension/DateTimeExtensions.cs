/* Orca Framework - Assistant : Shamsi Date and DateTime Extensions
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0	14010525 1010
 */

using System.Globalization;

namespace AryaVtd.Orca.Assistant;

public enum TimeFormatEnum
{
    Normal = 1,
    TwentyFour = 2,
    HourMinute = 3
}

public static class DateTimeExtensions
{
    private const int SECOND = 1;
    private const int MINUTE = 60 * SECOND;
    private const int HOUR = 60 * MINUTE;
    private const int DAY = 24 * HOUR;
    private const int MONTH = 30 * DAY;

    /// <summary>
    /// محاسبه زمان گذشته از زمان جاری و برگشت معادل متنی آن
    /// <para>string relativeTime = GetRelativeTime(DateTime.Now.AddMinutes(-10));</para>
    /// </summary>
    /// <param name="dateTime">تاریخ میلادی</param>
    /// <returns>معادل فارسی وابسته</returns>
    public static string GetRelativeTimeFa(this DateTime dateTime)
    {
        var ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
        double delta = Math.Abs(ts.TotalSeconds);
        if (delta < 1 * MINUTE)
            return ts.Seconds <= 1 ? "لحظه ای قبل" : ts.Seconds + " ثانیه قبل";

        if (delta < 2 * MINUTE)
            return "یک دقیقه قبل";

        if (delta < 45 * MINUTE)
            return ts.Minutes + " دقیقه قبل";

        if (delta < 90 * MINUTE)
            return "یک ساعت قبل";

        if (delta < 24 * HOUR)
            return ts.Hours + " ساعت قبل";

        if (delta < 48 * HOUR)
            return "دیروز";

        if (delta < 30 * DAY)
            return ts.Days + " روز قبل";

        if (delta < 12 * MONTH)
        {
            int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
            return months <= 1 ? "یک ماه قبل" : months + " ماه قبل";
        }

        int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
        return years <= 1 ? "یک سال قبل" : years + " سال قبل";
    }

    /// <summary>
    /// محاسبه زمان گذشته از زمان جاری و برگشت معادل متنی آن
    /// <para>string relativeTime = GetRelativeTimeEn(DateTime.Now.AddMinutes(-10));</para>
    /// </summary>
    /// <param name="dateTime">تاریخ میلادی</param>
    /// <returns>معادل انگلیسی وابسته</returns>
    public static string GetRelativeTimeEn(this DateTime dateTime)
    {
        var ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
        double delta = Math.Abs(ts.TotalSeconds);
        if (delta < 1 * MINUTE)
            return ts.Seconds <= 1 ? "a moment ago" : ts.Seconds + " second ago";

        if (delta < 2 * MINUTE)
            return "a minute ago";

        if (delta < 45 * MINUTE)
            return ts.Minutes + " minutes ago";

        if (delta < 90 * MINUTE)
            return "a hour ago";

        if (delta < 24 * HOUR)
            return ts.Hours + " hours ago";

        if (delta < 48 * HOUR)
            return "yesterday";

        if (delta < 30 * DAY)
            return ts.Days + " days ago";

        if (delta < 12 * MONTH)
        {
            int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
            return months <= 1 ? "a month ago" : months + " months ago";
        }

        int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
        return years <= 1 ? "a year ago" : years + " years ago";
    }

    /// <summary>
    /// محاسبه زمان گذشته از زمان جاری و برگشت معادل متنی آن برحسب کالچر جاری
    /// <para>string relativeTime = GetRelativeTime(DateTime.Now.AddMinutes(-10), English);</para>
    /// </summary>
    /// <param name="dateTime">تاریخ میلادی</param>
    /// <returns>معادل فارسی یا انگلیسی وابسته</returns>
    public static string GetRelativeTime(this DateTime dateTime)
    {
        string retVal = "";

        switch (CultureInfo.CurrentCulture.Name)
        {
            case "fa":
                retVal = GetRelativeTimeFa(dateTime);
                break;

            default:
                retVal = GetRelativeTimeEn(dateTime);
                break;
        }

        return retVal;
    }

    /// <summary>
    /// بدست آوردن ساعت از داده تاریخ-ساعت در فرمت مد نظر
    /// </summary>
    /// <param name="gregorianDateTime">تاریخ-ساعت</param>
    /// <param name="option">فرمت مد نظر ساعت</param>
    public static string GetTimeFromDateTime(this DateTime gregorianDateTime, TimeFormatEnum option = TimeFormatEnum.TwentyFour)
    {
        string retValue = "";

        switch (option)
        {
            case TimeFormatEnum.Normal:
                retValue = String.Format("{0:hh:mm:ss}", gregorianDateTime);
                break;

            case TimeFormatEnum.TwentyFour:
                retValue = String.Format("{0:HH:mm:ss}", gregorianDateTime);
                break;

            case TimeFormatEnum.HourMinute:
                retValue = String.Format("{0:HH:mm}", gregorianDateTime);
                break;
        }

        return retValue;
    }
}