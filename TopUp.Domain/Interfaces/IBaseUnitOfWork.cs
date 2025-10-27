namespace TopUp.Domain.Interfaces;

public interface IBaseUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task<long> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    void TrackingRemove();
}
