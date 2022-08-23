/* Orca Framework - Assistant : NumberUtility
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0  14010426 1837
 */

using System.Globalization;

namespace AryaVtd.Orca.Assistant;

public static class NumberExtension
{
    /// <summary>
    /// تبدیل عدد انگلیسی به عدد فارسی
    /// </summary>
    /// <param name="strNumber">عدد انگلیسی</param>
    /// <returns>عدد فارسی به صورت رشته متنی</returns>
    public static string ToPersianNumber(this string strNumber) =>
        strNumber.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳")
            .Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷")
            .Replace("8", "۸").Replace("9", "۹");

    /// <summary>
    /// تبدیل عدد فارسی به عدد انگلیسی
    /// </summary>
    /// <param name="strNumber">عدد فارسی</param>
    /// <returns>عدد انگلیسی به صورت رشته متنی</returns>
    public static string ToEnglishNumber(this string strNumber) =>
        strNumber.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3")
            .Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7")
            .Replace("۸", "8").Replace("۹", "9");

    /// <summary>
    /// تبدیل عدد به رشته بدون در نظر گرفتن کالچر
    /// </summary>
    public static string ToInvariantCultureString(this byte number) => Convert.ToString(number, CultureInfo.InvariantCulture);

    /// <summary>
    /// تبدیل عدد به رشته بدون در نظر گرفتن کالچر
    /// </summary>
    public static string ToInvariantCultureString(this int number) => Convert.ToString(number, CultureInfo.InvariantCulture);

    /// <summary>
    /// تبدیل عدد به رشته بدون در نظر گرفتن کالچر
    /// </summary>
    public static string ToInvariantCultureString(this long number) => Convert.ToString(number, CultureInfo.InvariantCulture);

    /// <summary>
    /// تبدیل عدد به رشته بدون در نظر گرفتن کالچر
    /// </summary>
    public static string ToInvariantCultureString(this float number) => Convert.ToString(number, CultureInfo.InvariantCulture);

    /// <summary>
    /// تبدیل عدد به رشته بدون در نظر گرفتن کالچر
    /// </summary>
    public static string ToInvariantCultureString(this double number) => Convert.ToString(number, CultureInfo.InvariantCulture);

    /// <summary>
    /// تبدیل عدد به رشته بدون در نظر گرفتن کالچر
    /// </summary>
    public static string ToInvariantCultureString(this decimal number) => Convert.ToString(number, CultureInfo.InvariantCulture);
}