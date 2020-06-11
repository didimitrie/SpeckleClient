using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public interface IServerInfo
    {
        string Name { get; }

        string Company { get; }

        string Description { get; }

        string AdminContact { get; }

        string TermsOfService { get; }

        IReadOnlyList<IRole> Roles { get; }
    }
}
