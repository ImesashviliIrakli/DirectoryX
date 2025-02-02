using FluentValidation;

namespace Application.RelatedIndividuals.AddRelatedIndividual;

public sealed class AddRelatedIndividualCommandValidator : AbstractValidator<AddRelatedIndividualCommand>
{
    public AddRelatedIndividualCommandValidator()
    {
        RuleFor(x => x.IndividualId)
            .GreaterThan(0).WithMessage("IndividualId must be greater than 0.");

        RuleFor(x => x.RelatedIndividualId)
            .GreaterThan(0).WithMessage("RelatedIndividualId must be greater than 0.");

        RuleFor(x => x.IndividualId)
            .NotEqual(x => x.RelatedIndividualId).WithMessage("IndividualId and RelatedIndividualId must not be the same.");

        RuleFor(x => x.RelationshipType)
            .IsInEnum().WithMessage("Invalid RelationshipType.");
    }
}
