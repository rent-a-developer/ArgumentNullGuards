namespace RentADeveloper.ArgumentNullGuards;

/// <summary>
/// Represents the nullability of a type, method or parameter.
/// </summary>
internal enum Nullability
{
    /// <summary>
    /// The nullability is unknown or not specified.
    /// </summary>
    Oblivious = 0,

    /// <summary>
    /// Indicates that a value must not be <see langword="null" />.
    /// </summary>
    NotNull = 1,

    /// <summary>
    /// Indicates that a value can be <see langword="null" />.
    /// </summary>
    Nullable = 2
}
