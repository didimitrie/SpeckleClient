using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class Stream
        : IStream
    {
        public Stream(
            string name, 
            string createdAt, 
            string updatedAt, 
            ICommitCollection commits)
        {
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Commits = commits;
        }

        public string Name { get; }

        public string CreatedAt { get; }

        public string UpdatedAt { get; }

        public ICommitCollection Commits { get; }
    }
}
