using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class UserEditOperation
        : IOperation<IUserEdit>
    {
        public string Name => "userEdit";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IUserEdit);

        public Optional<UserEditInput> User { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (User.HasValue)
            {
                variables.Add(new VariableValue("user", "UserEditInput", User.Value));
            }

            return variables;
        }
    }
}
