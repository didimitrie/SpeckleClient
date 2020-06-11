using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public interface IStream
    {
        string Name { get; }

        string CreatedAt { get; }

        string UpdatedAt { get; }

        ICommitCollection Commits { get; }
    }
}
