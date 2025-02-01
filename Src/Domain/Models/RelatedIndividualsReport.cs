using Domain.Enums;

namespace Domain.Models;

public class RelatedIndividualsReport
{
    public int IndividualId { get; set; }
    public List<RelationshipCount> Relationships { get; set; } = new();
}

public class RelationshipCount
{
    public RelationshipType Type { get; set; }
    public int Count { get; set; }
}