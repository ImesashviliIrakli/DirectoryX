using Application.Abstractions.Messaging;

namespace Application.RelatedIndividuals.DeleteRelatedIndividual;

public record DeleteRelatedIndividualCommand(
        int IndividualId,
        int RelatedIndividualId
    ) : ICommandQuery;
