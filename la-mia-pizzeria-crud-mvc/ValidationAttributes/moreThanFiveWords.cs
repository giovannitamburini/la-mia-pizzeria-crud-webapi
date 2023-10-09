using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_mvc.ValidationAttributes
{
    public class moreThanFiveWord : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string)
            {
                string inputValue = (string)value;

                if(inputValue == null || inputValue.Split(' ').Length < 5)
                {
                    return new ValidationResult("La descrizione deve contenere almeno 5 parole");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("La descrizione inserita deve essere ti dipo stringa");
        }
    }
}
