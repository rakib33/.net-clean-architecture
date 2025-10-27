using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using TopUp.Domain.Interfaces;

namespace TopUp.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);

        }
        public async Task<T> GetByIdAsync(long id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<long>(e, "Id") == id);
        }

        /// <summary>
        /// IQueryable is not awaitable; just return the queryable directly.
        /// AsNoTracking() improves performance for read-only queries
        /// </summary>
        /// <returns></returns>
        public Task<IQueryable<T>> GetAllAsync()
        {
            return Task.FromResult(_dbSet.AsNoTracking());
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }
        public async Task DeleteRangeAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await _context.Set<T>().Where(predicate).ToListAsync();
            if (entities.Count != 0)
            {
                _context.Set<T>().RemoveRange(entities);
            }
        }
        public Task SoftDeleteAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
        public Task RestoreAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
        public Task UpdatePartialAsync(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Attach(entity);

            foreach (var property in updatedProperties)
            {
                var memberExpression = property.Body as MemberExpression
                    ?? (property.Body as UnaryExpression)?.Operand as MemberExpression;

                if (memberExpression == null)
                {
                    throw new InvalidOperationException($"Invalid expression type for property: {property}");
                }

                var propertyName = memberExpression.Member.Name;
                _context.Entry(entity).Property(propertyName).IsModified = true;
            }
            return Task.CompletedTask;
        }
        public async Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TResult>> GetListByConditionAsync<TResult>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>>? selector = null)
        {
            IQueryable<T> query = _dbSet.Where(predicate);

            if (selector is not null)
            {
                return await query.Select(selector).ToListAsync();
            }
            var result = await query.ToListAsync();
            return result.Cast<TResult>().ToList();
        }

        public async Task<IEnumerable<T>> GetListByConditionWithIncludesAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync();
        }

        public async Task<List<T>> GetListByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        public async Task<List<T>> GetPagedListAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize)
        {
            return await _dbSet.Where(predicate)
                               .Skip((pageNumber - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();
        }
        public async Task<(int totalCount, IEnumerable<T>? data)> GetPaginatedResponse(Expression<Func<T, bool>> predicate, int pageNumber,
            int pageSize, List<(Expression<Func<T, object>> OrderBy, bool Ascending)>? sortFields = null)
        {
            var query = _dbSet.Where(predicate);
            IOrderedQueryable<T>? orderedQuery = null;
            if (sortFields != null)
            {
                foreach (var (orderBy, ascending) in sortFields)
                {
                    orderedQuery = orderedQuery == null
                        ? ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy)
                        : (ascending ? orderedQuery.ThenBy(orderBy) : orderedQuery.ThenByDescending(orderBy));
                }
                if (orderedQuery != null)
                {
                    query = orderedQuery;
                }
            }
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
            return (totalCount, items);
        }
        public async Task<List<T>> GetPagedListAsync<TKey>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TKey>> orderBy,
            TKey? lastKey = default,
            int pageSize = 10,
            bool isDescending = false)
        {
            // Input Validations
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (orderBy == null) throw new ArgumentNullException(nameof(orderBy));
            if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than zero.");

            // Base Query
            var query = _dbSet.Where(predicate);

            // Apply Keyset Filtering if lastKey is provided
            if (lastKey != null)
            {
                var parameter = orderBy.Parameters.Single();
                var comparison = isDescending
                    ? Expression.LessThan(orderBy.Body, Expression.Constant(lastKey, orderBy.Body.Type))
                    : Expression.GreaterThan(orderBy.Body, Expression.Constant(lastKey, orderBy.Body.Type));
                var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);

                query = query.Where(lambda);
            }

            // Apply Sorting and Paging
            query = isDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

            // Execute Query and Return Results
            var sqlQuery = query.ToQueryString();
            return await query.Take(pageSize).ToListAsync();
        }
        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
      
    }
}
