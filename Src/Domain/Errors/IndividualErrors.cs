using Domain.Abstractions;

namespace Domain.Errors;

public static class IndividualErrors
{
    public static readonly Error IndividualNotFound = new(
        "NotFound",
        "Individual not found."
        );

    public static readonly Error IndividualAlreadyExists = new(
        "BadRequest",
        "Individual already exists."
        );

    public static readonly Error ImageShouldNotBeEmpty = new(
        "BadRequest",
        "Image should not be empty."
        );

    public static readonly Error CouldNotDeleteOldImage = new(
        "SystemFailure",
        "Old image could not be deleted."
        );
}
