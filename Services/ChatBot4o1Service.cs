using AIApiWrapper.Models;
using System.Text;
using System.Text.Json;

namespace AIApiWrapper.Services
{
    public class ChatBot4o1Service
    {
        private readonly HttpClient _httpClient;

        public ChatBot4o1Service(IHttpClientFactory httpClientFactory, ChatBot4o1Config configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            //_httpClient.BaseAddress = new Uri(configuration.Endpoint);
            _httpClient.BaseAddress = new Uri("https://main.gpt-chatbotru-4-o1.ru");
        }
        public async Task<ChatBot4o1ResponseObject> SendInputStringAsync(ChatBot4o1Payload payload)
        {
            var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");


            var request = new HttpRequestMessage(HttpMethod.Post, "/api/openai/v1/chat/completions")
            {
                Content = requestContent
            };

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ChatBot4o1ResponseObject>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }

}
