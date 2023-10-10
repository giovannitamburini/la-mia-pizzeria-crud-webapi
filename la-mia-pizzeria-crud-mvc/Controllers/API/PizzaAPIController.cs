using la_mia_pizzeria_crud_mvc.Database;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_crud_mvc.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaAPIController : ControllerBase
    {
        private PizzeriaContext _myDb;

        public PizzaAPIController(PizzeriaContext myDb)
        {
            this._myDb = myDb;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> pizzas = db.Pizzas.Include(pizza => pizza.Ingredients).ToList();

                return Ok(pizzas);
            }
        }

        // punto interrogativo perchè potrei ricevere un argomento  nullo
        [HttpGet]
        public IActionResult SearchPizzaByStringInTheName(string? stringToSearch)
        {
            // inizializzo una nuova lista di pizze nel caso in cui la stringa di ricerca fosse vuota ("")
            List<Pizza> foundedPizzas = new List<Pizza>();

            // gestisco il caso in cui la stringa da cercare nel nome sia nulla
            if (stringToSearch == null)
            {
                // return BadRequest(new { Message = "Non hai inserito alcuna stringa da ricercare nel database" });

                foundedPizzas = _myDb.Pizzas.Include(pizza => pizza.Ingredients).ToList();

                return Ok(foundedPizzas);
            }
            else
            {
                using (PizzeriaContext db = new PizzeriaContext())
                {
                    foundedPizzas = db.Pizzas.Where(pizza => pizza.Name.ToLower().Contains(stringToSearch.ToLower())).ToList();

                    return Ok(foundedPizzas);
                }
            }

        }

        [HttpGet("{id}")]
        public IActionResult SearchPizzaById(int id)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza? foundPizza = db.Pizzas.Where(pizza => pizza.Id == id).Include(pizza => pizza.Category).Include(pizza => pizza.Ingredients).FirstOrDefault();

                if (foundPizza != null)
                {
                    return Ok(foundPizza);
                }
                else
                {
                    return NotFound(new { Message = "Non è stata trovata alcuna pizza che corrisponde al numero dell'id inserito" });
                }
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pizza newPizza)
        {
            try
            {
                _myDb.Pizzas.Add(newPizza);
                _myDb.SaveChanges();

                return Ok(newPizza);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Pizza pizza)
        {
            Pizza? pizzaToUpdate = _myDb.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

            if (pizzaToUpdate == null)
            {
                return NotFound(new { Message = "Non è stata trovata alcuna pizza da modificare" });
            }

            pizzaToUpdate.Name = pizza.Name;
            pizzaToUpdate.Description = pizza.Description;
            pizzaToUpdate.PathImage = pizza.PathImage;
            pizzaToUpdate.Price = pizza.Price;
            pizzaToUpdate.CategoryId = pizza.CategoryId;

            _myDb.SaveChanges();

            return Ok(pizzaToUpdate);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pizza? pizzaToDelete = _myDb.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

            if (pizzaToDelete == null)
            {
                //return NotFound(new {Message = "la pizza che vorresti eliminare non è stata trovata"});

                return BadRequest(new { Message = "Non è stata trovata nessuna pizza che corrisponde all'id inserito" });
            }

            _myDb.Pizzas.Remove(pizzaToDelete);
            _myDb.SaveChanges();

            return Ok();
        }
    }
}
