using System.Data;

namespace Domain.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    IDbTransaction BeginTransaction();
}
