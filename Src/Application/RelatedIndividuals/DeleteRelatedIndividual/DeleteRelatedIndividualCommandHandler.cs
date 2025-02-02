using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Errors;
using Domain.Repositories;

namespace Application.RelatedIndividuals.DeleteRelatedIndividual;

internal sealed class DeleteRelatedIndividualCommandHandler(
        IRelatedIndividualRepository relatedIndividualRepository,
        IUnitOfWork unitOfWork
    ) : ICommandQueryHandler<DeleteRelatedIndividualCommand>
{
    private readonly IRelatedIndividualRepository _relatedIndividualRepository = relatedIndividualRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteRelatedIndividualCommand request, CancellationToken cancellationToken)
    {
        var relatedIndividuals = await _relatedIndividualRepository
            .GetAllRelationsAsync(request.IndividualId, request.RelatedIndividualId, cancellationToken);

        if (!relatedIndividuals.Any())
            return Result.Failure(GlobalStatusCodes.NotFound, RelatedIndividualErrors.RelationshipNotFound);

        _relatedIndividualRepository.DeleteRange(relatedIndividuals);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
