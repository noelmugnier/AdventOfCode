using FluentAssertions;
using Xunit;

namespace CamelCards.Tests;

public class GameShould
{
    [Fact]
    public void CreateGameInstance()
    {
        var sut = Game.CreateGameV1("32T3K 765");

        sut.Bid.Should().Be(765);
        sut.Hand.OriginalValue.Should().Be("32T3K");
    }
}