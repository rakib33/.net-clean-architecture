using Microsoft.EntityFrameworkCore.Storage;
using TopUp.Domain.Interfaces;
using TopUp.Infrastructure.Persistence.Context;

namespace TopUp.Infrastructure.Repositories;

public class BaseUnitOfWork : IBaseUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;
    private IDbContextTransaction? _transaction;
    private readonly Dictionary<Type, object> _repositories = new();

    public BaseUnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepository<T> Repository<T>() where T : class
    {
        if (_repositories.TryGetValue(typeof(T), out var repository))
        {
            return (IRepository<T>)repository;
        }
        var newRepository = new Repository<T>(_context);
        _repositories[typeof(T)] = newRepository;
        return newRepository;
    }

    public async Task<long> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        if (_transaction != null)
            throw new InvalidOperationException("A transaction is already in progress.");

        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction == null)
            throw new InvalidOperationException("No transaction is in progress.");

        try
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            DisposeTransaction();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction == null)
            throw new InvalidOperationException("No transaction is in progress.");

        await _transaction.RollbackAsync();
        DisposeTransaction();
    }

    public void TrackingRemove()
    {
        _context.ChangeTracker.Clear();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }

    private void DisposeTransaction()
    {
        _transaction?.Dispose();
        _transaction = null;
    }
}
