using FluentAssertions;
using Race.App;
using Xunit;

namespace Race.Tests;

public class RaceParserShould
{
    [Fact]
    public void ParseData()
    {
        const string input = "Time:      7  15   30\nDistance:  9  40  200";
        var result = RaceParser.Parse(input);

        result.Length.Should().Be(3);
    }

    [Fact]
    public void ParseDataV2()
    {
        const string input = "Time:      7  15   30\nDistance:  9  40  200";
        var result = RaceParser.ParseV2(input);

        result.Length.Should().Be(1);
    }
}