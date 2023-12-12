using FluentAssertions;
using Xunit;

namespace Mirage.Tests;

public class InstabilitySensorShould
{
    [Fact]
    public void ReturnFinalResultForPartOne()
    {
        var result = InstabilitySensor.GetPartOneResult(_input);

        result.Should().Be(114);
    }

    [Fact]
    public void ReturnFinalResultForPartTwo()
    {
        var result = InstabilitySensor.GetPartTwoResult(_input);

        result.Should().Be(2);
    }

    private const string _input = """
                                  0 3 6 9 12 15
                                  1 3 6 10 15 21
                                  10 13 16 21 30 45
                                  """;
}