using Domain.Entities;
using Domain.Models;

namespace Domain.Repositories;

public interface IIndividualRepository
{
    Task<(List<Individual> Individuals, int TotalCount)> SearchIndividualsAsync(IndividualSearchCriteria criteria, CancellationToken cancellationToken = default);
    Task<Individual?> GetByIdAsync(int individualId, bool includeDetails = false, bool track = true, CancellationToken cancellationToken = default);
    Task<bool> CheckIfIndividualExistsAsync(string personalNumber, CancellationToken cancellationToken = default);
    Task<bool> CheckIfIndividualsExistAsync(int individualId, int relatedIndividualId, CancellationToken cancellationToken = default);
    Task AddAsync(Individual individual, CancellationToken cancellationToken = default);
    void Delete(Individual individual);
}
