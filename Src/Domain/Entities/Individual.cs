using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

public class Individual : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public GenderType Gender { get; private set; }
    public string PersonalNumber { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public int CityId { get; private set; }
    public string ImagePath { get; private set; }

    private readonly List<PhoneNumber> _phoneNumbers = new();

    private readonly List<RelatedIndividual> _relatedIndividuals = new();

    public IReadOnlyCollection<PhoneNumber> PhoneNumbers => _phoneNumbers.AsReadOnly();
    public IReadOnlyCollection<RelatedIndividual> RelatedIndividuals => _relatedIndividuals.AsReadOnly();

    public Individual() { } // EF Core requirement

    public Individual(
        string firstName,
        string lastName,
        GenderType gender,
        string personalNumber,
        DateTime dateOfBirth,
        int cityId,
        string imagePath = ""
        )
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        PersonalNumber = personalNumber;
        DateOfBirth = dateOfBirth;
        CityId = cityId;
        ImagePath = imagePath;
    }

    public void AddRelatedIndividual(List<RelatedIndividual> relatedIndividuals)
    {
        _relatedIndividuals.AddRange(relatedIndividuals);
    }

    public void AddPhoneNumbers(List<PhoneNumber> phoneNumbers)
    {
        _phoneNumbers.AddRange(phoneNumbers);
    }

    public void UpdateBasicInfo(
        string firstName,
        string lastName,
        GenderType gender,
        string personalNumber,
        DateTime dateOfBirth,
        int cityId
        )
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        PersonalNumber = personalNumber;
        DateOfBirth = dateOfBirth;
        CityId = cityId;
    }

    public void UpdatePhoneNumbers(List<PhoneNumber> phoneNumbers)
    {
        _phoneNumbers.Clear();
        _phoneNumbers.AddRange(phoneNumbers);
    }

    public void UpdateImagePath(string path)
    {
        ImagePath = path;
    }
}
