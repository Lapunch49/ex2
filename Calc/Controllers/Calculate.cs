using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Calc.Controllers
{
    [Route("api/Calculator")]
    [ApiController]
    public class Calculate : ControllerBase
    {
        // GET: api/<Calculate>
        /*[HttpGet("Add")]
        public Calculator GetAdd()
        {
            AddCalculator c = new AddCalculator(Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100));
            return c;
        }

        [HttpGet("Sub")]
        public Calculator GetSub()
        {
            SubCalculator c = new SubCalculator(Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100));
            return c;
        }

        [HttpGet("Div")]
        public Calculator GetDiv()
        {
            DivCalculator c = new DivCalculator(Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100));
            return c;
        }*/
        [HttpGet("Mult")]
        public Calculator GetMult()
        {
            MultCalculator c = new MultCalculator(Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100));
            return c;
        }
        

        // GET api/<Calculate>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<Calculate>
        [HttpPost("Add")]
        public string Post(int val1, int val2, int val3)
        {
            AddCalculator c = new AddCalculator(val1, val2);
            c.value1 = c.result;
            c.value2 = val3;
            return $"{val1} + {val2} + {val3} = {c.result}";
        }
        /*
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/<Calculate>/5
        [HttpPut("Sub")]
        public string Put(int val1, int val2, int val3)
        {
            SubCalculator c = new SubCalculator(val1, val2);
            c.value1 = c.result;
            c.value2 = val3;
            return $"Update {val1} - {val2} - {val3} = {c.result}";
        }
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<Calculate>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
        [HttpDelete("Div")]
        public int Delete(int val1)
        {
            DivCalculator c = new DivCalculator(val1, 2);
            return c.result;
        }
    }
}
