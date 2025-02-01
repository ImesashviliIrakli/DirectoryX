using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;
using Domain.Errors;
using Domain.Repositories;

namespace Application.Individuals.UpdateIndividual;

internal sealed class UpdateIndividualCommandHandler(
        IIndividualRepository individualRepository,
        IUnitOfWork unitOfWork
    ) : ICommandQueryHandler<UpdateIndividualCommand>
{
    private readonly IIndividualRepository _individualRepository = individualRepository;
    public readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(UpdateIndividualCommand request, CancellationToken cancellationToken)
    {
        var individual = await _individualRepository.GetByIdAsync(
            individualId: request.IndividualId, 
            includeDetails: true,
            cancellationToken:cancellationToken
        );

        if (individual is null)
            return Result.Failure(GlobalStatusCodes.NotFound, IndividualErrors.IndividualNotFound);

        individual.UpdateBasicInfo(
                request.FirstName,
                request.LastName,
                request.Gender,
                request.PersonalNumber,
                request.DateOfBirth,
                request.CityId
            );

        var phoneNumbers = request.PhoneNumbers
            .Select(p => new PhoneNumber(individual.Id, p.NumberType, p.Number))
            .ToList();

        individual.UpdatePhoneNumbers(phoneNumbers);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
