namespace Race.App;

public static class RaceParser
{
    public static RaceInfo[] Parse(string input)
    {
        var lines = input.Split('\n');
        var times = lines[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var distances = lines[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var racesInfo = new List<RaceInfo>();
        for (var index = 0; index < times.Length; index++)
        {
            var time = times[index];
            var distance = distances[index];
            racesInfo.Add(new RaceInfo(int.Parse(time), int.Parse(distance)));
        }

        return racesInfo.ToArray();
    }

    public static RaceInfo[] ParseV2(string input)
    {
        var lines = input.Split('\n');
        var time = lines[0].Split(':')[1].Replace(" ", "");
        var distance = lines[1].Split(':')[1].Replace(" ", "");
        return new[] { new RaceInfo(long.Parse(time), long.Parse(distance)) };
    }
}

public record MarginOrError(RaceInfo[] Races)
{
    public long Value => Races.Select(r => r.WinPossibilities).Aggregate((a, r) => a * r);
}