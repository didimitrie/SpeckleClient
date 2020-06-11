using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public interface ICommitCollection
    {
        int? TotalCount { get; }

        IReadOnlyList<IObject> Commits { get; }
    }
}
