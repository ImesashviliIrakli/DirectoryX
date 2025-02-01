using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class PhoneNumberRepository(
        AppDbContext context
    ) : IPhoneNumberRepository
{
    private readonly AppDbContext _context = context;

    public async Task DeleteAllByIndividualIdAsync(int individualId, CancellationToken cancellationToken = default)
    {
        var phoneNumbers = await _context.PhoneNumbers
        .Where(p => p.IndividualId == individualId)
        .ToListAsync(cancellationToken);

        if (phoneNumbers.Any())
            _context.PhoneNumbers.RemoveRange(phoneNumbers);
    }
}
