/* Orca Framework - Assistant : NumberUtility
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0  14010426 1837
 */

using System.Globalization;

namespace AryaVtd.Orca.Assistant
{
    public static class NumberUtility
    {
        #region Private Fields

        private static readonly string[] Yakan = new[] { "صفر", "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" };
        private static readonly string[] Dahgan = new[] { "", "", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
        private static readonly string[] Dahyek = new[] { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };
        private static readonly string[] Sadgan = new[] { "", "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };
        private static readonly string[] Basex = new[] { "", "هزار", "میلیون", "میلیارد", "تریلیون", "تریلیارد", "کوآدریلیون" };
        private static readonly string[] Aashar = new[] { "ممیز", "دهم", "صدم", "هزارم", "ده هزارم", "صدهزارم", "میلیونیم" };

        public static readonly string ThosandSeperator = "٬";

        #endregion

        #region Number Methods

        /// <summary>
        /// تبدیل عدد اعشاری به معادل حرفی
        /// <para>فقط تا 5 رقم اعشار</para>
        /// </summary>
        /// <param name="floatNumber">عدد اعشاری</param>
        /// <seealso cref="ConvertNumberToWords(string)"/>
        /// <returns>معادل حرفی</returns>
        public static string ConvertFloatNumberToWords(string floatNumber)
        {
            string retVal;
            string integerPartWord;
            string decimalPartWord;
            string integerPart = floatNumber;

            string decimalPart = string.Empty;
            if (floatNumber.Contains("."))
            {
                decimalPart = floatNumber.Substring(floatNumber.IndexOf(".")).Replace(".", "");
                integerPart = floatNumber.Substring(0, floatNumber.IndexOf("."));
                if (decimalPart.Length > 6)
                    decimalPart = decimalPart.Substring(0, 6);
            }

            integerPartWord = ConvertNumberToWords(integerPart);
            int.TryParse(decimalPart, out int decimalPartValue);
            if (decimalPart.Length > 0 && decimalPartValue != 0)
            {
                decimalPartWord = ConvertNumberToWords(decimalPart);
                retVal = $"{integerPartWord} {Aashar[0]} {decimalPartWord} {Aashar[decimalPart.Length]}";
            }
            else
            {
                retVal = $"{integerPartWord}";
            }

            return retVal;
        }

        /// <summary>
        /// تبدیل عدد به معادل حرفی
        /// </summary>
        /// <param name="lNumber">عدد غیر اعشاری و غیر منفی (می تواند کاما داشته باشد)</param>
        /// <returns>معادل حرفی عدد</returns>
        public static string ConvertNumberToWords(string lNumber)
        {
            string retVal = "";

            lNumber = lNumber.Replace(",", "").Replace("،", "").Replace("٬", "");

            if (long.TryParse(lNumber, out long tNumber))
            {
                if (lNumber == "" || lNumber == "0")
                {
                    retVal = Yakan[0];
                }
                else
                {
                    lNumber = lNumber.PadLeft(((lNumber.Length - 1) / 3 + 1) * 3, '0');
                    int L = lNumber.Length / 3 - 1;
                    for (int i = 0; i <= L; i++)
                    {
                        int b = int.Parse(lNumber.Substring(i * 3, 3));
                        if (b != 0)
                            retVal = retVal + GetNum3(b) + " " + Basex[L - i] + " و ";
                    }
                    retVal = retVal.Substring(0, retVal.Length - 3);
                }
            }
            else
            {
                retVal = Yakan[0];
            }

            return retVal;
        }

        private static string GetNum3(int num3)
        {
            string s = "";
            int d3, d12;
            d12 = num3 % 100;
            d3 = num3 / 100;
            if (d3 != 0)
                s = Sadgan[d3] + " و ";
            if ((d12 >= 10) && (d12 <= 19))
            {
                s += Dahyek[d12 - 10];
            }
            else
            {
                int d2 = d12 / 10;
                if (d2 != 0)
                    s += Dahgan[d2] + " و ";
                int d1 = d12 % 10;
                if (d1 != 0)
                    s += Yakan[d1] + " و ";
                s = s.Substring(0, s.Length - 3);
            };
            return s;
        }

        /// <summary>
        /// تبدیل عدد فارسی به عدد انگلیسی
        /// </summary>
        /// <param name="strNumber">عدد فارسی</param>
        /// <returns>عدد انگلیسی به صورت رشته متنی</returns>
        public static string ConvertNumberPersianToEnglish(string strNumber)
        {
            return strNumber.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3")
                .Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7")
                .Replace("۸", "8").Replace("۹", "9");
        }

        /// <summary>
        /// تبدیل عدد با استفاده از فرهنگ زبان جاری (اعداد فارسی، انگلیسی یا ...)
        /// </summary>
        /// <returns>عدد در زبان جاری</returns>
        public static string ConvertNumberByCulture(object objNumber, CultureInfo newCulture)
        {
            string retVal = "";

            if (objNumber is not null)
            {
                var convertedNumber = objNumber.ToString();
                for (int i = 0; i <= 9; i++)
                    retVal = convertedNumber.Replace(i.ToString(), newCulture.NumberFormat.NativeDigits[i]);
            }

            return retVal;
        }

        /// <summary>
        /// افزودن کاما جدا کننده هزارتایی با در نظر گرفتن اعشار و سایر موارد
        /// </summary>
        public static string ConvertToThosandSepratedNumber(object objNumber)
        {
            string retVal = "";

            if (objNumber is not null)
            {
                try
                {
                    string standardNo = Convert.ToString(objNumber, CultureInfo.InvariantCulture);
                    string floatDigits = string.Empty;

                    if (standardNo.Contains("."))
                    {
                        floatDigits = standardNo.Substring(standardNo.IndexOf("."));
                        standardNo = standardNo.Substring(0, standardNo.IndexOf("."));
                    }

                    retVal = string.Format("{0:N0}", Convert.ToDecimal(standardNo));
                    retVal += floatDigits;
                }
                catch (Exception) { }
            }

            return retVal;
        }

        /// <summary>
        /// حذف کاما جدا کننده هزارتایی
        /// </summary>
        public static string RemoveThosandSepratedComma(string number) => number.Replace(",", "").Replace("،", "").Replace("٬", "");

        #endregion
    }
}