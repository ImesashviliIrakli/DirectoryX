using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.RelatedIndividuals.AddRelatedIndividual;

public record AddRelatedIndividualCommand(
        int IndividualId,
        int RelatedIndividualId,
        RelationshipType RelationshipType
    ) : ICommandQuery;
