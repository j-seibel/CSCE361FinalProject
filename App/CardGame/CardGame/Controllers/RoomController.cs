using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CardGame.DataModels;
using CardGame.Models;
using CardGame.SQL;
namespace CardGame.Controllers
{
    [Produces("application/json")]
    [Route("api/Room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        // GET: api/Room
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Room/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Room
        [HttpPost]
        [EnableCors]
        public void Post([FromBody] Room room)
        {
            try
            {
                
                if (DataLoader.getPlayerInfo(room.name)[0] == -1 )
                {
                    DataInserter.createPlayer(room.name);
                }
                RoomUtilites.createRoom(room);
                RoomUtilites.joinRoom(room);
                

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // PUT api/Room/5

        // POST api/Room/join
        [HttpPost("join")]
        [EnableCors]
        public void Join([FromBody] Room room)
        {
            try
            {

                if (DataLoader.getPlayerInfo(room.name)[0] == -1)
                {
                    DataInserter.createPlayer(room.name);
                }
                RoomUtilites.joinRoom(room);


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
