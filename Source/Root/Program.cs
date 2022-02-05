using Microsoft.AspNetCore;

namespace Root
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var webHost = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

            await webHost.RunAsync();
        }
    }
}