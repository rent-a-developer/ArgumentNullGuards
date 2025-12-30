namespace RentADeveloper.ArgumentNullGuards;

/// <summary>
/// Information about a call of a constructor or a method.
/// </summary>
/// <param name="ConstructorOrMethod">The constructor or method that is called.</param>
/// <param name="Instance">
/// The expression of the instance on which the method is called.
/// This is <see langword="null" /> for constructor calls and static method calls.
/// </param>
/// <param name="Arguments">
/// The expressions of the arguments with which the constructor or method is called.
/// </param>
/// <param name="ParameterIndexes">
/// The indexes of the parameters of the called constructor or method.
/// The keys are the parameter names, and the values are their respective indexes.
/// </param>
/// <param name="ParameterTypes">
/// The parameter types of the parameters of the called constructor or method.
/// The keys are the parameter names, and the values are their respective types.
/// </param>
/// <param name="NonNullableParameters">
/// The non-nullable parameters of the constructor or method.
/// </param>
internal sealed record CallInfo(
    MethodBase ConstructorOrMethod,
    Expression? Instance,
    ReadOnlyCollection<Expression> Arguments,
    Dictionary<String, Int32> ParameterIndexes,
    Dictionary<String, Type> ParameterTypes,
    ParameterInfo[] NonNullableParameters
);
