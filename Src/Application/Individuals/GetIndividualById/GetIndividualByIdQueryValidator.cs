using FluentValidation;

namespace Application.Individuals.GetIndividualById;

public sealed class GetIndividualByIdQueryValidator : AbstractValidator<GetIndividualByIdQuery>
{
    public GetIndividualByIdQueryValidator()
    {
        RuleFor(x => x.IndividualId)
            .GreaterThan(0).WithMessage("IndividualId must be greater than 0.");
    }
}
