/* Orca Framework - Assistant : StringUtility
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0  14010426 1837
 */

using System.Text.RegularExpressions;

namespace AryaVtd.Orca.Assistant
{
    public static class StringExtension
    {
        #region String Utility Methods

        /// <summary>
        /// برش تعداد کلمات دلخواه به اندازه تعیین شده و به اندازه حداکثر تعداد کاراکتر تعیین شده
        /// </summary>
        /// <param name="text">متن برای برش زدن</param>
        /// <param name="count">تعداد کلماتی که باید در برش موجود باشد</param>
        /// <param name="addEllipsis">اضافه کردن سه نقطه آخر خط</param>
        /// <param name="maxLength">حداکثر طول متن برش خورده، مقدار پیش فرض 256 کاراکتر</param>
        /// <returns>متن برش خورده</returns>
        public static string GetWords(this string text, int count, bool addEllipsis = true, int maxLength = 128)
        {
            string retValue = "";
            string tmpString = "";
            string[] words;

            tmpString = text.Replace("\r\n", " ");
            words = tmpString.Split(' ');

            if (count <= words.Length)
            {
                for (int i = 0; i < count; i++)
                    retValue += words[i] + " ";
                if (retValue.Length > maxLength && maxLength != 0)
                    retValue = retValue.Substring(0, maxLength);
                if (addEllipsis)
                    retValue += "...";
            }
            else
                retValue = tmpString;

            return retValue.Trim();
        }

        /// <summary>
        /// Remove all HTML tag and element from string (useful for strip user input, msword data and ...)
        /// </summary>
        public static string StripHTML(this string htmlString)
        {
            string retValue = string.Empty;

            if (!string.IsNullOrEmpty(htmlString))
            {
                string pattern = "<.*?>";
                string str = Regex.Replace(htmlString, pattern, string.Empty);
                pattern = "&nbsp;";
                str = Regex.Replace(str, pattern, string.Empty);
                retValue = str;
            }
            return retValue;
        }

        /// <summary>
        /// Cleans up text to make a nice little URL string
        /// </summary>
        public static string ToFriendlyURL(this string strUrl, bool isPersian = true, byte maxLetters = 80)
        {
            string retVal = "";

            if (!string.IsNullOrEmpty(strUrl))
            {
                if (!isPersian)
                {
                    strUrl = strUrl.ToLower();
                    // remove anything that is not letters, numbers, dash, or space
                    strUrl = Regex.Replace(strUrl, @"[^a-z0-9\-\s]", "");
                }

                strUrl = Regex.Replace(strUrl, @"&\w+;", "");// remove entities

                strUrl = strUrl.Replace("™", "").Replace("&trade;", "")
                    .Replace("©", "").Replace("&copy;", "")
                    .Replace(".", "").Replace(":", "")
                    .Replace("?", "").Replace("!", "").Replace("*", "")
                    .Replace("'", "").Replace("\"", "").Replace("%", "")
                    .Replace("/", "").Replace("&", "").Replace("#", "")
                    .Replace("  ", " ").Replace(" ", "-")
                    .Replace("«", "").Replace("»", "")
                    .Replace("،", "").Replace(",", "").Replace("؛", "");

                strUrl = Regex.Replace(strUrl, @"-{2,}", "-");// collapse dashes
                strUrl = strUrl.TrimStart(new[] { '-' });// trim excessive dashes at the beginning
                strUrl = strUrl.TrimEnd(new[] { '-' });// remove trailing dashes

                // if it's too long, clip it
                if (strUrl.Length > maxLetters)
                    strUrl = strUrl.Substring(0, maxLetters - 1);

                retVal = strUrl;
            }
            else
            {
                retVal = string.Empty;
            }

            return retVal;
        }

        /// <summary>
        /// Trim spaces from start or end of string
        /// Remove multiple empty lines
        /// </summary>
        public static string DecorateText(this string text, bool showEmptyAsDash = true, string emptyText = "-")
        {
            string retVal = "";

            if (!string.IsNullOrEmpty(text))
            {
                retVal = Regex.Replace(text, @"^\s+$[\r\n]*", Environment.NewLine, RegexOptions.Multiline);
                retVal = Regex.Replace(retVal, "\r?\n|\r", "<br />");
            }
            else if (showEmptyAsDash)
                retVal = emptyText;

            return retVal;
        }

        public static bool IsExistPersianLetter(this string text)
        {
            bool retVal = false;

            if (!string.IsNullOrEmpty(text))
            {
                string persianPattern = @"^[\u0600-\u06FF\uFB8A\u067E\u0686\u06AF\u200C\u200F ]+$";
                Regex expValidator = new(persianPattern);
                retVal = expValidator.IsMatch(text);
            }

            return retVal;
        }

        /// <summary>
        /// شمارش تعداد صفحه پیامک بر اساس متن (فارسی یا انگلیسی) و تعداد کاراکتر آن
        /// </summary>
        public static int CountSMSPages(this string message)
        {
            int retVal = 0;

            if (!string.IsNullOrEmpty(message))
            {
                bool isPersian = message.IsExistPersianLetter();

                int firstPageCount;
                int secondPageCount;
                int otherPageCount;

                if (isPersian)
                {
                    firstPageCount = 70;
                    secondPageCount = 64;
                    otherPageCount = 67;
                }
                else
                {
                    firstPageCount = 160;
                    secondPageCount = 146;
                    otherPageCount = 153;
                }

                if (message.Length > firstPageCount)
                {
                    if (message.Length > firstPageCount + secondPageCount)
                    {
                        if (message.Length - (firstPageCount + secondPageCount) > 0)
                        {
                            retVal = (message.Length - (firstPageCount + secondPageCount)) / otherPageCount + 2;
                            if ((message.Length - (firstPageCount + secondPageCount)) % otherPageCount > 0)
                                retVal++;
                        }
                    }
                    else
                        retVal = 2;
                }
                else
                    retVal = 1;
            }

            return retVal;
        }

        #endregion
    }
}