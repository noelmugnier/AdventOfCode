using FluentAssertions;
using Gear.App;
using Xunit;

namespace Gear.Tests;

public class TestShould
{
    private readonly char[][] _input = {
        new[] { '.', '5', '2', '.' },
        new[] { '3', '%', '6', '.' },
        new[] { '.', '.', '*', '.' },
        new[] { '2', '3', '.', '.' },
        new[] { '.', '.', '5', '.' }
    };

    [Fact]
    public void ReturnParsedGrid()
    {
        var grid = GridParser.Parse(_input);

        grid.Symbols.Count.Should().Be(2);

        var firstSymbol = grid.Symbols[0];
        firstSymbol.Value.Should().Be('%');
        firstSymbol.X.Should().Be(1);
        firstSymbol.Y.Should().Be(1);

        var secondSymbol = grid.Symbols[1];

        secondSymbol.Value.Should().Be('*');
        secondSymbol.X.Should().Be(2);
        secondSymbol.Y.Should().Be(2);

        grid.AllNumbers.Count.Should().Be(5);

        var firstPartNumber = grid.AllNumbers[0];
        firstPartNumber.Value.Should().Be(52);
        firstPartNumber.X.Should().Be(0);
        firstPartNumber.Y.Should().Be(1);

        var secondPartNumber = grid.AllNumbers[1];
        secondPartNumber.Value.Should().Be(3);
        secondPartNumber.X.Should().Be(1);
        secondPartNumber.Y.Should().Be(0);

        var thirdPartNumber = grid.AllNumbers[2];
        thirdPartNumber.Value.Should().Be(6);
        thirdPartNumber.X.Should().Be(1);
        thirdPartNumber.Y.Should().Be(2);

        var fourthPartNumber = grid.AllNumbers[3];
        fourthPartNumber.Value.Should().Be(23);
        fourthPartNumber.X.Should().Be(3);
        fourthPartNumber.Y.Should().Be(0);

        var fifthPartNumber = grid.AllNumbers[4];
        fifthPartNumber.Value.Should().Be(5);
        fifthPartNumber.X.Should().Be(4);
        fifthPartNumber.Y.Should().Be(2);
    }

    [Fact]
    public void ReturnValidPartNumbers()
    {
        var grid = GridParser.Parse(_input);

        grid.PartNumbers.Count.Should().Be(4);
        grid.GearValues.Count.Should().Be(1);
        grid.GearValues.Sum().Should().Be(138);
    }

    [Fact]
    public void ReturnValidGearValues()
    {
        var grid = GridParser.Parse(_input);

        grid.GearValues.Count.Should().Be(1);
        grid.GearValues.Sum().Should().Be(138);
    }
}