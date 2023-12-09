using FluentAssertions;
using Xunit;

namespace CamelCards.Tests;

public class HandShould
{
    [Fact]
    public void CreateInstance()
    {
        var sut = Hand.CreateV1("32T3K");

        sut.OriginalValue.Should().Be("32T3K");
        sut.MappedValue.Should().Be("LMELB");
    }

    [Theory]
    [InlineData(7, "AAAAA")]
    [InlineData(6, "AAQAA")]
    [InlineData(5, "AAQAQ")]
    [InlineData(4, "AAJAQ")]
    [InlineData(3, "AJJAQ")]
    [InlineData(2, "A23AJ")]
    [InlineData(1, "Q23AJ")]
    public void ReturnKindAsV1(int expectedKind, string cards)
    {
        var sut = Hand.CreateV1(cards);

        sut.Kind.Should().Be(expectedKind);
    }

    [Theory]
    [InlineData(7, "JJJJA")]
    [InlineData(7, "JJJAA")]
    [InlineData(7, "JJAAA")]
    [InlineData(7, "JAAAA")]
    [InlineData(6, "JJJAB")]
    [InlineData(6, "JJAAB")]
    [InlineData(6, "JJABB")]
    [InlineData(6, "JAAAB")]
    [InlineData(6, "JABBB")]
    [InlineData(5, "JAABB")]
    [InlineData(4, "JJABC")]
    [InlineData(4, "JABBC")]
    [InlineData(4, "JABCC")]
    [InlineData(2, "JABCD")]



    [InlineData(7, "JJJJJ")]
    [InlineData(7, "AAAAA")]
    [InlineData(7, "AAAAJ")]
    [InlineData(6, "AAQAA")]
    [InlineData(6, "JAJAQ")]
    [InlineData(6, "AAQJA")]
    [InlineData(5, "AAQJQ")]
    [InlineData(5, "AAQAQ")]
    [InlineData(4, "AJEJQ")]
    [InlineData(4, "AAEAQ")]
    [InlineData(4, "AAEJQ")]
    [InlineData(3, "AEEAQ")]
    [InlineData(2, "A23AQ")]
    [InlineData(1, "Q23AE")]
    public void ReturnKindAsV2(int expectedKind, string cards)
    {
        var sut = Hand.CreateV2(cards);

        sut.Kind.Should().Be(expectedKind);
    }
}