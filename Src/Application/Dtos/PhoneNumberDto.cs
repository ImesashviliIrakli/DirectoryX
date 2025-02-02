using Domain.Enums;

namespace Application.Dtos;

public class PhoneNumberDto
{
    public int Id { get; set; }
    public PhoneNumberType Type { get;  set; }
    public required string Number { get;  set; }
}
