using Domain.Enums;

namespace Application.Individuals.AddIndividual;

public record AddPhoneNumberDto(
        PhoneNumberType Type,
        string Number
    );

