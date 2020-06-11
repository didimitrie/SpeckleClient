using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class CommitCollection
        : ICommitCollection
    {
        public CommitCollection(
            int? totalCount, 
            IReadOnlyList<IObject> commits)
        {
            TotalCount = totalCount;
            Commits = commits;
        }

        public int? TotalCount { get; }

        public IReadOnlyList<IObject> Commits { get; }
    }
}
