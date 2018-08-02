using BaseProject.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Intrastructure
{
    public class NameValidatorAttribute : ValidationAttribute//, IClientModelValidator
    {
        public NameValidatorAttribute()
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            {
                var name = (Name)value;
                if (name.FirstName == name.LastName)
                {
                    return new ValidationResult("First and last names cannot be the same");
                }
                return ValidationResult.Success;
            }
        }
    }
}
