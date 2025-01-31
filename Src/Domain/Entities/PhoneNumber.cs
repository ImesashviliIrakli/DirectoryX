using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

public sealed class PhoneNumber : Entity
{
    public int IndividualId { get; private set; }
    public PhoneNumberType Type { get; private set; }
    public string Number { get; private set; }

    private PhoneNumber() { } // EF Core requirement

    public PhoneNumber(PhoneNumberType type, string number)
    {
        Type = type;
        Number = number;
    }
}
