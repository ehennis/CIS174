using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Linq;
using System.Threading.Tasks;


namespace CIS174Library.Models
{
    public class BookName : ValidationAttribute, IClientModelValidator
    {
        public BookName()
        {
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-bookname-name", "EvanH");
            context.Attributes.Add("data-val-bookname", GetErrorMessage());
        }

        public string GetErrorMessage()
        {
            return "Custom Validation: Do not use your first name";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return value != null && value.ToString() != "EvanHennis" ? ValidationResult.Success : new ValidationResult(GetErrorMessage());
        }
    }
}
