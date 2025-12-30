using System.Runtime.CompilerServices;

namespace RentADeveloper.ArgumentNullGuards.Helpers;

/// <summary>
/// Provides helper methods for inspecting methods and parameters via reflection.
/// </summary>
internal static class ReflectionHelper
{
    /// <summary>
    /// Gets the default nullability for the specified method.
    /// </summary>
    /// <param name="method">The method to inspect.</param>
    /// <returns>
    /// The default nullability of the specified method or <see langword="null" /> if the method is not in a nullable
    /// enabled context.
    /// </returns>
    internal static Nullability? GetDefaultNullability(MethodBase method)
    {
        var nullableContextAttribute = method.GetCustomAttribute<NullableContextAttribute>()
                                       ?? method.DeclaringType?.GetCustomAttribute<NullableContextAttribute>();

        return nullableContextAttribute is not null
            ? (Nullability)nullableContextAttribute.Flag
            : null;
    }

    /// <summary>
    /// Gets the nullability of the specified parameter.
    /// </summary>
    /// <param name="parameter">The parameter to inspect.</param>
    /// <param name="defaultNullability">The default nullability of the method the parameter belongs to.</param>
    /// <returns>
    /// The nullability of the specified parameter if specified; otherwise, <paramref name="defaultNullability" />.
    /// </returns>
    internal static Nullability GetNullability(ParameterInfo parameter, Nullability defaultNullability)
    {
        var nullableAttribute = parameter.GetCustomAttribute<NullableAttribute>();

        if (nullableAttribute is null || nullableAttribute.NullableFlags.Length != 1)
        {
            return defaultNullability;
        }

        return (Nullability)nullableAttribute.NullableFlags[0];
    }

    /// <summary>
    /// Determines whether the specified method is an async iterator method, meaning it satisfies the following
    /// conditions:
    /// 1. Its return type is <see cref="IAsyncEnumerable{T}" /> and
    /// 2. It is marked with the <see cref="AsyncIteratorStateMachineAttribute" /> attribute.
    /// </summary>
    /// <param name="method">The method to inspect.</param>
    /// <returns>
    /// <see langword="true" /> if the specified method is an async iterator method; otherwise,
    /// <see langword="false" />.
    /// </returns>
    internal static Boolean IsAsyncIteratorMethod(MethodInfo method) =>
        method.ReturnType.IsGenericType
        &&
        method.ReturnType.GetGenericTypeDefinition() == typeof(IAsyncEnumerable<>)
        &&
        method.GetCustomAttribute<AsyncIteratorStateMachineAttribute>() is not null;

    /// <summary>
    /// Determines whether the specified method is an iterator method, meaning it satisfies the following conditions:
    /// 1. Its return type is <see cref="IEnumerable" /> or <see cref="IEnumerable{T}" /> and
    /// 2. It is marked with the <see cref="IteratorStateMachineAttribute" /> attribute.
    /// </summary>
    /// <param name="method">The method to inspect.</param>
    /// <returns>
    /// <see langword="true" /> if the specified method is an iterator method; otherwise, <see langword="false" />.
    /// </returns>
    internal static Boolean IsIteratorMethod(MethodInfo method) =>
        (
            method.ReturnType == typeof(IEnumerable)
            ||
            (
                method.ReturnType.IsGenericType &&
                method.ReturnType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
            )
        )
        &&
        method.GetCustomAttribute<IteratorStateMachineAttribute>() is not null;
}
