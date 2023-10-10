using la_mia_pizzeria_crud_mvc.Models;

namespace la_mia_pizzeria_crud_mvc.Database
{
    public interface IRepositoryPizza
    {
        public List<Pizza> GetPizzas();
        public Pizza GetPizzaById(int id);
        public List<Pizza> GetPizzaByName(string title);
        public bool AddPizza(Pizza pizzaToAdd);
        public bool UpdatePizza(int id, Pizza updatedPizza);
        public bool DeletePizza(int id);
    }
}
