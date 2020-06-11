using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class UserEditInput
    {
        public Optional<string> Bio { get; set; }

        public Optional<string> Company { get; set; }

        public Optional<string> Name { get; set; }
    }
}
