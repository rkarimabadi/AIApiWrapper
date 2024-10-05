using AIApiWrapper.Models;
using System.Text;
using System.Text.Json;

namespace AIApiWrapper.Services
{
    public class AudioService
    {
        private readonly HttpClient _httpClient;

        public AudioService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            IConfigurationSection textToSpeachConfig = configuration.GetSection("TextToSpeach");
            _httpClient.BaseAddress = new Uri(textToSpeachConfig["Endpoint"]!);
            _httpClient.DefaultRequestHeaders.Add("gateway-token", textToSpeachConfig["Token"]);
        }

        public async Task<AudioResponse> SendAudioAsync(string base64Audio)
        {
            var request = new AudioRequest
            {
                Language = "fa",
                Data = base64Audio
            };

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync("/speechRecognition/v1/base64", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AudioResponse>(responseContent, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
        public async Task<SpeachResponse> SendInputStringAsync(string inputString)
        {
            var payload = new SpeachRequestPayload
            {
                Data = inputString,
                FilePath = true,
                Base64 = "1",
                Checksum = "1",
                Timestamp = "1",
                Speaker = "3",
                Speed = "1"
            };
            var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync("/TextToSpeech/v1/speech-synthesys", requestContent);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SpeachResponse>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }

}
