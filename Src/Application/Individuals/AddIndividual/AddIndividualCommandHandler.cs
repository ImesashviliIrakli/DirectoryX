using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Individuals.AddIndividual;

internal sealed class AddIndividualCommandHandler(
        IIndividualRepository individualRepository,
        IUnitOfWork unitOfWork
    ) : ICommandQueryHandler<AddIndividualCommand>
{
    private readonly IIndividualRepository _individualRepository = individualRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(AddIndividualCommand request, CancellationToken cancellationToken)
    {
        var individual = new Individual(
                request.FirstName,
                request.LastName,
                request.Gender,
                request.PersonalNumber,
                request.DateOfBirth,
                request.CityId
            );

        if (request.PhoneNumbers.Count > 0)
        {
            var phoneNumbers = request.PhoneNumbers
              .Select(p => new PhoneNumber(individual.Id, p.Type, p.Number))
              .ToList();

            individual.AddPhoneNumbers(phoneNumbers);
        }

        await _individualRepository.AddAsync(individual, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
