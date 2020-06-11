using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class GetServerInfo
        : IGetServerInfo
    {
        public GetServerInfo(
            IServerInfo serverInfo)
        {
            ServerInfo = serverInfo;
        }

        public IServerInfo ServerInfo { get; }
    }
}
