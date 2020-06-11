using System;
using System.Threading.Tasks;
using StrawberryShake;
using StrawberryShake.Serializers;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;


namespace SpeckleClient
{
  class Program
  {
    static async Task Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      var serviceCollection = new ServiceCollection();
      var token = "e90c8db18d0a5175877bd106105fa0806bba36e621";

      serviceCollection.AddHttpClient("SpeckleClient", c => {
        c.BaseAddress = new Uri("http://localhost:3000/graphql");
        c.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
      });

      serviceCollection.AddSpeckleClient();
      serviceCollection.AddSingleton<IValueSerializer, JSONObjectSerializer>();

      IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
      ISpeckleClient client = serviceProvider.GetRequiredService<ISpeckleClient>();

      var result = await client.GetServerInfoAsync();
      Console.WriteLine(result.Data.ServerInfo.Name);
      Console.WriteLine(result.Data.ServerInfo.Company);
      Console.WriteLine(result.Data.ServerInfo.TermsOfService);
      Console.WriteLine(string.Join(", ", result.Data.ServerInfo.Roles.Select(role => role.Name).ToArray()));

      var testStream = await client.GetStreamAsync("154eaa6a1b");
      Console.WriteLine("-------- Stream -------- /n");
      Console.WriteLine(testStream.Data.Stream.Name);
      Console.WriteLine(testStream.Data.Stream.Commits.TotalCount);
      Console.WriteLine(testStream.Data.Stream.CreatedAt.ToString());
    }
  }

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
