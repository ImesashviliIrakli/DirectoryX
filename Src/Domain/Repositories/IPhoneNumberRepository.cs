namespace Domain.Repositories;

public interface IPhoneNumberRepository
{
    Task DeleteAllByIndividualIdAsync(int individualId, CancellationToken cancellationToken = default);
}
