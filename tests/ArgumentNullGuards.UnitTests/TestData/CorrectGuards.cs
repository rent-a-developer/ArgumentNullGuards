namespace RentADeveloper.ArgumentNullGuards.UnitTests.TestData;

// ReSharper disable UnusedParameter.Local

public class CorrectGuards
{
    public CorrectGuards()
    {
    }

    public CorrectGuards(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    )
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p3);
        ArgumentNullException.ThrowIfNull(p6);
    }

    public async IAsyncEnumerable<Int32> AsyncIteratorMethod(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    )
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p3);
        ArgumentNullException.ThrowIfNull(p6);

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
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p3);
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
        ArgumentNullException.ThrowIfNull(p3);
        ArgumentNullException.ThrowIfNull(p6);

        yield return 1;
    }

    public void Method(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    )
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p3);
        ArgumentNullException.ThrowIfNull(p6);
    }

    public static async IAsyncEnumerable<Int32> StaticAsyncIteratorMethod(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    )
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p3);
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
        ArgumentNullException.ThrowIfNull(p3);
        ArgumentNullException.ThrowIfNull(p6);

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
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p3);
        ArgumentNullException.ThrowIfNull(p6);

        yield return 1;
    }

    public static void StaticMethod(
        String p1,
        String? p2,
        Int32 p3,
        Int32? p4,
        Int32? p5 = null,
        params String[] p6
    )
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p3);
        ArgumentNullException.ThrowIfNull(p6);
    }
}
