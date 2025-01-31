using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class IndividualRepository(AppDbContext context) : IIndividualRepository
{
    private readonly AppDbContext _context = context;
    public async Task<Individual?> GetByIdAsync(int individualId, CancellationToken cancellationToken = default)
    {
        return await _context.Individuals
            .Include(x => x.PhoneNumbers)
            .FirstOrDefaultAsync(x => x.Id.Equals(individualId));
    }

    public async Task AddAsync(Individual individual, CancellationToken cancellationToken = default)
    {
        await _context.Individuals.AddAsync(individual, cancellationToken);
    }
}
