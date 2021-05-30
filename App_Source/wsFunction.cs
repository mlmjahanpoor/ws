using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication6.App_Source
{
    public class wsFunction
    {
        public async Task ListenAcceptAsync(HttpContext context)
        {
            WebSocket ws = await context.WebSockets.AcceptWebSocketAsync();
            await ReceiveAsync(ws);
        }

        public async Task ReceiveAsync(WebSocket ws)
        {
            byte[] buff;
            while (ws.State == WebSocketState.Open)
            {
                buff = new byte[wsConfig.BufferSize];

                WebSocketReceiveResult result = await ws.ReceiveAsync(buff, CancellationToken.None);

                if (result != null)
                {
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        string StrMsg = Encoding.UTF8.GetString(buff);
                        await SendAsync(ws, StrMsg + "***");
                    }
                   
                }
            }
        }

        public async Task SendAsync(WebSocket ws,string StrMsg)
        {
            byte[] buff = Encoding.UTF8.GetBytes(StrMsg);
            await ws.SendAsync(buff, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
