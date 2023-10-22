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

            var ibge = context.IBGE.FirstOrDefault(x => x.Id == idStr);

            if (ibge == null)
            {
                return NotFound();
            }
            return Ok(ibge);
        }

        [HttpGet("state/{state}")]
        public IActionResult GetByState(
        [FromRoute] string state,
        [FromServices] RelatorioDbContext context)
        {
            var ibge = context.IBGE.Where(x => x.State == state).ToList();

            if (ibge == null)
            {
                return NotFound();
            }
            return Ok(ibge);
        }

        [HttpGet("city/{city}")]
        public IActionResult GetByCity(
        [FromRoute] string city,
        [FromServices] RelatorioDbContext context)
        {
            var ibge = context.IBGE.Where(x => x.City == city).ToList();

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

        [HttpPut("{id}")]
        public Ibge Put(
            [FromRoute] int id,
            [FromBody] Ibge ibge,
            [FromServices] RelatorioDbContext context)
        {
            string idStr = id.ToString();
            var model = context.IBGE.FirstOrDefault(x => x.Id == idStr);
            if (model == null)
                return model;

            model.City = ibge.City;
            model.State = ibge.State;

            context.IBGE.Update(model);
            context.SaveChanges();
            return model;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(
        [FromRoute] int id,
        [FromServices] RelatorioDbContext context)
        {
            string idStr = id.ToString();
            var ibge = context.IBGE.FirstOrDefault(x => x.Id == idStr);

            if (ibge == null)
            {
                return NotFound();
            }

            context.IBGE.Remove(ibge);
            context.SaveChanges();
            return Ok();
        }
    }
}