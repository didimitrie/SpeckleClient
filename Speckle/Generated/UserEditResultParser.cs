using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace SpeckleClient
{
    public class UserEditResultParser
        : JsonResultParserBase<IUserEdit>
    {
        private readonly IValueSerializer _booleanSerializer;

        public UserEditResultParser(IValueSerializerResolver serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _booleanSerializer = serializerResolver.GetValueSerializer("Boolean");
        }

        protected override IUserEdit ParserData(JsonElement data)
        {
            return new UserEdit1
            (
                DeserializeBoolean(data, "userEdit")
            );

        }

        private bool DeserializeBoolean(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (bool)_booleanSerializer.Deserialize(value.GetBoolean());
        }
    }
}
