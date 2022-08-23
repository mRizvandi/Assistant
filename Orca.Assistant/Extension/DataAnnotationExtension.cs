/* Orca Framework - Assistant : DataAnnotationExtension
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0  140001616 1756
*/

using System.ComponentModel.DataAnnotations;

namespace AryaVtd.Orca.Assistant;

public static class DataAnnotationExtension
{
    /// <summary>
    /// Get value of Attribute of Property like [MinLength ...]
    /// </summary>
    public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
    {
        var attrType = typeof(T);
        var property = instance.GetType().GetProperty(propertyName);
        return (T)property.GetCustomAttributes(attrType, false).FirstOrDefault();
    }

    /// <summary>
    /// Get value of Display Name attribute of property
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    public static string GetDisplayNameFrom(this object instance, string propertyName)
    {
        string retVal = "";

        var attrType = typeof(DisplayAttribute);
        var property = instance.GetType().GetProperty(propertyName);
        var propertyValue = (DisplayAttribute)property.GetCustomAttributes(attrType, false).FirstOrDefault();

        if (propertyValue is not null)
            retVal = propertyValue.GetName();

        return retVal;
    }

    /// <summary>
    /// Get value of IsRequired attribute of property
    /// </summary>
    public static bool GetRequiredFrom(this object instance, string propertyName)
    {
        bool retVal = false;

        var attrType = typeof(RequiredAttribute);
        var property = instance.GetType().GetProperty(propertyName);

        var propertyValue = (RequiredAttribute)property.GetCustomAttributes(attrType, false).FirstOrDefault();

        if (propertyValue is not null)
            retVal = true;

        return retVal;
    }
}