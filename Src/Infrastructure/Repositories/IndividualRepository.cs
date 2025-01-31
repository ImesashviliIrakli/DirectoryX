using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories;

internal sealed class IndividualRepository(AppDbContext context) : IIndividualRepository
{
    private readonly AppDbContext _context = context;
    public async Task AddAsync(Individual individual, CancellationToken cancellationToken = default)
    {
        await _context.Individuals.AddAsync(individual, cancellationToken);
    }
}
