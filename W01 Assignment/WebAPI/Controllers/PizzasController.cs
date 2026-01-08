using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    private static List<Pizza> Pizzas = new List<Pizza>
    {
        new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
        new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = false },
        new Pizza { Id = 3, Name = "Pepperoni", IsGlutenFree = false },
        new Pizza { Id = 4, Name = "Hawaiian", IsGlutenFree = false },
        new Pizza { Id = 5, Name = "Margherita", IsGlutenFree = false },
        new Pizza { Id = 6, Name = "Supreme", IsGlutenFree = false }
    };

    // GET: api/Pizzas
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return Pizzas;
    }

    // GET: api/Pizzas/5
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
        
        if (pizza == null)
        {
            return NotFound();
        }
        
        return pizza;
    }

    // POST: api/Pizzas
    [HttpPost]
    public ActionResult<Pizza> Create(Pizza pizza)
    {
        pizza.Id = Pizzas.Max(p => p.Id) + 1;
        Pizzas.Add(pizza);
        
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // PUT: api/Pizzas/5
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        var existingPizza = Pizzas.FirstOrDefault(p => p.Id == id);
        
        if (existingPizza == null)
        {
            return NotFound();
        }
        
        existingPizza.Name = pizza.Name;
        existingPizza.IsGlutenFree = pizza.IsGlutenFree;
        
        return NoContent();
    }

    // DELETE: api/Pizzas/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
        
        if (pizza == null)
        {
            return NotFound();
        }
        
        Pizzas.Remove(pizza);
        
        return NoContent();
    }
}
