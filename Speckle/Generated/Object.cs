using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class Object
        : IObject
    {
        public Object(
            string id, 
            IBaseUser author, 
            System.DateTimeOffset? createdAt, 
            string data)
        {
            Id = id;
            Author = author;
            CreatedAt = createdAt;
            Data = data;
        }

        public string Id { get; }

        public IBaseUser Author { get; }

        public System.DateTimeOffset? CreatedAt { get; }

        public string Data { get; }
    }
}
