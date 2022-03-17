using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proj.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        // GET: api/<HelloController>
        [HttpGet]
        public string Get()
        {
            return "Hi";
        }

        // GET api/<HelloController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Hello {id}";
        }

        // POST api/<HelloController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HelloController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HelloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
