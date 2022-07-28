/* Orca Framework - Assistant : Validation
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0  14010426 1837
 */

using System.Text.RegularExpressions;

namespace AryaVtd.Orca.Assistant
{
    public class Validation
    {
        #region String Validation

        /// <summary>
        /// Check if URL have Valid format
        /// </summary>
        public static bool IsValidUrlFormat(string url)
        {
            bool retVal;
            string urlExpression = @"^(http(s?):\/\/)[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";

            Regex expValidator = new(urlExpression);
            retVal = expValidator.IsMatch(url);

            return retVal;
        }

        /// <summary>
        /// Check if Email have Valid format
        /// </summary>
        public static bool IsValidEmailFormat(string emailAddress)
        {
            bool retVal;
            string emailExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

            Regex expValidator = new(emailExpression);
            retVal = expValidator.IsMatch(emailAddress);

            return retVal;
        }

        /// <summary>
        /// Check if Mobile No have Valid format
        /// </summary>
        public static bool IsValidMobileFormat(string mobileNo)
        {
            bool retVal;
            string mobileExpression = "09[0-3][0-9]-?[0-9]{3}-?[0-9]{4}";

            Regex expValidator = new(mobileExpression);
            retVal = expValidator.IsMatch(mobileNo);

            return retVal;
        }

        /// <summary>
        /// Check if Phone No Valid format
        /// </summary>
        public static bool IsValidPhoneFormat(string phoneNo)
        {
            bool retVal;
            string phoneExpression = "^0[0-9]{2,}[0-9]{7,}$";

            Regex expValidator = new(phoneExpression);
            retVal = expValidator.IsMatch(phoneNo);

            return retVal;
        }

        /// <summary>
        /// Check if Persian Date have Valid format (1[3-4]YY/MM/DD)
        /// </summary>
        public static bool IsValidPersianDateFormat(string emailAddress)
        {
            bool retVal;
            string emailExpression = @"1[34][0-9][0-9]/(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])";

            Regex expValidator = new(emailExpression);
            retVal = expValidator.IsMatch(emailAddress);

            return retVal;
        }

        /// <summary>
        /// Check value for hex color format #ffffff
        /// </summary>
        /// <param name="color">color hex code</param>
        /// <returns>validate status</returns>
        public static bool IsValidColorFormat(string color)
        {
            bool retVal;
            string colorExpression = "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";

            Regex expValidator = new(colorExpression);
            retVal = expValidator.IsMatch(color);

            return retVal;
        }

        /// <summary>
        /// Check value for hex color format #ffffffff with transparency value
        /// </summary>
        /// <param name="color">color hex code</param>
        /// <returns>validate status</returns>
        public static bool IsValidFullColorFormat(string color)
        {
            bool retVal;
            string colorExpression = "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{8}|[A-Fa-f0-9]{3})$";

            Regex expValidator = new(colorExpression);
            retVal = expValidator.IsMatch(color);

            return retVal;
        }

        /// <summary>
        /// Check if Iranian Personal National Code have Valid format
        /// </summary>
        public static bool IsValidNationalCode(string peopleNationalCode)
        {
            bool isValid = false;
            int result = 0;
            int remaining = 0;
            int decrementor = peopleNationalCode.Count() + 1;

            if (peopleNationalCode.Length == 10)
            {
                for (int i = 0; i < peopleNationalCode.Count() - 1; i++)
                {
                    if (decrementor >= 2)
                        result += (int)Char.GetNumericValue(peopleNationalCode, i) * --decrementor;
                }

                int lastCode = (int)Char.GetNumericValue(peopleNationalCode, peopleNationalCode.Count() - 1);
                remaining = (result % 11);

                if (remaining == 0 && remaining == lastCode)
                    isValid = true;
                else if (remaining == 1 && lastCode == 1)
                    isValid = true;
                else if (remaining > 1 && lastCode == (11 - remaining))
                    isValid = true;
                else
                    isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check if Iranian Company National Id have Valid format
        /// </summary>
        public static bool IsValidNationalID(string companyNationalId)
        {
            bool isValid = false;
            int result = 0;
            int remaining = 0;
            string saltString = "2927231917";

            if (companyNationalId.Length == 11)
            {
                int j = 0;

                int beforeParityNum = (int)Char.GetNumericValue(companyNationalId, companyNationalId.Length - 2);

                for (int i = 0; i < companyNationalId.Count() - 1; i++)
                {
                    j = j % 5 == 0 ? 0 : j;
                    result += int.Parse(saltString.Substring(j, 2)) * (beforeParityNum + 2 + (int)Char.GetNumericValue(companyNationalId, i));
                    j += 2;
                }

                int lastCode = (int)Char.GetNumericValue(companyNationalId, companyNationalId.Count() - 1);
                remaining = (result % 11);

                isValid = remaining == lastCode;
            }

            return isValid;
        }

        #endregion
    }
}