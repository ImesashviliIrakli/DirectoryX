using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Repositories;

namespace Application.Individuals.GetIndividuals;

internal sealed class GetIndividualsQueryHandler(
        IIndividualRepository individualRepository
    ) : ICommandQueryHandler<GetIndividualsQuery>
{
    private readonly IIndividualRepository _individualRepository = individualRepository;

    public async Task<Result> Handle(GetIndividualsQuery request, CancellationToken cancellationToken)
    {
        var individuals = await _individualRepository.SearchIndividualsAsync(request.IndividualSearchCriteria, cancellationToken);

        return Result.Success( new {  totalCount = individuals.TotalCount, individuals = individuals.Individuals });
    }
}
