namespace RentADeveloper.ArgumentNullGuards.UnitTests.TestData;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local
// ReSharper disable NotResolvedInText
public class WrongParameterNameGuards
{
    public WrongParameterNameGuards()
    {
    }

    public WrongParameterNameGuards(Object parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException("wrongParameterName");
        }
    }

    public async IAsyncEnumerable<Int32> AsyncIteratorMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException("wrongParameterName");
        }

        await Task.CompletedTask;
        yield return 1;
    }

    public Task AsyncMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException("wrongParameterName");
        }

        return Task.CompletedTask;
    }

    public IEnumerable<Int32> IteratorMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException("wrongParameterName");
        }

        yield return 1;
    }

    public void Method(Object parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException("wrongParameterName");
        }
    }

    public static async IAsyncEnumerable<Int32> StaticAsyncIteratorMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException("wrongParameterName");
        }

        await Task.CompletedTask;
        yield return 1;
    }

    public static Task StaticAsyncMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException("wrongParameterName");
        }

        return Task.CompletedTask;
    }

    public static IEnumerable<Int32> StaticIteratorMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException("wrongParameterName");
        }

        yield return 1;
    }

    public static void StaticMethod(Object parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException("wrongParameterName");
        }
    }
}
