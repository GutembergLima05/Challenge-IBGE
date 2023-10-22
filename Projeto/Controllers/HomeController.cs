using Microsoft.AspNetCore.Mvc;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controller
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public List<Ibge> Get(
            [FromServices]
            RelatorioDbContext context)
        {
            return context.IBGE.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
        [FromRoute] int id,
        [FromServices] RelatorioDbContext context)
        {
            string idStr = id.ToString();

            Ibge ibge = context.IBGE.FirstOrDefault(x => x.Id == idStr);

            if (ibge == null)
            {
                return NotFound();
            }
            return Ok(ibge);
        }

        [HttpPost("/")]
        public Ibge Post(
            [FromBody] Ibge ibge,
            [FromServices]
            RelatorioDbContext context)
        {
            context.IBGE.Add(ibge);
            context.SaveChanges();
            return ibge;
        }
    }
}