using AIApiWrapper.Configurations;
using AIApiWrapper.Models;
using System.Text;
using System.Text.Json;

namespace AIApiWrapper.Services
{
    public class ChatBotService
    {
        private readonly HttpClient _httpClient;

        public ChatBotService(IHttpClientFactory httpClientFactory, ChitChatBotsConfig configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(configuration.Endpoint);
            _httpClient.DefaultRequestHeaders.Add("gateway-token", configuration.Token);
        }
        public async Task<ChitChatBotResponseObject> SendInputStringAsync(ChitChatBotPayload payload)
        {
            var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");


            var request = new HttpRequestMessage(HttpMethod.Post, "/chitChatBot/v1/chitChatBots")
            {
                Content = requestContent
            };

            request.Headers.Add("Origin", "https://isahab.ir"); // Add the Origin header

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ChitChatBotResponseObject>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }

}
