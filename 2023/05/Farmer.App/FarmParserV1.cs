using System.Text.RegularExpressions;

namespace Farmer.App;

public class FarmParserV1
{
    public Farm Parse(string input)
    {
        var parts = input.Split(':');

        var seeds = ParseSeeds(parts[1]);

        var mappings = new List<Mapping[]>();
        for (var i = 2; i < parts.Length; i++)
            mappings.Add(MappingParser.Parse(parts[i]));

        return new Farm(seeds, mappings);
    }

    protected virtual SeedMapping[] ParseSeeds(string input)
    {
        var regex = new Regex("(?<value>[0-9]{1,20})");
        var matches = regex.Matches(input);
        return matches.Select(m => new SeedMapping(long.Parse(m.Groups["value"].Value), 1)).ToArray();
    }
}