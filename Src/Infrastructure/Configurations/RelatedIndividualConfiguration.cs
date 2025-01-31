using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class RelatedIndividualConfiguration : IEntityTypeConfiguration<RelatedIndividual>
{
    public void Configure(EntityTypeBuilder<RelatedIndividual> builder)
    {
        builder.HasKey(relatedIndividual => relatedIndividual.Id);

        builder.HasOne<Individual>()
               .WithMany(individual => individual.RelatedIndividuals)
               .HasForeignKey(relatedIndividual => relatedIndividual.IndividualId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(relatedIndividual => relatedIndividual.RelationshipType)
               .HasConversion<int>()
               .IsRequired();
    }
}
