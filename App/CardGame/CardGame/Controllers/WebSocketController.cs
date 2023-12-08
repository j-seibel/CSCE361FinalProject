using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CardGame.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebSocketsSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebSocketController : ControllerBase
    {
        private static List<WebSocket> connections = new List<WebSocket>();
        private static Dictionary<String, WebSocket> map = new Dictionary<string, WebSocket>();

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
            var buffer = new byte[1024 * 4];

            while (true)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Room r = JsonConvert.DeserializeObject<Room>(receivedMessage);
                    
                    if (!map.ContainsKey(r.name))
                    {
                        map.Add(r.name, webSocket);
                    }
                    System.Diagnostics.Debug.WriteLine(map.Count);
                    System.Diagnostics.Debug.WriteLine("FUCK THIS SHIT BRO");


                    foreach (var socket in connections)
                    {
                        if (socket.State == WebSocketState.Open)
                        {
                            await socket.SendAsync(
                                new ArraySegment<byte>(buffer, 0, result.Count),
                                result.MessageType,
                                result.EndOfMessage,
                                CancellationToken.None);
                        }
                    }
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                    connections.Remove(webSocket);
                }
            }
        }
    }
}
