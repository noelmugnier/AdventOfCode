using System.Diagnostics;

await using var fs = File.OpenRead("./input.txt");
using var fsReader = new StreamReader(fs);

var input = await fsReader.ReadToEndAsync();

var timer = Stopwatch.StartNew();
var partOneResult = InstabilitySensor.GetPartOneResult(input);
Console.WriteLine($"First exercise: {partOneResult} in {timer.ElapsedMilliseconds}ms");

timer.Restart();
var partTwoResult = InstabilitySensor.GetPartTwoResult(input);
Console.WriteLine($"Second exercise: {partTwoResult} in {timer.ElapsedMilliseconds}ms");

timer.Stop();