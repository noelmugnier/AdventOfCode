namespace Farmer.App;

public class Farm
{
    public Farm(SeedMapping[] seeds, List<Mapping[]> allMappings)
    {
        Seeds = seeds;
        AllMappings = allMappings;
    }

    public SeedMapping[] Seeds { get; }
    public List<Mapping[]> AllMappings { get; }

    public Recipe GetSeedRecipe(long seed)
    {
        var soil = GetMappedValueFromMappings(AllMappings[0], seed);
        var fertilizer = GetMappedValueFromMappings(AllMappings[1], soil);
        var water = GetMappedValueFromMappings(AllMappings[2], fertilizer);
        var light = GetMappedValueFromMappings(AllMappings[3], water);
        var temperature = GetMappedValueFromMappings(AllMappings[4], light);
        var humidity = GetMappedValueFromMappings(AllMappings[5], temperature);
        var location = GetMappedValueFromMappings(AllMappings[6], humidity);

        return new Recipe(seed, soil, fertilizer, water, light, temperature, humidity, location);
    }

    public long GetClosestLocation()
    {
        var obj = new { };
        long? location = null;

        Parallel.ForEach(Seeds, seed =>
        {
            Parallel.ForEach(Enumerable.Range(0, (int)seed.Range), index =>
            {
                var recipe = GetSeedRecipe(index + seed.Index);
                lock (obj)
                {
                    location ??= recipe.Location;
                    if (recipe.Location < location)
                        location = recipe.Location;
                }
            });
        });

        return location ?? 0;
    }

    private static long GetMappedValueFromMappings(Mapping[] mappings, long valueToMap)
    {
        var mapping = mappings.FirstOrDefault(m => valueToMap >= m.Start && valueToMap <= m.End);
        return mapping == null ? valueToMap : valueToMap + mapping.OffsetToMappedValue;
    }
}