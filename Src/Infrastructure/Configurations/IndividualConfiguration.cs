using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class IndividualConfiguration : IEntityTypeConfiguration<Individual>
{
    public void Configure(EntityTypeBuilder<Individual> builder)
    {
        builder.HasKey(individual => individual.Id);

        builder.Property(individual => individual.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(individual => individual.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(individual => individual.Gender)
              .HasConversion<int>()
              .IsRequired();

        builder.Property(individual => individual.PersonalNumber)
            .HasMaxLength(11)
            .IsRequired();

        builder.HasIndex(individual => individual.PersonalNumber)
            .IsUnique();

        builder.Property(individual => individual.DateOfBirth)
            .IsRequired();

        builder.Property(individual => individual.CityId)
            .IsRequired();

        builder.Property(individual => individual.ImagePath)
            .HasMaxLength(255)
            .IsRequired(false);

        // PhoneNumbers Configuration (Separate Table)
        builder.HasMany(individual => individual.PhoneNumbers)
            .WithOne()
            .HasForeignKey(p => p.IndividualId)
            .OnDelete(DeleteBehavior.Cascade);

        // RelatedIndividuals Configuration (Separate Table)
        builder.HasMany(individual => individual.RelatedIndividuals)
            .WithOne()
            .HasForeignKey(relatedIndividual => relatedIndividual.IndividualId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(individual => individual.PhoneNumbers)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(individual => individual.RelatedIndividuals)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
