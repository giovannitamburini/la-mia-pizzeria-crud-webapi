using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome della categoria è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome della categoria deve essere composto al massimo da 50 caratteri")]
        public string Name { get; set; }

        // relazione N a 1 con Pizza
        public List<Pizza> Pizzas { get; set;}

        public Category()
        {
        }
    }
}
