using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        ReqContext db;
        public ClientController(ReqContext context)
        {
            db = context;
            if (!db.Clients.Any())
            {
                db.Clients.Add(new Client { Name = "Иванов" });
                db.Clients.Add(new Client { Name = "Петров" });
                db.SaveChanges();
            }
        }
        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            return await db.Clients.ToListAsync();
        }

        // GET: api/Client/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            Client client = await db.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
                return NotFound();
            return new ObjectResult(client);
        }

        // POST: api/Client
        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            if(client == null)
            {
                return BadRequest();
            }

            db.Clients.Add(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> Put(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            if (!db.Clients.Any(x => x.Id == client.Id))
            {
                return NotFound();
            }

            db.Update(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            Client client = db.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            db.Clients.Remove(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }
    }
}
