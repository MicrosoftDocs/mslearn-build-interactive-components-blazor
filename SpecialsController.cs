using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

[Route("specials")]
[ApiController]
public class SpecialsController(PizzaStoreContext db) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials() => (await db.Specials.ToListAsync()).OrderByDescending(s => s.BasePrice).ToList();
}