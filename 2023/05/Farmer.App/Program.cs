using System.Diagnostics;
using Farmer.App;

await using var fs = File.OpenRead("./input.txt");
using var fsReader = new StreamReader(fs);

var input = await fsReader.ReadToEndAsync();

var watch = Stopwatch.StartNew();
var farm = new FarmParserV1().Parse(input);
Console.WriteLine($"First exercise: {farm.GetClosestLocation()} in {watch.ElapsedMilliseconds}ms");

watch.Restart();
var farmV2 = new FarmParserV2().Parse(input);
Console.WriteLine($"Second exercise: {farmV2.GetClosestLocation()} in {watch.ElapsedMilliseconds}ms");
watch.Stop();