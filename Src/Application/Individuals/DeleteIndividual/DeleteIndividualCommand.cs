using Application.Abstractions.Messaging;

namespace Application.Individuals.DeleteIndividual;

public record DeleteIndividualCommand(int IndividualId) : ICommandQuery;
