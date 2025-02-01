using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Repositories;

namespace Application.RelatedIndividuals.GetRelatedIndividuals;

internal sealed class GetRelatedIndividualsQueryHandler(
        IRelatedIndividualRepository relatedIndividualRepository
    ) : ICommandQueryHandler<GetRelatedIndividualsQuery>
{
    private readonly IRelatedIndividualRepository _relatedIndividualRepository = relatedIndividualRepository;

    public async Task<Result> Handle(GetRelatedIndividualsQuery request, CancellationToken cancellationToken)
    {
        var report = await _relatedIndividualRepository.GetRelatedIndividualsReportAsync(cancellationToken: cancellationToken);

        return Result.Success(report);
    }
}
