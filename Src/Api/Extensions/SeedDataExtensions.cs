using Bogus;
using Domain.Entities;
using Domain.Enums;
using Infrastructure;

namespace Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // Ensure the database is created and migrations are applied
        dbContext.Database.EnsureCreated();

        // Seed Individuals
        if (!dbContext.Individuals.Any())
        {
            var individuals = GenerateIndividuals(10); // Generate 100 fake individuals
            dbContext.Individuals.AddRange(individuals);
            dbContext.SaveChanges();
        }

        // Seed PhoneNumbers
        if (!dbContext.PhoneNumbers.Any())
        {
            var phoneNumbers = GeneratePhoneNumbers(dbContext.Individuals.ToList(), 2); // Generate 2 phone numbers per individual
            dbContext.PhoneNumbers.AddRange(phoneNumbers);
            dbContext.SaveChanges();
        }
    }

    private static List<Individual> GenerateIndividuals(int count)
    {
        var faker = new Faker<Individual>()
            .RuleFor(i => i.FirstName, f => f.Person.FirstName)
            .RuleFor(i => i.LastName, f => f.Person.LastName)
            .RuleFor(i => i.Gender, f => f.PickRandom<GenderType>())
            .RuleFor(i => i.PersonalNumber, f => f.Random.Replace("##########"))
            .RuleFor(i => i.DateOfBirth, f => f.Date.Past(30))
            .RuleFor(i => i.CityId, f => f.Random.Int(1, 100))
            .RuleFor(i => i.ImagePath, f => f.Image.PicsumUrl());

        return faker.Generate(count);
    }

    private static List<PhoneNumber> GeneratePhoneNumbers(List<Individual> individuals, int phoneNumbersPerIndividual)
    {
        var phoneNumbers = new List<PhoneNumber>();
        var faker = new Faker();

        foreach (var individual in individuals)
        {
            for (int i = 0; i < phoneNumbersPerIndividual; i++)
            {
                phoneNumbers.Add(new PhoneNumber(
                    individual.Id,
                    faker.PickRandom<PhoneNumberType>(),
                    faker.Random.Replace("5########")
                ));
            }
        }

        return phoneNumbers;
    }
}