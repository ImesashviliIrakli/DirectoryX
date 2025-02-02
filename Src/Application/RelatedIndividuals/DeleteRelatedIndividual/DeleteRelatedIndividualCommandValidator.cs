using FluentValidation;

namespace Application.RelatedIndividuals.DeleteRelatedIndividual;

public sealed class DeleteRelatedIndividualCommandValidator : AbstractValidator<DeleteRelatedIndividualCommand>
{
    public DeleteRelatedIndividualCommandValidator()
    {
        RuleFor(x => x.IndividualId)
            .GreaterThan(0).WithMessage("IndividualId must be greater than 0.");

        RuleFor(x => x.RelatedIndividualId)
            .GreaterThan(0).WithMessage("RelatedIndividualId must be greater than 0.");

        RuleFor(x => x.IndividualId)
            .NotEqual(x => x.RelatedIndividualId).WithMessage("IndividualId and RelatedIndividualId must not be the same.");
    }
}
