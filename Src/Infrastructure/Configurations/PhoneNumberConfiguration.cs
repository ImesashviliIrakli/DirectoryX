using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations;

internal sealed class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
{
    public void Configure(EntityTypeBuilder<PhoneNumber> builder)
    {
        builder.HasKey(phoneNumber => phoneNumber.Id);

        builder.HasOne<Individual>()
               .WithMany(individual => individual.PhoneNumbers)
               .HasForeignKey(pn => pn.IndividualId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(phoneNumber => phoneNumber.Type)
               .HasConversion<int>()
               .IsRequired();

        builder.Property(phoneNumber => phoneNumber.Number)
               .HasMaxLength(50)
               .IsRequired();
    }
}