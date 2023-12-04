using Cube.App;
using FluentAssertions;
using Xunit;

namespace Cube.Tests;

public class GameV1Should
{
    [Fact]
    public void ParseData()
    {
        var parsedGame = new GameV1("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 0, 0, 0);
        parsedGame.Sets.Length.Should().Be(3);

        var firstGameSet = parsedGame.Sets[0];
        firstGameSet.RedCount.Should().Be(4);
        firstGameSet.GreenCount.Should().Be(0);
        firstGameSet.BlueCount.Should().Be(3);

        var secondGameSet = parsedGame.Sets[1];
        secondGameSet.RedCount.Should().Be(1);
        secondGameSet.GreenCount.Should().Be(2);
        secondGameSet.BlueCount.Should().Be(6);

        var thirdGameSet = parsedGame.Sets[2];
        thirdGameSet.RedCount.Should().Be(0);
        thirdGameSet.GreenCount.Should().Be(2);
        thirdGameSet.BlueCount.Should().Be(0);
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 2)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 0)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 0)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 5)]
    public void ReturnExpectedPower(string rawGameData, int expectedResult)
    {
        var sut = new GameV1(rawGameData, 12, 13, 14);
        sut.Power.Should().Be(expectedResult);
    }
}