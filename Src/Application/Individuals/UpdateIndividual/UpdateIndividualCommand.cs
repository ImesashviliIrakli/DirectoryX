using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.Individuals.UpdateIndividual;

public record UpdateIndividualCommand(
        int IndividualId,
        string FirstName,
        string LastName,
        GenderType Gender,
        string PersonalNumber,
        DateTime DateOfBirth,
        int CityId,
        List<UpdatePhoneNumberDto> PhoneNumbers
    ) : ICommandQuery;
