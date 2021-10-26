using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mycrud.Data;
using mycrud.Models;
using System.Web.Http.Cors;

namespace mycrud.Controllers
{

    [ApiController]
    [EnableCors(origins: "http://localhost:5000", headers: "*", methods: "*")]
    public class PersonController : ControllerBase
    {

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<Person>>> Get([FromServices] DataContext context)
        {
            return await context.People.ToListAsync();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Person>> Post([FromServices] DataContext context, [FromBody] Person model)
        {
            if (ModelState.IsValid)
            {
                context.People.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public async Task<int> Delete([FromServices] DataContext context, int id)
        {
            Person p = await context.People.FirstOrDefaultAsync(e => e.Id == id);
            context.People.Remove(p);
            await context.SaveChangesAsync();
            return id;
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Person>> Update([FromServices] DataContext context, Person model)
        {
            if (ModelState.IsValid)
            {
                context.People.Update(model);
                await context.SaveChangesAsync();
                return model;
            }
            else return BadRequest(ModelState);

        }

    }
}