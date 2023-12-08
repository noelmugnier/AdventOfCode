using FluentAssertions;
using Race.App;
using Xunit;

namespace Race.Tests;

public class RaceInfoShould
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(6, 1)]
    [InlineData(10, 2)]
    [InlineData(12, 3)]
    [InlineData(12, 4)]
    [InlineData(10, 5)]
    [InlineData(6, 6)]
    [InlineData(0, 7)]
    public void ReturnDistanceWhenHoldingButtonFor(int expectedDistance, int holdingDuration)
    {
        var sut = new RaceInfo(7, 9);
        sut.GetTravelDistanceWhenHolding(holdingDuration).Should().Be(expectedDistance);
    }

    [Theory]
    [InlineData(7, 9, 4)]
    [InlineData(15, 40, 8)]
    [InlineData(30, 200, 9)]
    public void ReturnWinPossibilities(int raceDuration, int recordDistance, int expectedPossibilies)
    {
        var sut = new RaceInfo(raceDuration, recordDistance);
        sut.WinPossibilities.Should().Be(expectedPossibilies);
    }
}