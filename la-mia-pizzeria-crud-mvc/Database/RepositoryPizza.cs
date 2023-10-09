using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_crud_mvc.Database
{
    public class RepositoryPizza : IRepositoryPizza
    {
        private PizzeriaContext _myDb;

        public RepositoryPizza(PizzeriaContext db)
        {
            this._myDb = db;
        }

        public List<Pizza> GetPizzas()
        {
            List<Pizza> pizzas = _myDb.Pizzas.Include(pizza => pizza.Ingredients).ToList<Pizza>();

            return pizzas;
        }

        public Pizza GetPizzaById(int id)
        {
            Pizza? foundPizza = _myDb.Pizzas.Where(pizza => pizza.Id == id).Include(pizza => pizza.Category).Include(pizza => pizza.Ingredients).FirstOrDefault();

            if(foundPizza != null)
            {
                return foundPizza;
            }
            else
            {
                throw new Exception("La pizza non è stata trovata");
            }
        }

        public List<Pizza> GetPizzaByName(string title)
        {
            List<Pizza> foundPizzas = _myDb.Pizzas.Where(pizza => pizza.Name.ToLower().Contains(title.ToLower())).ToList();

            return foundPizzas;
        }

        public bool AddPizza(Pizza pizzaToAdd)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePizza(int id, Pizza updatedPizza)
        {
            throw new NotImplementedException();
        }

        public bool DeletePizza(int id)
        {
            throw new NotImplementedException();
        }
    }
}
