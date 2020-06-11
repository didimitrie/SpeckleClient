using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class GetStream
        : IGetStream
    {
        public GetStream(
            IStream stream)
        {
            Stream = stream;
        }

        public IStream Stream { get; }
    }
}
