using FluentAssertions;
using Xunit;

namespace Mirage.Tests;

public class SensorHistoryShould
{
    [Fact]
    public void ReturnInstance()
    {
        const string input = "0 3 6 9 12 15";
        var sut = SensorHistory.Create(input);

        sut.Values.Should().BeEquivalentTo(new List<int> { 0, 3, 6, 9, 12, 15 });
    }

    [Theory]
    [InlineData("0 3 6 9 12 15", 18)]
    [InlineData("1 3 6 10 15 21", 28)]
    [InlineData("10 13 16 21 30 45", 68)]
    public void ResolveNextPrediction(string input, int expected)
    {
        var sut = SensorHistory.Create(input);

        sut.NextPrediction.Should().Be(expected);
    }

    [Theory]
    [InlineData("0 3 6 9 12 15", -3)]
    [InlineData("1 3 6 10 15 21", 0)]
    [InlineData("10 13 16 21 30 45", 5)]
    public void ResolvePreviousPrediction(string input, int expected)
    {
        var sut = SensorHistory.Create(input);

        sut.PreviousPrediction.Should().Be(expected);
    }
}