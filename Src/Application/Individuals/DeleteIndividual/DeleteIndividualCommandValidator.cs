using FluentValidation;

namespace Application.Individuals.DeleteIndividual;

public sealed class DeleteIndividualCommandValidator : AbstractValidator<DeleteIndividualCommand>
{
    public DeleteIndividualCommandValidator()
    {
        RuleFor(x => x.IndividualId)
            .GreaterThan(0).WithMessage("IndividualId must be greater than 0.");
    }
}
