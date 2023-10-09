using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_mvc.ValidationAttributes
{
    public class ValidFormatImage : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is string)
            {
                string svg = ".svg";
                string jpg = ".jpg";
                string webp = ".webp";
                string png = ".png";

                string inputValue = (string)value;

                if (inputValue == null || (!inputValue.EndsWith(svg) && !inputValue.EndsWith(jpg) && !inputValue.EndsWith(png) && !inputValue.EndsWith(webp)))
                {
                    return new ValidationResult("Il formato dell'immagine deve essere tra quelli elencati: svg, jpg, png, webp");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Il path dell'immagine inserito deve essere ti dipo stringa");
        }
    }
}
