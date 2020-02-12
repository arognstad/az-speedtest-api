using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using SpeedTestApi.Models;

namespace SpeedTestApi.Services
{
  public class SpeedTestEvents : ISpeedTestEvents
  {
    private readonly EventHubClient _client;

    public SpeedTestEvents(string connectionString, string entityPath)
    {
      var connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString)
      {
        EntityPath = entityPath
      };

      _client = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
    }

    // Code continues here

    public void Dispose()
    {
      _client.CloseAsync();
    }

    public async Task PublishSpeedTest(TestResult speedTest)
    {
      var message = JsonSerializer.Serialize(speedTest);
      var data = new EventData(Encoding.UTF8.GetBytes(message));

      await _client.SendAsync(data);
    }
  }
}