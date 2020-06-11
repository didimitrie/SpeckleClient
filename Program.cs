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
      var token = "1ba000c750cbce7264b89d0b212e0cec581362f38a";

      serviceCollection.AddHttpClient("SpeckleClient", c =>
      {
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

      // var testStream = await client.GetStreamAsync("154eaa6a1b");
      // Console.WriteLine("-------- Stream -------- /n");
      // Console.WriteLine(testStream.Data.Stream.Name);
      // Console.WriteLine(testStream.Data.Stream.Commits.TotalCount);
      // Console.WriteLine(testStream.Data.Stream.CreatedAt.ToString());

      var profile = await client.GetMyProfileAsync();
      Console.WriteLine($"My name is now {profile.Data.User.Name}");
      var testUEdit = await client.UserEditAsync( new Optional<UserEditInput>(new UserEditInput{
        Name = "Balrog The Third"
      }));
      
      var profile2 = await client.GetMyProfileAsync();
      Console.WriteLine($"My name is now {profile2.Data.User.Name}");


    }
  }
}
