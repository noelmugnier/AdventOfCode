using System.Diagnostics;
using Race.App;

await using var fs = File.OpenRead("./input.txt");
using var fsReader = new StreamReader(fs);

var input = await fsReader.ReadToEndAsync();

var timer = Stopwatch.StartNew();
var marginOfErrorV1 = new MarginOrError(RaceParser.Parse(input));
Console.WriteLine($"First exercise: {marginOfErrorV1.Value} in {timer.ElapsedMilliseconds}ms");

timer.Reset();
var marginOfErrorV2 = new MarginOrError(RaceParser.ParseV2(input));
Console.WriteLine($"Second exercise: {marginOfErrorV2.Value} in {timer.ElapsedMilliseconds}ms");
timer.Stop();