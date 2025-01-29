using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.Entities;

public class Individual
{
    [Key]
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Gender { get; private set; }
    public string PersonalNumber { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public int CityId { get; private set; }
    public string Image { get; private set; }
    private readonly List<PhoneNumber> _phoneNumbers = new();
    private readonly List<RelatedIndividual> _relatedIndividuals = new();

    public IReadOnlyCollection<PhoneNumber> PhoneNumbers => _phoneNumbers.AsReadOnly();
    public IReadOnlyCollection<RelatedIndividual> RelatedIndividuals => _relatedIndividuals.AsReadOnly();

    private Individual() { } // EF Core requirement

    private Individual(string firstName, string lastName, string gender, string personalNumber, DateTime dateOfBirth, int cityId, string image)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        PersonalNumber = personalNumber;
        DateOfBirth = dateOfBirth;
        CityId = cityId;
        Image = image;
    }
}
