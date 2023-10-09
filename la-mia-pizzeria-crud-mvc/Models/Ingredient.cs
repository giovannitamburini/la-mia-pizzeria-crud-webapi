namespace la_mia_pizzeria_crud_mvc.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // aggiungo il collegamento per la relazione N a N
        public List<Pizza> Pizzas { get; set; }
    }
}
