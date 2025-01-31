using Domain.Entities;

namespace Domain.Repositories;

public interface IIndividualRepository
{
    Task AddAsync(Individual individual, CancellationToken cancellationToken = default);
}
