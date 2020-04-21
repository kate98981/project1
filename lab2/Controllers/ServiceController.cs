using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        ReqContext db;

        public ServiceController(ReqContext context)
        {
            db = context;
            if (!db.Services.Any())
            {
                db.Services.Add(new Service { Name = "Ремонт компьютера" });
                db.Services.Add(new Service { Name = "Уборка дома" });
                db.SaveChanges();
            }
        }
        // GET: api/Service
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> Get()
        {
            return await db.Services.ToListAsync();
        }

        // GET: api/Service/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Service service = db.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
                return NotFound();
            return new ObjectResult(service);
        }

        // POST: api/Service
        [HttpPost]
        public async Task<ActionResult<Service>> Post(Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }

            db.Services.Add(service);
            await db.SaveChangesAsync();
            return Ok(service);
        }

        // PUT api/service/
        [HttpPut]
        public async Task<ActionResult<Service>> Put(int id, [FromBody]Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }
            if (!db.Services.Any(x => x.Id == service.Id))
            {
                return NotFound();
            }

            db.Update(service);
            await db.SaveChangesAsync();
            return Ok(service);
        }

        // DELETE: api/service/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> Delete(int id)
        {
            Service service = db.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            db.Services.Remove(service);
            await db.SaveChangesAsync();
            return Ok(service);
        }
    }
}
