using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BSynchro.DataAccess.Context;
using BSynchro.Dto.Mapper;
using BSynchro.WebApi.Constants;
using BSynchro.DataAccess.Seed;
using Serilog;
using BSynchro.Service.Abstraction;
using BSynchro.Service;
using BSynchro.Helpers.Configuration;
using Microsoft.EntityFrameworkCore;
using BSynchro.DataAccess.RelationalDb.EFCore;
using BSynchro.DataAccess.RelationalDb.EFCore.Configuration;
using System;
using BSynchro.Helpers.Constants;
using AutoMapper;
using BSynchro.Helpers.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using BSynchro.WebApi.Controllers;
using BSynchro.Helpers.ActionFilters;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using BSynchro.Helpers.Settings;
using Microsoft.Extensions.Options;
using BSynchro.DataAccess.RelationalDb.Abstraction;

namespace BSynchro.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            HealthCheckConfiguration.ConfigureService(services);
            services.AddControllers();
            LoggerServiceConfiguration.ConfigureService(services, Configuration);
            RegisterDatabaseServices<BSynchroContext, BSynchroDataSeeder>(services);
            RegisterBSynchroServices(services);
            RegisterBSynchroMappingServices(services, typeof(BSynchroMappingProfile));
            AddCrossOriginResourceSharing(services);
            RegisterSwaggerConfiguration<AccountsController>(services, new SwaggerConstants());
            RegisterBSynchroExceptionFilter(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSerilogRequestLogging();
            app.UseCors("BSynchroPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            MigrateDatabase<BSynchroContext>(app);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            SwaggerConfiguration.Configure(app);
        }

        private void RegisterBSynchroServices(IServiceCollection services)
        {
            services.AddTransient<IAccountsService, AccountsService>();
            services.AddTransient<ITransactionsService, TransactionsService>();
            services.AddTransient<ICustomersService, CustomersService>();
        }
        private void RegisterDatabaseServices<TContext, TDataSeeder>(IServiceCollection services) where TDataSeeder : class, IEFCoreDataSeeder where TContext : DbContext, IDbContext
        {
            services.AddTransient<IDataSeeder<ModelBuilder>, TDataSeeder>();
            services.Configure<StorageSettings>(Configuration.GetSection(DefaultConstants.StorageSettings));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<StorageSettings>>().Value);
            IEFCoreDatabaseType databaseType = EntityFrameworkConfiguration.ConfigureService(services);
            var connectionOptions = services.BuildServiceProvider().GetRequiredService<StorageSettings>();
            services.AddDbContext<TContext>(options =>
                databaseType.GetContextBuilder(options, connectionOptions));
            services.AddScoped<IDbContext, TContext>();
        }
        private void RegisterBSynchroMappingServices(IServiceCollection services, params Type[] types)
        {
            services.AddAutoMapper(types);
            services.AddTransient<IBSynchroMapper, BSynchroAutoMapper>();
        }
        private void AddCrossOriginResourceSharing(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("BSynchroPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }
        private void RegisterSwaggerConfiguration<TController>(IServiceCollection services,
            IBaseSwaggerSettings baseSwaggerSettings, bool hasTenantHeader = true, bool hasUserHeader = true)
            where TController : ControllerBase
        {
            var xmlFile = $"{typeof(TController).Assembly.GetName().Name}.xml";
            var xmlDocumentationPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            SwaggerConfiguration.ConfigureService(services, xmlDocumentationPath, baseSwaggerSettings.GetTitle(),
                baseSwaggerSettings.GetVersion(), baseSwaggerSettings.GetDescription(),
                baseSwaggerSettings.GetEndpointName(), hasTenantHeader, hasUserHeader);
        }
        private void RegisterBSynchroExceptionFilter(IServiceCollection services)
        {
            services.AddMvcCore(config => { config.Filters.Add(typeof(BSynchroExceptionFilter)); });
        }
        private void MigrateDatabase<TContext>(IApplicationBuilder app) where TContext : DbContext
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetService<TContext>();
            context.GetInfrastructure().GetService<IMigrator>();
            context.Database.Migrate();
        }
    }
}