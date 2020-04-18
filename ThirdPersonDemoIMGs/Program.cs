using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Logging;

namespace ThirdPersonDemoIMGs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                             .Build();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)  //.UseUrls("http://0.0.0.0:5000")
                   .UseStartup<Startup>();
    }
}
