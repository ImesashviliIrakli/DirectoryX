using Domain.Abstractions;

namespace Domain.Errors;

public class GlobalErrors
{
    public static readonly Error SystemFailure = new(
        "SystemFailure",
        "System Failure"
        );
}
