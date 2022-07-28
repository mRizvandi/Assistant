/* Orca Framework - Assistant : RandomUtility
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0  14010426 1837
 */

using System.Text;

namespace AryaVtd.Orca.Assistant
{
	public static class RandomUtility
	{
		private static readonly Random random = new();

		#region Random Generation

		/// <summary>
		/// Get Random number in range of Min and Max, default min value is 10,000
		/// </summary>
		public static int GetRandomNumber(int min = 10000, int max = int.MaxValue)
		{
			return random.Next(min, max);
		}

		/// <summary>
		/// Get random chars in string format, default minimum char count is 5 and are UpperCase
		/// </summary>
		public static string GetRandomString(byte size = 5, bool lowerCase = false)
		{
			var builder = new StringBuilder(size);

			char offset = lowerCase ? 'a' : 'A';
			const int lettersOffset = 26; // A...Z or a..z: length = 26

			for (var i = 0; i < size; i++)
			{
				var @char = (char)random.Next(offset, offset + lettersOffset);
				builder.Append(@char);
			}

			return lowerCase ? builder.ToString().ToLower() : builder.ToString();
		}

		/// <summary>
		/// Get special sign character for password and so on
		/// </summary>
		public static string GetRandomSignCharacter()
		{
			char[] signChars = new char[100];

			int j = 0;
			for (int i = 33; i <= 46; i++, j++)
				signChars[j] = (char)i;

			for (int i = 58; i <= 64; i++, j++)
				signChars[j] = (char)i;

			for (int i = 91; i <= 95; i++, j++)
				signChars[j] = (char)i;

			char retVal = signChars[random.Next(0, j)];

			return retVal.ToString();
		}

		/// <summary>
		/// Generates a random password
		/// <para>
		/// default values: letters: 3, digits = 2, uppercase letters = 2 and sign characters = 1
		/// </para>
		/// </summary>
		/// <param name="letters">lower case letters</param>
		/// <param name="digits">a number in digits</param>
		/// <param name="uppercaseletters">upper case letters</param>
		/// <param name="signchars">sign characters</param>
		/// <returns>string as password</returns>
		public static string GetRandomPassword(byte letters = 3, byte digits = 2, byte uppercaseletters = 2, byte signchars = 1)
		{
			var passwordBuilder = new StringBuilder();

			passwordBuilder.Append(GetRandomString(letters, true));

			string tmpLetter = GetRandomNumber(Convert.ToInt32(Math.Pow(10, digits - 1)), Convert.ToInt32(Math.Pow(10, digits)) - 1).ToString();

			for (int i = 0; i < digits; i++)
				passwordBuilder.Insert(random.Next(letters + i), tmpLetter[i]);

			tmpLetter = GetRandomString(uppercaseletters);
			for (int i = 0; i < uppercaseletters; i++)
				passwordBuilder.Insert(random.Next(letters + digits + i), tmpLetter[i]);

			for (int i = 0; i < signchars; i++)
				passwordBuilder.Insert(random.Next(letters + digits + uppercaseletters + i), GetRandomSignCharacter());

			return passwordBuilder.ToString();
		}

		#endregion
	}
}