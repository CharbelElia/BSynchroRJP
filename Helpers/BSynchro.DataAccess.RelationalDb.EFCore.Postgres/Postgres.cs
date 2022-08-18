using BSynchro.Helpers.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BSynchro.DataAccess.RelationalDb.EFCore.Postgres
{
    public class Postgres : IEFCoreDatabaseType
    {
        /// <inherit/>
        public IServiceCollection EnableDatabase(IServiceCollection services, StorageSettings connectionOptions)
        {
            services.AddEntityFrameworkNpgsql();
            return services;
        }

        /// <inherit/>
        public string GetConnectionString(string server, string port, string username, string password, string databaseName)
        {
            var npgsqlConnectionStringBuilder = new Npgsql.NpgsqlConnectionStringBuilder
            {
                Host = server,
                Port = int.Parse(port),
                Username = username,
                Password = password,
                Database = databaseName
            };
            // decrypt password later on than return the connectionString as string;
            return npgsqlConnectionStringBuilder.ConnectionString;
        }

        /// <inherit/>
        public DbContextOptionsBuilder GetContextBuilder(DbContextOptionsBuilder optionsBuilder, StorageSettings connectionOptions)
        {
            return optionsBuilder.UseNpgsql(connectionOptions.ConnectionString, b => { b.MigrationsHistoryTable("__EFMigrationsHistory"); });
        }

        /// <inherit/>
        public DbContextOptionsBuilder<TContext> SetConnectionString<TContext>(DbContextOptionsBuilder<TContext> contextOptionsBuilder, StorageSettings connectionOptions) where TContext : DbContext
        {
            return contextOptionsBuilder.UseNpgsql(connectionOptions.ConnectionString, b => { b.MigrationsHistoryTable("__EFMigrationsHistory"); });
        }
    }
}