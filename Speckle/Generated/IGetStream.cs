using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public interface IGetStream
    {
        IStream Stream { get; }
    }
}
