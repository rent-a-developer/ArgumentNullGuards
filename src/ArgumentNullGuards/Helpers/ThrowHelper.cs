using System.Diagnostics.CodeAnalysis;
using RentADeveloper.ArgumentNullGuards.Exceptions;

namespace RentADeveloper.ArgumentNullGuards.Helpers;

/// <summary>
/// Provides helper methods for throwing exceptions.
/// </summary>
internal static class ThrowHelper
{
    [DoesNotReturn]
    internal static void ThrowExpressionBodyIsNeitherConstructorCallNorMethodCallException() =>
        throw new ArgumentException(
            "The body of the specified expression is neither a constructor call nor a method call.",
            // ReSharper disable once NotResolvedInText
            "validCallExpression"
        );

    [DoesNotReturn]
    internal static void ThrowNoNullableEnabledContextException(MethodBase method) =>
        throw new NoNullableEnabledContextException(
            $"""
             Can't check the following method for Null Argument Guards:

             Type: {method.DeclaringType}
             Method: {method}

             The type and/or the method is not in a nullable enabled context.

             """
        );

    [DoesNotReturn]
    internal static void ThrowNullArgumentGuardMissingException(MethodBase method, String parameterName) =>
        throw new ArgumentNullGuardException(
            $"""
             The Null Argument Guard for the following method parameter is missing:

             Type: {method.DeclaringType}
             Method: {method}
             Parameter: {parameterName}

             The method did not throw an {typeof(ArgumentNullException)} when called with a null argument for the parameter.

             """
        );

    [DoesNotReturn]
    internal static void ThrowNullArgumentGuardNotReturningCorrectParameterNameException(
        MethodBase method,
        String? actualParameterName,
        String expectedParameterName
    ) =>
        throw new ArgumentNullGuardException(
            $"""
             The Null Argument Guard for the following method parameter returned the wrong parameter name:

             Type: {method.DeclaringType}
             Method: {method}
             Parameter: {expectedParameterName}

             Expected Parameter Name: {expectedParameterName}
             Actual Parameter Name: {actualParameterName}

             """
        );

    [DoesNotReturn]
    internal static void ThrowNullArgumentGuardNotThrowingCorrectExceptionTypeException(
        MethodBase method,
        String parameterName,
        Exception actualException
    ) =>
        throw new ArgumentNullGuardException(
            $"""
             The Null Argument Guard for the following method parameter threw the wrong type of exception:

             Type: {method.DeclaringType}
             Method: {method}
             Parameter: {parameterName}

             Expected Exception: {typeof(ArgumentNullException)}
             Actual Exception: {actualException}

             """
        );
}
