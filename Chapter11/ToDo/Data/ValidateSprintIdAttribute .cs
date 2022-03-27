using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class ValidateSprintIdAttribute : ValidationAttribute, IClientModelValidator
    {
        private int maxId;
        private int minId;
        public ValidateSprintIdAttribute(int min = 1, int max = 10)
        {
            minId = min;
            maxId = max;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
            {
                context.Attributes.Add("data-val", "true");
            }
            string message = Msg(context.ModelMetadata.DisplayName ?? context.ModelMetadata.Name);
            context.Attributes.Add("data-val-sprintId", message);
        }

        private string Msg(string name)
        {
            return base.ErrorMessage ?? $"You must choose a {name} between {minId} and {maxId}.";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is int)
            {
                int integer = (int)value;
                int max = 10;
                int min = 1;
                if (integer == -1 || (integer >= min && integer <= max))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(Msg(validationContext.DisplayName));
        }
    }
}
