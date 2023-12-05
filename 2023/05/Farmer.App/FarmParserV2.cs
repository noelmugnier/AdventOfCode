using System.Text.RegularExpressions;

namespace Farmer.App;

public class FarmParserV2 : FarmParserV1
{
    protected override SeedMapping[] ParseSeeds(string input)
    {
        var regex = new Regex("(?<index>[0-9]{1,20}) (?<range>[0-9]{1,20})");
        var matches = regex.Matches(input);

        return matches.Select(m => new SeedMapping(long.Parse(m.Groups["index"].Value),
            long.Parse(m.Groups["range"].Value))).ToArray();
    }
}