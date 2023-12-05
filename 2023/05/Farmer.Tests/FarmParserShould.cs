using Farmer.App;
using FluentAssertions;
using Xunit;

namespace Farmer.Tests;

public class FarmParserShould
{
    [Fact]
    public void ParseSeedsInfo()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.Seeds.Length.Should().Be(4);
    }

    [Fact]
    public void ParseMapping()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.AllMappings[0].Length.Should().Be(2);

        farm.AllMappings[0][0].Start.Should().Be(98);
        farm.AllMappings[0][0].End.Should().Be(99);
        farm.AllMappings[0][0].OffsetToMappedValue.Should().Be(-48);

        farm.AllMappings[0][1].Start.Should().Be(50);
        farm.AllMappings[0][1].End.Should().Be(97);
        farm.AllMappings[0][1].OffsetToMappedValue.Should().Be(2);
    }

    [Fact]
    public void ParseSeedToSoils()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.AllMappings[0].Length.Should().Be(2);
    }

    [Fact]
    public void ParseSoilToFertilizerMappings()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.AllMappings[1].Length.Should().Be(3);
    }

    [Fact]
    public void ParseFertilizerToWaterMappings()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.AllMappings[2].Length.Should().Be(4);
    }

    [Fact]
    public void ParseWaterToLightMappings()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.AllMappings[3].Length.Should().Be(2);
    }

    [Fact]
    public void ParseLightToTemperatureMappings()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.AllMappings[4].Length.Should().Be(3);
    }

    [Fact]
    public void ParseTemperatureToHumidityMappings()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.AllMappings[5].Length.Should().Be(2);
    }

    [Fact]
    public void ParseHumidityToLocationMappings()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.AllMappings[6].Length.Should().Be(2);
    }

    [Fact]
    public void ReturnSoilFromRecipe()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.GetSeedRecipe(79).Soil.Should().Be(81);
    }

    [Fact]
    public void ReturnFertilizerFromRecipe()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.GetSeedRecipe(79).Fertilizer.Should().Be(81);
    }

    [Fact]
    public void ReturnWaterFromRecipe()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.GetSeedRecipe(79).Water.Should().Be(81);
    }

    [Fact]
    public void ReturnLightFromRecipe()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.GetSeedRecipe(79).Light.Should().Be(74);
    }

    [Fact]
    public void ReturnTemperatureFromRecipe()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.GetSeedRecipe(79).Temperature.Should().Be(78);
    }

    [Fact]
    public void ReturnHumidityFromRecipe()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.GetSeedRecipe(79).Humidity.Should().Be(78);
    }

    [Fact]
    public void ReturnLocationFromRecipe()
    {
        var farm = new FarmParserV1().Parse(_input);
        farm.GetSeedRecipe(79).Location.Should().Be(82);
    }

    [Theory]
    [InlineData(79, 81, 81, 81, 74, 78, 78, 82)]
    [InlineData(14, 14, 53, 49, 42, 42, 43, 43)]
    [InlineData(55, 57, 57, 53, 46, 82, 82, 86)]
    [InlineData(13, 13, 52, 41, 34, 34, 35, 35)]
    public void ReturnRecipeFromSeed(int seed, int soil, int fertilizer, int water, int light, int temperature,
        int humidity, int location)
    {
        var sut = new FarmParserV1().Parse(_input);
        var recipe = sut.GetSeedRecipe(seed);
        recipe.Should().BeEquivalentTo(new Recipe(seed, soil, fertilizer, water, light, temperature, humidity, location));
    }

    [Fact]
    public void ReturnLowestLocation()
    {
        var sut = new FarmParserV1().Parse(_input);
        var result = sut.GetClosestLocation();
        result.Should().Be(35);
    }

    [Fact]
    public void ReturnSeedRangesForV2()
    {
        var sut = new FarmParserV2().Parse(_input);
        sut.Seeds.Length.Should().Be(2);
    }

    [Fact]
    public void ReturnLowestLocationForV2()
    {
        var sut = new FarmParserV2().Parse(_input);
        var result = sut.GetClosestLocation();
        result.Should().Be(46);
    }

    private const string _input = """
                                  seeds: 79 14 55 13

                                  seed-to-soil map:
                                  50 98 2
                                  52 50 48

                                  soil-to-fertilizer map:
                                  0 15 37
                                  37 52 2
                                  39 0 15

                                  fertilizer-to-water map:
                                  49 53 8
                                  0 11 42
                                  42 0 7
                                  57 7 4

                                  water-to-light map:
                                  88 18 7
                                  18 25 70

                                  light-to-temperature map:
                                  45 77 23
                                  81 45 19
                                  68 64 13

                                  temperature-to-humidity map:
                                  0 69 1
                                  1 0 69

                                  humidity-to-location map:
                                  60 56 37
                                  56 93 4
                                  """;
}