using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using BSynchro.Helpers.Settings;

namespace BSynchro.DataAccess.RelationalDb.EFCore.MsSQL
{
    /// <summary>
    /// Concrete implementation of the IEFCoreDatabaseType for MsSQL
    /// </summary>
    public class MsSql : IEFCoreDatabaseType
    {
        /// <inherit/>
        public IServiceCollection EnableDatabase(IServiceCollection services, StorageSettings connectionOptions)
        {
            return services;
        }

        /// <inherit/>
        public string GetConnectionString(string server, string port, string username, string password, string databaseName)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = $"{server},{port}",
                UserID = username,
                Password = password,
                InitialCatalog = databaseName
            };
            // decrypt password later on than return the connectionString as string;
            return sqlConnectionStringBuilder.ConnectionString;
        }

        /// <inherit/>
        public DbContextOptionsBuilder GetContextBuilder(DbContextOptionsBuilder optionsBuilder, StorageSettings connectionOptions)
        {
            return optionsBuilder.UseSqlServer(connectionOptions.ConnectionString);
        }
        /// <inherit/>
        public DbContextOptionsBuilder<TContext> SetConnectionString<TContext>(DbContextOptionsBuilder<TContext> contextOptionsBuilder, StorageSettings connectionOptions) where TContext : DbContext
        {
            return contextOptionsBuilder.UseSqlServer(connectionOptions.ConnectionString);
        }
    }
}