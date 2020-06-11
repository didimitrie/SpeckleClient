using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class ServerInfo
        : IServerInfo
    {
        public ServerInfo(
            string name, 
            string company, 
            string description, 
            string adminContact, 
            string termsOfService, 
            IReadOnlyList<IRole> roles)
        {
            Name = name;
            Company = company;
            Description = description;
            AdminContact = adminContact;
            TermsOfService = termsOfService;
            Roles = roles;
        }

        public string Name { get; }

        public string Company { get; }

        public string Description { get; }

        public string AdminContact { get; }

        public string TermsOfService { get; }

        public IReadOnlyList<IRole> Roles { get; }
    }
}
