using BSynchro.DataAccess.RelationalDb.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSynchro.DataAccess.RelationalDb.EFCore
{
    /// <summary>
    /// The Entity Framework implementation of IUnitOfWork
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private IDbContext dbContext;
        /// <summary>
        /// The repositories
        /// </summary>
        private Dictionary<Type, object> repositories;
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cacheService">the cache service </param>
        /// <param name="tenantContext">tenant contexr</param>
        public UnitOfWork(IDbContext context)
        {
            this.dbContext = context;
        }

        /// <inheritdoc/>
        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (this.repositories == null)
            {
                this.repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!this.repositories.ContainsKey(type))
            {
                this.repositories[type] = new Repository<TEntity>(this.dbContext);
            }

            return (IRepository<TEntity>) this.repositories[type];
        }

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync()
        {
            // Save changes with the default options
            return await this.dbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);

            // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
            GC.SuppressFinalize(obj: this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dbContext != null)
                {
                    this.dbContext.Dispose();
                    this.dbContext = null;
                }
            }
        }
    }
}