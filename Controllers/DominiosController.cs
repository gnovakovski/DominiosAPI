using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace DominiosAPI.Controllers
{
    [Route("api/[controller]")]
    public class DominiosController : Controller
    {
        // GET api/Dominios
        [HttpGet]
        public IEnumerable<Dominio> Get()
        {
            using (DominioDb db = new DominioDb())
            {
                return db.Dominios.ToList();
            }
        }

        // GET api/Dominios/5
        [HttpGet("{id}")]
        public Dominio Get(int id)
        {
            using (DominioDb db = new DominioDb())
            {
                return db.Dominios.First(t => t.Id == id);
            }
        }

        // POST api/Dominios
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            Dominio posted = value.ToObject<Dominio>();
            using (DominioDb db = new DominioDb())
            {
                db.Dominios.Add(posted);
                db.SaveChanges();
            }
        }

        // PUT api/Dominios/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]JObject value)
        {
            Dominio posted = value.ToObject<Dominio>();
            posted.Id = id; // Ensure an id is attached
            using (DominioDb db = new DominioDb())
            {
                db.Dominios.Update(posted);
                db.SaveChanges();
            }
        }

        // DELETE api/Dominios/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (DominioDb db = new DominioDb())
            {
                if (db.Dominios.Where(t => t.Id == id).Count() > 0) // Check if element exists
                    db.Dominios.Remove(db.Dominios.First(t => t.Id == id));
                db.SaveChanges();
            }
        }
    }
}