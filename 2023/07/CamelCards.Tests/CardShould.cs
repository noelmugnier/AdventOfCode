using FluentAssertions;
using Xunit;

namespace CamelCards.Tests;

public class CardShould
{
    [Theory]
    [InlineData('A', 'A')]
    [InlineData('K', 'B')]
    [InlineData('Q', 'C')]
    [InlineData('J', 'D')]
    [InlineData('T', 'E')]
    [InlineData('9', 'F')]
    [InlineData('8', 'G')]
    [InlineData('7', 'H')]
    [InlineData('6', 'I')]
    [InlineData('5', 'J')]
    [InlineData('4', 'K')]
    [InlineData('3', 'L')]
    [InlineData('2', 'M')]
    public void MappedValueTo(char value, char expected)
    {
        var sut = new Card(value, 1);

        sut.MappedValue.Should().Be(expected);
    }

    [Fact]
    public void OverrideJValueInV2()
    {
        var sut = new Card('J', 2);

        sut.MappedValue.Should().Be('Z');
    }
}