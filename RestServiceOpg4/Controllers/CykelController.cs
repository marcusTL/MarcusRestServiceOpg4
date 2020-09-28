using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opg1Lib;

namespace RestServiceOpg4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CykelController : ControllerBase
    {
        private static readonly List<Cykel> _cykler = new List<Cykel>()
        {
            new Cykel(1,"black",50,3),
            new Cykel(2,"white",80,4),
            new Cykel(3,"green",120,6),
            new Cykel(4,"blue",100,4)
        };
        // GET: api/Cykel
        [HttpGet]
        public IEnumerable<Cykel> Get()
        {
            return _cykler;
        }

        // GET: api/Cykel/5
        [HttpGet("{id}", Name = "Get")]
        public Cykel Get(int id)
        {
            return _cykler.Find(i => i.Id == id);
        }

        // POST: api/Cykel
        [HttpPost]
        public void Post([FromBody] Cykel value)
        {
            value.Id = _cykler.Max(c => c.Id) + 1;
            _cykler.Add(value);
        }

        // PUT: api/Cykel/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cykel value)
        {
            Cykel c1 = Get(id);
            if (c1 != null)
            {
                c1.Id = value.Id;
                c1.Color = value.Color;
                c1.Price = value.Price;
                c1.Gear = value.Gear;
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Cykel c1 = Get(id);
            _cykler.Remove(c1);
        }
    }
}
