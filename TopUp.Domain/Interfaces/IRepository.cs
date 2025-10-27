using System.Linq.Expressions;

namespace TopUp.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(long id);
    Task<IQueryable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(Expression<Func<T, bool>> predicate);
    Task SoftDeleteAsync(T entity);
    Task RestoreAsync(T entity);
    Task UpdatePartialAsync(T entity, params Expression<Func<T, object>>[] updatedProperties);
    Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate);
    Task<List<TResult>> GetListByConditionAsync<TResult>(Expression<Func<T, bool>> predicate,
        Expression<Func<T, TResult>>? selector = null);
    Task<IEnumerable<T>> GetListByConditionWithIncludesAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
    Task<(int totalCount, IEnumerable<T>? data)> GetPaginatedResponse(Expression<Func<T, bool>> predicate, int pageNumber,
        int pageSize, List<(Expression<Func<T, object>> OrderBy, bool Ascending)>? sortFields = null);
    Task<List<T>> GetPagedListAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize);
    Task<List<T>> GetPagedListAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy, TKey? lastKey = default, int pageSize = 10, bool isDescending = false);
    Task<T> GetByIdAsync(long id, params Expression<Func<T, object>>[] includes);
    Task<bool> Any(Expression<Func<T, bool>> predicate);
    
}
