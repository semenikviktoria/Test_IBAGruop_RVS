using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using Test_IBAGruop_RVS.Functional;

namespace Test_IBAGruop_RVS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (!(Directory.Exists(PathsToFileLocation.MainDirectiry)))
            {
                PathsToFileLocation.CreatCompletelyNewDataBase();
            }
                    CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
