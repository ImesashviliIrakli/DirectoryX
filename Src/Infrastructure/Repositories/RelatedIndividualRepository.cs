using Domain.Entities;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class RelatedIndividualRepository(
        AppDbContext context
    ) : IRelatedIndividualRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<RelatedIndividualsReport>> GetRelatedIndividualsReportAsync(int? individualId = null, CancellationToken cancellationToken = default)
    {
        var groupedData = await _context.RelatedIndividuals
            .GroupBy(r => new { r.IndividualId, r.RelationshipType })
            .Select(g => new
            {
                g.Key.IndividualId,
                g.Key.RelationshipType,
                Count = g.Count()
            })
            .ToListAsync(cancellationToken);

        var report = groupedData
            .GroupBy(g => g.IndividualId)
            .Select(g => new RelatedIndividualsReport
            {
                IndividualId = g.Key,
                Relationships = g.Select(r => new RelationshipCount
                {
                    Type = r.RelationshipType,
                    Count = r.Count
                }).ToList()
            })
            .ToList();

        return report;
    }

    public async Task<List<RelatedIndividual>> GetAllRelationsAsync(int individualId, int relatedIndividualId, CancellationToken cancellationToken = default)
    {
        return await _context.RelatedIndividuals
            .Where(r => (r.IndividualId == individualId && r.RelatedIndividualId == relatedIndividualId) ||
                        (r.IndividualId == relatedIndividualId && r.RelatedIndividualId == individualId))
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> CheckIfRelationExistsAsync(int individualId, int relatedIndividualId, CancellationToken cancellationToken = default)
    {
        return await _context.RelatedIndividuals
         .AnyAsync(r => r.IndividualId == individualId && r.RelatedIndividualId == relatedIndividualId, cancellationToken);
    }

    public async Task AddRangeAsync(List<RelatedIndividual> relatedIndividuals, CancellationToken cancellationToken = default)
    {
        await _context.RelatedIndividuals.AddRangeAsync(relatedIndividuals, cancellationToken);
    }

    public void DeleteRange(List<RelatedIndividual> relatedIndividuals)
    {
        _context.RelatedIndividuals.RemoveRange(relatedIndividuals);
    }

    public async Task DeleteAllRelationsAsync(int individualId, CancellationToken cancellationToken = default)
    {
        var relations = await _context.RelatedIndividuals
            .Where(r => r.IndividualId == individualId || r.RelatedIndividualId == individualId)
            .ToListAsync(cancellationToken);

        if (relations.Any())
            _context.RelatedIndividuals.RemoveRange(relations);
    }
}
