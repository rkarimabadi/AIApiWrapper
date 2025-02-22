using AIApiWrapper.Configurations;
using AIApiWrapper.Models;
using AIApiWrapper.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace AIApiWrapper
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddSingleton<TextToSpeachConfig>();
            builder.Services.AddSingleton<ChitChatBotsConfig>();
            builder.Services.AddSingleton<ChatBot4o1Config>();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<AudioService>();
            builder.Services.AddScoped<ChatBotService>();
            builder.Services.AddScoped<ChatBot4o1Service>();
            await builder.Build().RunAsync();
        }
    }
}
