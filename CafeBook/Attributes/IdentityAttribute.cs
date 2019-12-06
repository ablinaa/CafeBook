using System;
using System.ComponentModel.DataAnnotations;

namespace CafeBook.Attributes
{
    public class IdentityAttribute : ValidationAttribute
    {
        private string val;

        public IdentityAttribute(string val, string error)
        {
            this.val = val;
            ErrorMessage = error;
        }

        protected override ValidationResult IsValid(object val, ValidationContext validationContext)
        {
            {
                string NUMBER = val.ToString();

                if (NUMBER.Length < 12)
                {
                    return new ValidationResult(ErrorMessage);
                }
                return ValidationResult.Success;
            }
        }
    }
}
