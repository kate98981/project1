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
    public class ReqController : Controller
    {
        ReqContext db;

        public ReqController(ReqContext context)
        {
            db = context;
            if (!db.Reqs.Any())
            {
                db.Reqs.Add(new Req { ClientId = 1, ServiceId = 1 });
                db.Reqs.Add(new Req { ClientId = 2, ServiceId = 2 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Req>>> Get()
        {
            return await db.Reqs.ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Req req = db.Reqs.FirstOrDefault(x => x.Id == id);
            if (req == null)
                return NotFound();
            return new ObjectResult(req);
        }

        [HttpPost]
        public async Task<ActionResult<Req>> Post(Req req)
        {
            if (req == null)
            {
                return BadRequest();
            }

            db.Reqs.Add(req);
            await db.SaveChangesAsync();
            return Ok(req);
        }

        [HttpPut]
        public async Task<ActionResult<Req>> Put(int id, [FromBody]Req req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            if (!db.Reqs.Any(x => x.Id == req.Id))
            {
                return NotFound();
            }

            db.Update(req);
            await db.SaveChangesAsync();
            return Ok(req);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Req>> Delete(int id)
        {
            Req req = db.Reqs.FirstOrDefault(x => x.Id == id);
            if (req == null)
            {
                return NotFound();
            }
            db.Reqs.Remove(req);
            await db.SaveChangesAsync();
            return Ok(req);
        }
    }
}
