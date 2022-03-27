using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class ValidatePointsAttribute : ValidationAttribute, IClientModelValidator
    {
        private int maxPoints;
        private int minPoints;
        public ValidatePointsAttribute(int min = 1, int max = 10)
        {
            minPoints = min;
            maxPoints = max;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
            {
                context.Attributes.Add("data-val", "true");
            }
            context.Attributes.Add("data-val-points", Msg(context.ModelMetadata.DisplayName ?? context.ModelMetadata.Name));
        }
        
        private string Msg(string name)
        {
            return base.ErrorMessage ?? $"{name} must be a number between {minPoints} and {maxPoints}.";
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if(value is int)
            {
                int integer = (int)value;
                int max = Ticket.PossPoints.Max();
                int min = Ticket.PossPoints.Min();
                if (integer >= min && integer <= max)
                {
                    return ValidationResult.Success;
                }
            }
            string message = Msg(context.DisplayName);

            return new ValidationResult(message);
        }
    }
}
