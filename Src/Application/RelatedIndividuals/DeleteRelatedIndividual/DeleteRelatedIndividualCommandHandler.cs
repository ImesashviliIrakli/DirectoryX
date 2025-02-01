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
        var exists = await _relatedIndividualRepository.CheckIfRelationExistsAsync(request.IndividualId, request.RelatedIndividualId, cancellationToken);

        if (!exists)
            return Result.Failure(GlobalStatusCodes.NotFound, RelatedIndividualErrors.RelationshipNotFound);

        await _relatedIndividualRepository.DeleteAsync(request.IndividualId, request.RelatedIndividualId, cancellationToken);
        await _relatedIndividualRepository.DeleteAsync(request.RelatedIndividualId, request.IndividualId, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
