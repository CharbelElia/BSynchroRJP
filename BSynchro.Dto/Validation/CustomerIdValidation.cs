using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;

namespace BSynchro.Dto.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class CustomerIdValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = value?.ToString();
            if (string.IsNullOrWhiteSpace(val))
                return new ValidationResult("customer_id_cannot_be_null");
            Guid guidVal;
            if (!Guid.TryParse(val, out guidVal))
                return new ValidationResult($"invalid_customer_id");
            return ValidationResult.Success;
        }
    }
}