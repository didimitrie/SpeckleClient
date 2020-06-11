using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class GetStreamOperation
        : IOperation<IGetStream>
    {
        public string Name => "getStream";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IGetStream);

        public Optional<string> Id { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Id.HasValue)
            {
                variables.Add(new VariableValue("id", "String", Id.Value));
            }

            return variables;
        }
    }
}
