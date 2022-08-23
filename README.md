# Assistant
### Assistant is a most usefule codes for developers, include Class, Attribute and some Extensions.

### The default Namespace is: AryaVtd.Orca.Assistant
you can find 2 folders inside project that include all methods:

# Class\Attribute
Attribute used on variable, model, entity or viewmodels

Attribute name | Description
---|---
ByteNotZeroValidationAttribute | When you use this attribute on property, this means property can't be 0 and its must be bigger than 0. its useful for prevent default value of property or enum.
CustomUrlValidationAttribute | Check and validate the value of property to be url in correct format. "AllowEmptyString" is a attribute option and used for nullable property (not required).
CustomEmailValidation | Check and validate the value of property to be email address in correct format. "AllowEmptyString" is a attribute option and used for nullable property (not required).
DictionaryIsRequiredValidationAttribute | One of most useful attribute to check the Dicionary have KeyPair value and not only initialized.
GuidNotEmptyValidationAttribute | Guid is not nullable and default value of Guid is '00000000-0000-0000-0000-000000000000', this attribute validate property to not be empty value.
ListIsRequiredValidationAttribute | It's check the generic list to have atleast one item and not only initialized.
NationalCodeValidation | Check the value of property with special Iranian people National Code format.
CompanyNationalIDValidation | Check the value of property with special Iranian company National ID format.

## Attribute using sample:
        [CustomEmailValidation(AllowEmptyString = true, ErrorMessageResourceType = typeof(Translation.SystemMessages), ErrorMessageResourceName = nameof(Translation.SystemMessages.InvalidEmail))]
        public string Email { get; set; }
		
		[Display(ResourceType = typeof(Translation.DataDictionary), Name = nameof(Translation.DataDictionary.NationalCode))]
        [NationalCodeValidation(AllowEmptyString = true, ErrorMessageResourceType = typeof(Translation.SystemMessages), ErrorMessageResourceName = nameof(Translation.SystemMessages.InvalidNationalCode))]
        public string NationalCode { get; set; }

# This is file is under writing...
