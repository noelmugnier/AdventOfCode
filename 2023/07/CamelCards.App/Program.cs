using System.Diagnostics;

await using var fs = File.OpenRead("./input.txt");
using var fsReader = new StreamReader(fs);

var input = await fsReader.ReadToEndAsync();

var timer = Stopwatch.StartNew();
var solverV1 = GameSolver.CreateV1(input);
Console.WriteLine($"First exercise: {solverV1.Total} in {timer.ElapsedMilliseconds}ms");

timer.Restart();
var solverV2 = GameSolver.CreateV2(input);
Console.WriteLine($"Second exercise: {solverV2.Total} in {timer.ElapsedMilliseconds}ms");
timer.Stop();