using Domain.Entities;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class IndividualRepository(AppDbContext context) : IIndividualRepository
{
    private readonly AppDbContext _context = context;

    public async Task<(List<Individual> Individuals, int TotalCount)> SearchIndividualsAsync(IndividualSearchCriteria criteria, CancellationToken cancellationToken = default)
    {
        var query = _context.Individuals.AsQueryable();

        // Quick Search (name, surname, or personal number)
        if (!string.IsNullOrEmpty(criteria.QuickSearch))
        {
            var searchTerm = $"%{criteria.QuickSearch}%";
            query = query.Where(i =>
                EF.Functions.Like(i.FirstName, searchTerm) ||
                EF.Functions.Like(i.LastName, searchTerm) ||
                EF.Functions.Like(i.PersonalNumber, searchTerm));
        }

        // Detailed Search
        if (!string.IsNullOrEmpty(criteria.FirstName))
        {
            query = query.Where(i => i.FirstName.Contains(criteria.FirstName));
        }
        if (!string.IsNullOrEmpty(criteria.LastName))
        {
            query = query.Where(i => i.LastName.Contains(criteria.LastName));
        }
        if (!string.IsNullOrEmpty(criteria.PersonalNumber))
        {
            query = query.Where(i => i.PersonalNumber.Contains(criteria.PersonalNumber));
        }
        if (criteria.Gender.HasValue)
        {
            query = query.Where(i => i.Gender == criteria.Gender.Value);
        }
        if (criteria.CityId.HasValue)
        {
            query = query.Where(i => i.CityId == criteria.CityId.Value);
        }
        if (criteria.DateOfBirthFrom.HasValue)
        {
            query = query.Where(i => i.DateOfBirth >= criteria.DateOfBirthFrom.Value);
        }
        if (criteria.DateOfBirthTo.HasValue)
        {
            query = query.Where(i => i.DateOfBirth <= criteria.DateOfBirthTo.Value);
        }

        // Get the total count of matching records (before paging)
        int totalCount = await query.CountAsync(cancellationToken);

        // Apply paging
        var individuals = await query
            .AsNoTracking() // Don't need to track, only used for displaying individuals
            .OrderBy(i => i.LastName) // Default sorting
            .Skip((criteria.PageNumber - 1) * criteria.PageSize)
            .Take(criteria.PageSize)
            .ToListAsync(cancellationToken);

        return (individuals, totalCount);
    }
    public async Task<Individual?> GetByIdAsync(int individualId, bool includeDetails = false, bool track = true, CancellationToken cancellationToken = default)
    {
        var query = _context.Individuals.AsQueryable();

        if (!track)
        {
            query = query.AsNoTracking();
        }

        if (includeDetails)
        {
            query = query
                .Include(x => x.PhoneNumbers)
                .Include(x => x.RelatedIndividuals);
        }

        return await query.FirstOrDefaultAsync(x => x.Id == individualId, cancellationToken);
    }

    public async Task<bool> CheckIfIndividualExistsAsync(string personalNumber, CancellationToken cancellationToken = default)
    {
        return await _context.Individuals.AnyAsync(x => x.PersonalNumber.Equals(personalNumber), cancellationToken);
    }

    public async Task<bool> CheckIfIndividualsExistAsync(int individualId, int relatedIndividualId, CancellationToken cancellationToken = default)
    {
        var count = await _context.Individuals
            .Where(x => x.Id == individualId || x.Id == relatedIndividualId)
            .CountAsync(cancellationToken);

        return count == 2;
    }

    public async Task AddAsync(Individual individual, CancellationToken cancellationToken = default)
    {
        await _context.Individuals.AddAsync(individual, cancellationToken);
    }

    public void Delete(Individual individual)
    {
        _context.Individuals.Remove(individual);
    }
}
