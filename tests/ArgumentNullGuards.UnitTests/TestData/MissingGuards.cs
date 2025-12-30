namespace RentADeveloper.ArgumentNullGuards.UnitTests.TestData;

// ReSharper disable UnusedParameter.Local

public class MissingGuards
{
    public MissingGuards()
    {
    }

    public MissingGuards(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    ) =>
        ArgumentNullException.ThrowIfNull(p1);

    public async IAsyncEnumerable<Int32> AsyncIteratorMethod(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    )
    {
        ArgumentNullException.ThrowIfNull(p3);

        await Task.CompletedTask;
        yield return 1;
    }

    public Task AsyncMethod(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    )
    {
        ArgumentNullException.ThrowIfNull(p6);

        return Task.CompletedTask;
    }

    public IEnumerable<Int32> IteratorMethod(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    )
    {
        ArgumentNullException.ThrowIfNull(p1);

        yield return 1;
    }

    public void Method(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    ) =>
        ArgumentNullException.ThrowIfNull(p3);

    public static async IAsyncEnumerable<Int32> StaticAsyncIteratorMethod(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    )
    {
        ArgumentNullException.ThrowIfNull(p6);

        await Task.CompletedTask;
        yield return 1;
    }

    public static Task StaticAsyncMethod(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    )
    {
        ArgumentNullException.ThrowIfNull(p1);

        return Task.CompletedTask;
    }

    public static IEnumerable<Int32> StaticIteratorMethod(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    )
    {
        ArgumentNullException.ThrowIfNull(p3);

        yield return 1;
    }

    public static void StaticMethod(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    ) =>
        ArgumentNullException.ThrowIfNull(p6);
}
