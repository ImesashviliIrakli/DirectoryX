using Domain.Enums;

namespace Application.Individuals.UpdateIndividual;

public record UpdatePhoneNumberDto(
    int PhoneNumberId,
    PhoneNumberType NumberType,
    string Number
);