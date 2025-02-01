using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.Individuals.AddIndividual;

public record AddIndividualCommand(
        string FirstName,
        string LastName,
        GenderType Gender,
        string PersonalNumber,
        DateTime DateOfBirth,
        int CityId,
        List<AddPhoneNumberDto> PhoneNumbers
    ) : ICommandQuery;

