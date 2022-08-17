using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.OpenApi.Models;
using BSynchro.Helpers.Constants;

namespace BSynchro.Helpers.Configuration
{
    /// <summary>
    /// Swagger API documentation components start-up configuration
    /// </summary>
    public static class SwaggerConfiguration
    {
        private static string endpointName;

        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        /// <param name="title"></param>
        /// <param name="version"></param>
        /// <param name="description"></param>
        /// <param name="epName"></param>
        public static void ConfigureService(IServiceCollection services, string xmlPath, string title, string version,
            string description, string epName, bool tenantHeaderOperation = true, bool userHeaderOperation = true)
        {
            SwaggerConfiguration.endpointName = epName;
            // Swagger API documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(DefaultConstants.SwaggerVersion,
                    new OpenApiInfo
                    {
                        Title = title,
                        Version = version,
                        Description = description,
                        Contact = new OpenApiContact
                        {
                            Name = DefaultConstants.SwaggerDeveloperName,
                            Email = DefaultConstants.SwaggerDeveloperEmail
                        }
                    });
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void Configure(IApplicationBuilder app)
        {
            // This will redirect default url to Swagger url
            var option = new RewriteOptions();
            option.AddRedirect(DefaultConstants.SwaggerRedirectionRegex,
                DefaultConstants.SwaggerRedirectionReplacement);
            app.UseRewriter(option);

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint(DefaultConstants.SwaggerEndpointUrl, endpointName); });
        }
    }
}