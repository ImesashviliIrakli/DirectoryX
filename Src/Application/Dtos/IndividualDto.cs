using Domain.Enums;

namespace Application.Dtos;

public class IndividualDto
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public GenderType Gender { get; set; }
    public required string PersonalNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int CityId { get; set; }
    public required string ImagePath { get; set; }

    public List<PhoneNumberDto>? PhoneNumbers { get; set; }
    public List<RelatedIndividualDto>? RelatedIndividuals { get; set; }
}
