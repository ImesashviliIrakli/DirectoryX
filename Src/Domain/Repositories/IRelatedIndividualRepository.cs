using Domain.Entities;
using Domain.Models;

namespace Domain.Repositories;

public interface IRelatedIndividualRepository
{
    Task<List<RelatedIndividualsReport>> GetRelatedIndividualsReportAsync(int? individualId = null, CancellationToken cancellationToken = default);
    Task<List<RelatedIndividual>> GetAllRelationsAsync(int individualId, int relatedIndividualId, CancellationToken cancellationToken = default);
    Task<bool> CheckIfRelationExistsAsync(int individualId, int relatedIndividualId, CancellationToken cancellationToken = default);
    Task AddRangeAsync(List<RelatedIndividual> relatedIndividuals, CancellationToken cancellationToken = default);
    void DeleteRange(List<RelatedIndividual> relatedIndividuals);
    Task DeleteAllRelationsAsync(int individualId, CancellationToken cancellationToken = default);
}

