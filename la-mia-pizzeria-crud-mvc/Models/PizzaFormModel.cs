using Microsoft.AspNetCore.Mvc.Rendering;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class PizzaFormModel
    {
        public Pizza Pizza { get; set; }
        public List<Category>? Categories { get; set; }

        // proprietà per gestire la select multipla degli ingredienti all'interno delle viste
        public List<SelectListItem>? Ingredients { get; set; }
        public List<string>? SelectedIngredientsId { get; set; }
    }
}