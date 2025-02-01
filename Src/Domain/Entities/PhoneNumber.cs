using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

public sealed class PhoneNumber : Entity
{
    public int IndividualId { get; private set; }
    public PhoneNumberType Type { get; private set; }
    public string Number { get; private set; }

    public PhoneNumber() { } // EF Core requirement

    public PhoneNumber(int individualId,PhoneNumberType type, string number)
    {
        IndividualId = individualId;
        Type = type;
        Number = number;
    }
}
