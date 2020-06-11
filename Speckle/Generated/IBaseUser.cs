using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public interface IBaseUser
    {
        string Id { get; }

        string Name { get; }

        string Email { get; }
    }
}
