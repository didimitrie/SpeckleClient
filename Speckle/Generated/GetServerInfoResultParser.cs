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
    public class GetServerInfoResultParser
        : JsonResultParserBase<IGetServerInfo>
    {
        private readonly IValueSerializer _stringSerializer;

        public GetServerInfoResultParser(IValueSerializerResolver serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.GetValueSerializer("String");
        }

        protected override IGetServerInfo ParserData(JsonElement data)
        {
            return new GetServerInfo
            (
                ParseGetServerInfoServerInfo(data, "serverInfo")
            );

        }

        private IServerInfo ParseGetServerInfoServerInfo(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new ServerInfo
            (
                DeserializeString(obj, "name"),
                DeserializeNullableString(obj, "company"),
                DeserializeNullableString(obj, "description"),
                DeserializeNullableString(obj, "adminContact"),
                DeserializeNullableString(obj, "termsOfService"),
                ParseGetServerInfoServerInfoRoles(obj, "roles")
            );
        }

        private IReadOnlyList<IRole> ParseGetServerInfoServerInfoRoles(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            int objLength = obj.GetArrayLength();
            var list = new IRole[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Role
                (
                    DeserializeString(element, "name"),
                    DeserializeString(element, "description")
                );

            }

            return list;
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString());
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
    }
}
