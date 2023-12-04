using System.Text.RegularExpressions;

namespace Cube.App;

public static class GameParser
{
    public static (int gameId, Set[] sets) ParseRawData(string rawGameData)
    {
        var gameId = int.Parse(new Regex("Game (?<id>\\d+)").Match(rawGameData).Groups["id"].Value);

        var rawDataSets = rawGameData.Split(";");
        var sets = rawDataSets.Select(rawDataSet =>
        {
            var regexMatches = new Regex(@"(?<red>\d+) red|(?<green>\d+) green|(?<blue>\d+) blue").Matches(rawDataSet);
            return new Set(GetMatchedColorValue(regexMatches, "red"), GetMatchedColorValue(regexMatches, "green"),
                GetMatchedColorValue(regexMatches, "blue"));
        }).ToArray();

        return (gameId, sets);
    }

    private static int GetMatchedColorValue(MatchCollection matchesCollection, string color)
    {
        var colorMatch = matchesCollection.FirstOrDefault(match => match.Success && match.Groups[color].Success);
        return int.Parse(colorMatch?.Groups[color].Value ?? "0");
    }
}