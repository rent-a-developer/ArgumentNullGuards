namespace RentADeveloper.ArgumentNullGuards.UnitTests;

/// <summary>
/// Base class for tests.
/// </summary>
public class TestsBase
{
    public TestsBase() =>
        // Ensure consistent culture for tests.
        Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new("en-US");
}
