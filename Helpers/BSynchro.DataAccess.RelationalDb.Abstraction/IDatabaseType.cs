using Microsoft.Extensions.DependencyInjection;
using BSynchro.Helpers.Settings;

namespace BSynchro.DataAccess.RelationalDb.Abstraction
{
    /// <summary>
    /// An interface used for configuring the relational database
    /// All database connection types should implement this interface to connect via entity framework core.
    /// </summary>
    public interface IDatabaseType
    {
        /// <summary>
        /// Enables database type in the service collection. 
        /// </summary>
        /// <param name="services">to Enable the SQL database services</param>
        /// <param name="connectionOptions">storage settings for the SQL database</param>
        /// <returns>An IServiceCollection </returns>
        IServiceCollection EnableDatabase(IServiceCollection services, StorageSettings connectionOptions);

        /// <summary>
        /// Based on the database type and tenant id connection object is returned
        /// </summary>
        /// <param name="server">host name/address to the database</param>
        /// <param name="port">port that the host is bind to it</param>
        /// <param name="username">username credential</param>
        /// <param name="password">password credential</param>
        /// <param name="databaseName"> nanne of the Database</param>
        /// <returns>connection string</returns>
        string GetConnectionString(string server, string port, string username, string password, string databaseName);
    }
}
