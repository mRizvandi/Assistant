/* Orca Framework - Assistant : EnumUtility
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0  14010426 1837
 */

using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AryaVtd.Orca.Assistant
{
	public static class EnumUtility
	{
		#region Enum Utility Methods

		public static string GetDisplayName<T>(object value)
		{
			var member = ((T)value).GetType().GetMember(value.ToString())[0];
			var displayAttribute = member.GetCustomAttribute<DisplayAttribute>();

			if (displayAttribute != null)
				return displayAttribute.GetName();

			return value.ToString();
		}

		#endregion
	}
}