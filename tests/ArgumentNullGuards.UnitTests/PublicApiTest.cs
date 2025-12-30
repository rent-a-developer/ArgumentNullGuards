using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using PublicApiGenerator;

namespace RentADeveloper.ArgumentNullGuards.UnitTests;

public class PublicApiTest
{
    [Fact]
    [Description("Verifies that the public API of ArgumentNullGuards has not been changed unnoticed.")]
    public Task PublicApiHasNotChanged()
    {
        var assembly = typeof(ArgumentNullGuardVerifier).Assembly;

        var options = new ApiGeneratorOptions
        {
            ExcludeAttributes =
            [
                typeof(InternalsVisibleToAttribute).FullName!,
                typeof(TargetFrameworkAttribute).FullName!
            ],
            DenyNamespacePrefixes = []
        };

        var publicApi = assembly.GeneratePublicApi(options);

        return Verify(publicApi);
    }
}
