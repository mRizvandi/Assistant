/* Orca Framework - Assistant : Attributes
 * Mehdi Rizvandi | AryaVandidad.com
 * Ver 1.0  14010426 1837
 */

using System.ComponentModel.DataAnnotations;

namespace AryaVtd.Orca.Assistant
{
    /// <summary>
    /// Byte property can not be 0, its so useful for Enum
    /// </summary>
    public class ByteNotZeroValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            byte val = 0;

            try
            {
                val = Convert.ToByte(value);
                if (val == 0)
                    throw new Exception();

                return null;
            }
            catch (Exception)
            {
                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }
        }
    }

    /// <summary>
    /// Check the property as URL format
    /// </summary>
    public class CustomUrlValidationAttribute : ValidationAttribute
    {
        ///<summary>
        ///اجازه میدهد که لینک خالی یا پر باشد
        ///</summary>
        public bool AllowEmptyString { get; set; } = false;

        public override bool IsValid(object value)
        {
            Uri uriResult;

            if (AllowEmptyString)
            {
                if (string.IsNullOrEmpty((string)value))
                {
                    return true;
                }
                bool result = Uri.TryCreate((string)value, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                return result;
            }
            else
            {
                if (!string.IsNullOrEmpty((string)value))
                {
                    bool result = Uri.TryCreate((string)value, UriKind.Absolute, out uriResult)
                         && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    return result;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    /// <summary>
    /// Check the property as Email Address format
    /// </summary>
    public class CustomEmailValidation : ValidationAttribute
    {
        ///<summary>
        ///اجازه میدهد که ایمیل خالی یا پر باشد
        ///</summary>
        public bool AllowEmptyString { get; set; } = false;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (AllowEmptyString)
                {
                    if (string.IsNullOrEmpty((string)value))
                    {
                        return ValidationResult.Success;
                    }
                    var address = new System.Net.Mail.MailAddress((string)value);
                    return ValidationResult.Success;
                }
                else
                {
                    if (!string.IsNullOrEmpty((string)value))
                    {
                        var address = new System.Net.Mail.MailAddress((string)value);
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                    }
                }
            }
            catch (FormatException)
            {
                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }
        }
    }

    /// <summary>
    /// Dictionary must have a key pair value and can not be null or initialized only
    /// </summary>
    public class DictionaryIsRequiredValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var val = value as Dictionary<Guid, string>;

            try
            {
                if (val is not null)
                {
                    if (val.Count == 0)
                        throw new Exception();
                }
                else
                    throw new Exception();

                return null;
            }
            catch (Exception)
            {
                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }
        }
    }

    /// <summary>
    /// Guid property prevention with Guid.Empty value
    /// </summary>
    public class GuidNotEmptyValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                Guid val = Guid.Empty;

                try
                {
                    val = Guid.Parse(value.ToString());
                    if (val == Guid.Empty)
                        throw new Exception();

                    return null;
                }
                catch (Exception)
                {
                    return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                }
            }
            else
                return null;
        }
    }

    /// <summary>
    /// List must have value and can not be null or initialized only
    /// </summary>
    public class ListIsRequiredValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<object> val = (List<object>)value;

            try
            {
                if (val is not null)
                {
                    if (val.Count == 0)
                        throw new Exception();
                }
                else
                    throw new Exception();

                return null;
            }
            catch (Exception)
            {
                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }
        }
    }

    /// <summary>
    /// Check the value of property with special Iranian people National Code format
    /// </summary>
    public class NationalCodeValidation : ValidationAttribute
    {
        ///<summary>
        ///اجازه میدهد که کد ملی خالی یا پر باشد
        ///</summary>
        public bool AllowEmptyString { get; set; } = false;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (AllowEmptyString)
                {
                    if (string.IsNullOrEmpty((string)value))
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        if (Validation.IsValidNationalCode(value.ToString()))
                        {
                            return ValidationResult.Success;
                        }
                        else
                        {
                            return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                        }
                    }
                }
                else
                {
                    if (Validation.IsValidNationalCode(value.ToString()))
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                    }
                }
            }
            catch (FormatException)
            {
                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }
        }
    }

    /// <summary>
    /// Check the value of property with special Iranian company National ID format
    /// </summary>
    public class CompanyNationalIDValidation : ValidationAttribute
    {
        ///<summary>
        ///اجازه میدهد که شناسه ملی یا پر باشد
        ///</summary>
        public bool AllowEmptyString { get; set; } = false;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (AllowEmptyString)
                {
                    if (string.IsNullOrEmpty((string)value))
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        if (Validation.IsValidNationalID(value.ToString()))
                        {
                            return ValidationResult.Success;
                        }
                        else
                        {
                            return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                        }
                    }
                }
                else
                {
                    if (Validation.IsValidNationalID(value.ToString()))
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                    }
                }

            }
            catch (FormatException)
            {
                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }
        }
    }
}