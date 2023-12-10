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
