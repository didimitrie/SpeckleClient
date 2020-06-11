using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class Role
        : IRole
    {
        public Role(
            string name, 
            string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }

        public string Description { get; }
    }
}
