using FluentAssertions;
using Race.App;
using Xunit;

namespace Race.Tests;

public class MarginOfErrorShould
{
    [Fact]
    public void ReturnAllPossibilitiesInV1()
    {
        var sut = new MarginOrError(new[]
        {
            new RaceInfo(7, 9),
            new RaceInfo(15, 40),
            new RaceInfo(30, 200)
        });

        sut.Value.Should().Be(4 * 8 * 9);
    }

    [Fact]
    public void ReturnAllPossibilitiesInV2()
    {
        var sut = new MarginOrError(new[]
        {
            new RaceInfo(71530, 940200),
        });

        sut.Value.Should().Be(71503);
    }
}