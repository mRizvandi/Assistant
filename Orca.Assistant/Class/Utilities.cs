/* Orca Framework - Assistant : Utilities (Misc Methods)
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0  14010426 1837
 */

namespace AryaVtd.Orca.Assistant
{
    public static class Utilities
    {
        /// <summary>
        /// Generate special SerialId as unique id for database based on date time
        /// </summary>
        /// <param name="offset">offset can reduce SerialId number</param>
        /// <returns></returns>
        public static long GetSerialId(DateTime? offset = null)
        {
            DateTime myDate1;
            if (offset == null)
                myDate1 = new DateTime(2000, 1, 1, 0, 0, 00);
            else
                myDate1 = (DateTime)offset;

            DateTime myDate2 = DateTime.Now;

            long p = (myDate2.Ticks / 10000000) - (myDate1.Ticks / 10000000);

            return p;
        }

        /// <summary>
        /// Generate Unique Id based on gGuid without "-"
        /// </summary>
        public static string GetUniqueId() => Guid.NewGuid().ToString().Replace("-", "");

        /// <summary>
        /// Generate Small Unique Id base on random string and random number
        /// <para>Random string length is 3, and Random Number has 5 length</para>
        /// </summary>
        /// <returns></returns>
        public static string GetSmallUniqueId() => RandomUtility.GetRandomString(3) + RandomUtility.GetRandomNumber(10000, 99999).ToString();
    }
}