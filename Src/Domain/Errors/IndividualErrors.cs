using Domain.Abstractions;

namespace Domain.Errors;

public static class IndividualErrors
{
    public static readonly Error IndividualNotFound = new(
        "NotFound",
        "Individual not found."
        );

    public static readonly Error ImageShouldNotBeEmpty = new(
        "BadRequest",
        "Image should not be empty."
        );
}
