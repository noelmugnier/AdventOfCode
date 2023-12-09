using System.Diagnostics;
using Wasteland.App;

await using var fs = File.OpenRead("./input.txt");
using var fsReader = new StreamReader(fs);

var input = await fsReader.ReadToEndAsync();

var timer = Stopwatch.StartNew();
var instructions = MapInstructions.Parse(input);
Console.WriteLine($"First exercise: {instructions.RequiredChoicesToReachDestination} in {timer.ElapsedMilliseconds}ms");

timer.Restart();
Console.WriteLine($"Second exercise: {instructions.RequiredChoicesToReachDestinationAsGhost} in {timer.ElapsedMilliseconds}ms");
timer.Stop();