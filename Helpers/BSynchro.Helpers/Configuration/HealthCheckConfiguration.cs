using Microsoft.Extensions.DependencyInjection;
using BSynchro.Helpers.HealthChecker;

namespace BSynchro.Helpers.Configuration
{
    /// <summary>
    /// Configures Health Check service in the application
    /// </summary>
    public static class HealthCheckConfiguration
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddHealthChecks().AddCheck<HealthCheck>("health_check");
        }
    }
}