using System.Text;
using Compare_addscope_addtransient.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Compare_addscope_addtransient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
      private readonly IServiceProvider _serviceProvider;

        public ValuesController(IServiceProvider serviceProvider)
        {
            _serviceProvider=serviceProvider;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            StringBuilder scopedString = new StringBuilder("Scoped: ");
            StringBuilder transientString = new StringBuilder("Transient: ");

            for (int i = 0; i < 10; i++)
            {
                scopedString.AppendLine(_serviceProvider.GetService<IScopedService>()?.Id.ToString());
                transientString.AppendLine(_serviceProvider.GetService<ITransientService>()?.Id.ToString());
            }

            Console.WriteLine(scopedString);
            Console.WriteLine(transientString);


            return new string[] { scopedString.ToString(), transientString.ToString() };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
