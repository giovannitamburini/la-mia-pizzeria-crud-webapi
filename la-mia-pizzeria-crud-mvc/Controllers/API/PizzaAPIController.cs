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
            // gestisco il caso in cui la stringa da cercare nel nome sia nulla
            if(stringToSearch == null)
            {
                return BadRequest(new { Message = "Non hai inserito alcuna stringa da ricercare nel database" });
            }

            using(PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> foundPizzas = db.Pizzas.Where(pizza => pizza.Name.ToLower().Contains(stringToSearch.ToLower())).ToList();

                return Ok(foundPizzas);
            }
        }
    }
}
