
using System.Net.WebSockets;
using System.Text;
using CardGame.DataModels;
using CardGame.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebSocketsSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebSocketController : ControllerBase
    {
        private static List<WebSocket> connections = new List<WebSocket>();
        private static Dictionary< WebSocket, (String, String)> map = new Dictionary<WebSocket, (String, String)>();

        [HttpGet("/ws")]
        public async Task<IActionResult> Connect()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                connections.Add(webSocket);
                await broadcastGameState(webSocket);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

     

        private static async Task broadcastGameState(WebSocket webSocket)
        {
            while (true)
            {
                var buffer = new byte[1024 * 4];
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                System.Diagnostics.Debug.WriteLine(receivedMessage);
                
                dynamic jsonDynamic = JsonConvert.DeserializeObject(receivedMessage);
                

                if (jsonDynamic != null)
                {
                    if (jsonDynamic.ContainsKey("won"))
                    {
                        State s = JsonConvert.DeserializeObject<State>(receivedMessage);
                        System.Diagnostics.Debug.WriteLine(s.won);
                        foreach (var socket in connections)
                        {
                            if (socket.State == WebSocketState.Open && socket != webSocket)
                            {
                                await socket.SendAsync(
                                    new ArraySegment<byte>(buffer, 0, result.Count),
                                    result.MessageType,
                                    result.EndOfMessage,
                                    CancellationToken.None);
                            }
                        }

                    }
                    else if (result.MessageType == WebSocketMessageType.Text)
                    {
                        Room r = JsonConvert.DeserializeObject<Room>(receivedMessage);

                        if (!map.ContainsKey(webSocket))
                        {
                            map.Add( webSocket, (r.name, r.roomID));
                        }
                        System.Diagnostics.Debug.WriteLine(map.Count);

                    }

                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                        connections.Remove(webSocket);
                        Room roomToLeave = new Room(map[webSocket].Item1, map[webSocket].Item2, "");
                        RoomUtilites.leaveRoom(roomToLeave);
                        map.Remove(webSocket);
                        
                    }
                }
            }
        }
    }
}
