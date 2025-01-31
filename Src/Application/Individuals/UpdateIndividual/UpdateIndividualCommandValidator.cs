using FluentValidation;

namespace Application.Individuals.UpdateIndividual;

public sealed class UpdateIndividualCommandValidator : AbstractValidator<UpdateIndividualCommand>
{
    public UpdateIndividualCommandValidator()
    {
        RuleFor(x => x.IndividualId)
            .NotEmpty().WithMessage("Individual id is required.")
            .GreaterThan(0).WithMessage("Individual id must be greater than 0.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MinimumLength(2).WithMessage("First name must be at least 2 characters long.")
            .MaximumLength(50).WithMessage("First name must be at most 50 characters long.")
            .Matches("^[ა-ჰ]+$|^[a-zA-Z]+$").WithMessage("First name must contain only Georgian or Latin letters and must not mix both.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MinimumLength(2).WithMessage("Last name must be at least 2 characters long.")
            .MaximumLength(50).WithMessage("Last name must be at most 50 characters long.")
            .Matches("^[ა-ჰ]+$|^[a-zA-Z]+$").WithMessage("Last name must contain only Georgian or Latin letters and must not mix both.");

        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("Invalid gender type.");

        RuleFor(x => x.PersonalNumber)
            .NotEmpty().WithMessage("Personal number is required.")
            .Matches("^[0-9]{11}$").WithMessage("Personal number must be exactly 11 digits.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required.")
            .Must(BeAtLeast18YearsOld).WithMessage("Individual must be at least 18 years old.");

        RuleFor(x => x.CityId)
            .GreaterThan(0).WithMessage("City ID must be a valid positive integer.");
    }

    private bool BeAtLeast18YearsOld(DateTime dateOfBirth)
    {
        return dateOfBirth <= DateTime.Today.AddYears(-18);
    }
}
