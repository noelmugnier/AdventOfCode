using FluentAssertions;
using Trebuchet.App;
using Xunit;

namespace Trebuchet.Tests;

public class CalibratorParserShould
{
    [Fact]
    public void ReturnZeroWhenReadingCalibrationWithNoDigits()
    {
        var result = CalibrationParser.Parse("qw");
        result.Should().Be(0);
    }

    [Fact]
    public void ReturnConcatenateValueTwiceWhenReadingCalibrationWithOneDigit()
    {
        var result = CalibrationParser.Parse("qw1");
        result.Should().Be(11);
    }

    [Fact]
    public void ReturnConcatenatedValuesWhenReadingCalibrationWithTwoDigits()
    {
        var result = CalibrationParser.Parse("qw1we2ew");
        result.Should().Be(12);
    }

    [Fact]
    public void ReturnFirstAndLastDigitsConcatenatedWhenReadingCalibrationWithMoreThanTwoDigits()
    {
        var result = CalibrationParser.Parse("qw1we2e3w");
        result.Should().Be(13);
    }

    [Fact] public void ParseStringNumberAsDigit()
    {
        var result = CalibrationParser.Parse("honemkmbfbnlhtbq19", true);
        result.Should().Be(19);
    }

    [Fact] public void ParseStringNumberAsDigitWhenOverlapping()
    {
        var result = CalibrationParser.Parse("honemkmbfbnlhtbq19twonekbp", true);
        result.Should().Be(11);
    }
}