﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SpeckleClient
{
    public class UserEditInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer _stringSerializer;

        public string Name { get; } = "UserEditInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(UserEditInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerResolver serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.GetValueSerializer("String");
            _needsInitialization = false;
        }

        public object Serialize(object value)
        {
            if (_needsInitialization)
            {
                throw new InvalidOperationException(
                    $"The serializer for type `{Name}` has not been initialized.");
            }

            if (value is null)
            {
                return null;
            }

            var input = (UserEditInput)value;
            var map = new Dictionary<string, object>();

            if (input.Bio.HasValue)
            {
                map.Add("bio", SerializeNullableString(input.Bio.Value));
            }

            if (input.Company.HasValue)
            {
                map.Add("company", SerializeNullableString(input.Company.Value));
            }

            if (input.Name.HasValue)
            {
                map.Add("name", SerializeNullableString(input.Name.Value));
            }

            return map;
        }

        private object SerializeNullableString(object value)
        {
            if (value is null)
            {
                return null;
            }


            return _stringSerializer.Serialize(value);
        }

        public object Deserialize(object value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
