using Api;
using Microsoft.AspNetCore;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await BuildHost(args).Build().RunAsync();
    }

    public static IWebHostBuilder BuildHost(string[] args)
    {
        return WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}
