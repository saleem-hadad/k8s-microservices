using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;

namespace PlatformService.Services.Http
{
    public class HttpCommandDataClient: ICommandDataClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto platformReadDto)
        {
            var payload = new StringContent(
                JsonSerializer.Serialize(platformReadDto),
                Encoding.UTF8, 
                "application/json"
            );

            var response = await _client.PostAsync(_configuration["CommandService"], payload);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync to commands service was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync to commands service was NOT OK!");
            }
        }
    }
}