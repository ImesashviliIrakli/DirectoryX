using Domain.Abstractions;

namespace Domain.Errors;

public static class IndividualErrors
{
    public static readonly Error IndividualNotFound = new(
        "NotFound",
        "Individual not found."
        );
}
