using Gear.App;

using var fs = File.OpenRead("./input.txt");
using var fsReader = new StreamReader(fs);

var data = new List<char[]>();
while (!fsReader.EndOfStream)
{
    data.Add(fsReader.ReadLine().ToCharArray());
}

var grid = GridParser.Parse(data.ToArray());

Console.WriteLine($"First exercise: {grid.PartNumbers.Sum()}");
Console.WriteLine($"Second exercise: {grid.GearValues.Sum()}");