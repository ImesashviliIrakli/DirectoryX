using Domain.Entities;

namespace Domain.Repositories;

public interface IPhoneNumberRepository
{
    Task AddRangeAsync(List<PhoneNumber> phoneNumbers, CancellationToken cancellationToken = default);
}
