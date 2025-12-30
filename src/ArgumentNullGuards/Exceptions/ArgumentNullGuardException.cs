namespace RentADeveloper.ArgumentNullGuards.Exceptions;

/// <summary>
/// Thrown when a constructor or method does not correctly guard against null arguments for one of its non-nullable
/// parameters.
/// </summary>
#pragma warning disable CA1032
#pragma warning disable CA1032
#pragma warning disable CA1515
public class ArgumentNullGuardException : Exception
#pragma warning restore CA1515
#pragma warning restore CA1032
#pragma warning restore CA1032
{
    /// <inheritdoc />
    public ArgumentNullGuardException(String message) : base(message)
    {
    }
}
