using Cube.App;

using var fs = File.OpenRead("./input.txt");
using var fsReader = new StreamReader(fs);

var scoreboardV1 = 0;
var scoreboardV2 = 0;

while (!fsReader.EndOfStream)
{
    var rawGameData = fsReader.ReadLine();
    scoreboardV1 += new GameV1(rawGameData!, 12, 13, 14).Power;
    scoreboardV2 += new GameV2(rawGameData!).Power;
}

Console.WriteLine($"First exercise: {scoreboardV1}");
Console.WriteLine($"Second exercise: {scoreboardV2}");