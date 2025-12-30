#nullable disable

namespace RentADeveloper.ArgumentNullGuards.UnitTests.TestData;

// ReSharper disable UnusedParameter.Local

public class NotInNullableEnabledContext
{
    public NotInNullableEnabledContext(Object parameter)
    {
    }

    public void Method(Object parameter)
    {
    }

    public static void StaticMethod(Object parameter)
    {
    }
}
