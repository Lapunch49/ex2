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
        [HttpGet("Mult")]
        public Calculator GetMult()
        {
            MultCalculator c = new (Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100));
            return c;
        }

        // POST api/<Calculate>
        [HttpPost("Add")]
        public string Post(double val1, double val2, double val3)
        {
            AddCalculator c = new(val1, val2);
            c.value1 = c.result;
            c.value2 = val3;
            return $"{val1} + {val2} + {val3} = {c.result}";
        }

        // PUT api/<Calculate>/5
        [HttpPut("Sub")]
        public string Put(double val1, double val2, double val3)
        {
            SubCalculator c = new(val1, val2);
            c.value1 = c.result;
            c.value2 = val3;
            return $"Update {val1} - {val2} - {val3} = {c.result}";
        }

        // DELETE api/<Calculate>/5
        [HttpDelete("Div")]
        public double Delete(double val1)
        {
            DivCalculator c = new(val1, 2);
            return c.result;
        }

        [HttpPatch("Exponention")]
        public string Patch(double val1)
        {
            ExCalculator c = new(val1, 2);
            return $"Update: {c.value1}^{c.value2} = {c.result}";
        }

        [HttpOptions("Options")]
        public OkResult Options()
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, PUT, POST, DELETE, OPTIONS");
            return Ok();
        }
    }
}
