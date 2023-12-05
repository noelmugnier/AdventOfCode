using System.Text.RegularExpressions;

namespace Farmer.App;

public static class MappingParser
{
    public static Mapping[] Parse(string input)
    {
        var regex = new Regex("(?<destination>[0-9]{1,20}) (?<source>[0-9]{1,20}) (?<range>[0-9]{1,20})");
        var matches = regex.Matches(input);
        return matches.Select(m => new Mapping(long.Parse(m.Groups["destination"].Value),
            long.Parse(m.Groups["source"].Value), long.Parse(m.Groups["range"].Value))).ToArray();
    }
}