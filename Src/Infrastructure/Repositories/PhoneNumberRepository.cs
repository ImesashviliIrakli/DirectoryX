using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories;

internal sealed class PhoneNumberRepository(
        AppDbContext context
    ) : IPhoneNumberRepository
{
    private readonly AppDbContext _context = context;
    public async Task AddRangeAsync(List<PhoneNumber> phoneNumbers, CancellationToken cancellationToken = default)
    {
        await _context.AddRangeAsync(phoneNumbers, cancellationToken );
    }
}
