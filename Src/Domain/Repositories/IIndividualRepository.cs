using Domain.Entities;

namespace Domain.Repositories;

public interface IIndividualRepository
{
    Task<Individual?> GetByIdAsync(int individualId, CancellationToken cancellationToken = default);
    Task AddAsync(Individual individual, CancellationToken cancellationToken = default);
}
