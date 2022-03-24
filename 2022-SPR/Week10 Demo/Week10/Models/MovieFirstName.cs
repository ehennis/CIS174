using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Linq;
using System.Threading.Tasks;


namespace Week10.Models
{
    public class MovieFirstName : ValidationAttribute, IClientModelValidator
    {
        public MovieFirstName()
        {
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-moviefirstname-name", "EvanH");
            context.Attributes.Add("data-val-moviefirstname", GetErrorMessage());
        }

        public string GetErrorMessage()
        {
            return "Do not use your first name";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (value.ToString() != "EvanH" ? ValidationResult.Success : new ValidationResult(GetErrorMessage()));
        }
    }
}
