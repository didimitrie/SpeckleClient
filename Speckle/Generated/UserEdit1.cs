using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class UserEdit1
        : IUserEdit
    {
        public UserEdit1(
            bool userEdit)
        {
            UserEdit = userEdit;
        }

        public bool UserEdit { get; }
    }
}
