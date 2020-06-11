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
    public class GetStreamResultParser
        : JsonResultParserBase<IGetStream>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _intSerializer;
        private readonly IValueSerializer _dateTimeSerializer;
        private readonly IValueSerializer _jSONObjectSerializer;

        public GetStreamResultParser(IValueSerializerResolver serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.GetValueSerializer("String");
            _intSerializer = serializerResolver.GetValueSerializer("Int");
            _dateTimeSerializer = serializerResolver.GetValueSerializer("DateTime");
            _jSONObjectSerializer = serializerResolver.GetValueSerializer("JSONObject");
        }

        protected override IGetStream ParserData(JsonElement data)
        {
            return new GetStream
            (
                ParseGetStreamStream(data, "stream")
            );

        }

        private IStream ParseGetStreamStream(
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

            return new Stream
            (
                DeserializeString(obj, "name"),
                DeserializeString(obj, "createdAt"),
                DeserializeString(obj, "updatedAt"),
                ParseGetStreamStreamCommits(obj, "commits")
            );
        }

        private ICommitCollection ParseGetStreamStreamCommits(
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

            return new CommitCollection
            (
                DeserializeNullableInt(obj, "totalCount"),
                ParseGetStreamStreamCommitsCommits(obj, "commits")
            );
        }

        private IReadOnlyList<IObject> ParseGetStreamStreamCommitsCommits(
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

            int objLength = obj.GetArrayLength();
            var list = new IObject[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Object
                (
                    DeserializeString(element, "id"),
                    ParseGetStreamStreamCommitsCommitsAuthor(element, "author"),
                    DeserializeNullableDateTime(element, "createdAt"),
                    DeserializeNullableJSONObject(element, "data")
                );

            }

            return list;
        }

        private IBaseUser ParseGetStreamStreamCommitsCommitsAuthor(
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

            return new BaseUser
            (
                DeserializeString(obj, "id"),
                DeserializeNullableString(obj, "name"),
                DeserializeNullableString(obj, "email")
            );
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString());
        }
        private int? DeserializeNullableInt(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (int?)_intSerializer.Deserialize(value.GetInt32());
        }
        private System.DateTimeOffset? DeserializeNullableDateTime(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (System.DateTimeOffset?)_dateTimeSerializer.Deserialize(value.GetString());
        }

        private string DeserializeNullableJSONObject(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (string)_jSONObjectSerializer.Deserialize(value.GetString());
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
