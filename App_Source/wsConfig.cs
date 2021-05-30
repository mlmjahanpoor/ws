
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.App_Source
{
    public static class wsConfig
    {
        public static int BufferSize = 4 * 1024;

        public static WebSocketOptions GetOptions()
        {
            WebSocketOptions wso = new WebSocketOptions()
            {
                ReceiveBufferSize=BufferSize,
                KeepAliveInterval=TimeSpan.FromSeconds(120)
            };
            return wso;
        }
    }
}
