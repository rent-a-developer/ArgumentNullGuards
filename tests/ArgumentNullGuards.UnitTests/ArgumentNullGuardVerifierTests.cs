namespace RentADeveloper.ArgumentNullGuards.UnitTests;

public class ArgumentNullGuardVerifierTests : TestsBase
{
    [Fact]
    public void Verify_CorrectGuards_ShouldNotThrow()
    {
        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() =>
                    CorrectGuards.StaticAsyncIteratorMethod("A", null, 1, null, null, "A")
                )
            )
            .Should().NotThrow();

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => CorrectGuards.StaticAsyncMethod("A", null, 1, null, null, "A"))
            )
            .Should().NotThrow();

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() =>
                    CorrectGuards.StaticIteratorMethod("A", null, 1, null, null, "A")
                )
            )
            .Should().NotThrow();

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => CorrectGuards.StaticMethod("A", null, 1, null, null, "A"))
            )
            .Should().NotThrow();

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => new CorrectGuards("A", null, 1, null, null, "A"))
            )
            .Should().NotThrow();

        var instance = new CorrectGuards();

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.AsyncIteratorMethod("A", null, 1, null, null, "A"))
            )
            .Should().NotThrow();

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.AsyncMethod("A", null, 1, null, null, "A"))
            )
            .Should().NotThrow();

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.IteratorMethod("A", null, 1, null, null, "A"))
            )
            .Should().NotThrow();

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.Method("A", null, 1, null, null, "A"))
            )
            .Should().NotThrow();
    }

    [Fact]
    public void Verify_ExpressionBodyIsNeitherConstructorNorMethodCall_ShouldThrow() =>
        Invoking(() => ArgumentNullGuardVerifier.Verify(() => 42))
            .Should().Throw<ArgumentException>()
            .WithMessage("The body of the specified expression is neither a constructor call nor a method call.*");

    [Fact]
    public void Verify_MissingGuards_ShouldThrow()
    {
        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() =>
                    MissingGuards.StaticAsyncIteratorMethod("A", null, 1, null, null, "A")
                )
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(MissingGuards)}
                 Method: System.Collections.Generic.IAsyncEnumerable`1[System.Int32] StaticAsyncIteratorMethod(System.String, System.String, Int32, System.Nullable`1[System.Int32], System.Nullable`1[System.Int32], System.String[])
                 Parameter: p1

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => MissingGuards.StaticAsyncMethod("A", null, 1, null, null, "A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(MissingGuards)}
                 Method: System.Threading.Tasks.Task StaticAsyncMethod(System.String, System.String, Int32, System.Nullable`1[System.Int32], System.Nullable`1[System.Int32], System.String[])
                 Parameter: p6

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() =>
                    MissingGuards.StaticIteratorMethod("A", null, 1, null, null, "A")
                )
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(MissingGuards)}
                 Method: System.Collections.Generic.IEnumerable`1[System.Int32] StaticIteratorMethod(System.String, System.String, Int32, System.Nullable`1[System.Int32], System.Nullable`1[System.Int32], System.String[])
                 Parameter: p1

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => MissingGuards.StaticMethod("A", null, 1, null, null, "A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(MissingGuards)}
                 Method: Void StaticMethod(System.String, System.String, Int32, System.Nullable`1[System.Int32], System.Nullable`1[System.Int32], System.String[])
                 Parameter: p1

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => new MissingGuards("A", null, 1, null, null, "A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(MissingGuards)}
                 Method: Void .ctor(System.String, System.String, Int32, System.Nullable`1[System.Int32], System.Nullable`1[System.Int32], System.String[])
                 Parameter: p6

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );

        var instance = new MissingGuards();

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.AsyncIteratorMethod("A", null, 1, null, null, "A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(MissingGuards)}
                 Method: System.Collections.Generic.IAsyncEnumerable`1[System.Int32] AsyncIteratorMethod(System.String, System.String, Int32, System.Nullable`1[System.Int32], System.Nullable`1[System.Int32], System.String[])
                 Parameter: p1

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.AsyncMethod("A", null, 1, null, null, "A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(MissingGuards)}
                 Method: System.Threading.Tasks.Task AsyncMethod(System.String, System.String, Int32, System.Nullable`1[System.Int32], System.Nullable`1[System.Int32], System.String[])
                 Parameter: p1

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.IteratorMethod("A", null, 1, null, null, "A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(MissingGuards)}
                 Method: System.Collections.Generic.IEnumerable`1[System.Int32] IteratorMethod(System.String, System.String, Int32, System.Nullable`1[System.Int32], System.Nullable`1[System.Int32], System.String[])
                 Parameter: p6

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.Method("A", null, 1, null, null, "A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(MissingGuards)}
                 Method: void Method(System.String, System.String, Int32, System.Nullable`1[System.Int32], System.Nullable`1[System.Int32], System.String[])
                 Parameter: p1

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );
    }

    [Fact]
    public void Verify_NullExpression_ShouldThrow() =>
        Invoking(() => ArgumentNullGuardVerifier.Verify(null!))
            .Should().Throw<ArgumentNullException>();

    [Fact]
    public void Verify_ThrownExceptionHasWrongParameterName_ShouldThrow()
    {
        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => WrongParameterNameGuards.StaticAsyncIteratorMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter returned the wrong parameter name:

                 Type: {typeof(WrongParameterNameGuards)}
                 Method: System.Collections.Generic.IAsyncEnumerable`1[System.Int32] StaticAsyncIteratorMethod(System.Object)
                 Parameter: parameter

                 Expected Parameter Name: parameter
                 Actual Parameter Name: wrongParameterName

                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => WrongParameterNameGuards.StaticAsyncMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter returned the wrong parameter name:

                 Type: {typeof(WrongParameterNameGuards)}
                 Method: System.Threading.Tasks.Task StaticAsyncMethod(System.Object)
                 Parameter: parameter

                 Expected Parameter Name: parameter
                 Actual Parameter Name: wrongParameterName

                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => WrongParameterNameGuards.StaticIteratorMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter returned the wrong parameter name:

                 Type: {typeof(WrongParameterNameGuards)}
                 Method: System.Collections.Generic.IEnumerable`1[System.Int32] StaticIteratorMethod(System.Object)
                 Parameter: parameter

                 Expected Parameter Name: parameter
                 Actual Parameter Name: wrongParameterName

                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => WrongParameterNameGuards.StaticMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter returned the wrong parameter name:

                 Type: {typeof(WrongParameterNameGuards)}
                 Method: Void StaticMethod(System.Object)
                 Parameter: parameter

                 Expected Parameter Name: parameter
                 Actual Parameter Name: wrongParameterName

                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => new WrongParameterNameGuards("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter returned the wrong parameter name:

                 Type: {typeof(WrongParameterNameGuards)}
                 Method: Void .ctor(System.Object)
                 Parameter: parameter

                 Expected Parameter Name: parameter
                 Actual Parameter Name: wrongParameterName

                 """
            );

        var instance = new WrongParameterNameGuards();

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.AsyncIteratorMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter returned the wrong parameter name:

                 Type: {typeof(WrongParameterNameGuards)}
                 Method: System.Collections.Generic.IAsyncEnumerable`1[System.Int32] AsyncIteratorMethod(System.Object)
                 Parameter: parameter

                 Expected Parameter Name: parameter
                 Actual Parameter Name: wrongParameterName

                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.AsyncMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter returned the wrong parameter name:

                 Type: {typeof(WrongParameterNameGuards)}
                 Method: System.Threading.Tasks.Task AsyncMethod(System.Object)
                 Parameter: parameter

                 Expected Parameter Name: parameter
                 Actual Parameter Name: wrongParameterName

                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.IteratorMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter returned the wrong parameter name:

                 Type: {typeof(WrongParameterNameGuards)}
                 Method: System.Collections.Generic.IEnumerable`1[System.Int32] IteratorMethod(System.Object)
                 Parameter: parameter

                 Expected Parameter Name: parameter
                 Actual Parameter Name: wrongParameterName

                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.Method("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter returned the wrong parameter name:

                 Type: {typeof(WrongParameterNameGuards)}
                 Method: Void Method(System.Object)
                 Parameter: parameter

                 Expected Parameter Name: parameter
                 Actual Parameter Name: wrongParameterName

                 """
            );
    }

    [Fact]
    public void Verify_TypeIsNotInNullableEnabledContext_ShouldAssumeReferenceTypeParametersAreNonNullable()
    {
        Invoking(() => ArgumentNullGuardVerifier.Verify(() => NotInNullableEnabledContext.StaticMethod("A")))
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(NotInNullableEnabledContext)}
                 Method: Void StaticMethod(System.Object)
                 Parameter: parameter

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );

        Invoking(() => ArgumentNullGuardVerifier.Verify(() => new NotInNullableEnabledContext("A")))
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(NotInNullableEnabledContext)}
                 Method: Void .ctor(System.Object)
                 Parameter: parameter

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );

        var instance = new NotInNullableEnabledContext("A");

        Invoking(() => ArgumentNullGuardVerifier.Verify(() => instance.Method("A")))
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter is missing:

                 Type: {typeof(NotInNullableEnabledContext)}
                 Method: Void Method(System.Object)
                 Parameter: parameter

                 The method did not throw an System.ArgumentNullException when called with a null argument for the parameter.
                 """
            );
    }

    [Fact]
    public void Verify_WrongTypeOfExceptionIsThrown_ShouldThrow()
    {
        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => WrongExceptionTypeGuards.StaticAsyncIteratorMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter threw the wrong type of exception:

                 Type: {typeof(WrongExceptionTypeGuards)}
                 Method: System.Collections.Generic.IAsyncEnumerable`1[System.Int32] StaticAsyncIteratorMethod(System.Object)
                 Parameter: parameter

                 Expected Exception: {typeof(ArgumentNullException)}
                 Actual Exception: System.InvalidOperationException: Operation is not valid due to the current state of the object.*
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => WrongExceptionTypeGuards.StaticAsyncMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter threw the wrong type of exception:

                 Type: {typeof(WrongExceptionTypeGuards)}
                 Method: System.Threading.Tasks.Task StaticAsyncMethod(System.Object)
                 Parameter: parameter

                 Expected Exception: {typeof(ArgumentNullException)}
                 Actual Exception: System.InvalidOperationException: Operation is not valid due to the current state of the object.*
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => WrongExceptionTypeGuards.StaticIteratorMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter threw the wrong type of exception:

                 Type: {typeof(WrongExceptionTypeGuards)}
                 Method: System.Collections.Generic.IEnumerable`1[System.Int32] StaticIteratorMethod(System.Object)
                 Parameter: parameter

                 Expected Exception: {typeof(ArgumentNullException)}
                 Actual Exception: System.InvalidOperationException: Operation is not valid due to the current state of the object.*
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => WrongExceptionTypeGuards.StaticMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter threw the wrong type of exception:

                 Type: {typeof(WrongExceptionTypeGuards)}
                 Method: Void StaticMethod(System.Object)
                 Parameter: parameter

                 Expected Exception: {typeof(ArgumentNullException)}
                 Actual Exception: System.InvalidOperationException: Operation is not valid due to the current state of the object.*
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => new WrongExceptionTypeGuards("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter threw the wrong type of exception:

                 Type: {typeof(WrongExceptionTypeGuards)}
                 Method: Void .ctor(System.Object)
                 Parameter: parameter

                 Expected Exception: {typeof(ArgumentNullException)}
                 Actual Exception: System.InvalidOperationException: Operation is not valid due to the current state of the object.*
                 """
            );

        var instance = new WrongExceptionTypeGuards();

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.AsyncIteratorMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter threw the wrong type of exception:

                 Type: {typeof(WrongExceptionTypeGuards)}
                 Method: System.Collections.Generic.IAsyncEnumerable`1[System.Int32] AsyncIteratorMethod(System.Object)
                 Parameter: parameter

                 Expected Exception: {typeof(ArgumentNullException)}
                 Actual Exception: System.InvalidOperationException: Operation is not valid due to the current state of the object.*
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.AsyncMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter threw the wrong type of exception:

                 Type: {typeof(WrongExceptionTypeGuards)}
                 Method: System.Threading.Tasks.Task AsyncMethod(System.Object)
                 Parameter: parameter

                 Expected Exception: {typeof(ArgumentNullException)}
                 Actual Exception: System.InvalidOperationException: Operation is not valid due to the current state of the object.*
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.IteratorMethod("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter threw the wrong type of exception:

                 Type: {typeof(WrongExceptionTypeGuards)}
                 Method: System.Collections.Generic.IEnumerable`1[System.Int32] IteratorMethod(System.Object)
                 Parameter: parameter

                 Expected Exception: {typeof(ArgumentNullException)}
                 Actual Exception: System.InvalidOperationException: Operation is not valid due to the current state of the object.*
                 """
            );

        Invoking(() =>
                ArgumentNullGuardVerifier.Verify(() => instance.Method("A"))
            )
            .Should().Throw<ArgumentNullGuardException>()
            .WithMessage(
                $"""
                 The Null Argument Guard for the following method parameter threw the wrong type of exception:

                 Type: {typeof(WrongExceptionTypeGuards)}
                 Method: Void Method(System.Object)
                 Parameter: parameter

                 Expected Exception: {typeof(ArgumentNullException)}
                 Actual Exception: System.InvalidOperationException: Operation is not valid due to the current state of the object.*
                 """
            );
    }
}
