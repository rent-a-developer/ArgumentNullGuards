namespace RentADeveloper.ArgumentNullGuards.UnitTests.TestData;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local

public class WrongExceptionTypeGuards
{
    public WrongExceptionTypeGuards()
    {
    }

    public WrongExceptionTypeGuards(Object parameter)
    {
        if (parameter is null)
        {
            throw new InvalidOperationException();
        }
    }

    public async IAsyncEnumerable<Int32> AsyncIteratorMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new InvalidOperationException();
        }

        await Task.CompletedTask;
        yield return 1;
    }

    public Task AsyncMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new InvalidOperationException();
        }

        return Task.CompletedTask;
    }

    public IEnumerable<Int32> IteratorMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new InvalidOperationException();
        }

        yield return 1;
    }

    public void Method(Object parameter)
    {
        if (parameter is null)
        {
            throw new InvalidOperationException();
        }
    }

    public static async IAsyncEnumerable<Int32> StaticAsyncIteratorMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new InvalidOperationException();
        }

        await Task.CompletedTask;
        yield return 1;
    }

    public static Task StaticAsyncMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new InvalidOperationException();
        }

        return Task.CompletedTask;
    }

    public static IEnumerable<Int32> StaticIteratorMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new InvalidOperationException();
        }

        yield return 1;
    }

    public static void StaticMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new InvalidOperationException();
        }
    }
}
