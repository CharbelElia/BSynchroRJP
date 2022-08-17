using Microsoft.EntityFrameworkCore;
using BSynchro.DataAccess.RelationalDb.Abstraction;
using BSynchro.Helpers.Settings;

namespace BSynchro.DataAccess.RelationalDb.EFCore
{
    public interface IEFCoreDatabaseType : IDatabaseType
    {
        /// <summary>
        /// Based on the database context builder instance is created
        /// </summary>
        /// <param name="optionsBuilder">Context builder</param>
        /// <param name="connectionOptions">Configured connection settings</param>
        /// <param name="connectionString">Connection String </param>
        /// <returns>the create DbContextOptionsBuilder</returns>
        DbContextOptionsBuilder GetContextBuilder(DbContextOptionsBuilder optionsBuilder, StorageSettings connectionOptions);
        /// <summary>
        /// updates with new connection string
        /// </summary>
        /// <typeparam name="TContext">Type of the context</typeparam>
        /// <param name="contextOptionsBuilder">Context builder</param>
        /// <param name="connectionString"> Connection string</param>
        /// <returns>the updated DbContextOptionsBuilder of a context </returns>
        DbContextOptionsBuilder<TContext> SetConnectionString<TContext>(DbContextOptionsBuilder<TContext> contextOptionsBuilder, StorageSettings connectionString) where TContext : DbContext;
    }
}
