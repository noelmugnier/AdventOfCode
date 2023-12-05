namespace Farmer.App;

public record Recipe(long Seed, long Soil, long Fertilizer, long Water, long Light, long Temperature, long Humidity,
    long Location);

public record Mapping
{
    public long Start { get; }
    public long End { get; }
    public long OffsetToMappedValue { get; }

    public Mapping(long destinationStartIndex, long start, long range)
    {
        Start = start;
        End = start + range - 1;
        OffsetToMappedValue = destinationStartIndex - start;
    }
}

public record SeedMapping(long Index, long Range);