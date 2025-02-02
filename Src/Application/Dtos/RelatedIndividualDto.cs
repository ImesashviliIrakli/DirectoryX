using Domain.Enums;

namespace Application.Dtos;

public class RelatedIndividualDto
{
    public int Id { get; set; }
    public int RelatedIndividualId { get; private set; } // Related Individual
    public RelationshipType RelationshipType { get; private set; }
}
