namespace RentADeveloper.ArgumentNullGuards.Exceptions;

/// <summary>
/// Thrown when a constructor or method to verify is not in a nullable enabled context.
/// </summary>
#pragma warning disable CA1032
#pragma warning disable CA1032
#pragma warning disable CA1515
public class NoNullableEnabledContextException : Exception
#pragma warning restore CA1515
#pragma warning restore CA1032
#pragma warning restore CA1032
{
    /// <inheritdoc />
    public NoNullableEnabledContextException(String message) : base(message)
    {
    }
}
