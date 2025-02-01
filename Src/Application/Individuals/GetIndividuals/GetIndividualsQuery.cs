using Application.Abstractions.Messaging;
using Domain.Models;

namespace Application.Individuals.GetIndividuals;

public record GetIndividualsQuery(IndividualSearchCriteria IndividualSearchCriteria) : ICommandQuery;
