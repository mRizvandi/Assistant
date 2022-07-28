/* Orca Framework - Assistant : Exception Helper (Get recursive exception messages)
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0  140001616 1756
*/

using System.Text;

namespace AryaVtd.Orca.Assistant
{
    public static class ExceptionExtension
    {
        /// <summary>
        /// Get all inner Exception in side of Exception to log or view on Development environment
        /// </summary>
        public static string GetMessages(this Exception exception)
        {
            StringBuilder sb = new();

            if (exception is not null)
            {
                sb.Append(exception.Message);
                if (exception.InnerException is not null)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(exception.InnerException.GetMessages());
                }
            }

            return sb.ToString();
        }
    }
}