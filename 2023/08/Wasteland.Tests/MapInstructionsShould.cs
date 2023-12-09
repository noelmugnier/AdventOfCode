using FluentAssertions;
using Wasteland.App;
using Xunit;

namespace Wasteland.Tests;

public class MapInstructionsShould
{
    [Fact]
    public void InitializeMovementInstructions()
    {
        var sut = MapInstructions.Parse(_input);
        sut.NextMovements.Should().BeEquivalentTo(new [] { 'R', 'L' });
    }

    [Fact]
    public void InitializeDirectionInstructions()
    {
        var sut = MapInstructions.Parse(_input);
        sut.Directions.Count.Should().Be(7);
    }

    [Fact]
    public void NavigateToDestination()
    {
        var sut = MapInstructions.Parse(_input);
        sut.RequiredChoicesToReachDestination.Should().Be(2);
    }

    [Fact]
    public void NavigateToDestinationV2()
    {
        var sut = MapInstructions.Parse(_inputV2);
        sut.RequiredChoicesToReachDestinationAsGhost.Should().Be(6);
    }

    const string _input = """
                             RL
    
                             AAA = (BBB, CCC)
                             BBB = (DDD, EEE)
                             CCC = (ZZZ, GGG)
                             DDD = (DDD, DDD)
                             EEE = (EEE, EEE)
                             GGG = (GGG, GGG)
                             ZZZ = (ZZZ, ZZZ)
                             """;

    const string _inputV2 = """
                         LR
                         
                         11A = (11B, XXX)
                         11B = (XXX, 11Z)
                         11Z = (11B, XXX)
                         22A = (22B, XXX)
                         22B = (22C, 22C)
                         22C = (22Z, 22Z)
                         22Z = (22B, 22B)
                         XXX = (XXX, XXX)
                         """;
}