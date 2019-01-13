using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Farm_ASPCore_Webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseUrls("http://localhost:62573")
                .UseStartup<Startup>();
    }
}
