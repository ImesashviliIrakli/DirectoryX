using Application.Abstractions.Messaging;

namespace Application.Individuals.GetIndividualById;

public record GetIndividualByIdQuery(int IndividualId) : ICommandQuery;
