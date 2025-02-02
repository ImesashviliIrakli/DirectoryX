using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;
using Domain.Errors;
using Domain.Repositories;

namespace Application.RelatedIndividuals.AddRelatedIndividual;

internal sealed class AddRelatedIndividualCommandHandler(
        IIndividualRepository individualRepository,
        IRelatedIndividualRepository relatedIndividualRepository,
        IUnitOfWork unitOfWork
    ) : ICommandQueryHandler<AddRelatedIndividualCommand>
{
    private readonly IIndividualRepository _individualRepository = individualRepository;
    private readonly IRelatedIndividualRepository _relatedIndividualRepository = relatedIndividualRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(AddRelatedIndividualCommand request, CancellationToken cancellationToken)
    {
        var checkIndividuals = await _individualRepository.CheckIfIndividualsExistAsync(request.IndividualId, request.RelatedIndividualId, cancellationToken);

        if (!checkIndividuals)
            return Result.Failure(GlobalStatusCodes.NotFound, RelatedIndividualErrors.EitherOneOrNoneExist);

        var checkRelation = await _relatedIndividualRepository.CheckIfRelationExistsAsync(request.IndividualId, request.RelatedIndividualId, cancellationToken);

        if (checkRelation)
            return Result.Failure(GlobalStatusCodes.NotFound, RelatedIndividualErrors.RelationshipAlreadyExists);

        var relatedIndividuals = new List<RelatedIndividual>
        {
            new RelatedIndividual(request.IndividualId, request.RelatedIndividualId, request.RelationshipType),
            new RelatedIndividual(request.RelatedIndividualId, request.IndividualId, request.RelationshipType)
        };

        await _relatedIndividualRepository.AddRangeAsync(relatedIndividuals, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
