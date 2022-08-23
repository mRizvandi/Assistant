/* Orca Framework - Assistant : Shamsi Date Converter
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0	13991106 1553 Based on Gelavizh DateConverter Version 2.5
 */

using System.Globalization;

namespace AryaVtd.Orca.Assistant
{
	public enum PersianDateNameEnum
	{
		Normal = 1,
		WithoutYear = 2
	}

	/// <summary>
	/// Convert Persian date to Gregorian date and reverse
	/// </summary>
	public class ShamsiDate
	{
		#region Properties

		/// <summary>
		/// Get Current Month in 2 Digit Format
		/// </summary>
		public static string CurrentMonth
		{ get { return GetShamsiToday().Substring(5, 2); } }

		/// <summary>
		/// Get First Day of Current Month
		/// </summary>
		public static string CurrentYear
		{ get { return GetShamsiToday().Substring(0, 4); } }

		/// <summary>
		/// Get First Day of Current Month
		/// </summary>
		public static string CurrentMonthFirstDay
		{ get { return GetShamsiToday().Substring(0, 8) + "01"; } }

		/// <summary>
		/// Get Last Day of Current Month
		/// </summary>
		public static string CurrentMonthLastDay
		{
			get
			{
				PersianCalendar pc = new PersianCalendar();
				string ShamsiNow = GetShamsiToday();
				string retVal = ShamsiNow.Substring(0, 8);
				int iYear = Convert.ToInt32(ShamsiNow.Substring(0, 4));

				if (Convert.ToByte(ShamsiNow.Substring(5, 2)) <= 6)
					retVal += "31";
				else if ((Convert.ToByte(ShamsiNow.Substring(5, 2)) < 12) || (pc.IsLeapYear(iYear)))
					retVal += "30";
				else
					retVal += "29";

				return retVal;
			}
		}

		/// <summary>
		/// Check IsLeap Year of CurrentYear
		/// </summary>
		public static bool CurrentYearIsLeapYear
		{
			get
			{
				PersianCalendar pc = new PersianCalendar();
				int iYear = Convert.ToInt32(ConvertToShamsiDate(DateTime.Now).Substring(0, 4));
				return pc.IsLeapYear(iYear);
			}
		}

		/// <summary>
		/// Get Current Date in Persian format (Lookalike GetShamsiToday() Method)
		/// </summary>
		public static string Now
		{ get { return GetShamsiToday(); } }

		#endregion

		#region Convert Date Methods Ver 2.5

		public static string ConvertToShamsiDate(DateTime gregorianDate)
		{
			string strYear = "";
			string strMonth = "";
			string strDay = "";
			try
			{
				PersianCalendar persianCalendar = new PersianCalendar();
				strYear = persianCalendar.GetYear(gregorianDate).ToString();
				strMonth = persianCalendar.GetMonth(gregorianDate).ToString();
				strDay = persianCalendar.GetDayOfMonth(gregorianDate).ToString();

				if (strMonth.Length == 1)
					strMonth = "0" + strMonth;
				if (strDay.Length == 1)
					strDay = "0" + strDay;
			}
			catch (Exception ex)
			{
#if DEBUG
				throw new Exception("خطا در تبدیل تاریخ!" + ex.Message);
#endif
			}

			return strYear + "/" + strMonth + "/" + strDay;
		}

		public static string ConvertToShamsiDate(int gregorianDate)
		{
			DateTime dt;
			dt = Convert.ToDateTime(gregorianDate.ToString("0000/00/00"));

			return ConvertToShamsiDate(dt);
		}

		public static string ConvertToShamsiDate(string gregorianDate)
		{
			int iYear = Convert.ToInt32(gregorianDate.Substring(0, 4));
			int iMonth = Convert.ToInt32(gregorianDate.Substring(4, 2));
			int iDay = Convert.ToInt32(gregorianDate.Substring(6, 2));

			DateTime dt = new DateTime(iYear, iMonth, iDay);
			return ConvertToShamsiDate(dt);
		}

		public static DateTime ConvertToGregorianDate(string persianDate)
		{
			string strYear = persianDate.Substring(0, 4);
			string strMonth = persianDate.Substring(5, 2);
			string strDay = persianDate.Substring(8, 2);

			PersianCalendar persianCalendar = new PersianCalendar();
			return persianCalendar.ToDateTime(int.Parse(strYear), int.Parse(strMonth), int.Parse(strDay), 0, 0, 0, 0);
		}

		#endregion

		#region Public Utility Methods

		/// <summary>
		/// Get Persian Complete Date and Return Month Name
		/// </summary>
		/// <param name="persianDate">Complete Persian Date</param>
		/// <returns>Month name of Persian date or empty string</returns>
		public static string GetPersianMonthName(string persianDate)
		{
			string monthName = "";
			int month = Convert.ToInt16(persianDate.Substring(5, 2));

			switch (month)
			{
				case 1:
					monthName = "فروردین";
					break;

				case 2:
					monthName = "اردیبهشت";
					break;

				case 3:
					monthName = "خرداد";
					break;

				case 4:
					monthName = "تیر";
					break;

				case 5:
					monthName = "مرداد";
					break;

				case 6:
					monthName = "شهریور";
					break;

				case 7:
					monthName = "مهر";
					break;

				case 8:
					monthName = "آبان";
					break;

				case 9:
					monthName = "آذر";
					break;

				case 10:
					monthName = "دی";
					break;

				case 11:
					monthName = "بهمن";
					break;

				case 12:
					monthName = "اسفند";
					break;

				default:
					monthName = "";
					break;
			}
			return monthName;
		}

		/// <summary>
		/// Get day name of Persian from Gregorian date
		/// </summary>
		/// <param param name="gregorianDate">Gregorian date</param>
		/// <returns>Persian day name</returns>
		public static string GetPersianDayName(DateTime gregorianDate)
		{
			string dayName = "";
			System.DayOfWeek dayOfWeek;

			if (gregorianDate.Date > DateTime.MinValue && gregorianDate.Date < DateTime.MaxValue)
			{
				dayOfWeek = gregorianDate.DayOfWeek;
				switch (dayOfWeek)
				{
					case DayOfWeek.Saturday:
						dayName = "شنبه";
						break;

					case DayOfWeek.Sunday:
						dayName = "یکشنبه";
						break;

					case DayOfWeek.Monday:
						dayName = "دوشنبه";
						break;

					case DayOfWeek.Tuesday:
						dayName = "سه شنبه";
						break;

					case DayOfWeek.Wednesday:
						dayName = "چهارشنبه";
						break;

					case DayOfWeek.Thursday:
						dayName = "پنجشنبه";
						break;

					case DayOfWeek.Friday:
						dayName = "جمعه";
						break;
				}
			}
			return dayName;
		}

		/// <summary>
		/// Get Persian Date In Format: DayName, Day MonthName Year
		/// </summary>
		/// <param name="gregorianDate">Gregorian Date</param>
		/// <returns>Persian Date Name In String</returns>
		public static string GetPersianDateName(DateTime gregorianDate, PersianDateNameEnum option = PersianDateNameEnum.Normal)
		{
			string retValue = "";
			string persianDate = ConvertToShamsiDate(gregorianDate);
			string dayName = GetPersianDayName(gregorianDate);
			string monthName = GetPersianMonthName(persianDate);

			switch (option)
			{
				case PersianDateNameEnum.Normal:
					retValue = dayName + "، " + persianDate.ToString().Substring(8, 2) + " " + monthName + " " + persianDate.ToString().Substring(0, 4);
					break;

				case PersianDateNameEnum.WithoutYear:
					retValue = dayName + "، " + persianDate.ToString().Substring(8, 2) + " " + monthName;
					break;

				default:
					break;
			}
			return retValue;
		}

		public static string GetShamsiToday()
		{
			return ConvertToShamsiDate(DateTime.Now);
		}

		/// <summary>
		/// Get shamsi first day of year
		/// </summary>
		/// <param name="year">current year or input value year</param>
		/// <returns>first date in string</returns>
		public static string GetShamsiFirstDayOfYear(int year = 0)
		{
			return (year == 0 ? ConvertToShamsiDate(DateTime.Now).Substring(0, 4) : year.ToString()) + "/01/01";
		}

		/// <summary>
		/// Get Shamsi last day of current year or user defined year
		/// </summary>
		/// <param name="year">0: current year, value: user year</param>
		/// <returns>get last day of year in string</returns>
		public static string GetShamsiLastDayOfYear(int year = 0)
		{
			int iYear = year == 0 ? Convert.ToInt32(ConvertToShamsiDate(DateTime.Now).Substring(0, 4)) : year;
			string lastDay = iYear.ToString();

			PersianCalendar pc = new PersianCalendar();
			if (pc.IsLeapYear(iYear))
				lastDay += "/12/30";
			else
				lastDay += "/12/29";

			return lastDay;
		}

		#endregion
	}
}