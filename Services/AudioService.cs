using AIApiWrapper.Configurations;
using AIApiWrapper.Models;
using System.Text;
using System.Text.Json;

namespace AIApiWrapper.Services
{
    public class AudioService
    {
        private readonly HttpClient _httpClient;

        public AudioService(IHttpClientFactory httpClientFactory, TextToSpeachConfig configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(configuration.Endpoint);
            _httpClient.DefaultRequestHeaders.Add("gateway-token", configuration.Token);
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
        public async Task<SpeachResponse> SendInputStringAsync(SpeachRequestPayload payload)
        {
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
        public async Task<TextToSpeechResponse> SendLongInputStringAsync(SpeachRequestPayload payload)
        {
            var json = JsonSerializer.Serialize(new { data = payload.Data, speaker = payload.Speaker }, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/TextToSpeech/v1/longText", requestContent);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TextToSpeechResponse>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public async Task<TextToSpeechTrackingResponse> GetAudioFileLinkAsync(string token)
        {
            var response = await _httpClient.GetAsync($"/TextToSpeech/v1/trackingFile/{token}");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TextToSpeechTrackingResponse>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }

}
