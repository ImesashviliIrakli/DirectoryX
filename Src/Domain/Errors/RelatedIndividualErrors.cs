using Domain.Abstractions;

namespace Domain.Errors;

public static class RelatedIndividualErrors
{
    public static readonly Error EitherOneOrNoneExist = new(
        "NotFound",
        "Either one of the individuals does not exist, or both of them are missing."
        );

    public static readonly Error RelationshipNotFound = new(
        "NotFound",
        "Relationship not found."
        );

    public static readonly Error RelationshipAlreadyExists = new(
        "BadRequest",
        "Relationship already exists."
        );
}
