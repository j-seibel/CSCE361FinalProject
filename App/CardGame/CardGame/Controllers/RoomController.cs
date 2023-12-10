using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using System;
using CardGame.DataModels;
using System.Collections.Generic;
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
                System.Diagnostics.Debug.WriteLine("Request Received");
                System.Diagnostics.Debug.WriteLine($"Property1: {room.name}");
                System.Diagnostics.Debug.WriteLine($"Property2: {room.roomID}");
                System.Diagnostics.Debug.WriteLine($"Property3: {room.userId}");
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
        [HttpPut("{id}")]
        public void Put([FromBody] Room room)
        {
            System.Diagnostics.Debug.WriteLine("Request Received");
        }

        // DELETE api/Room/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // POST api/Room/join
        [HttpPost("join")]
        [EnableCors]
        public IActionResult Join([FromBody] Room joinRequest)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Join Request Received");
                System.Diagnostics.Debug.WriteLine($"RoomID: {joinRequest.roomID}");
                System.Diagnostics.Debug.WriteLine($"UserID: {joinRequest.userId}");

                return Ok("Successfully joined the room"); 
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error joining room: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
