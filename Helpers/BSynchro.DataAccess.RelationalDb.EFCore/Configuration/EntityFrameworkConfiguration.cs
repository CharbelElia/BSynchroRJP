using Microsoft.Extensions.DependencyInjection;
using BSynchro.DataAccess.RelationalDb.Abstraction;
using BSynchro.Helpers.Reflection;
using BSynchro.Helpers.Settings;
using System;
using System.Linq;

namespace BSynchro.DataAccess.RelationalDb.EFCore.Configuration
{
    /// <summary>
    /// Configurations related to entity framework
    /// </summary>
    public static class EntityFrameworkConfiguration
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        public static IEFCoreDatabaseType ConfigureService(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            // Database connection settings
            var connectionOptions = services.BuildServiceProvider().GetRequiredService<StorageSettings>();
            var databaseTypeInstance = GetDatabaseTypeInstance(connectionOptions);
            databaseTypeInstance.EnableDatabase(services, null);
            return databaseTypeInstance;
        }

        /// <summary>
        /// Get DataBase Type instance
        /// </summary>
        /// <returns>IDatabaseType instance </returns>
        private static IEFCoreDatabaseType GetDatabaseTypeInstance(StorageSettings connectionOptions)
        {
            var databaseInterfaceType = typeof(IEFCoreDatabaseType);
            var instanceType = connectionOptions.DatabaseType;
            var databaseType = ReflectionHelper.GetDatabaseType(instanceType);
            var instance = databaseType.Assembly.GetTypes().FirstOrDefault(x =>
             databaseInterfaceType.IsAssignableFrom(x)
             &&
             string.Equals(instanceType, x.Name, StringComparison.OrdinalIgnoreCase));
            return (IEFCoreDatabaseType)Activator.CreateInstance(instance);
        }

    }
}