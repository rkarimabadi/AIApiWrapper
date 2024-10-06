using AIApiWrapper.Configurations;
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
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<AudioService>();
            builder.Services.AddScoped<ChatBotService>();
            await builder.Build().RunAsync();
        }
    }
}
