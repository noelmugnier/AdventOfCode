using System.Text.RegularExpressions;

namespace Scratchcards.App;

public static class ScratchCardParser
{
    public static ScratchCard Parse(string input)
    {
        var idAndNumbers = input.Split(":");

        var id = int.Parse(new Regex(@"(?<id>\d+)").Match(idAndNumbers[0]).Groups["id"].Value);
        var splittedNumbersPart = idAndNumbers[1].Split("|");

        var winningNumbers = ExtractNumbers(splittedNumbersPart[0]);
        var playedNumbers = ExtractNumbers(splittedNumbersPart[1]);

        return new ScratchCard(id, winningNumbers, playedNumbers);
    }

    private static int[] ExtractNumbers(string split)
    {
        return split.Split(" ").Where(v => !string.IsNullOrWhiteSpace(v)).Select(int.Parse).ToArray();
    }

    public static IEnumerable<ScratchCard> ParseAll(string input)
    {
        var lines = input.Split(Environment.NewLine);
        foreach (var line in lines)
            yield return Parse(line);
    }
}