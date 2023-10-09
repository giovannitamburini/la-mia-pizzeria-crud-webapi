using System.Text.Json.Serialization;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class Ingredient
    {
        // il comando [JsonIgnore] serve per dire alla serializzazione in Json di ignorare la proprietà specificata (in questo caso l'id)
        // [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }

        // aggiungo il collegamento per la relazione N a N
        public List<Pizza> Pizzas { get; set; }
    }
}
