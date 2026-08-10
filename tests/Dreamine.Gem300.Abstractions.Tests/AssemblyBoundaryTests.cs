using Dreamine.Gem300.Abstractions.Interfaces;
using Xunit;

namespace Dreamine.Gem300.Abstractions.Tests;

public sealed class AssemblyBoundaryTests
{
    [Fact]
    public void RuntimeContractBelongsToExpectedAssembly() =>
        Assert.Equal("Dreamine.Gem300.Abstractions", typeof(IGem300Runtime).Assembly.GetName().Name);
}
