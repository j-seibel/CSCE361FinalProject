using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
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

                        if (!map.ContainsKey(r.name))
                        {
                            map.Add(r.name, webSocket);
                        }
                        System.Diagnostics.Debug.WriteLine(map.Count);

                        // Ensure you use a new buffer instance when sending messages
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
}
