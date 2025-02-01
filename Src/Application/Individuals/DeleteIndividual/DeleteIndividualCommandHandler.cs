using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Errors;
using Domain.Repositories;

namespace Application.Individuals.DeleteIndividual;

internal sealed class DeleteIndividualCommandHandler(
        IIndividualRepository individualRepository,
        IPhoneNumberRepository phoneNumberRepository,
        IRelatedIndividualRepository relatedIndividualRepository,
        IUnitOfWork unitOfWork
    ) : ICommandQueryHandler<DeleteIndividualCommand>
{
    private readonly IIndividualRepository _individualRepository = individualRepository;
    private readonly IPhoneNumberRepository _phoneNumberRepository = phoneNumberRepository;
    private readonly IRelatedIndividualRepository _relatedIndividualRepository = relatedIndividualRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteIndividualCommand request, CancellationToken cancellationToken)
    {
        using (var transaction = _unitOfWork.BeginTransaction())
        {
            var individual = await _individualRepository.GetByIdAsync(
                individualId: request.IndividualId, 
                includeDetails: false,
                cancellationToken: cancellationToken
            );

            if (individual is null)
            {
                transaction.Rollback();
                return Result.Failure(GlobalStatusCodes.NotFound, IndividualErrors.IndividualNotFound);
            }

            // Remove related individuals
            await _relatedIndividualRepository.DeleteAllRelationsAsync(request.IndividualId, cancellationToken);

            // Remove phone numbers
            await _phoneNumberRepository.DeleteAllByIndividualIdAsync(request.IndividualId, cancellationToken);

            // Remove the individual
            _individualRepository.Delete(individual);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            transaction.Commit();

            return Result.Success();
        }
    }
}
