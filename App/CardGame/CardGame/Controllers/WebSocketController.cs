using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebSocketsSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebSocketController : ControllerBase
    {
        private static List<WebSocket> connections = new List<WebSocket>();

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
