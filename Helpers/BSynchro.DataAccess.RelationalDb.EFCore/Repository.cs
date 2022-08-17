using System.Linq.Expressions;
using BSynchro.DataAccess.Abstraction.Models;
using BSynchro.DataAccess.RelationalDb.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BSynchro.DataAccess.RelationalDb.EFCore
{
    /// <summary>
    /// Generic repository, contains CRUD operation of EF entity
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// EF data base context
        /// </summary>
        private readonly IDbContext _context;
        /// <summary>
        /// cash service
        /// </summary>
        
        /// <summary>
        /// Used to query and save instances of
        /// </summary>
        private readonly DbSet<T> dbSet;
        /// <summary>
        /// tenant context
        /// </summary>
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>       
        /// /// <param name="context">The context.</param>
        /// <param name="cacheService">the cache service </param>
        /// <param name="tenantContext">tenant contexr</param>
        public Repository(IDbContext context)
        {
            this._context = context;
            this.dbSet = context.Set<T>();
        }

        /// <inheritdoc />
        public virtual async Task AddAsync(T entity)
        {
            if (typeof(T).IsSubclassOf(typeof(BaseEntity)))
            {
                BaseEntity baseEntity = entity as BaseEntity;
                baseEntity.UpdatedOn = DateTime.UtcNow;
                baseEntity.CreatedOn = DateTime.UtcNow;
                await this.dbSet.AddAsync(entity);
            }
            await this.dbSet.AddAsync(entity);
        }
        /// <inheritdoc />
      
        public async Task<T> GetAsync<TKey>(TKey id)
        {
            return await this.dbSet.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<T> GetAsync(params object[] keyValues)
        {
            return await this.dbSet.FindAsync(keyValues);
        }
        /// <inheritdoc />
       
        /// <inheritdoc />
        public async Task<List<T>> FindAllByAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.dbSet.Where(predicate).ToListAsync();
        }
        /// <inheritdoc />
        public async Task<T> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.dbSet.Where(predicate).FirstOrDefaultAsync();
        }
        /// <inheritdoc />
        

        /// <inheritdoc />
        public async Task<List<T>> FindAllByAsync(Expression<Func<T, bool>> predicate, string include)
        {
            return await this.dbSet.Where(predicate).Include(include).ToListAsync();
        }
        /// <inheritdoc />
        public async Task<T> FindByAsync(Expression<Func<T, bool>> predicate, string include)
        {
            return await this.dbSet.Where(predicate).Include(include).FirstOrDefaultAsync();
        }
        /// <inheritdoc />
        

        /// <inheritdoc />
        public IQueryable<T> GetAll()
        {
            return this.dbSet;
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(int page, int pageCount)
        {
            var pageSize = (page - 1) * pageCount;
            return dbSet.Skip(pageSize).Take(pageCount);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll<TProperty>(int page, int pageCount,
            Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            var pageSize = (page - 1) * pageCount;
            return this.dbSet.Include(navigationPropertyPath).Skip(pageSize).Take(pageCount);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(string include)
        {
            return this.dbSet.Include(include);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(string include, string include2)
        {
            return this.dbSet.Include(include).Include(include2);
        }

        /// <inheritdoc />
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.dbSet.AnyAsync(predicate);
        }

        /// <inheritdoc />
        public async Task DeleteAsync<TKey>(TKey id)
        {
            var entity = await this.GetAsync<TKey>(id);
            if (entity != null)
                this.dbSet.Remove(entity);
        }
        /// <inheritdoc />
        
        /// <inheritdoc />
        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await this.dbSet.Where(predicate).FirstOrDefaultAsync();
            if (entity != null)
                this.dbSet.Remove(entity);
        }
        /// <inheritdoc />
        
        /// <inheritdoc />
        public async Task DeleteRangeAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await this.dbSet.Where(predicate).ToListAsync();
            if (entities != null && entities.Count > 0)
                this.dbSet.RemoveRange(entities);
        }
        /// <inheritdoc />
        public async Task DeleteAsync(params object[] keyValues)
        {
            var entity = await this.GetAsync(keyValues);
            if (entity != null)
                this.dbSet.Remove(entity);
        }
        /// <inheritdoc />     
    }
}