using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace BSynchro.Helpers.Configuration
{
    public class LoggerServiceConfiguration
    {
        public static void ConfigureService(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
        
    }
}