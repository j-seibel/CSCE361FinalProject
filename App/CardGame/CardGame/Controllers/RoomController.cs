using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using CardGame.Model;
using System.Reflection;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardGame.Controllers
{
    [Produces("application/json")]
    [Route("api/Room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Room room)
        {
            System.Diagnostics.Debug.WriteLine("Request Received");
            // Access model properties here
            System.Diagnostics.Debug.WriteLine($"Property1: {room.Id}");
            System.Diagnostics.Debug.WriteLine($"Property2: {room.RoomCode}");
            System.Diagnostics.Debug.WriteLine($"Property2: {room.Name}");
            System.Diagnostics.Debug.WriteLine($"Property2: {room.Host}");
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Room room)
        {
            System.Diagnostics.Debug.WriteLine("Request Received");
            // Access model properties here
            System.Diagnostics.Debug.WriteLine($"Property1: {room.Id}");
            System.Diagnostics.Debug.WriteLine($"Property2: {room.RoomCode}");
            System.Diagnostics.Debug.WriteLine($"Property2: {room.Name}");
            System.Diagnostics.Debug.WriteLine($"Property2: {room.Host}");


        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
