using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Errors;
using Domain.Repositories;

namespace Application.Individuals.GetIndividualById;

internal sealed class GetIndividualByIdQueryHandler(
        IIndividualRepository individualRepository
    ) : ICommandQueryHandler<GetIndividualByIdQuery>
{
    private readonly IIndividualRepository _individualRepository = individualRepository;
    public async Task<Result> Handle(GetIndividualByIdQuery request, CancellationToken cancellationToken)
    {
        var individual = await _individualRepository.GetByIdAsync(
            individualId: request.IndividualId,
            includeDetails: true,
            cancellationToken: cancellationToken
        );

        if (individual is null)
            return Result.Failure(GlobalStatusCodes.NotFound, IndividualErrors.IndividualNotFound);

        return Result.Success(individual);
    }
}
