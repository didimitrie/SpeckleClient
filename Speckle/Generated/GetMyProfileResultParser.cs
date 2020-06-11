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
    public class GetMyProfileResultParser
        : JsonResultParserBase<IGetMyProfile>
    {
        private readonly IValueSerializer _stringSerializer;

        public GetMyProfileResultParser(IValueSerializerResolver serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.GetValueSerializer("String");
        }

        protected override IGetMyProfile ParserData(JsonElement data)
        {
            return new GetMyProfile
            (
                ParseGetMyProfileUser(data, "user")
            );

        }

        private IUser ParseGetMyProfileUser(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new User
            (
                DeserializeNullableString(obj, "role"),
                DeserializeString(obj, "id"),
                DeserializeNullableString(obj, "name"),
                DeserializeNullableString(obj, "email")
            );
        }

        private string DeserializeNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (string)_stringSerializer.Deserialize(value.GetString());
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString());
        }
    }
}
