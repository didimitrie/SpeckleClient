using System;
using System.Threading.Tasks;
using StrawberryShake;
using StrawberryShake.Serializers;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace SpeckleClient
{
#nullable enable
  public class JSONObjectSerializer : ValueSerializerBase<String, String>
  {
    public override string Name => "JSONObject";

    public override ValueKind Kind => ValueKind.String;
    public override object? Serialize(object? value)
    {
      if (value is null)
      {
        return null;
      }

      if (value is string s)
      {
        return s;
      }

      throw new ArgumentException(
          "The specified value is of an invalid type. " +
          $"{ClrType.FullName} was expeceted.");
    }

    public override object? Deserialize(object? serialized)
    {
      if (serialized is null)
      {
        return null;
      }

      if (serialized is string s)
      {
        return s;
      }

      throw new ArgumentException(
          "The specified value is of an invalid type. " +
          $"{SerializationType.FullName} was expeceted.");
    }

  }
}