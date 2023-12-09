using FluentAssertions;
using Xunit;

namespace CamelCards.Tests;

public class GameSolverShould
{
    [Fact]
    public void ReturnTotalV1()
    {
        const string input = """
                             32T3K 765
                             T55J5 684
                             KK677 28
                             KTJJT 220
                             QQQJA 483
                             """;

        var sut = GameSolver.CreateV1(input);
        sut.Total.Should().Be(6440);
    }

    [Fact]
    public void ReturnTotalV2()
    {
        const string input = """
                             32T3K 765
                             T55J5 684
                             KK677 28
                             KTJJT 220
                             QQQJA 483
                             """;

        var sut = GameSolver.CreateV2(input);
        sut.Total.Should().Be(5905);
    }
}