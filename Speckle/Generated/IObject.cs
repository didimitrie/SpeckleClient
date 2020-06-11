using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public interface IObject
    {
        string Id { get; }

        IBaseUser Author { get; }

        System.DateTimeOffset? CreatedAt { get; }

        string Data { get; }
    }
}
