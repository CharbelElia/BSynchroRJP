using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BSynchro.DataAccess.RelationalDb.Abstraction
{
    /// <summary>
    /// Interface for generic repository, contains CRUD operation on entities
    /// </summary>
    /// <typeparam name="T">entity</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>Entity</returns>
        Task<T> GetAsync<TKey>(TKey id);
        /// <summary>
        /// Gets an entity by the keys specified in <paramref name="keyValues"/>
        /// </summary>
        /// <param name="keyValues">Composite Primary Key Identifiers</param>
        /// <returns>The requested Entity</returns>
        Task<T> GetAsync(params object[] keyValues);
        /// <summary>
        /// Generic find by predicate
        /// </summary>
        /// <param name="predicate">Query predicate</param>
        /// <returns>Entity</returns>
        Task<T> FindByAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Generic find by predicate 
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Queryable</returns>
        Task<List<T>> FindAllByAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Generic find by predicate and option to include child entity
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="include">The include sub-entity.</param>
        /// <returns>Queryable</returns>
        Task<List<T>> FindAllByAsync(Expression<Func<T, bool>> predicate, string include);
        /// <summary>
        /// Generic find by predicate and option to include child entity
        /// </summary>
        /// <param name="predicate">Query predicate</param>
        /// <param name="include">The include sub-entity.</param>
        /// <returns>Entity</returns>
        Task<T> FindByAsync(Expression<Func<T, bool>> predicate, string include);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List of entities</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets all. With data pagination.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageCount">The page count.</param>
        /// <returns></returns>
        IQueryable<T> GetAll(int page, int pageCount);

        /// <summary>
        /// Gets all. With data pagination.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageCount">The page count.</param>
        /// <param name="navigationPropertyPath">Child entity to include</param>
        /// <returns></returns>
        IQueryable<T> GetAll<TProperty>(int page, int pageCount, Expression<Func<T, TProperty>> navigationPropertyPath);

        /// <summary>
        /// Gets all and offers to include a related table
        /// </summary>
        /// <param name="include">Te sub.entity to include</param>
        /// <returns>List of entities</returns>
        IQueryable<T> GetAll(string include);
        /// <summary>
        /// Gets all and offers to include 2 related tables
        /// </summary>
        /// <param name="include">The sub.entity to include</param>
        /// <param name="include2">The second sub.entity to include</param>
        /// <returns>List of entities</returns>
        IQueryable<T> GetAll(string include, string include2);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task AddAsync(T entity);
        /// <summary>
        /// delete the entity with this identifier.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        Task DeleteAsync<TKey>(TKey id);
        /// <summary>
        /// delete the first entity that match the predicate
        /// </summary>
        /// <param name="predicate">Expression function representing the predicate to be applied</param>
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// delete all entities that match the predicate"/>
        /// </summary>
        /// <param name="predicate">Expression function representing the predicate to be applied</param>
        Task DeleteRangeAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// delete an entity by the keys specified in <paramref name="keyValues"/>
        /// </summary>
        /// <param name="keyValues">Composite Primary Key Identifiers</param>
        Task DeleteAsync(params object[] keyValues);
        /// <summary>
        /// Checks whether a entity matching the <paramref name="predicate"/> exists
        /// </summary>
        /// <param name="predicate">The predicate to filter on</param>
        /// <returns>Whether an entity matching the <paramref name="predicate"/> exists</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }
}