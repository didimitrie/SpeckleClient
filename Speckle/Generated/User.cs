using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class User
        : IUser
    {
        public User(
            string role, 
            string id, 
            string name, 
            string email)
        {
            Role = role;
            Id = id;
            Name = name;
            Email = email;
        }

        public string Role { get; }

        public string Id { get; }

        public string Name { get; }

        public string Email { get; }
    }
}
