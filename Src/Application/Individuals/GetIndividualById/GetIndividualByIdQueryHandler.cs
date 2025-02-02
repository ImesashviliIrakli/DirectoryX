using Application.Abstractions.Messaging;
using Application.Dtos;
using AutoMapper;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Errors;
using Domain.Repositories;

namespace Application.Individuals.GetIndividualById;

internal sealed class GetIndividualByIdQueryHandler(
        IIndividualRepository individualRepository,
        IMapper mapper
    ) : ICommandQueryHandler<GetIndividualByIdQuery>
{
    private readonly IIndividualRepository _individualRepository = individualRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<Result> Handle(GetIndividualByIdQuery request, CancellationToken cancellationToken)
    {
        var individual = await _individualRepository.GetByIdAsync(
            individualId: request.IndividualId,
            includeDetails: true,
            track: false,
            cancellationToken: cancellationToken
        );

        if (individual is null)
            return Result.Failure(GlobalStatusCodes.NotFound, IndividualErrors.IndividualNotFound);

        var result = _mapper.Map<IndividualDto>(individual);

        return Result.Success(result);
    }
}
