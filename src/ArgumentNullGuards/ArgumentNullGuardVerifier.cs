namespace RentADeveloper.ArgumentNullGuards;

/// <summary>
/// Verifies that a constructor or method has guards againsts null arguments for all its non-nullable parameters,
/// meaning it throws an <see cref="ArgumentNullException" /> when called with a null argument for such parameters.
/// </summary>
#pragma warning disable CA1515
public static class ArgumentNullGuardVerifier
#pragma warning restore CA1515
{
    /// <summary>
    /// Verifies that the constructor or method called in the expression <paramref name="validCallExpression" /> has
    /// guards against null arguments for all its non-nullable parameters.
    /// </summary>
    /// <param name="validCallExpression">
    /// The expression that calls the constructor or method to verify with valid arguments.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     <list type="bullet">
    ///         <item>
    ///             <description>
    ///                 The body of the expression <paramref name="validCallExpression" /> is neither a constructor
    ///                 call nor a method call.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 The constructor or method called in the expression <paramref name="validCallExpression" /> is
    ///                 not in a nullable enabled context.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="validCallExpression" /> is <see langword="null" />.
    /// </exception>
    public static void Verify(LambdaExpression validCallExpression)
    {
        ArgumentNullException.ThrowIfNull(validCallExpression);

        var callInfo = ExtractCallInfo(validCallExpression);

        foreach (var nonNullableParameter in callInfo.NonNullableParameters)
        {
            var parameterName = nonNullableParameter.Name!;
            var parameterIndex = callInfo.ParameterIndexes[parameterName];
            var parameterType = callInfo.ParameterTypes[parameterName];

            var argumentExpressions = callInfo.Arguments.ToArray();

            argumentExpressions[parameterIndex] = Expression.Constant(null, parameterType);

            var callExpression = CreateCallExpression(callInfo, argumentExpressions);

            var callDelegate = Expression.Lambda(callExpression).Compile();

            VerifyCall(callDelegate, callInfo, parameterName);
        }
    }

    /// <summary>
    /// Creates a call expression for the specified constructor or method with the specified arguments.
    /// </summary>
    /// <param name="callInfo">The information about the call for which to create the expression.</param>
    /// <param name="argumentExpressions">
    /// The expressions of the arguments to pass to the constructor or method.
    /// </param>
    /// <returns>The created call expression.</returns>
    private static Expression CreateCallExpression(
        CallInfo callInfo,
        Expression[] argumentExpressions
    )
    {
        switch (callInfo.ConstructorOrMethod)
        {
            case ConstructorInfo constructor:
                return Expression.New(constructor, argumentExpressions);

            // For async iterator methods we need to call MoveNextAsync on the returned async enumerator to force the
            // async iterator state machine to run. Otherwise the guards inside the async iterator method won't be
            // executed.
            case MethodInfo method when ReflectionHelper.IsAsyncIteratorMethod(method):
                return Expression.Call(
                    Expression.Call(
                        Expression.Call(
                            Expression.Call(callInfo.Instance, method, argumentExpressions),
                            typeof(IAsyncEnumerable<>)
                                .MakeGenericType(method.ReturnType.GenericTypeArguments[0])
                                .GetMethod(nameof(IAsyncEnumerable<>.GetAsyncEnumerator))!,
                            Expression.Constant(CancellationToken.None)
                        ),
                        typeof(IAsyncEnumerator<>)
                            .MakeGenericType(method.ReturnType.GenericTypeArguments[0])
                            .GetMethod(nameof(IAsyncEnumerator<>.MoveNextAsync))!
                    ),
                    typeof(ValueTask<Boolean>).GetMethod(nameof(ValueTask<>.AsTask))!
                );

            // For iterator methods we need to call MoveNext on the returned enumerator to force the iterator state
            // machine to run. Otherwise the guards inside the iterator method won't be executed.
            case MethodInfo method when ReflectionHelper.IsIteratorMethod(method):
                return Expression.Call(
                    Expression.Call(
                        Expression.Convert(
                            Expression.Call(callInfo.Instance, method, argumentExpressions),
                            typeof(IEnumerable)
                        ),
                        typeof(IEnumerable).GetMethod(nameof(IEnumerable.GetEnumerator))!
                    ),
                    typeof(IEnumerator).GetMethod(nameof(IEnumerator.MoveNext))!
                );

            case MethodInfo method:
                return Expression.Call(callInfo.Instance, method, argumentExpressions);

            default:
                ThrowHelper.ThrowExpressionBodyIsNeitherConstructorCallNorMethodCallException();
                return null;
        }
    }

    /// <summary>
    /// Extracts information about a constructor or method call from the specified expression.
    /// </summary>
    /// <param name="expression">
    /// The expression from which to extract the call information.
    /// </param>
    /// <returns>
    /// An instance of <see cref="CallInfo" /> containing the information about the constructor or
    /// method call.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     <list type="bullet">
    ///         <item>
    ///             <description>
    ///                 The body of the expression <paramref name="expression" /> is neither a constructor
    ///                 call nor a method call.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 The constructor or method called in the expression <paramref name="expression" /> is not in a
    ///                 nullable enabled context.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </exception>
    private static CallInfo ExtractCallInfo(LambdaExpression expression)
    {
        MethodBase constructorOrMethod;
        ReadOnlyCollection<Expression> callArguments;

        // ReSharper disable once UsePatternMatching
        var newExpression = expression.Body as NewExpression;
        var callExpression = expression.Body as MethodCallExpression;

        if (newExpression is not null)
        {
            constructorOrMethod = newExpression.Constructor!;
            callArguments = newExpression.Arguments;
        }
        else if (callExpression is not null)
        {
            constructorOrMethod = callExpression.Method;
            callArguments = callExpression.Arguments;
        }
        else
        {
            ThrowHelper.ThrowExpressionBodyIsNeitherConstructorCallNorMethodCallException();
            return null;
        }

        var methodParameters = constructorOrMethod.GetParameters();

        var parameterIndexes = new Dictionary<String, Int32>();
        var parameterTypes = new Dictionary<String, Type>();

        for (var i = 0; i < methodParameters.Length; i++)
        {
            var parameter = methodParameters[i];
            parameterIndexes.Add(parameter.Name!, i);
            parameterTypes.Add(parameter.Name!, parameter.ParameterType);
        }

        var nonNullableParameters = methodParameters
            .Where(parameter =>
                !parameter.ParameterType.IsValueType &&
                ReflectionHelper.GetNullability(parameter) is NullabilityState.NotNull or NullabilityState.Unknown
            )
            .ToArray();

        return new(
            constructorOrMethod,
            callExpression?.Object,
            callArguments,
            parameterIndexes,
            parameterTypes,
            nonNullableParameters
        );
    }

    /// <summary>
    /// Verifies that the specified call throws an <see cref="ArgumentNullException" /> for the specified parameter.
    /// </summary>
    /// <param name="call">The delegate that implements the call.</param>
    /// <param name="callInfo">The information about the constructor or method call.</param>
    /// <param name="parameterName">The name of the parameter to verify.</param>
    private static void VerifyCall(Delegate call, CallInfo callInfo, String parameterName)
    {
        Exception? exceptionThrown = null;

        try
        {
            var returnValue = call.DynamicInvoke();

            if (returnValue is Task task)
            {
                task.Wait();
            }
        }
#pragma warning disable CA1031
        catch (Exception ex)
#pragma warning restore CA1031
        {
            exceptionThrown = ex switch
            {
                TargetInvocationException targetInvocationException =>
                    targetInvocationException.InnerException,

                AggregateException aggregateException =>
                    aggregateException.InnerExceptions.Count == 1
                        ? aggregateException.InnerExceptions[0]
                        : aggregateException,
                _ => ex
            };
#pragma warning disable ERP022
        }
#pragma warning restore ERP022

        switch (exceptionThrown)
        {
            case null:
                ThrowHelper.ThrowNullArgumentGuardMissingException(callInfo.ConstructorOrMethod, parameterName);
                break;

            case ArgumentNullException argumentNullException
                when argumentNullException.ParamName != parameterName:
                ThrowHelper.ThrowNullArgumentGuardNotReturningCorrectParameterNameException(
                    callInfo.ConstructorOrMethod,
                    argumentNullException.ParamName,
                    parameterName
                );
                break;

            case ArgumentNullException:
                break;

            default:
                ThrowHelper.ThrowNullArgumentGuardNotThrowingCorrectExceptionTypeException(
                    callInfo.ConstructorOrMethod,
                    parameterName,
                    exceptionThrown
                );
                break;
        }
    }
}
